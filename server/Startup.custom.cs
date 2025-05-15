using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RecoCms6.Services;
using RecoCms6.Services.GraphApi;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using Microsoft.AspNetCore.Http;
using RecoCms6.Data;
using System.IO;
using System;
using AutoMapper;
using RecoCms6.Utility;
using RecoCms6.Config;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Hangfire.Dashboard;
using RecoCms6.Services.MailerService;
using RecoCms6.Services.Automatizations;
using RecoCms6.Models.RecoDb;
using RecoCms6.Services.Background.MailServices;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Hosting;
using System.Linq;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace RecoCms6
{
    public partial class Startup
    {
        private IHostEnvironment Environment { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
            Configuration = configuration;
        }

        partial void OnConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSyncfusionBlazor();
            services.AddServerSideBlazor().AddHubOptions(options =>
            {
                // maximum message size of 128MB
                options.MaximumReceiveMessageSize = 128000000;
            });
            Dictionary<string, Credential> credentials = Configuration.GetSection("MailAccounts").Get<Dictionary<string, Credential>>();

            string mailServer = Configuration.GetValue<string>("MailBeeMailServer");
            MailBee.Global.LicenseKey = Configuration.GetValue<string>("MailBeeLicence");

            services.AddScoped(sp => new MacroService(sp.GetService<RecoDbService>()));
            services.AddScoped(sp =>
                new GraphApiAuthProvider(sp.GetService<IHttpContextAccessor>(), Configuration, sp.GetService<RecoDbContext>(), sp.GetService<AuthenticationStateProvider>()));
            services.AddScoped(sp => new MailService(sp.GetService<GraphApiAuthProvider>(), sp.GetService<RecoDbContext>()));
            services.AddAutoMapper(typeof(Program));


            MailConfig mailConfig = new MailConfig();

            services.AddScoped<IDiariesMailSenderService>(sp => new DiariesMailSenderService(mailConfig, sp.GetService<RecoDbContext>()));
            services.AddHangfire(configuration =>
            {
                configuration.UseSqlServerStorage(Configuration.GetConnectionString("RECODbConnection"));
            });

            //var use = Configuration.GetValue<bool>("UseAzureSignalR");
            //if (use)
            //{
            //    services.AddSignalR().AddHubOptions(options =>
            //    {
            //        options.ServerStickyMode =
            //         Microsoft.Azure.SignalR.ServerStickyMode.Required;
            //    });
            //}

            services.AddScoped(provider => new InboxHandlerBuilder(credentials, mailServer, provider.GetService<RecoDbContext>()));
            services.AddScoped<MailHandlerBuilder>();
            services.AddScoped<ITimeProvider, UtcTimeProvider>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
            });

            // Add converter to DI
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddHangfireServer();
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHangfireDashboard("/hangfire", new DashboardOptions
                {
                    Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
                });
            });

            SyncfusionLicenseProvider.RegisterLicense(Configuration.GetSection("SyncfusionLicenseKey").Value);

            // load wkhtml
            var architectureFolder = (IntPtr.Size == 8) ? "64 bit" : "32 bit";
            var wkHtmlToPdfPath = Path.Combine(env.ContentRootPath, $"wkhtmltox/{architectureFolder}/libwkhtmltox");
            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(wkHtmlToPdfPath);

            // Recurring Task
            RecurringJob.RemoveIfExists("AttachmentsOnly");
            RecurringJob.AddOrUpdate<AttachmentMailHandler>("AttachmentsOnly", x => x.Process(), "*/5 * * * *");    // Cron expression each 5 minutes
            RecurringJob.RemoveIfExists("AttachEmail");
            RecurringJob.AddOrUpdate<PdfMailHandler>("AttachEmail", x => x.Process(), "*/3 * * * *");   // Cron expression each 3 minutes
            RecurringJob.RemoveIfExists("Diary");
            RecurringJob.AddOrUpdate<IDiariesMailSenderService>("Diary", x => x.SendMailAsync(), "0 * * * *");    // Cron expression each 1 hour
        }

        public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
        {
            public bool Authorize(DashboardContext context)
            {
                var httpContext = context.GetHttpContext();
                return httpContext.User.IsInRole("Program Manager") || httpContext.User.IsInRole("System Admin");
            }
        }
    }
}
