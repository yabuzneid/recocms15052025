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
    public partial class ClaimReportComponent : ComponentBase, IDisposable
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
        public dynamic ClaimID { get; set; }
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid0;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid1;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid2;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid3;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid5;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid4;
        protected RadzenGrid<RecoCms6.Models.RecoDb.File> gridFiles;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimActivityLog> gridActivityLog;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> gridReports;

        int _intClaimID;
        protected int intClaimID
        {
            get
            {
                return _intClaimID;
            }
            set
            {
                if (!object.Equals(_intClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intClaimID", NewValue = value, OldValue = _intClaimID };
                    _intClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Claim _claim;
        protected RecoCms6.Models.RecoDb.Claim claim
        {
            get
            {
                return _claim;
            }
            set
            {
                if (!object.Equals(_claim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claim", NewValue = value, OldValue = _claim };
                    _claim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.UserDetail _userdetail;
        protected RecoCms6.Models.RecoDb.UserDetail userdetail
        {
            get
            {
                return _userdetail;
            }
            set
            {
                if (!object.Equals(_userdetail, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "userdetail", NewValue = value, OldValue = _userdetail };
                    _userdetail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProvider _serviceprovider;
        protected RecoCms6.Models.RecoDb.ServiceProvider serviceprovider
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

        RecoCms6.Models.RecoDb.ClaimReport _report;
        protected RecoCms6.Models.RecoDb.ClaimReport report
        {
            get
            {
                return _report;
            }
            set
            {
                if (!object.Equals(_report, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "report", NewValue = value, OldValue = _report };
                    _report = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _Insured;
        protected string Insured
        {
            get
            {
                return _Insured;
            }
            set
            {
                if (!object.Equals(_Insured, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Insured", NewValue = value, OldValue = _Insured };
                    _Insured = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _Claimant;
        protected string Claimant
        {
            get
            {
                return _Claimant;
            }
            set
            {
                if (!object.Equals(_Claimant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Claimant", NewValue = value, OldValue = _Claimant };
                    _Claimant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _FileHandler;
        protected string FileHandler
        {
            get
            {
                return _FileHandler;
            }
            set
            {
                if (!object.Equals(_FileHandler, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "FileHandler", NewValue = value, OldValue = _FileHandler };
                    _FileHandler = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _parameterFlags;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> parameterFlags
        {
            get
            {
                return _parameterFlags;
            }
            set
            {
                if (!object.Equals(_parameterFlags, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "parameterFlags", NewValue = value, OldValue = _parameterFlags };
                    _parameterFlags = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ServiceProvider> _defenseCounsels = new List<ServiceProvider>();
        protected List<RecoCms6.Models.RecoDb.ServiceProvider> defenseCounsels
        {
            get
            {
                return _defenseCounsels;
            }
            set
            {
                if (!object.Equals(_defenseCounsels, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "defenseCounsels", NewValue = value, OldValue = _defenseCounsels };
                    _defenseCounsels = value;
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

        int _getClaimReportFileTypeID;
        protected int getClaimReportFileTypeID
        {
            get
            {
                return _getClaimReportFileTypeID;
            }
            set
            {
                if (!object.Equals(_getClaimReportFileTypeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimReportFileTypeID", NewValue = value, OldValue = _getClaimReportFileTypeID };
                    _getClaimReportFileTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.File> _files;
        protected IEnumerable<RecoCms6.Models.RecoDb.File> files
        {
            get
            {
                return _files;
            }
            set
            {
                if (!object.Equals(_files, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "files", NewValue = value, OldValue = _files };
                    _files = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _claimReports;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> claimReports
        {
            get
            {
                return _claimReports;
            }
            set
            {
                if (!object.Equals(_claimReports, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimReports", NewValue = value, OldValue = _claimReports };
                    _claimReports = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousClaimReports;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousClaimReports
        {
            get
            {
                return _previousClaimReports;
            }
            set
            {
                if (!object.Equals(_previousClaimReports, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousClaimReports", NewValue = value, OldValue = _previousClaimReports };
                    _previousClaimReports = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousActionPlans;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousActionPlans
        {
            get
            {
                return _previousActionPlans;
            }
            set
            {
                if (!object.Equals(_previousActionPlans, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousActionPlans", NewValue = value, OldValue = _previousActionPlans };
                    _previousActionPlans = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousFacts;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousFacts
        {
            get
            {
                return _previousFacts;
            }
            set
            {
                if (!object.Equals(_previousFacts, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousFacts", NewValue = value, OldValue = _previousFacts };
                    _previousFacts = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousCoverage;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousCoverage
        {
            get
            {
                return _previousCoverage;
            }
            set
            {
                if (!object.Equals(_previousCoverage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousCoverage", NewValue = value, OldValue = _previousCoverage };
                    _previousCoverage = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousLiability;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousLiability
        {
            get
            {
                return _previousLiability;
            }
            set
            {
                if (!object.Equals(_previousLiability, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousLiability", NewValue = value, OldValue = _previousLiability };
                    _previousLiability = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousDamages;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousDamages
        {
            get
            {
                return _previousDamages;
            }
            set
            {
                if (!object.Equals(_previousDamages, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousDamages", NewValue = value, OldValue = _previousDamages };
                    _previousDamages = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousRecommendations;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> previousRecommendations
        {
            get
            {
                return _previousRecommendations;
            }
            set
            {
                if (!object.Equals(_previousRecommendations, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousRecommendations", NewValue = value, OldValue = _previousRecommendations };
                    _previousRecommendations = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _LegalReserves;
        protected string LegalReserves
        {
            get
            {
                return _LegalReserves;
            }
            set
            {
                if (!object.Equals(_LegalReserves, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "LegalReserves", NewValue = value, OldValue = _LegalReserves };
                    _LegalReserves = value;
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

        bool _rfvExecSummary;
        protected bool rfvExecSummary
        {
            get
            {
                return _rfvExecSummary;
            }
            set
            {
                if (!object.Equals(_rfvExecSummary, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvExecSummary", NewValue = value, OldValue = _rfvExecSummary };
                    _rfvExecSummary = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvFacts;
        protected bool rfvFacts
        {
            get
            {
                return _rfvFacts;
            }
            set
            {
                if (!object.Equals(_rfvFacts, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvFacts", NewValue = value, OldValue = _rfvFacts };
                    _rfvFacts = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvCoverage;
        protected bool rfvCoverage
        {
            get
            {
                return _rfvCoverage;
            }
            set
            {
                if (!object.Equals(_rfvCoverage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvCoverage", NewValue = value, OldValue = _rfvCoverage };
                    _rfvCoverage = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvLiability;
        protected bool rfvLiability
        {
            get
            {
                return _rfvLiability;
            }
            set
            {
                if (!object.Equals(_rfvLiability, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvLiability", NewValue = value, OldValue = _rfvLiability };
                    _rfvLiability = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvDamages;
        protected bool rfvDamages
        {
            get
            {
                return _rfvDamages;
            }
            set
            {
                if (!object.Equals(_rfvDamages, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvDamages", NewValue = value, OldValue = _rfvDamages };
                    _rfvDamages = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvRecommendations;
        protected bool rfvRecommendations
        {
            get
            {
                return _rfvRecommendations;
            }
            set
            {
                if (!object.Equals(_rfvRecommendations, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvRecommendations", NewValue = value, OldValue = _rfvRecommendations };
                    _rfvRecommendations = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvActionPlan;
        protected bool rfvActionPlan
        {
            get
            {
                return _rfvActionPlan;
            }
            set
            {
                if (!object.Equals(_rfvActionPlan, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvActionPlan", NewValue = value, OldValue = _rfvActionPlan };
                    _rfvActionPlan = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvEstimatedExpenses;
        protected bool rfvEstimatedExpenses
        {
            get
            {
                return _rfvEstimatedExpenses;
            }
            set
            {
                if (!object.Equals(_rfvEstimatedExpenses, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvEstimatedExpenses", NewValue = value, OldValue = _rfvEstimatedExpenses };
                    _rfvEstimatedExpenses = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvEstimatedIndmenity;
        protected bool rfvEstimatedIndmenity
        {
            get
            {
                return _rfvEstimatedIndmenity;
            }
            set
            {
                if (!object.Equals(_rfvEstimatedIndmenity, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvEstimatedIndmenity", NewValue = value, OldValue = _rfvEstimatedIndmenity };
                    _rfvEstimatedIndmenity = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvDamagesClaimed;
        protected bool rfvDamagesClaimed
        {
            get
            {
                return _rfvDamagesClaimed;
            }
            set
            {
                if (!object.Equals(_rfvDamagesClaimed, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvDamagesClaimed", NewValue = value, OldValue = _rfvDamagesClaimed };
                    _rfvDamagesClaimed = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvSubrogation;
        protected bool rfvSubrogation
        {
            get
            {
                return _rfvSubrogation;
            }
            set
            {
                if (!object.Equals(_rfvSubrogation, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvSubrogation", NewValue = value, OldValue = _rfvSubrogation };
                    _rfvSubrogation = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvSettlement;
        protected bool rfvSettlement
        {
            get
            {
                return _rfvSettlement;
            }
            set
            {
                if (!object.Equals(_rfvSettlement, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvSettlement", NewValue = value, OldValue = _rfvSettlement };
                    _rfvSettlement = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _saveResult;
        protected bool saveResult
        {
            get
            {
                return _saveResult;
            }
            set
            {
                if (!object.Equals(_saveResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "saveResult", NewValue = value, OldValue = _saveResult };
                    _saveResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimActivityLog> _activityLog;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimActivityLog> activityLog
        {
            get
            {
                return _activityLog;
            }
            set
            {
                if (!object.Equals(_activityLog, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "activityLog", NewValue = value, OldValue = _activityLog };
                    _activityLog = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _IsSubmitEvent;
        protected bool IsSubmitEvent
        {
            get
            {
                return _IsSubmitEvent;
            }
            set
            {
                if (!object.Equals(_IsSubmitEvent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "IsSubmitEvent", NewValue = value, OldValue = _IsSubmitEvent };
                    _IsSubmitEvent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            //await Security.InitializeAsync(AuthenticationStateProvider);
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
            intClaimID = StringExtensions.IntegerFromBase64(ClaimID);

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID } });
            claim = recoDbGetClaimsResult.FirstOrDefault();

            if (Globals.gblCurrentClaim == null)
            {
                var recoDbGetClaimListsResult = await RecoDb.GetClaimLists(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                Globals.gblCurrentClaim = recoDbGetClaimListsResult.FirstOrDefault();
            }

            var recoDbGetUsersResult = await RecoDb.GetUserDetails(new Query { Filter = $@"i=> i.UserName == @0", FilterParameters = new object[] { Security.Principal.Identity.Name } });
            userdetail = recoDbGetUsersResult.FirstOrDefault();

            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { userdetail.Id } });
            serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();

            report = await getClaimReport(claim.ClaimID);

            report.ClaimID = claim.ClaimID;

            if (Insured==null || Insured == String.Empty) {
                Insured = Globals.gblCurrentClaim.Insured1;
            }

            if (Claimant == null || Claimant == String.Empty) {
                Claimant = Globals.gblCurrentClaim.Claimant1;
            }

            if (FileHandler == null || FileHandler == String.Empty) {
                FileHandler = Globals.gblCurrentClaim.FileHandler;
            }

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Claim Report Flag", "ProgramID", "File Type" }, OrderBy = $"ParamDesc asc" });
            parameterFlags = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claim Report Flag");

            var defenseCounselsResult = await RecoDb.GetServiceProviders(new Query()
            {
                Filter = "i => @0.Contains(i.ServiceProviderID)",
                FilterParameters = [serviceprovider.AsLegalAssistant
                .Select(la => la.DefenseCounselID)
                .Distinct()
                .ToList()]
            });

            defenseCounsels = [.. defenseCounselsResult];

            isEOProgram = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="EO").First().ParameterID == claim.ProgramID;

            getClaimReportFileTypeID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamDesc=="Claim Report" && p.ParamTypeDesc=="File Type").ParameterID;

            var recoDbGetFilesResult = await RecoDb.GetFiles(new Query() { Filter = $@"i => i.ClaimID == @0 && i.VisibleToCounsel == @1", FilterParameters = new object[] { claim.ClaimID, true }, OrderBy = $"EntryDate desc" });
            files = recoDbGetFilesResult;

            var recoDbGetClaimReportDetailsResult = await RecoDb.GetClaimReportDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.FirmType == @1", FilterParameters = new object[] { claim.ClaimID, "Defense Counsel" }, OrderBy = $"DateCreated desc" });
            claimReports = recoDbGetClaimReportDetailsResult;

            previousClaimReports = recoDbGetClaimReportDetailsResult.Where(cr=>cr.DateSubmitted != null);

            previousActionPlans = previousClaimReports.Where(cr=>cr.ActionPlan != null && cr.ActionPlan != string.Empty);

            previousFacts = previousClaimReports.Where(cr=>cr.Facts != null && cr.Facts != string.Empty);

            previousCoverage = previousClaimReports.Where(cr=>cr.Coverage != null && cr.Coverage != string.Empty);

            previousLiability = previousClaimReports.Where(cr=>cr.Liability != null && cr.Liability != string.Empty);

            previousDamages = previousClaimReports.Where(cr=>cr.Damages != null && cr.Damages != string.Empty);

            previousRecommendations = previousClaimReports.Where(cr=>cr.Recommendations != null && cr.Recommendations != string.Empty);

            report = await getClaimReport(claim.ClaimID);

            var recoDbGetClaimCurrentReservesResult = await RecoDb.GetClaimCurrentReserves(new Query() { Filter = $@"i => i.IncurredType == @0 && i.ClaimID == @1", FilterParameters = new object[] { "Legal", claim.ClaimID } });
            if (recoDbGetClaimCurrentReservesResult.FirstOrDefault() != null && recoDbGetClaimCurrentReservesResult.FirstOrDefault().TotalReserve != null) {
                LegalReserves = string.Format("{0:C}",recoDbGetClaimCurrentReservesResult.FirstOrDefault().TotalReserve);
            }

            docExtensions = new List<string> {".pdf",".xls",".xlsx",".doc",".docx"};

            imageExtensions = new List<string>{".png",".jpeg",".jpg",".gif"};

            avExtensions = new List<string> {".avi",".mov",".mp4",".mp3",".m4a",".wav"};

            rfvExecSummary = false;

            rfvFacts = false;

            rfvCoverage = false;

            rfvLiability = false;

            rfvDamages = false;

            rfvRecommendations = false;

            rfvActionPlan = false;

            rfvEstimatedExpenses = false;

            rfvEstimatedIndmenity = false;

            rfvDamagesClaimed = false;

            rfvSubrogation = false;

            rfvSettlement = false;

            saveResult = false;

            var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            activityLog = recoDbGetClaimActivityLogsResult;

            SetPreference();
        }

        protected async System.Threading.Tasks.Task FormReportInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            await ShowFormErrors(args);
        }

        protected async System.Threading.Tasks.Task FormReportSubmit(RecoCms6.Models.RecoDb.ClaimReport args)
        {
            await ShowBusyDialog();
        }

        protected async System.Threading.Tasks.Task BtnAttachToClaimClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFile>($"Add Document", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} });
            await gridFiles.Reload();
        }

        protected async System.Threading.Tasks.Task ButtonDownloadFileClick(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data.FileID);
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data.FileID);
        }

        protected async System.Threading.Tasks.Task ButtonSaveClick(MouseEventArgs args)
        {
            IsSubmitEvent = false;
        }

        protected async System.Threading.Tasks.Task ButtonSubmitClick(MouseEventArgs args)
        {
            IsSubmitEvent = true;
        }
    }
}
