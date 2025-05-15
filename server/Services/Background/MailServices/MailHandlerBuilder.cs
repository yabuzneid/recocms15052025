using RecoCms6.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using RecoCms6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace RecoCms6.Services.Background.MailServices
{
    public class MailHandlerBuilder
    {
        private IServiceProvider ServiceProvider { get; }
        private IConfiguration Configuration { get => ServiceProvider.GetService<IConfiguration>(); }
        private InboxHandlerBuilder InboxHandlerBuilder { get => ServiceProvider.GetService<InboxHandlerBuilder>(); }
        private RecoDbContext DbContext { get => ServiceProvider.GetService<RecoDbContext>(); }
        private UserManager<ApplicationUser> UserManager { get => ServiceProvider.GetService<UserManager<ApplicationUser>>(); }

        public MailHandlerBuilder(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IAutomaticMailHandler GetAutomaticMailHandler(MailHandlerType type)
        {
            switch (type)
            {
                case MailHandlerType.Attachment: return new AttachmentMailHandler(Configuration, DbContext, UserManager);
                case MailHandlerType.Pdf: return new PdfMailHandler(Configuration, DbContext, UserManager);
                default: throw new NotImplementedException();
            }
        }

        public IAutomaticMailHandler GetAutomaticMailHandler<T>() where T : IAutomaticMailHandler
        {
            if (typeof(T) == typeof(AttachmentMailHandler))
            {
                return new AttachmentMailHandler(Configuration, DbContext, UserManager);
            }
            if (typeof(T) == typeof(PdfMailHandler))
            {
                return new PdfMailHandler(Configuration, DbContext, UserManager);
            }
            throw new NotImplementedException();
        }
    }
}