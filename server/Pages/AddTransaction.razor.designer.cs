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
using Serilog;

namespace RecoCms6.Pages
{
    public partial class AddTransactionComponent : ComponentBase, IDisposable
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

        [Parameter]
        public int ClaimID { get; set; }

        [Parameter]
        public dynamic TransactionID { get; set; }
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> gridTotalIncurred;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.File> datagridClaimFiles;

        IEnumerable<RecoCms6.Models.RecoDb.Claim> _getClaimsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Claim> getClaimsResult
        {
            get
            {
                return _getClaimsResult;
            }
            set
            {
                if (!object.Equals(_getClaimsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimsResult", NewValue = value, OldValue = _getClaimsResult };
                    _getClaimsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getProgramID;
        protected int getProgramID
        {
            get
            {
                return _getProgramID;
            }
            set
            {
                if (!object.Equals(_getProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgramID", NewValue = value, OldValue = _getProgramID };
                    _getProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimList _claimlist;
        protected RecoCms6.Models.RecoDb.ClaimList claimlist
        {
            get
            {
                return _claimlist;
            }
            set
            {
                if (!object.Equals(_claimlist, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimlist", NewValue = value, OldValue = _claimlist };
                    _claimlist = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParametersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParametersResult
        {
            get
            {
                return _getParametersResult;
            }
            set
            {
                if (!object.Equals(_getParametersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersResult", NewValue = value, OldValue = _getParametersResult };
                    _getParametersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getPaymentID;
        protected int getPaymentID
        {
            get
            {
                return _getPaymentID;
            }
            set
            {
                if (!object.Equals(_getPaymentID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPaymentID", NewValue = value, OldValue = _getPaymentID };
                    _getPaymentID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        dynamic _getEOProgramID;
        protected dynamic getEOProgramID
        {
            get
            {
                return _getEOProgramID;
            }
            set
            {
                if (!object.Equals(_getEOProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEOProgramID", NewValue = value, OldValue = _getEOProgramID };
                    _getEOProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getIndemnityID;
        protected int getIndemnityID
        {
            get
            {
                return _getIndemnityID;
            }
            set
            {
                if (!object.Equals(_getIndemnityID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getIndemnityID", NewValue = value, OldValue = _getIndemnityID };
                    _getIndemnityID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLegalID;
        protected int getLegalID
        {
            get
            {
                return _getLegalID;
            }
            set
            {
                if (!object.Equals(_getLegalID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLegalID", NewValue = value, OldValue = _getLegalID };
                    _getLegalID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getAdjustingID;
        protected int getAdjustingID
        {
            get
            {
                return _getAdjustingID;
            }
            set
            {
                if (!object.Equals(_getAdjustingID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAdjustingID", NewValue = value, OldValue = _getAdjustingID };
                    _getAdjustingID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _getContractYear;
        protected string getContractYear
        {
            get
            {
                return _getContractYear;
            }
            set
            {
                if (!object.Equals(_getContractYear, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getContractYear", NewValue = value, OldValue = _getContractYear };
                    _getContractYear = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getReserveID;
        protected int getReserveID
        {
            get
            {
                return _getReserveID;
            }
            set
            {
                if (!object.Equals(_getReserveID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getReserveID", NewValue = value, OldValue = _getReserveID };
                    _getReserveID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getReserveReasonList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getReserveReasonList
        {
            get
            {
                return _getReserveReasonList;
            }
            set
            {
                if (!object.Equals(_getReserveReasonList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getReserveReasonList", NewValue = value, OldValue = _getReserveReasonList };
                    _getReserveReasonList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDeductibleID;
        protected int getDeductibleID
        {
            get
            {
                return _getDeductibleID;
            }
            set
            {
                if (!object.Equals(_getDeductibleID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeductibleID", NewValue = value, OldValue = _getDeductibleID };
                    _getDeductibleID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getSubrogationID;
        protected int getSubrogationID
        {
            get
            {
                return _getSubrogationID;
            }
            set
            {
                if (!object.Equals(_getSubrogationID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSubrogationID", NewValue = value, OldValue = _getSubrogationID };
                    _getSubrogationID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDefaultNoteTypeID;
        protected int getDefaultNoteTypeID
        {
            get
            {
                return _getDefaultNoteTypeID;
            }
            set
            {
                if (!object.Equals(_getDefaultNoteTypeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDefaultNoteTypeID", NewValue = value, OldValue = _getDefaultNoteTypeID };
                    _getDefaultNoteTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getPaymentRequestFileID;
        protected int getPaymentRequestFileID
        {
            get
            {
                return _getPaymentRequestFileID;
            }
            set
            {
                if (!object.Equals(_getPaymentRequestFileID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPaymentRequestFileID", NewValue = value, OldValue = _getPaymentRequestFileID };
                    _getPaymentRequestFileID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Firm> _getFirmsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Firm> getFirmsResult
        {
            get
            {
                return _getFirmsResult;
            }
            set
            {
                if (!object.Equals(_getFirmsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFirmsResult", NewValue = value, OldValue = _getFirmsResult };
                    _getFirmsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Transaction _transaction;
        protected RecoCms6.Models.RecoDb.Transaction transaction
        {
            get
            {
                return _transaction;
            }
            set
            {
                if (!object.Equals(_transaction, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "transaction", NewValue = value, OldValue = _transaction };
                    _transaction = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProviderDetail _serviceprovider;
        protected RecoCms6.Models.RecoDb.ServiceProviderDetail serviceprovider
        {
            get
            {
                return _serviceprovider;
            }
            set
            {
                if (!object.Equals(_serviceprovider, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "serviceprovider", NewValue = value, OldValue = _serviceprovider };
                    _serviceprovider = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isEOProgram;
        protected bool isEOProgram
        {
            get
            {
                return _isEOProgram;
            }
            set
            {
                if (!object.Equals(_isEOProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isEOProgram", NewValue = value, OldValue = _isEOProgram };
                    _isEOProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> _getTotalIncurredResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> getTotalIncurredResult
        {
            get
            {
                return _getTotalIncurredResult;
            }
            set
            {
                if (!object.Equals(_getTotalIncurredResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTotalIncurredResult", NewValue = value, OldValue = _getTotalIncurredResult };
                    _getTotalIncurredResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoMail _newRecoMail;
        protected RecoMail newRecoMail
        {
            get
            {
                return _newRecoMail;
            }
            set
            {
                if (!object.Equals(_newRecoMail, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newRecoMail", NewValue = value, OldValue = _newRecoMail };
                    _newRecoMail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _Attachments;
        protected string Attachments
        {
            get
            {
                return _Attachments;
            }
            set
            {
                if (!object.Equals(_Attachments, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Attachments", NewValue = value, OldValue = _Attachments };
                    _Attachments = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _Notes;
        protected string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                if (!object.Equals(_Notes, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Notes", NewValue = value, OldValue = _Notes };
                    _Notes = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProviderList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProviderList
        {
            get
            {
                return _getServiceProviderList;
            }
            set
            {
                if (!object.Equals(_getServiceProviderList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServiceProviderList", NewValue = value, OldValue = _getServiceProviderList };
                    _getServiceProviderList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProviderDetail _getPrimeProgramManager;
        protected RecoCms6.Models.RecoDb.ServiceProviderDetail getPrimeProgramManager
        {
            get
            {
                return _getPrimeProgramManager;
            }
            set
            {
                if (!object.Equals(_getPrimeProgramManager, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPrimeProgramManager", NewValue = value, OldValue = _getPrimeProgramManager };
                    _getPrimeProgramManager = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal _zeroamount;
        protected decimal zeroamount
        {
            get
            {
                return _zeroamount;
            }
            set
            {
                if (!object.Equals(_zeroamount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "zeroamount", NewValue = value, OldValue = _zeroamount };
                    _zeroamount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.AvailableIncurredCategory> _getAvailableIncurredCategoryList;
        protected IEnumerable<RecoCms6.Models.RecoDb.AvailableIncurredCategory> getAvailableIncurredCategoryList
        {
            get
            {
                return _getAvailableIncurredCategoryList;
            }
            set
            {
                if (!object.Equals(_getAvailableIncurredCategoryList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAvailableIncurredCategoryList", NewValue = value, OldValue = _getAvailableIncurredCategoryList };
                    _getAvailableIncurredCategoryList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.AvailableIncurredType> _getAvailableIncurredTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.AvailableIncurredType> getAvailableIncurredTypeList
        {
            get
            {
                return _getAvailableIncurredTypeList;
            }
            set
            {
                if (!object.Equals(_getAvailableIncurredTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAvailableIncurredTypeList", NewValue = value, OldValue = _getAvailableIncurredTypeList };
                    _getAvailableIncurredTypeList = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "accountantList", NewValue = value, OldValue = _accountantList };
                    _accountantList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bReadOnly;
        protected bool bReadOnly
        {
            get
            {
                return _bReadOnly;
            }
            set
            {
                if (!object.Equals(_bReadOnly, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bReadOnly", NewValue = value, OldValue = _bReadOnly };
                    _bReadOnly = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bLegalExpense;
        protected bool bLegalExpense
        {
            get
            {
                return _bLegalExpense;
            }
            set
            {
                if (!object.Equals(_bLegalExpense, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bLegalExpense", NewValue = value, OldValue = _bLegalExpense };
                    _bLegalExpense = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _docExtensions;
        protected List<string> docExtensions
        {
            get
            {
                return _docExtensions;
            }
            set
            {
                if (!object.Equals(_docExtensions, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "docExtensions", NewValue = value, OldValue = _docExtensions };
                    _docExtensions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _imageExtensions;
        protected List<string> imageExtensions
        {
            get
            {
                return _imageExtensions;
            }
            set
            {
                if (!object.Equals(_imageExtensions, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "imageExtensions", NewValue = value, OldValue = _imageExtensions };
                    _imageExtensions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _avExtensions;
        protected List<string> avExtensions
        {
            get
            {
                return _avExtensions;
            }
            set
            {
                if (!object.Equals(_avExtensions, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "avExtensions", NewValue = value, OldValue = _avExtensions };
                    _avExtensions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bRequestIncrease;
        protected bool bRequestIncrease
        {
            get
            {
                return _bRequestIncrease;
            }
            set
            {
                if (!object.Equals(_bRequestIncrease, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bRequestIncrease", NewValue = value, OldValue = _bRequestIncrease };
                    _bRequestIncrease = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal? _totalReserve;
        protected decimal? totalReserve
        {
            get
            {
                return _totalReserve;
            }
            set
            {
                if (!object.Equals(_totalReserve, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "totalReserve", NewValue = value, OldValue = _totalReserve };
                    _totalReserve = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal? _totalPayment;
        protected decimal? totalPayment
        {
            get
            {
                return _totalPayment;
            }
            set
            {
                if (!object.Equals(_totalPayment, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "totalPayment", NewValue = value, OldValue = _totalPayment };
                    _totalPayment = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bProcessPayment;
        protected bool bProcessPayment
        {
            get
            {
                return _bProcessPayment;
            }
            set
            {
                if (!object.Equals(_bProcessPayment, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bProcessPayment", NewValue = value, OldValue = _bProcessPayment };
                    _bProcessPayment = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimCurrentReserf _getCurrentReserve;
        protected RecoCms6.Models.RecoDb.ClaimCurrentReserf getCurrentReserve
        {
            get
            {
                return _getCurrentReserve;
            }
            set
            {
                if (!object.Equals(_getCurrentReserve, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCurrentReserve", NewValue = value, OldValue = _getCurrentReserve };
                    _getCurrentReserve = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.FindOpenFilesForRegistrant> _getOpenFileList;
        protected IEnumerable<RecoCms6.Models.RecoDb.FindOpenFilesForRegistrant> getOpenFileList
        {
            get
            {
                return _getOpenFileList;
            }
            set
            {
                if (!object.Equals(_getOpenFileList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOpenFileList", NewValue = value, OldValue = _getOpenFileList };
                    _getOpenFileList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Parameter _selectedCategory;
        protected RecoCms6.Models.RecoDb.Parameter selectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                if (!object.Equals(_selectedCategory, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedCategory", NewValue = value, OldValue = _selectedCategory };
                    _selectedCategory = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _incurredTypeDesc;
        protected string incurredTypeDesc
        {
            get
            {
                return _incurredTypeDesc;
            }
            set
            {
                if (!object.Equals(_incurredTypeDesc, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "incurredTypeDesc", NewValue = value, OldValue = _incurredTypeDesc };
                    _incurredTypeDesc = value;
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
            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            getClaimsResult = recoDbGetClaimsResult;

            getProgramID = recoDbGetClaimsResult.First().ProgramID;

            var recoDbGetClaimListsResult = await RecoDb.GetClaimLists(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            claimlist = recoDbGetClaimListsResult.First();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2 || i.ParamTypeDesc == @3 || i.ParamTypeDesc == @4 || i.ParamTypeDesc == @5 || i.ParamTypeDesc == @6", FilterParameters = new object[] { "Incurred Type", "ProgramID", "Contract Year", "Incurred Category", "Reserve Type", "Note Type", "File Type" }, OrderBy = $"ParamDesc asc" });
            getParametersResult = recoDbGetParameterDetailsResult;

            getPaymentID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Category" && p.ParamDesc=="Payment").First().ParameterID;

            getEOProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="EO").First().ParameterID;

            getIndemnityID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Indemnity").First().ParameterID;

            getLegalID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Legal").First().ParameterID;

            getAdjustingID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Adjusting").First().ParameterID;

            getContractYear = recoDbGetParameterDetailsResult.Where(p=>p.ParameterID == getClaimsResult.First().ContractYearID).First().ParamDesc;

            getReserveID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Category" && p.ParamDesc=="Reserve").First().ParameterID;

            getReserveReasonList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Reserve Type");

            getDeductibleID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Deductible").ParameterID;

            getSubrogationID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamAbbrev=="OthRec").ParameterID;

            getDefaultNoteTypeID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="Note Type" && p.ParamDesc=="Note").ParameterID;

            getPaymentRequestFileID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="File Type" && p.ParamDesc=="Payment Request").ParameterID;

            var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmsResult;

            transaction = new RecoCms6.Models.RecoDb.Transaction(){};

            transaction.ClaimID = ClaimID;

            transaction.TransactionDate = DateTime.Today;

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            serviceprovider = recoDbGetServiceProviderDetailsResult.First();

            transaction.EnteredByID = serviceprovider.Name;

            isEOProgram = getProgramID == getEOProgramID;

            var recoDbGetClaimTotalIncurredByCategoriesResult = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            getTotalIncurredResult = recoDbGetClaimTotalIncurredByCategoriesResult;

            newRecoMail = new RecoMail();

            Attachments = String.Empty;

            Notes = String.Empty;

            var recoDbGetSystemTemplatesResult = await RecoDb.GetSystemTemplates(new Query() { Filter = $@"i => i.TemplateName == @0", FilterParameters = new object[] { "Invoice" } });
            generatedinvoicetemplate = recoDbGetSystemTemplatesResult.First();

            var recoDbGetServiceProviderDetailsResult0 = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"NameandFirm asc" });
            getServiceProviderList = recoDbGetServiceProviderDetailsResult0;

            getPrimeProgramManager = recoDbGetServiceProviderDetailsResult0.FirstOrDefault(sp=>sp.PrimeUser==true && sp.ServiceProviderRole=="Program Manager");

            zeroamount = 0;

            var recoDbGetAvailableIncurredCategoriesResult = await RecoDb.GetAvailableIncurredCategories();
            if (Globals.userdetails.SubmitPayments == true) {
                getAvailableIncurredCategoryList = recoDbGetAvailableIncurredCategoriesResult;
            }

            if (Globals.userdetails.SubmitPayments == null || Globals.userdetails.SubmitPayments == false) {
                getAvailableIncurredCategoryList = recoDbGetAvailableIncurredCategoriesResult.Where(cat=>cat.ParamDesc != "Payment");
            }

            var recoDbGetAvailableIncurredTypesResult = await RecoDb.GetAvailableIncurredTypes();
            getAvailableIncurredTypeList = recoDbGetAvailableIncurredTypesResult;

            var recoDbGetUserDetailsResult = await RecoDb.GetUserDetails(new Query() { Filter = $@"i => i.Role == @0", FilterParameters = new object[] { "Accountant" } });
            accountantList = recoDbGetUserDetailsResult;

            bReadOnly = TransactionID != 0;

            if (TransactionID != 0)
            {
                var recoDbGetTransactionsResult = await RecoDb.GetTransactions(new Query() { Filter = $@"i => i.TransactionID == @0", FilterParameters = new object[] { TransactionID } });
                transaction = recoDbGetTransactionsResult.First();
            }

            bLegalExpense = false;

            docExtensions = new List<string>{".pdf",".xls",".xlsx",".doc",".docx"};

            imageExtensions = new List<string>{".png",".jpeg",".jpg",".gif"};

            avExtensions = new List<string>{".avi",".mov",".mp4",".mp3",".m4a",".wav"};

            bRequestIncrease = false;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Transaction args)
        {
            totalReserve = (decimal?)0.0;

            totalPayment = (decimal?)0.0;

            bProcessPayment = false;

            if (transaction.IncurredCategoryID == getPaymentID && transaction.ApplicableDeductible == null) {
                transaction.ApplicableDeductible = 0;
            }

            var recoDbGetClaimCurrentReservesResult = await RecoDb.GetClaimCurrentReserves(new Query() { Filter = $@"i => i.ClaimID == @0 && i.IncurredTypeID == @1", FilterParameters = new object[] { transaction.ClaimID, transaction.IncurredTypeID } });
            if (recoDbGetClaimCurrentReservesResult != null && recoDbGetClaimCurrentReservesResult.FirstOrDefault() != null) {
                totalReserve = recoDbGetClaimCurrentReservesResult.FirstOrDefault().TotalReserve;
            }

            if (recoDbGetClaimCurrentReservesResult == null || recoDbGetClaimCurrentReservesResult.FirstOrDefault() == null) {
                totalReserve = 0;
            }

            var recoDbGetClaimCurrentPaymentsResult = await RecoDb.GetClaimCurrentPayments(new Query() { Filter = $@"i => i.ClaimID == @0 && i.IncurredTypeID == @1", FilterParameters = new object[] { transaction.ClaimID, transaction.IncurredTypeID } });
            if (recoDbGetClaimCurrentPaymentsResult != null && recoDbGetClaimCurrentPaymentsResult.FirstOrDefault() != null) {
                totalPayment = recoDbGetClaimCurrentPaymentsResult.FirstOrDefault().TotalPayment;
            }

            if (recoDbGetClaimCurrentPaymentsResult == null || recoDbGetClaimCurrentPaymentsResult.FirstOrDefault() == null) {
                totalPayment = 0;
            }

            CheckTransactionLimits();

            if (!bProcessPayment)
            {
                return;
            }

            if ((transaction.IncurredCategoryID == getPaymentID && claimlist.MasterFileID == null) || (transaction.IncurredCategoryID == getPaymentID && claimlist.MasterFileID != null && transaction.IncurredTypeID == getIndemnityID))
            {
                var recoDbGetClaimCurrentReservesResult0 = await RecoDb.GetClaimCurrentReserves(new Query() { Filter = $@"i => i.ClaimID == @0 && i.IncurredTypeID == @1", FilterParameters = new object[] { transaction.ClaimID, transaction.IncurredTypeID } });
                getCurrentReserve = recoDbGetClaimCurrentReservesResult0.FirstOrDefault();
            }
            else if ((transaction.IncurredCategoryID == getPaymentID && claimlist.ClaimID != null && transaction.IncurredTypeID != getIndemnityID))
            {
                var recoDbGetClaimCurrentReservesResult01 = await RecoDb.GetClaimCurrentReserves(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claimlist.MasterFileID } });
                getCurrentReserve = recoDbGetClaimCurrentReservesResult01.FirstOrDefault();

                transaction.ClaimID = (int)claimlist.ClaimID;
            }

            if (transaction.IncurredCategoryID == getPaymentID && (getCurrentReserve == null || getCurrentReserve.TotalReserve < (transaction.Amount-transaction.ApplicableDeductible)))
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Insufficient Reserve",Detail = $"There are insufficient reserves for the payment to be processed" });
                return;
            }

            transaction.ID = Guid.NewGuid();

            if (transaction.Firm != null) {
                transaction.FirmID = transaction.Firm.FirmID;
            }

            transaction.Disbursements = null;

            if (bLegalExpense) {
                transaction.Disbursements = transaction.Amount;
            }

            try
            {
                var recoDbCreateTransactionResult = await RecoDb.CreateTransaction(transaction);
                if (transaction.IncurredCategoryID == getPaymentID)
                {
                    var recoDbProcessPaymentsResult = await RecoDb.ProcessPayments(transaction.TransactionID);
                    if (transaction.ApplicableDeductible == null) {
                        transaction.ApplicableDeductible = 0;
                    }

                    if ((transaction.Amount - transaction.ApplicableDeductible) > 0)
                    {
                        SendInvoice();
                    }

                    if (transaction.IncurredCategoryID==getPaymentID && transaction.IncurredTypeID==getIndemnityID)
                    {
                        var recoDbGetFindOpenFilesForRegistrantsResult = await RecoDb.GetFindOpenFilesForRegistrants(transaction.ClaimID);
                        getOpenFileList = recoDbGetFindOpenFilesForRegistrantsResult;

                        if (recoDbGetFindOpenFilesForRegistrantsResult != null)
                        {
                            await SendIndemnityMessage();
                        }
                    }
                }

                var recoDbUpdateJournalEntryNumbersResult = await RecoDb.UpdateJournalEntryNumbers(transaction.TransactionID, $"{serviceprovider.Name}");

                DialogService.Close(transaction);
            }
            catch (System.Exception recoDbCreateTransactionException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable to create new Transaction",Detail = $"{recoDbCreateTransactionException.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task IncurredCategoryIdChange(dynamic args)
        {
            var recoDbGetParametersResult = await RecoDb.GetParameters(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { transaction.IncurredCategoryID } });
            selectedCategory = recoDbGetParametersResult.First();

            var recoDbGetAvailableIncurredTypesResult = await RecoDb.GetAvailableIncurredTypes(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 && i.ParamValue == @1", FilterParameters = new object[] { "Incurred Type", selectedCategory.ParamValue }, OrderBy = $"ParamDesc asc" });
            getAvailableIncurredTypeList = recoDbGetAvailableIncurredTypesResult;
        }

        protected async System.Threading.Tasks.Task IncurredTypeIdChange(dynamic args)
        {
            var recoDbGetParameterByParameterIdResult = await RecoDb.GetParameterByParameterId(transaction.IncurredTypeID);
            incurredTypeDesc = recoDbGetParameterByParameterIdResult.ParamDesc;
        }

        protected async System.Threading.Tasks.Task Checkbox0Change(bool args)
        {
            transaction.Disbursements = null;

            if (bLegalExpense) {
                transaction.Disbursements = transaction.Amount;
            }
        }

        protected async System.Threading.Tasks.Task AmountChange(decimal args)
        {
            transaction.Disbursements = null;

            if (bLegalExpense) {
                transaction.Disbursements = transaction.Amount;
            }
        }

        protected async System.Threading.Tasks.Task FirmIdChange(dynamic args)
        {
            if (Globals.generalsettings.ApplicationName=="REIX CMS")
            {
                var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { Filter = $@"i => i.FirmID == @0", FilterParameters = new object[] { transaction.FirmID } });
                transaction.PayableTo = recoDbGetFirmsResult.First().Name;
            }

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.FirmID == @0", FilterParameters = new object[] { transaction.FirmID }, OrderBy = $"NameandFirm asc" });
            getServiceProviderList = recoDbGetServiceProviderDetailsResult;
        }

        protected async System.Threading.Tasks.Task ButtonNewFirmClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFirm>("Add Firm", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                transaction.FirmID = dialogResult.FirmID;
            }

            if (dialogResult != null)
            {
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.FirmID == @0", FilterParameters = new object[] { transaction.FirmID }, OrderBy = $"Name asc" });
                getServiceProviderList = recoDbGetServiceProviderDetailsResult;

                transaction.ServiceProviderID = null;
            }

            var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmsResult;
        }

        protected async System.Threading.Tasks.Task ServiceProviderIdChange(dynamic args)
        {
            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { args } });
            if (Globals.generalsettings.ApplicationName=="REIX CMS") {
                transaction.PayableTo = recoDbGetServiceProviderDetailsResult.First().NameandFirm;
            }
        }

        protected async System.Threading.Tasks.Task ButtonNewServiceProviderClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddServiceProvider>("Add Service Provider", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                transaction.ServiceProviderID = dialogResult.ServiceProviderID;
            }

            if (dialogResult != null)
            {
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"Name asc" });
                getServiceProviderList = recoDbGetServiceProviderDetailsResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddNotesClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectNote>($"Claim Notes", new Dictionary<string, object>() { {"ClaimID", ClaimID} });
            newRecoMail.Notes = dialogResult;

            Notes = newRecoMail.NoteSubjects();
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data);
        }

        protected async System.Threading.Tasks.Task ButtonDeleteFileClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to remove this file?") == true)
            {
                newRecoMail.ClaimFiles.Remove(data);
            }

            await datagridClaimFiles.Reload();

            Attachments = newRecoMail.Filenames();
        }

        protected async System.Threading.Tasks.Task ButtonAddAttachmentsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectFile>($"Claim Documents", new Dictionary<string, object>() { {"ClaimID", ClaimID} }, new DialogOptions(){ Width = $"{"75%"}",Resizable = true });
            newRecoMail.ClaimFiles = dialogResult;

            Attachments = newRecoMail.Filenames();
        }

        protected async System.Threading.Tasks.Task Button6Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task ButtonRequestIncreaseClick(MouseEventArgs args)
        {
            await SendLimitIncreaseRequest();
        }

        protected async System.Threading.Tasks.Task ButtonResendInvoiceClick(MouseEventArgs args)
        {
                SendInvoice();

            DialogService.Close(transaction);
        }
    }
}
