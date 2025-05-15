using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RecoCms6.Models;

namespace RecoCms6.Pages
{
    public partial class UploadInvoiceComponent : ComponentBase, IDisposable
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }

        public void Dispose()
        {
            Globals.PropertyChanged -= OnPropertyChanged;
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected RecoDbService RecoDb { get; set; }
        protected RadzenGrid<RecoCms6.Models.RecoDb.InvoiceUploadRowError> gridErrors;

        IEnumerable<RecoCms6.Models.RecoDb.Firm> _getFirmList;
        protected IEnumerable<RecoCms6.Models.RecoDb.Firm> getFirmList
        {
            get
            {
                return _getFirmList;
            }
            set
            {
                if (!object.Equals(_getFirmList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFirmList", NewValue = value, OldValue = _getFirmList };
                    _getFirmList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _payableTo;
        protected string payableTo
        {
            get
            {
                return _payableTo;
            }
            set
            {
                if (!object.Equals(_payableTo, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "payableTo", NewValue = value, OldValue = _payableTo };
                    _payableTo = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedFirmID;
        protected int selectedFirmID
        {
            get
            {
                return _selectedFirmID;
            }
            set
            {
                if (!object.Equals(_selectedFirmID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedFirmID", NewValue = value, OldValue = _selectedFirmID };
                    _selectedFirmID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _comments;
        protected string comments
        {
            get
            {
                return _comments;
            }
            set
            {
                if (!object.Equals(_comments, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "comments", NewValue = value, OldValue = _comments };
                    _comments = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _invoicenumber;
        protected string invoicenumber
        {
            get
            {
                return _invoicenumber;
            }
            set
            {
                if (!object.Equals(_invoicenumber, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "invoicenumber", NewValue = value, OldValue = _invoicenumber };
                    _invoicenumber = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _sendinginstructions;
        protected string sendinginstructions
        {
            get
            {
                return _sendinginstructions;
            }
            set
            {
                if (!object.Equals(_sendinginstructions, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sendinginstructions", NewValue = value, OldValue = _sendinginstructions };
                    _sendinginstructions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        DateTime _invoicedate;
        protected DateTime invoicedate
        {
            get
            {
                return _invoicedate;
            }
            set
            {
                if (!object.Equals(_invoicedate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "invoicedate", NewValue = value, OldValue = _invoicedate };
                    _invoicedate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.InvoiceUpload> _uploadeddata;
        protected IEnumerable<RecoCms6.Models.RecoDb.InvoiceUpload> uploadeddata
        {
            get
            {
                return _uploadeddata;
            }
            set
            {
                if (!object.Equals(_uploadeddata, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadeddata", NewValue = value, OldValue = _uploadeddata };
                    _uploadeddata = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.InvoiceUploadRowError> _uploaderrors;
        protected IEnumerable<RecoCms6.Models.RecoDb.InvoiceUploadRowError> uploaderrors
        {
            get
            {
                return _uploaderrors;
            }
            set
            {
                if (!object.Equals(_uploaderrors, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploaderrors", NewValue = value, OldValue = _uploaderrors };
                    _uploaderrors = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.InvoiceUploadFile _invoiceuploadfile;
        protected RecoCms6.Models.RecoDb.InvoiceUploadFile invoiceuploadfile
        {
            get
            {
                return _invoiceuploadfile;
            }
            set
            {
                if (!object.Equals(_invoiceuploadfile, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "invoiceuploadfile", NewValue = value, OldValue = _invoiceuploadfile };
                    _invoiceuploadfile = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        System.Collections.ArrayList _validationarray;
        protected System.Collections.ArrayList validationarray
        {
            get
            {
                return _validationarray;
            }
            set
            {
                if (!object.Equals(_validationarray, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "validationarray", NewValue = value, OldValue = _validationarray };
                    _validationarray = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _processing;
        protected int processing
        {
            get
            {
                return _processing;
            }
            set
            {
                if (!object.Equals(_processing, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "processing", NewValue = value, OldValue = _processing };
                    _processing = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.SystemTemplate _generatedinvoicetemplate;
        protected RecoCms6.Models.RecoDb.SystemTemplate generatedinvoicetemplate
        {
            get
            {
                return _generatedinvoicetemplate;
            }
            set
            {
                if (!object.Equals(_generatedinvoicetemplate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "generatedinvoicetemplate", NewValue = value, OldValue = _generatedinvoicetemplate };
                    _generatedinvoicetemplate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProviderDetail _currentuser;
        protected RecoCms6.Models.RecoDb.ServiceProviderDetail currentuser
        {
            get
            {
                return _currentuser;
            }
            set
            {
                if (!object.Equals(_currentuser, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "currentuser", NewValue = value, OldValue = _currentuser };
                    _currentuser = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isValid;
        protected bool isValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                if (!object.Equals(_isValid, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isValid", NewValue = value, OldValue = _isValid };
                    _isValid = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _claimNoList;
        protected List<string> claimNoList
        {
            get
            {
                return _claimNoList;
            }
            set
            {
                if (!object.Equals(_claimNoList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimNoList", NewValue = value, OldValue = _claimNoList };
                    _claimNoList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDemandLetterID;
        protected int getDemandLetterID
        {
            get
            {
                return _getDemandLetterID;
            }
            set
            {
                if (!object.Equals(_getDemandLetterID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDemandLetterID", NewValue = value, OldValue = _getDemandLetterID };
                    _getDemandLetterID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getSmallClaimID;
        protected int getSmallClaimID
        {
            get
            {
                return _getSmallClaimID;
            }
            set
            {
                if (!object.Equals(_getSmallClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSmallClaimID", NewValue = value, OldValue = _getSmallClaimID };
                    _getSmallClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getSuperiorCourtID;
        protected int getSuperiorCourtID
        {
            get
            {
                return _getSuperiorCourtID;
            }
            set
            {
                if (!object.Equals(_getSuperiorCourtID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSuperiorCourtID", NewValue = value, OldValue = _getSuperiorCourtID };
                    _getSuperiorCourtID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getBrokerageOnlyID;
        protected int getBrokerageOnlyID
        {
            get
            {
                return _getBrokerageOnlyID;
            }
            set
            {
                if (!object.Equals(_getBrokerageOnlyID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBrokerageOnlyID", NewValue = value, OldValue = _getBrokerageOnlyID };
                    _getBrokerageOnlyID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getRegistrantOnlyID;
        protected int getRegistrantOnlyID
        {
            get
            {
                return _getRegistrantOnlyID;
            }
            set
            {
                if (!object.Equals(_getRegistrantOnlyID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRegistrantOnlyID", NewValue = value, OldValue = _getRegistrantOnlyID };
                    _getRegistrantOnlyID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getPaymentRequestID;
        protected int getPaymentRequestID
        {
            get
            {
                return _getPaymentRequestID;
            }
            set
            {
                if (!object.Equals(_getPaymentRequestID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPaymentRequestID", NewValue = value, OldValue = _getPaymentRequestID };
                    _getPaymentRequestID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
            getFirmList = recoDbGetFirmsResult;

            payableTo = String.Empty;

            selectedFirmID = 0;

            comments = String.Empty;

            invoicenumber = String.Empty;

            sendinginstructions = String.Empty;

            invoicedate = DateTime.Today;

            var recoDbClearInvoiceUploadDataResult = await RecoDb.ClearInvoiceUploadData();

            var recoDbGetInvoiceUploadsResult = await RecoDb.GetInvoiceUploads();
            uploadeddata = recoDbGetInvoiceUploadsResult;

            var recoDbGetInvoiceUploadRowErrorsResult = await RecoDb.GetInvoiceUploadRowErrors();
            uploaderrors = recoDbGetInvoiceUploadRowErrorsResult;

            invoiceuploadfile = new RecoCms6.Models.RecoDb.InvoiceUploadFile();

            validationarray = new System.Collections.ArrayList();

            processing = 0;

            var recoDbGetSystemTemplatesResult = await RecoDb.GetSystemTemplates(new Query() { Filter = $@"i => i.TemplateName == @0", FilterParameters = new object[] { "Invoice" } });
            generatedinvoicetemplate = recoDbGetSystemTemplatesResult.FirstOrDefault();

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            currentuser = recoDbGetServiceProviderDetailsResult.FirstOrDefault();

            isValid = false;

            claimNoList = new List<string>();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Claim Initiation", "BrokerageOnly", "File Type" } });
            getDemandLetterID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc == "Claim Initiation" && p.ParamDesc == "Demand Letter").ParameterID;

            getSmallClaimID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc == "Claim Initiation" && p.ParamDesc == "Small Claim").ParameterID;

            getSuperiorCourtID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc == "Claim Initiation" && p.ParamDesc == "Superior Court").ParameterID;

            getBrokerageOnlyID = recoDbGetParameterDetailsResult.FirstOrDefault(p => p.ParamTypeDesc == "BrokerageOnly" && p.ParamDesc == "Brokerage Only").ParameterID;

            getRegistrantOnlyID = recoDbGetParameterDetailsResult.FirstOrDefault(p => p.ParamTypeDesc == "BrokerageOnly" && p.ParamDesc == "Registrant Only").ParameterID;

            getPaymentRequestID = recoDbGetParameterDetailsResult.FirstOrDefault(p => p.ParamTypeDesc == "File Type" && p.ParamDesc == "Payment Request").ParameterID;

            var recoDbGetInvoiceUploadRowErrorsResult0 = await RecoDb.GetInvoiceUploadRowErrors(new Query() { OrderBy = $"RowNumber asc,Problem asc" });
            uploaderrors = recoDbGetInvoiceUploadRowErrorsResult0;
        }

        protected async System.Threading.Tasks.Task TemplateForm0Submit(RecoCms6.Models.RecoDb.InvoiceUploadFile args)
        {
            var validateResult = Validate();
            isValid = validateResult;

            if (!isValid)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Fix Errors On Form" });
                return;
            }

            var recoDbClearInvoiceUploadDataResult = await RecoDb.ClearInvoiceUploadData();

            ProcessInvoiceFile();

            var recoDbGetInvoiceUploadRowErrorsResult = await RecoDb.GetInvoiceUploadRowErrors();
            uploaderrors = recoDbGetInvoiceUploadRowErrorsResult;

            if (uploaderrors.Count() > 0)
            {
                await gridErrors.Reload();
            }

            if (uploaderrors != null && uploaderrors.Count() > 0)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Row Errors",Detail = $"See Grid For Details" });
            }

            if (uploaderrors.Count() == 0 && isValid)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"Invoice Has Been Uploaded" });
            }
        }

        protected async System.Threading.Tasks.Task FirmIdChange(dynamic args)
        {
            if (selectedFirmID != null) {
                payableTo = getFirmList.FirstOrDefault(f=>f.FirmID == selectedFirmID).Name;
            }
        }

        protected async System.Threading.Tasks.Task Upload0Complete(UploadCompleteEventArgs args)
        {
            UploadCompleted(args);
        }

        protected async System.Threading.Tasks.Task ButtonGenerateInvoiceClick(MouseEventArgs args)
        {
            try
            {
                GeneratePDF();
            }
            catch (System.Exception generatePdfException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"There was an error" });
            }

                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"Succeeded" });
        }

        protected async System.Threading.Tasks.Task ButtonExportErrorsClick(MouseEventArgs args)
        {
            await RecoDb.ExportInvoiceUploadRowErrorsToExcel(fileName: $"invoiceuploaderrors");
        }
    }
}
