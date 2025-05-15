using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using Radzen;
using System.Linq;
using RecoCms6.Data;

namespace RecoCms6.Services.Background.MailServices
{
    public class InboxHandlerBuilder
    {
        private Dictionary<string, Credential> Credentials { get; }
        private string MailServer { get; set; }
        [Inject]
        protected RecoDbService RecoDb { get; set; }

        private readonly RecoDbContext _context;

        public InboxHandlerBuilder(Dictionary<string, Credential> credentials, string mailServer)
        {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            MailServer = mailServer ?? throw new ArgumentNullException(nameof(mailServer));
        }

        public InboxHandlerBuilder(Dictionary<string, Credential> credentials, string mailServer, RecoDbContext context)
        {
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            MailServer = mailServer ?? throw new ArgumentNullException(nameof(mailServer));
            _context = context;
        }

        public IInboxHandler GetHandler(MailHandlerType type)
        {

            var generalsettings = _context.GeneralSettings.Where(x => x.Active==true).FirstOrDefault();
            
            Credentials["Attachment"].User = generalsettings.BindAttachmentsToClaimEmail;
            Credentials["Attachment"].Password = generalsettings.BindAttachmentsToClaimPassword;
            Credentials["Pdf"].User = generalsettings.BindEmailToClaimEmail;
            Credentials["Pdf"].Password = generalsettings.BindEmailToClaimPassword;
            MailServer = generalsettings.ImapHost;
            
            switch (type)
            {
                case MailHandlerType.Attachment: return new InboxHandler(Credentials["Attachment"], MailServer);
                case MailHandlerType.Pdf:  return new InboxHandler(Credentials["Pdf"], MailServer);                
                default: throw new NotImplementedException("InboxHandler-type not implemented");
            }
        }

        public IInboxHandler GetHandler(MailHandlerType type, RecoDbContext context)
        {

            var generalsettings = context.GeneralSettings.Where(x => x.Active == true).FirstOrDefault() ?? new Models.RecoDb.GeneralSetting();

            Credentials["Attachment"].User = generalsettings.BindAttachmentsToClaimEmail;
            Credentials["Attachment"].Password = generalsettings.BindAttachmentsToClaimPassword;
            Credentials["Pdf"].User = generalsettings.BindEmailToClaimEmail;
            Credentials["Pdf"].Password = generalsettings.BindEmailToClaimPassword;
            MailServer = generalsettings.ImapHost;

            switch (type)
            {
                case MailHandlerType.Attachment: return new InboxHandler(Credentials["Attachment"], MailServer);
                case MailHandlerType.Pdf: return new InboxHandler(Credentials["Pdf"], MailServer);
                default: throw new NotImplementedException("InboxHandler-type not implemented");
            }
        }
    }
}
