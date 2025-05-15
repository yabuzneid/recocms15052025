using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RecoCms6.Data;
using RecoCms6.Models;
using RecoCms6.Authentication;
using Radzen;
using Serilog;
using RecoCms6.Middlewares;
using RecoCms6.Services.IdentityStores;


namespace RecoCms6
{
    public partial class Startup
    {
        partial void OnConfigureServices(IServiceCollection services);

        partial void OnConfiguringServices(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            OnConfiguringServices(services);
            Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(Configuration)
           .CreateLogger();

            services.AddHttpContextAccessor();
            services.AddScoped(serviceProvider =>
            {

              var uriHelper = serviceProvider.GetRequiredService<NavigationManager>();

              return new HttpClient
              {
                BaseAddress = new Uri(uriHelper.BaseUri)
              };
            });

            services.AddHttpClient();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddScoped(sp =>
            {
                var options = sp.GetRequiredService<DbContextOptions<ApplicationIdentityDbContext>>();
                return new ApplicationIdentityDbContext(options);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddUserStore<RecoUserStore>()
                .AddRoleStore<RecoRoleStore>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUserStore<ApplicationUser>, RecoUserStore>();
            services.AddTransient<IRoleStore<IdentityRole>, RecoRoleStore>();
            
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                  ApplicationPrincipalFactory>();
            services.AddScoped<SecurityService>();
            services.AddScoped<RecoDbService>();

            services.AddDbContext<RecoCms6.Data.RecoDbContext>(options =>
            {
              options.UseSqlServer(Configuration.GetConnectionString("RECODbConnection"));
            }, ServiceLifetime.Scoped);

            services.AddPooledDbContextFactory<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RECODbConnection"), 
                    dbOptions => dbOptions.CommandTimeout(90));
            });

            services.AddSingleton<IDbContextFactory<ApplicationIdentityDbContext>>(sp =>
            {
                var options = sp.GetRequiredService<DbContextOptions<ApplicationIdentityDbContext>>();
                return new PooledDbContextFactory<ApplicationIdentityDbContext>(options);
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor()
             .AddCircuitOptions(options =>
             {
                 options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(60);
                 options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(2);
             })
             .AddHubOptions(o =>
             {
                 o.MaximumReceiveMessageSize = 10 * 1024 * 1024;
             });

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<GlobalsService>();

            OnConfigureServices(services);
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            OnConfiguring(app, env);
            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ExceptionMiddleware>();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            OnConfigure(app, env);
        }
    }


}
