using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Syncfusion.XlsIO;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using RecoCms6.Models.RecoDb;
using Syncfusion.Pdf.Parsing;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Mvc;
using RecoCms6.Services;
using Microsoft.AspNetCore.Components;
using MimeKit;
using File = RecoCms6.Models.RecoDb.File;
using Microsoft.Graph;


namespace RecoCms6.Pages
{
    public partial class UploadInvoiceComponent
    {
        IEnumerable<RecoCms6.Models.RecoDb.ClaimInsured> _getInsureds;
        protected EoClaimDetail eoclaimdetails { get; set; }

        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimInsured> getInsureds
        {
            get
            {
                return _getInsureds;
            }
            set
            {
                if (!object.Equals(_getInsureds, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getInsureds", NewValue = value, OldValue = _getInsureds };
                    _getInsureds = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.UserDetail> _accountantList;
        protected IEnumerable<RecoCms6.Models.RecoDb.UserDetail> accountantList
        {
            get
            {
                return _accountantList;
            }
            set
            {
                if (!object.Equals(_accountantList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "accountantList", NewValue = value, OldValue = _accountantList };
                    _accountantList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        [Inject]
        protected MailService mailService { get; set; }
        protected void ClearForm()
        {
            selectedFirmID = 0;
            payableTo = String.Empty;
            invoiceuploadfile.StoredInvoice = null;
            invoicenumber = String.Empty;
            comments = String.Empty;
            sendinginstructions = String.Empty;
            uploaderrors = new List<InvoiceUploadRowError>();
        }

        public async void GeneratePDF()
        { 
            Stream inputStream = new MemoryStream(generatedinvoicetemplate.TemplateDocument);
            inputStream.Position = 0;

            FileStream docStream = new FileStream("Templates\\rptInvoice.pdf", FileMode.Open, FileAccess.Read);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
            processing = 76;
            // Load the form from the loaded document.
            PdfLoadedForm form = loadedDocument.Form;

            // Load the form field collections from the form.
            PdfLoadedFormFieldCollection fieldCollection = form.Fields as PdfLoadedFormFieldCollection;
            PdfLoadedField fieldValue;
            
            var recoDbGetFirmDetailsResult = await RecoDb.GetFirmDetails(new Query() { Filter = $@"i => i.FirmID == @0", FilterParameters = new object[] { selectedFirmID } });
            var selectedFirm = recoDbGetFirmDetailsResult.FirstOrDefault();

            processing = 80;
            // Go through the fields and put in correct details
            if (fieldCollection.TryGetField("AuthorizationDate", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = DateTime.Today.ToString("MMM dd, yyyy");
            processing++;
            if (fieldCollection.TryGetField("ServiceProvider", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = selectedFirm.Name;
            processing++;
            //if (fieldCollection.TryGetField("ClaimNo", out fieldValue))
            //    (fieldValue as PdfLoadedTextBoxField).Text = string.Join(' ',claimNoList);

            if (fieldCollection.TryGetField("InvoiceNum", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = invoicenumber;
            processing++;
            if (fieldCollection.TryGetField("InvoiceDate", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = invoicedate.ToString("MMM dd, yyyy");
            processing++;
            var recoDbGetPeriodPaymentBreakdownsResult = await RecoDb.GetPeriodPaymentBreakdowns();
            var periodpaymentbreakdown = recoDbGetPeriodPaymentBreakdownsResult;
            processing++;
            string strBreakdown = String.Empty;
            decimal totalAmount = 0;
            foreach (PeriodPaymentBreakdown ppb in periodpaymentbreakdown)
            {
                if (fieldCollection.TryGetField("payment" + ppb.ParamAbbrev, out fieldValue))
                    (fieldValue as PdfLoadedTextBoxField).Text = string.Format("{0:C}", ppb.TotalAmount);

                totalAmount += (decimal)ppb.TotalAmount;
            }

            //if (fieldCollection.TryGetField("PaymentBreakdown", out fieldValue))
            //    (fieldValue as PdfLoadedTextBoxField).Text = strBreakdown;
            processing++;

            if (fieldCollection.TryGetField("PayableTo", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = payableTo;
            processing++;

            if (fieldCollection.TryGetField("AmountPayable", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = string.Format("{0:C}",totalAmount);
            processing++;
            if (fieldCollection.TryGetField("FirmType", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = selectedFirm.FirmType;
            processing++;
            if (fieldCollection.TryGetField("Comments", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = comments;

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            string enteredBy = recoDbGetServiceProviderDetailsResult.First().Name;

            if (fieldCollection.TryGetField("UploadedBy", out fieldValue))
                    (fieldValue as PdfLoadedTextBoxField).Text = enteredBy;

            if (fieldCollection.TryGetField("UploadDate", out fieldValue))
                (fieldValue as PdfLoadedTextBoxField).Text = DateTime.Today.ToString("MMM dd, yyyy");

            //Save the document into stream.
            MemoryStream generatedstream = new MemoryStream();
            loadedDocument.Form.Flatten = true;
            loadedDocument.Save(generatedstream);
            processing++;
            generatedstream.Position = 0;

            byte[] result;
            result = generatedstream.ToArray();

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "paymentinvoice" + DateTime.Now.ToFileTime().ToString() + ".pdf";

            invoiceuploadfile.GeneratedInvoice = result;
            invoiceuploadfile.GeneratedInvoiceContentType = contentType;
            invoiceuploadfile.GeneratedInvoiceFilename = fileName;
            invoiceuploadfile.UploadDate = DateTime.Now;
            invoiceuploadfile.UploadedByID = enteredBy;            
            invoiceuploadfile.FirmID = selectedFirmID;

            try
            {
                var recoDbCreateInvoiceUploadFileResult = await RecoDb.CreateInvoiceUploadFile(invoiceuploadfile);
            }
            catch { }
            
            //Close the document.
            loadedDocument.Close(true);
            processing = 100;

            var recoDbGetInvoiceUploadsResult = await RecoDb.GetInvoiceUploads();
            var invoiceuploads = recoDbGetInvoiceUploadsResult.ToList();

            File file1;

            
            foreach (InvoiceUpload invoiceuploadrow in invoiceuploads)
            {

                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimNo == @0", FilterParameters = new object[] { invoiceuploadrow.ClaimNo } });
                var claim = recoDbGetClaimsResult.FirstOrDefault();

                //Save PDF
                try
                {
                    file1 = new File();
                    file1.ID = Guid.NewGuid();
                    file1.ClaimID = claim.ClaimID;
                    file1.Extension = ".pdf";
                    file1.Subject = $"Payment Request Filed By {enteredBy}";
                    file1.Filename = fileName;
                    file1.EntryDate = DateTime.Now;
                    file1.StoredDocument = result;
                    file1.UploadedById = Security.User.Id;
                    file1.ContentType =contentType;
                    file1.FileTypeID = getPaymentRequestID;
                    await RecoDb.CreateFile(file1);
                }
                catch (Exception ex) {
                    string jsonMessage = JsonConvert.SerializeObject(ex);
                    await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", null);
                }
            }

            var recoDbGetUserDetailsResult = await RecoDb.GetUserDetails(new Query() { Filter = $@"i => i.Role == @0", FilterParameters = new object[] { "Accountant" } });
            accountantList = recoDbGetUserDetailsResult.ToList();

            List<Recipient> recipientsList = new List<Recipient>();
            foreach (var recipient in accountantList)
                recipientsList.Add(new Recipient { EmailAddress = new EmailAddress { Address = recipient.Email.Trim() } });

            if (recipientsList.Count == 0)//If no accountants, exit function
                return;

            var message = new Microsoft.Graph.Message
            {
                Subject = Globals.generalsettings.ApplicationName + " Payment Request",
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = "Please find the attached payment request from " + enteredBy
                },
                ToRecipients = recipientsList,
                From = new Recipient { EmailAddress = new EmailAddress { Address = Globals.generalsettings.SystemEmail.Trim() } }
            };

            //var builder = new BodyBuilder();

            //// Set the plain-text version of the message text
            //builder.HtmlBody = "Please find the attached payment request from " + enteredBy;

            //builder.Attachments.Add(fileName, result, new ContentType("application", "pdf"));

            message.Attachments = new MessageAttachmentsCollectionPage();

            message.Attachments.Add(new FileAttachment { Name = fileName, ContentBytes = result, ContentType = "application/pdf" });

            // Now we just need to set the message body and we're done
            //message.Body = builder.ToMessageBody();
            //message.From.Add(new MailboxAddress(Globals.generalsettings.SystemEmail));
            //message.To.AddRange(recipientsList);

            await mailService.SendMail(message,"");
        }
        public Boolean Validate()
        {
            bool bIsValid = true;

            validationarray = new System.Collections.ArrayList();
            if (selectedFirmID == 0)
            {
                bIsValid = false;
                validationarray.Add("FirmID");
            }
            if (payableTo == String.Empty)
            {
                bIsValid = false;
                validationarray.Add("PayableTo");
            }
            if (invoiceuploadfile.StoredInvoice == null)
            {
                bIsValid = false;
                validationarray.Add("InvoiceFile");
            }
            // if (invoicedate == null)
            // {
            //     bIsValid = false;
            //     validationarray.Add("InvoiceDate");
            // }
            if (invoicenumber == String.Empty)
            {
                bIsValid = false;
                validationarray.Add("InvoiceNumber");
            }

            return bIsValid;
        }
        public async void ProcessInvoiceFile()
        {
            bool isTransaction = false;
            try
            {
                //Load Excel Spreadsheet into table
                await LoadRows();
                //Check For Errors
                await CheckForErrors();

                var recoDbGetInvoiceUploadRowErrorsResult = await RecoDb.GetInvoiceUploadRowErrors(new Query() { OrderBy = $"RowNumber asc,Problem asc" });
                uploaderrors = recoDbGetInvoiceUploadRowErrorsResult.ToList();
                //If no errors process file & Generate Invoice Pdf
                if (uploaderrors.Count() == 0)
                {
                    RecoDb.BeginTransaction();
                    isTransaction = true;
                    await ProcessInvoices();
                    //Generate invoice pdf
                    GeneratePDF();
                    RecoDb.CommitTransaction();
                    isTransaction = false;
                    ClearForm();
                    UriHelper.NavigateTo($"/export/RecoDb/generatedinvoice/pdf(FileID={invoiceuploadfile.FileID})", true);
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                if (isTransaction)
                    RecoDb.RollbackTransaction();

                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", null);
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Problem with Invoice File", Detail = ex.Message });
            }

        }
        private async Task LoadRows()
        {

            //Convert to Excel Document
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel97to2003;

                Stream inputStream = new MemoryStream(invoiceuploadfile.StoredInvoice);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.UsedRangeIncludesFormatting = false;
                //Check it is a proper Excel File
                //Read data from the worksheet and Export to the DataTable
                DataTable invoiceTable = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames | ExcelExportDataTableOptions.ComputedFormulaValues);
                workbook.Close();
                excelEngine.Dispose();

                int rownumber = 1;
                int maxPercent = 25;
                int numRows = invoiceTable.Rows.Count;

            foreach (DataRow invoicerow in invoiceTable.Rows)
            {
                processing = maxPercent * rownumber / numRows;
                //Store Data in uploadinvoice  tables database
                var invoiceuploadrow = new InvoiceUpload();
                invoiceuploadrow.InsuredLastName = invoicerow.ItemArray[0].ToString();
                invoiceuploadrow.ClaimNo = invoicerow.ItemArray[2].ToString();
                invoiceuploadrow.FileNo = invoicerow.ItemArray[4].ToString();
                if (invoicerow.ItemArray[2] != null) //Only load dollars if a claim number has been loaded.
                {
                    try
                    {
                        invoiceuploadrow.Fees = decimal.Parse(invoicerow.ItemArray[6].ToString());
                        invoiceuploadrow.Disbursements = decimal.Parse(invoicerow.ItemArray[8].ToString());
                        invoiceuploadrow.Taxes = decimal.Parse(invoicerow.ItemArray[10].ToString());
                        invoiceuploadrow.Total = decimal.Parse(invoicerow.ItemArray[12].ToString());
                        invoiceuploadrow.PayAndClose = invoicerow.ItemArray[14].ToString();
                        invoiceuploadrow.RowNumber = rownumber;
                        var recoDbCreateInvoiceUploadResult = await RecoDb.CreateInvoiceUpload(invoiceuploadrow);
                    }
                    catch { }
                }
                
                rownumber++;
            }

        }
        private async Task CheckForErrors()
        {
            processing = 30;
            var recoDbCheckInvoicesForErrorsResult = await RecoDb.CheckInvoicesForErrors(selectedFirmID);
            processing = 50;
        }
        private async Task ProcessInvoices()
        {
            var recoDbGetInvoiceUploadsResult = await RecoDb.GetInvoiceUploads();
            var invoiceuploads = recoDbGetInvoiceUploadsResult.ToList();

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            string enteredByID = recoDbGetServiceProviderDetailsResult.First().Name;

            int numRows = invoiceuploads.Count();
            int minpercent = 51;
            int maxpercent = 75;
            int rownumber = 1;
            foreach(InvoiceUpload invoiceuploadrow in invoiceuploads)
            {
                processing = minpercent + ((maxpercent-minpercent) * rownumber/numRows);
                claimNoList.Add(invoiceuploadrow.ClaimNo);
                var recoDbProcessInvoicePaymentsResult = await RecoDb.ProcessInvoicePayments(invoiceuploadrow.InvoiceUploadID, selectedFirmID, $"{invoicedate}", $"{comments}", enteredByID);
                if (invoiceuploadrow.PayAndClose == "C")
                {
                    try
                    {
                        await SendSurveyEmail(invoiceuploadrow.ClaimNo);
                    }
                    catch (Exception ex)
                    {
                        string jsonMessage = JsonConvert.SerializeObject(ex);
                        await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", null);
                    }
                }
                    
                rownumber++;
            }
        }
        protected async Task SendSurveyEmail(string claimNo)
        {
            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimNo == @0", FilterParameters = new object[] { claimNo }, Expand = "ClaimFileReportings" });
            var claim = recoDbGetClaimsResult.First();


            if (!claim.SurveyOnClose)
                return;

            var recoDbGetEoClaimDetailByClaimIdResult = await RecoDb.GetEoClaimDetailByClaimId(claim.ClaimID);

            if (recoDbGetEoClaimDetailByClaimIdResult != null)
                eoclaimdetails = recoDbGetEoClaimDetailByClaimIdResult;
            else 
                return;

            //Only Send DemandLetter, SmallClaim, SuperiorCourt Files
            if (!(eoclaimdetails.ClaimInitiationID == getDemandLetterID || eoclaimdetails.ClaimInitiationID == getSmallClaimID || eoclaimdetails.ClaimInitiationID == getSuperiorCourtID))
                return;

            return;

        }

        protected void UploadCompleted(UploadCompleteEventArgs args)
        {
            invoiceuploadfile = JsonConvert.DeserializeObject<Models.RecoDb.InvoiceUploadFile>(args.RawResponse);
            if (invoiceuploadfile == null)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable to upload Invoice File, please try again" });
            };
        }

    }
}
