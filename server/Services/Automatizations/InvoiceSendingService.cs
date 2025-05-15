using Microsoft.Graph;
using RecoCms6.Data;
using RecoCms6.Models.RecoDb;
using RecoCms6.Services.GraphApi;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecoCms6.Services.Automatizations
{
    public interface IInvoiceSendingService<T>
    {
        void Send(T @object);
    }

    public class TransactionInvoiceSendingService(RecoDbContext dbContext,
            IDbContextFactory<ApplicationIdentityDbContext> identityDbContextFactory, GraphApiAuthProvider authProvider)
        : IInvoiceSendingService<Transaction>
    {
        private RecoDbContext DbContext { get; } = dbContext;
        private ApplicationIdentityDbContext IdentityDbContext => identityDbContextFactory.CreateDbContext();
        private GraphServiceClient GraphServiceClient { get; } = new(authProvider);

        public void Send(Transaction @object)
        {
            var invoiceTemplate = DbContext.SystemTemplates.Single(template => template.TemplateName == "Invoice");
            var firm = DbContext.FirmDetails.SingleOrDefault(_firm => _firm.FirmID == @object.FirmID);
            var claim = DbContext.Claims.SingleOrDefault(_claim => _claim.ClaimID == @object.ClaimID);
            var generalsettings = DbContext.GeneralSettings.SingleOrDefault(_settings => _settings.Active == true);

            PdfLoadedDocument loadedDocument;
            byte[] bytes;
            using (var stream = new FileStream("Templates/paymentinvoice.pdf", FileMode.Open, FileAccess.Read))
            {
                loadedDocument = new PdfLoadedDocument(stream);
                var form = loadedDocument.Form;
                var fields = form.Fields;

                var floatAccount = generalsettings.FloatAccount;
                if (floatAccount == null)
                    floatAccount = String.Empty;

                var values = new List<(string key, string value)>()
                {
                    ("AuthorizationDate", DateTime.Today.ToShortDateString()),
                    ("ApplicationName", generalsettings.ApplicationName),
                    ("ServiceProvider", firm?.Name),
                    ("ClaimNo", claim?.ClaimNo),
                    ("InvoiceNo", @object.InvoiceNum),
                    ("InvoiceDate", @object.TransactionDate.ToShortDateString()),
                    ("Claimant", claim?.Claimants?.First().Name),
                    ("DefenseCounselFileNumber", claim?.CounselFileNo),
                    ("PaymentBreakdown", ""),
                    ("PayableTo", @object.PayableTo),
                    ("IncurredType", ""),
                    ("Amount", @object.Amount.ToString()),
                    ("Comments", @object.Comments),
                    ("SendingInstructions", @object.SendingInstructions),
                    ("FloatAccount", floatAccount),
                    ("UploadedBy", @object.EnteredByID),
                    ("DateUploaded", DateTime.Today.ToShortDateString())
                };

                values.ForEach(value => InsertIfExists(fields, value.key, value.value));
                using(var saveStream = new MemoryStream())
                {
                    loadedDocument.Form.Flatten = true;
                    loadedDocument.Save(saveStream);
                    saveStream.Position = 0;
                    bytes = saveStream.ToArray();
                }
                loadedDocument.Close(true);
            }
            var accountantsQuery =
                from users in IdentityDbContext.Users
                join userroles in IdentityDbContext.UserRoles on users.Id equals userroles.UserId
                join roles in IdentityDbContext.Roles on userroles.RoleId equals roles.Id
                where roles.NormalizedName == "ACCOUNTANT" && users.EmailConfirmed
                select new { users.Email };
            var recipients = accountantsQuery.Select(accountant => new Recipient() { EmailAddress = new EmailAddress() { Address = accountant.Email } });
            var message = new Message()
            {
                Subject = generalsettings.ApplicationName + " Payment Request",
                Body = new ItemBody()
                {
                    ContentType = BodyType.Html,
                    Content = "Please find the attached paymenet request from " + @object.EnteredByID
                },
                ToRecipients = recipients,
                Attachments = new MessageAttachmentsCollectionPage() { new FileAttachment() { Name = "paymentrequest.pdf", ContentType = "application/pdf", ContentBytes = bytes } }
            };

            GraphServiceClient.Me.SendMail(message, true)
                .Request()
                .PostAsync()
                .ContinueWith(task =>
                {
                    // Log or something
                })
                .ConfigureAwait(false);
        }

        private bool InsertIfExists(PdfLoadedFormFieldCollection fieldCollection, string field, string value)
        {
            if(fieldCollection.TryGetField(field, out PdfLoadedField loadedField))
            {
                (loadedField as PdfLoadedTextBoxField).Text = value ?? "";
                return true;
            }

            return false;
        }
    }
}
