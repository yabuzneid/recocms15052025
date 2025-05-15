using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Syncfusion.Pdf.Parsing;
using System.IO;
using RecoCms6.Models.RecoDb;
using Microsoft.AspNetCore.Components;
using RecoCms6.Services.Automatizations;
using MimeKit;
using RecoCms6.Services;
using RecoCms6.Services.TemplateEngine;
using RecoCms6.Utility;
using Newtonsoft.Json;
using Microsoft.Graph;

namespace RecoCms6.Pages
{
    public partial class AddTransactionComponent
    {
        private CheckTransactionLimit getAllowableAmount;

        //[Inject]
        //protected IInvoiceSendingService<Transaction> InvoiceSendingService { get; set; }
        [Inject]
        protected MailService mailService { get; set; }
        protected async void SendInvoice()
        {
            try
            {
                var firm = transaction.Firm;
                var claim = getClaimsResult.First();
                var transactionAmt = transaction.Amount - transaction.ApplicableDeductible;
                string paymentBreakdown = String.Empty;

                string filename = "paymentrequest_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                PdfLoadedDocument loadedDocument;
                byte[] bytes;

                List<Recipient> recipientsList = new List<Recipient>();
                foreach (var recipient in accountantList)
                    recipientsList.Add(new Recipient{ EmailAddress = new EmailAddress{ Address = recipient.Email} });

                if (recipientsList.Count == 0)//If no accountants, exit function
                    return;

                using (var stream = new FileStream("Templates/paymentinvoice.pdf", FileMode.Open, FileAccess.Read))
                {
                    loadedDocument = new PdfLoadedDocument(stream);
                    var form = loadedDocument.Form;
                    var fields = form.Fields;

                    var floatAccount = Globals.generalsettings.FloatAccount;
                    if (floatAccount == null)
                        floatAccount = String.Empty;

                    paymentBreakdown = getContractYear + ": " + transaction.Amount.ToString("C");
                    if (transaction.ApplicableDeductible != null && transaction.ApplicableDeductible > 0)
                    {
                        decimal deductible = (decimal)transaction.ApplicableDeductible;
                        paymentBreakdown = paymentBreakdown + " Deductible: " + deductible.ToString("C");
                    }

                    var values = new List<(string key, string value)>()
                    {
                        ("AuthorizationDate", DateTime.Today.ToShortDateString()),
                        ("ApplicationName", Globals.generalsettings.ApplicationName),
                        ("ServiceProvider", firm?.Name),
                        ("ClaimNo", claimlist.ClaimNo),
                        ("InvoiceNo", transaction.InvoiceNum),
                        ("InvoiceDate", transaction.TransactionDate.ToShortDateString()),
                        ("Claimant", claimlist.Claimant),
                        ("DefenseCounselFileNumber", claimlist.CounselFileNo),
                        ("PaymentBreakdown", paymentBreakdown),
                        ("PayableTo", transaction.PayableTo),
                        ("IncurredType", incurredTypeDesc),
                        ("Amount",string.Format("{0:C}", transactionAmt)),
                        ("Comments", transaction.Comments),
                        ("SendingInstructions", transaction.SendingInstructions),
                        ("UploadedBy", transaction.EnteredByID),
                        ("DateUploaded", DateTime.Today.ToShortDateString())
                    };

                    values.ForEach(value => InsertIfExists(fields, value.key, value.value));
                    using (var saveStream = new MemoryStream())
                    {
                        loadedDocument.Form.Flatten = true;
                        loadedDocument.Save(saveStream);
                        saveStream.Position = 0;
                        bytes = saveStream.ToArray();
                    }
                    loadedDocument.Close(true);

                    try
                    {
                    
                        var file = new Models.RecoDb.File()
                        {
                            ID = Guid.NewGuid(),
                            ClaimID = transaction.ClaimID,
                            Extension = ".pdf",
                            Subject = $"Payment Request",
                            Filename = filename,
                            EntryDate = DateTime.Now,
                            FileTypeID = getPaymentRequestFileID,
                            StoredDocument = bytes,
                            UploadedById = Security.User.Id,
                            ContentType = "application/pdf"
                        };

                        await RecoDb.CreateFile(file);
                    }
                    catch (Exception ex) {
                        string jsonMessage = JsonConvert.SerializeObject(ex);
                        await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", transaction.ClaimID);
                    }
                }

                var message = new Microsoft.Graph.Message
                {
                    Subject = Globals.generalsettings.ApplicationName + ": " + claim.ClaimNo +  " - Payment Request",
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Html,
                        Content = "Please find the attached payment request from " + transaction.EnteredByID,
                        
                    },
                    ToRecipients = recipientsList,
                    From = new Recipient { EmailAddress = new EmailAddress { Address=Security.User.Email } }
                };

                message.Attachments = new MessageAttachmentsCollectionPage();

                message.Attachments.Add(new FileAttachment { Name = filename, ContentBytes = bytes, ContentType = "application/pdf" });

                newRecoMail.Claim = claim;
                newRecoMail.Claimlist = claimlist;

                newRecoMail.ClaimFiles.ForEach(file =>
                    {
                        message.Attachments.Add(new FileAttachment { Name = file.Filename, ContentBytes = file.StoredDocument, ContentType = file.ContentType });
                    });

                foreach (var file in newRecoMail.Files)
                        message.Attachments.Add(new FileAttachment { Name = file.Name, ContentBytes = await ToByteArray(file.Data) });

                if (newRecoMail.Notes?.Count > 0)
                {
                    string result = TemplateBuilder.BuildNotesAttachment(newRecoMail);
                    message.Attachments.Add(new FileAttachment { Name = "Notes.pdf", ContentBytes = result.ToPDFByteArray(), ContentType = "application/pdf" });
                }

                await mailService.SendMail(message, Security.User.Email);
            }
            catch(Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", transaction.ClaimID);
                NotificationService.Notify(NotificationSeverity.Warning, "Warning", "Failed to send the payment email notification!");
            }
        }

        protected async void CheckTransactionLimits()
        {
            if (Globals.generalsettings.ApplicationName != "RECO CMS" || Security.IsInRole("Program Manager"))
            {
                bProcessPayment = true;
                return;
            }

            Decimal topAmount = 0;

            if (transaction.IncurredCategoryID == getPaymentID)
                topAmount = (decimal)totalPayment + transaction.Amount;
            else if (transaction.IncurredCategoryID == getReserveID)
                topAmount = (decimal)totalReserve + transaction.Amount;
            else  //Currently allow any amount of deductible/subrogation to be processed
            {
                bProcessPayment = true;
                return;
            }

            var recoDbGetCheckTransactionLimitsResult = await RecoDb.GetCheckTransactionLimits($"{Security.User.Id}", transaction.IncurredCategoryID, transaction.IncurredTypeID, claimlist.ProgramID);
            if (recoDbGetCheckTransactionLimitsResult != null)
                getAllowableAmount = recoDbGetCheckTransactionLimitsResult.FirstOrDefault();

            if (getAllowableAmount == null || getAllowableAmount.ApprovalLimit < topAmount)
            {
                bRequestIncrease = true;
                NotificationService.Notify(NotificationSeverity.Warning, "Warning", "The amount entered for this transaction will exceed the authorized limit. Please enter information in the comments section to provide additional information");
            }
            else
            {
                bRequestIncrease = false;
                bProcessPayment = true;
            }
                
        }
        protected async Task SendLimitIncreaseRequest()
        {
            try
            {
                if (await DialogService.Confirm("This transaction exceeds allowable limits, send email to Norma?") == false)
                    return;

                var firm = transaction.Firm;
                decimal transactionAmt; 

                string strTitle = String.Empty;
                string strMsg = String.Empty;
                string noteMsg = string.Empty;
                string insureds = string.Empty;

                transactionAmt = transaction.Amount;

                if (transaction.ApplicableDeductible != null)
                    transactionAmt = (decimal)(transactionAmt - transaction.ApplicableDeductible);

                List<MailboxAddress> recipientsList = new List<MailboxAddress>();
                
                recipientsList.Add(MailboxAddress.Parse(getPrimeProgramManager.EmailAddress.Trim()));

                if (recipientsList.Count == 0)//If no prime program manager, exit function
                    return;

                if (!string.IsNullOrEmpty(claimlist.Insureds))
                    insureds = claimlist.Insureds;

                noteMsg = "Claim #: " + claimlist.ClaimNo + " Insured(s): " + insureds + "<br/>";
                strMsg = serviceprovider.Name + " Requests an increase in ";

                if (transaction.IncurredCategoryID == getPaymentID)
                {
                    if (transaction.IncurredTypeID == getIndemnityID)
                    {
                        strMsg += "Indemnity Payment of ";
                        strTitle = " Request To Increase Payment";
                        noteMsg += "<br/>Suggested Indemnity Payment: {0} <br/>Transaction Type: Indemnity<br/>";
                    }
                    else if (transaction.IncurredTypeID == getLegalID)
                    {
                        strMsg += "Legal Payment of ";
                        strTitle = "Request To Increase Payment";
                        noteMsg += "<br/>Suggested Legal Payment: {0} <br/>Transaction Type: Legal<br/>";
                    }
                    else if (transaction.IncurredTypeID == getAdjustingID)
                    {
                        strMsg += "Adjusting Payment of ";
                        strTitle = "Request To Increase Payment";
                        noteMsg += "<br/>Suggested Adjusting Payment: {0} <br/>Transaction Type: Adjusting<br/>";
                    }
                }
                else if (transaction.IncurredCategoryID == getReserveID)
                {
                    if (transaction.IncurredTypeID == getIndemnityID)
                    {
                        strMsg += "Indemnity Reserve of ";
                        strTitle = "Request To Increase Reserve";
                        noteMsg += "<br/>Suggested Increase In Indemnity Reserve: {0} <br/>Transaction Type: Indemnity<br/>";
                    }
                    else if (transaction.IncurredTypeID == getLegalID)
                    {
                        strMsg += "Legal Reserve of ";
                        strTitle = "Request To Increase Reserve";
                        noteMsg += "<br/>Suggested Increase In Legal Reserve: {0} <br/>Transaction Type: Legal<br/>";
                    }
                    else if (transaction.IncurredTypeID == getAdjustingID)
                    {
                        strMsg += "Adjusting Reserve of ";
                        strTitle = "Request To Increase Reserve";
                        noteMsg += "<br/>Suggested Increase In Adjusting Reserve: {0} <br/>Transaction Type: Adjusting<br/>";
                    }
                }
                else if (transaction.IncurredTypeID == getDeductibleID)
                {
                    strMsg += "Deductible of ";
                    strTitle = "Request To Increase Deductible";
                    noteMsg += "<br/>Suggested Increase In Deductible: {0} <br/>Transaction Type: Deductible<br/>";
                }
                else if (transaction.IncurredTypeID == getDeductibleID)
                {
                    strMsg += "Subrogation of ";
                    strTitle = "Request To Increase Subrogation";
                    noteMsg += "<br/>Suggested Increase In Subrogation: {0} <br/>Transaction Type: Subrogation<br/>";
                }
                else //No 
                    return;

                strMsg += transaction.Amount.ToString("C") + "<br/>";
                noteMsg = string.Format(noteMsg, transaction.Amount.ToString("C"));
                if (!String.IsNullOrEmpty(transaction.Comments))
                {
                    strMsg += transaction.Comments;
                    noteMsg += "<br/><br/>" + serviceprovider.Name + " Comment: " + transaction.Comments;
                }
                    

                var message = new MimeKit.MimeMessage
                {
                    Subject = Globals.generalsettings.ApplicationName + ":  " + strTitle,
                    Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = noteMsg
                    }
                };

                var builder = new BodyBuilder();

                // Set the plain-text version of the message text
                builder.TextBody = noteMsg.Replace("<br/>", Environment.NewLine);
                builder.HtmlBody = noteMsg;

                // Now we just need to set the message body and we're done
                message.Body = builder.ToMessageBody();
                message.From.Add(new MailboxAddress(Security.User.Name, Security.User.Email));
                message.To.AddRange(recipientsList);

                await mailService.SendMail(message);
                await CreateLimitIncreaseNote(noteMsg);

                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = $"Increase Request Sent" });

                DialogService.Close(transaction);
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", transaction.ClaimID);
                NotificationService.Notify(NotificationSeverity.Warning, "Warning", "Failed to send the request email");
            }
        }

        protected async Task CreateLimitIncreaseNote(string noteMsg)
        {
            Note note = new Note();

            note.ID = Guid.NewGuid();
            note.Subject = "Request To Increase Reserve";
            note.Details = "Claim #" + claimlist.ClaimNo + " Insured(s):" + claimlist.Insureds + "<br/>";
            note.Details = noteMsg;
            note.EnteredByID = Security.User.Name;
            note.ClaimID = transaction.ClaimID;
            note.EnteredByID = serviceprovider.Name;
            note.NoteTypeID = getDefaultNoteTypeID;

            try
            {
                var recoDbCreateNoteResult = await RecoDb.CreateNote(note);
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", transaction.ClaimID);
            }
        }
        protected async Task SendIndemnityMessage()
        {
            try
            {
                string curEmail=String.Empty;
                string strMsg = String.Empty;

                if (getOpenFileList.Count() > 0)
                foreach (FindOpenFilesForRegistrant openFile in getOpenFileList)
                {
                    strMsg = openFile.PaidClaimNo + " has just processed a payment for registrant: " + openFile.Name + " - " + openFile.RegistrantNo;
                    strMsg += "<br/>This registrant is also currently on a claim you are handling: " + openFile.ClaimNo;

                    List<MailboxAddress> recipientsList = new List<MailboxAddress>();
                    recipientsList.Add(MailboxAddress.Parse(openFile.FilehandlerEmail.Trim()));

                    var message = new MimeKit.MimeMessage
                    {
                        Subject = Globals.generalsettings.ApplicationName + " Indemnity Payment Notice",
                        Body = new TextPart(MimeKit.Text.TextFormat.Html)
                        {
                            Text = strMsg
                        }
                    };

                    var builder = new BodyBuilder();

                    // Set the plain-text version of the message text
                    builder.TextBody = strMsg.Replace("<br/>", Environment.NewLine);
                    builder.HtmlBody = strMsg;

                    // Now we just need to set the message body and we're done
                    message.Body = builder.ToMessageBody();
                    message.From.Add(new MailboxAddress(Globals.generalsettings.SystemNameFrom,Globals.generalsettings.SystemEmail));
                    message.To.AddRange(recipientsList);

                    try
                    {
                        await mailService.SendMail(message);
                    }
                    catch { }
                }                
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", transaction.ClaimID);
            }
        }
        protected async System.Threading.Tasks.Task DownloadFileAsync(Models.RecoDb.ClaimFilesByUser file)
        {
            try
            {
                UriHelper.NavigateTo($"/downloadfullfile/FileID={file.FileID}", true);
            }
            catch { }
        }

        private bool InsertIfExists(PdfLoadedFormFieldCollection fieldCollection, string field, string value)
        {
            if (fieldCollection.TryGetField(field, out PdfLoadedField loadedField))
            {
                (loadedField as PdfLoadedTextBoxField).Text = value ?? "";
                return true;
            }

            return false;
        }

        private async Task<Byte[]> ToByteArray(Stream stream)
        {
            var ms = new MemoryStream();

            await stream.CopyToAsync(ms);

            return ms.ToArray();
        }

        //private async void GeneratePDF()
        //{
        //    Stream inputStream = new MemoryStream(generatedinvoicetemplate.TemplateDocument);
        //    inputStream.Position = 0;
        //    //PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);
        //    //PdfLoadedDocument loadedDocument = new PdfLoadedDocument(generatedinvoicetemplate.TemplateDocument);
        //    FileStream docStream = new FileStream("D:\\Templates\\paymentinvoice.pdf", FileMode.Open, FileAccess.Read);
        //    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

        //    // Load the form from the loaded document.
        //    PdfLoadedForm form = loadedDocument.Form;

        //    // Load the form field collections from the form.
        //    PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;
        //    PdfLoadedField fieldValue;


        //    var recoDbGetFirmDetailsResult = await RecoDb.GetFirmDetails(new Query() { Filter = $@"i => i.FirmID == @0", FilterParameters = new object[] { transaction.FirmID } });
        //    var selectedFirm = recoDbGetFirmDetailsResult.FirstOrDefault();

        //    // Go through the fields and put in correct details
        //    if (fieldCollection.TryGetField("AuthorizationDate", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = DateTime.Today.ToLongDateString();

        //    if (fieldCollection.TryGetField("ServiceProvider", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = selectedFirm.Name;
        //    //if (fieldCollection.TryGetField("ClaimNo", out fieldValue))
        //    //    (fieldValue as PdfLoadedTextBoxField).Text = DateTime.Today.ToLongDateString();
        //    if (fieldCollection.TryGetField("InvoiceNo", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = transaction.InvoiceNum;

        //    if (fieldCollection.TryGetField("InvoiceDate", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = transaction.TransactionDate.ToLongDateString();

        //    string strBreakdown = String.Empty;
        //    decimal totalAmount = 0;

        //    strBreakdown += getContractYear + ": " + string.Format("{0:C}", transaction.Amount) ;

        //    if (fieldCollection.TryGetField("PaymentBreakdown", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = strBreakdown;
        //    if (fieldCollection.TryGetField("PayableTo", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = transaction.PayableTo;

        //    if (fieldCollection.TryGetField("Amount", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = string.Format("{0:C}", transaction.Amount);

        //    if (fieldCollection.TryGetField("IncurredType", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = selectedFirm.IndemnityType + " Payment";

        //    if (fieldCollection.TryGetField("Comments", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = transaction.Comments;

        //    if (fieldCollection.TryGetField("UploadedBy", out fieldValue))
        //            (fieldValue as PdfLoadedTextBoxField).Text = Security.User.Name;

        //    if (fieldCollection.TryGetField("DateUploaded", out fieldValue))
        //        (fieldValue as PdfLoadedTextBoxField).Text = DateTime.Today.ToLongDateString();

        //    //Save the document into stream.
        //    MemoryStream generatedstream = new MemoryStream();
        //    loadedDocument.Form.Flatten = true;
        //    loadedDocument.Save(generatedstream);

        //    generatedstream.Position = 0;

        //    byte[] result;
        //    result = generatedstream.ToArray();

        //    //Defining the ContentType for pdf file.
        //    string contentType = "application/pdf";

        //    //Define the file name.
        //    string fileName = "paymentinvoice" + DateTime.Now.ToFileTime().ToString() + ".pdf";

        //    invoiceuploadfile.GeneratedInvoice = result;
        //    invoiceuploadfile.GeneratedInvoiceContentType = contentType;
        //    invoiceuploadfile.GeneratedInvoiceFilename = fileName;
        //    invoiceuploadfile.UploadDate = DateTime.Now;
        //    invoiceuploadfile.UploadedByID = Security.User.Id;
        //    invoiceuploadfile.FirmID = selectedFirmID;

        //    var recoDbCreateInvoiceUploadFileResult = await RecoDb.CreateInvoiceUploadFile(invoiceuploadfile);
        //    //Close the document.
        //    loadedDocument.Close(true);
        //}
    }
}
