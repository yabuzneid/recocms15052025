using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Newtonsoft.Json;
using RecoCms6.Data;
using RecoCms6.Models;
using RecoCms6.Models.RecoDb;
using RecoCms6.Utility;
using System;
using System.Linq;
using System.Threading.Tasks;
using File = RecoCms6.Models.RecoDb.File;

namespace RecoCms6.Services.Background.MailServices
{
    public class PdfMailHandler : AttachmentMailHandler
    {
        public PdfMailHandler(IConfiguration configuration, RecoDbContext dbContext, UserManager<ApplicationUser> userManager) : base(configuration, dbContext, userManager)
        {
            var generalsettings = DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            userId = generalsettings.BindEmailObjectID;
        }

        protected async override Task<bool> Process(Message message)
        {
            if (!await base.Process(message))
            {
                return false;
            }

            bool bIsRECO = DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault().ApplicationName == "RECO CMS";
            message.TryGetClaimId(bIsRECO, out string claimId);

            var claim = DbContext.Claims.FirstOrDefault(c => c.ClaimNo == claimId);
            try
            {
                if (claim == null)
                    return false;

                var recieversText = message.ToRecipients
                    .Select(r => $"{r.EmailAddress.Name} - {r.EmailAddress.Address}")
                    .Aggregate((a, b) => $"{a}{b}. ");

                string bodyText = "<p style = 'text-align: center;'><strong><span style = 'font-size: 12pt;' >EMAIL Attachment </span></strong></p>";
                bodyText += "<p style = 'text-align: center;' ><span style = 'font-size: 16px;' >Subject: " + message.Subject + "&nbsp;</span></p>";
                bodyText += $"<p style = 'text-align: center;'><span style = 'font-size: 16px;'>From: {message.From.EmailAddress.Name} -  {message.From.EmailAddress.Address} </span></p>";
                bodyText += $"<p style = 'text-align: center;'><span style = 'font-size: 16px;'>To: {recieversText}";
                bodyText += $"<p style = 'text-align: center;'><span style = 'font-size: 16px;'>Sent: {message.Body.Content} </p>";

                var entry = new File()
                {
                    ID = Guid.NewGuid(),
                    ClaimID = claim.ClaimID,
                    Extension = ".pdf",
                    Subject = $"{message.Subject}",
                    Filename = $"Mail_As_Pdf_{claim.ClaimNo}_{Guid.NewGuid()}.pdf",
                    EntryDate = DateTime.Now, // it can be converted to a specific timezone if needed
                    StoredDocument = bodyText.ToPDFByteArray(),
                    UploadedById = GetSenderUserId(message.From.EmailAddress.Address),
                    ContentType = "application/pdf",
                    FileTypeID = GetFileType("application/pdf")
                };

                DbContext.Files.Add(entry);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                var errorLog = new ErrorLog()
                {
                    ErrorMessage = jsonMessage,
                    ClaimID = claim.ClaimID
                };
                DbContext.ErrorLogs.Add(errorLog);
                DbContext.SaveChanges();
                return false;
            }
            return true;
        }
    }
}
