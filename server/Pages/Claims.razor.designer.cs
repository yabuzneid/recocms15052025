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
    public partial class ClaimsComponent : ComponentBase, IDisposable
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
        public dynamic ProgramID { get; set; }

        [Parameter]
        public dynamic ExcludeClaimID { get; set; }

        [Parameter]
        public dynamic SelectClaim { get; set; }
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimSearchList> datagrid0;

        bool _isLoading;
        protected bool isLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (!object.Equals(_isLoading, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isLoading", NewValue = value, OldValue = _isLoading };
                    _isLoading = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _excludedClaimID;
        protected int excludedClaimID
        {
            get
            {
                return _excludedClaimID;
            }
            set
            {
                if (!object.Equals(_excludedClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "excludedClaimID", NewValue = value, OldValue = _excludedClaimID };
                    _excludedClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getDefenseCounselList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getDefenseCounselList
        {
            get
            {
                return _getDefenseCounselList;
            }
            set
            {
                if (!object.Equals(_getDefenseCounselList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDefenseCounselList", NewValue = value, OldValue = _getDefenseCounselList };
                    _getDefenseCounselList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getFileHandlerList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getFileHandlerList
        {
            get
            {
                return _getFileHandlerList;
            }
            set
            {
                if (!object.Equals(_getFileHandlerList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFileHandlerList", NewValue = value, OldValue = _getFileHandlerList };
                    _getFileHandlerList = value;
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

        int _getEOProgramID;
        protected int getEOProgramID
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

        System.Collections.Generic.HashSet<int> _excludedIDs;
        protected System.Collections.Generic.HashSet<int> excludedIDs
        {
            get
            {
                return _excludedIDs;
            }
            set
            {
                if (!object.Equals(_excludedIDs, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "excludedIDs", NewValue = value, OldValue = _excludedIDs };
                    _excludedIDs = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimSearchList> _getClaimListsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimSearchList> getClaimListsResult
        {
            get
            {
                return _getClaimListsResult;
            }
            set
            {
                if (!object.Equals(_getClaimListsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimListsResult", NewValue = value, OldValue = _getClaimListsResult };
                    _getClaimListsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProgramList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProgramList
        {
            get
            {
                return _getProgramList;
            }
            set
            {
                if (!object.Equals(_getProgramList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgramList", NewValue = value, OldValue = _getProgramList };
                    _getProgramList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _filterStatus;
        protected int filterStatus
        {
            get
            {
                return _filterStatus;
            }
            set
            {
                if (!object.Equals(_filterStatus, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "filterStatus", NewValue = value, OldValue = _filterStatus };
                    _filterStatus = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _filterBrokerageOnly;
        protected int filterBrokerageOnly
        {
            get
            {
                return _filterBrokerageOnly;
            }
            set
            {
                if (!object.Equals(_filterBrokerageOnly, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "filterBrokerageOnly", NewValue = value, OldValue = _filterBrokerageOnly };
                    _filterBrokerageOnly = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _filterParties;
        protected bool filterParties
        {
            get
            {
                return _filterParties;
            }
            set
            {
                if (!object.Equals(_filterParties, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "filterParties", NewValue = value, OldValue = _filterParties };
                    _filterParties = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _filterCoverageIssue;
        protected bool filterCoverageIssue
        {
            get
            {
                return _filterCoverageIssue;
            }
            set
            {
                if (!object.Equals(_filterCoverageIssue, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "filterCoverageIssue", NewValue = value, OldValue = _filterCoverageIssue };
                    _filterCoverageIssue = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedClaimID;
        protected int selectedClaimID
        {
            get
            {
                return _selectedClaimID;
            }
            set
            {
                if (!object.Equals(_selectedClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedClaimID", NewValue = value, OldValue = _selectedClaimID };
                    _selectedClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _selectedDefenseCounsel;
        protected string selectedDefenseCounsel
        {
            get
            {
                return _selectedDefenseCounsel;
            }
            set
            {
                if (!object.Equals(_selectedDefenseCounsel, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedDefenseCounsel", NewValue = value, OldValue = _selectedDefenseCounsel };
                    _selectedDefenseCounsel = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimList _selectedClaim;
        protected RecoCms6.Models.RecoDb.ClaimList selectedClaim
        {
            get
            {
                return _selectedClaim;
            }
            set
            {
                if (!object.Equals(_selectedClaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedClaim", NewValue = value, OldValue = _selectedClaim };
                    _selectedClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getStatusList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getStatusList
        {
            get
            {
                return _getStatusList;
            }
            set
            {
                if (!object.Equals(_getStatusList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStatusList", NewValue = value, OldValue = _getStatusList };
                    _getStatusList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _PageSizes;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> PageSizes
        {
            get
            {
                return _PageSizes;
            }
            set
            {
                if (!object.Equals(_PageSizes, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "PageSizes", NewValue = value, OldValue = _PageSizes };
                    _PageSizes = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _pagesize;
        protected int pagesize
        {
            get
            {
                return _pagesize;
            }
            set
            {
                if (!object.Equals(_pagesize, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "pagesize", NewValue = value, OldValue = _pagesize };
                    _pagesize = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _Parameters;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> Parameters
        {
            get
            {
                return _Parameters;
            }
            set
            {
                if (!object.Equals(_Parameters, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Parameters", NewValue = value, OldValue = _Parameters };
                    _Parameters = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bAuto;
        protected bool bAuto
        {
            get
            {
                return _bAuto;
            }
            set
            {
                if (!object.Equals(_bAuto, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bAuto", NewValue = value, OldValue = _bAuto };
                    _bAuto = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getBrokerageOnlyList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getBrokerageOnlyList
        {
            get
            {
                return _getBrokerageOnlyList;
            }
            set
            {
                if (!object.Equals(_getBrokerageOnlyList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBrokerageOnlyList", NewValue = value, OldValue = _getBrokerageOnlyList };
                    _getBrokerageOnlyList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimOrIncidentList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getClaimOrIncidentList
        {
            get
            {
                return _getClaimOrIncidentList;
            }
            set
            {
                if (!object.Equals(_getClaimOrIncidentList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimOrIncidentList", NewValue = value, OldValue = _getClaimOrIncidentList };
                    _getClaimOrIncidentList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _showNewClaimButtons;
        protected bool showNewClaimButtons
        {
            get
            {
                return _showNewClaimButtons;
            }
            set
            {
                if (!object.Equals(_showNewClaimButtons, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "showNewClaimButtons", NewValue = value, OldValue = _showNewClaimButtons };
                    _showNewClaimButtons = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _randomParam;
        protected string randomParam
        {
            get
            {
                return _randomParam;
            }
            set
            {
                if (!object.Equals(_randomParam, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "randomParam", NewValue = value, OldValue = _randomParam };
                    _randomParam = value;
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
            isLoading = true;

            if (ExcludeClaimID == null) {
                excludedClaimID = 0;
            }

            if (ExcludeClaimID != null) {
                excludedClaimID = Int32.Parse(ExcludeClaimID.ToString());
            }

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails();
            getDefenseCounselList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FirmType=="Defense Counsel");

            getFileHandlerList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FirmType=="Adjusters" || sp.FirmType=="Managing General Agent");

            serviceprovider = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.UserID == Security.User.Id).FirstOrDefault();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 && i.ParamDesc == @1", FilterParameters = new object[] { "ProgramID", "Errors And Omissions" } });
            getEOProgramID = recoDbGetParameterDetailsResult.FirstOrDefault().ParameterID;

            if (ProgramID == null && Globals.selectedProgramID==0) {
                Globals.selectedProgramID = getEOProgramID;
            }

            if (ProgramID != null) {
                Globals.selectedProgramID = ProgramID;
            }

            var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { excludedClaimID }, OrderBy = $"XRefClaimID asc" });
            excludedIDs = new HashSet<int>(recoDbGetXRefClaimsResult.Select(p => p.XRefClaimID));

            if (!Security.IsInRole("Defense Counsel", "Legal Assistants") && 1==0)
            {
                var recoDbGetClaimSearchListsResult = await RecoDb.GetClaimSearchLists(new Query() { Filter = $@"i => i.ClaimID != @0", FilterParameters = new object[] { excludedClaimID }, OrderBy = $"ContractYearID desc,ClaimNo desc" });
                getClaimListsResult = recoDbGetClaimSearchListsResult.Where(c=> c.ProgramID == Globals.selectedProgramID && !excludedIDs.Contains(c.ClaimID));
            }

            if (Security.IsInRole("Defense Counsel") && 1==0)
            {
                var recoDbGetClaimSearchListsResult0 = await RecoDb.GetClaimSearchLists(new Query() { Filter = $@"i => i.DefenseCounselID == @0", FilterParameters = new object[] { serviceprovider.ServiceProviderID }, OrderBy = $"ClaimNo desc" });
                getClaimListsResult = recoDbGetClaimSearchListsResult0.Where(c=> c.ProgramID == Globals.selectedProgramID);
            }

            var recoDbGetParameterDetailsResult0 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParamValue asc" });
            getProgramList = recoDbGetParameterDetailsResult0;

            filterStatus = 0;

            filterParties = true;

            filterCoverageIssue = false;

            search = "";

            selectedClaimID = 0;

            selectedDefenseCounsel = "";

            selectedClaim = new RecoCms6.Models.RecoDb.ClaimList();

            var recoDbGetParameterDetailsResult01 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "Page Size", "Claim Status" }, OrderBy = $"ParamDesc asc" });
            getStatusList = recoDbGetParameterDetailsResult01.Where(p=>p.ParamTypeDesc=="Claim Status");

            PageSizes = recoDbGetParameterDetailsResult01.Where(p=>p.ParamTypeDesc=="Page Size");

            pagesize = 25;

            if (SelectClaim == true) {
                pagesize = 5;
            }

            var recoDbGetParameterDetailsResult012 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamDesc == @1", FilterParameters = new object[] { "Province", "Canada" } });
            Globals.defaultProvinceID = recoDbGetParameterDetailsResult012.First(pd=>pd.ParamTypeDesc=="Province" && pd.ParamValue==1).ParameterID;

            Globals.defaultCountryID = recoDbGetParameterDetailsResult012.First(pd=>pd.ParamDesc=="Canada").ParameterID;

            isLoading = false;

            var recoDbGetParameterDetailsResult0123 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "BrokerageOnly", "Claim Status" }, OrderBy = $"ParamDesc asc" });
            Parameters = recoDbGetParameterDetailsResult0123;

            bAuto = true;

            var recoDbGetParameterDetailsResult01234 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "BrokerageOnly" }, OrderBy = $"ParamDesc asc" });
            getBrokerageOnlyList = recoDbGetParameterDetailsResult01234;

            var recoDbGetParameterDetailsResult012345 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ClaimOrIncident" }, OrderBy = $"ParamDesc asc" });
            getClaimOrIncidentList = recoDbGetParameterDetailsResult012345;

            showNewClaimButtons = false;

            if (SelectClaim == null && !Security.IsInRole("Auditor") && !Security.IsInRole("Defense Counsel", "Legal Assistants") && Globals.generalsettings.ApplicationName == "RECO CMS" && !Security.IsInRole("Actuary")) {
                showNewClaimButtons = true;
            }

            await TxtSearchChanged(false);
        }

        protected async System.Threading.Tasks.Task TxtSearchChange(string args)
        {
            await TxtSearchChanged(false);
        }

        protected async System.Threading.Tasks.Task DropdownStatusFilterChange(dynamic args)
        {
            filterStatus = args;

            await SelectBarStatusChanged((int)args);
        }

        protected async System.Threading.Tasks.Task DropdownChangeFilter2Change(dynamic args)
        {
            try
            {
                dropdownClaimOrIncident.Value = (int)args;
            }
            catch
            {
                dropdownClaimOrIncident.Value = null;
            }
            await TxtSearchChange($"{false}");
        }

        protected async System.Threading.Tasks.Task DropdownChangeProgramFilterChange(dynamic args)
        {
            await TxtSearchChange($"{false}");
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            try
            {
                UriHelper.NavigateTo("/add-claim");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            await datagrid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonAddCommissionClaimClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo("/add-commission-claim");
        }

        protected async System.Threading.Tasks.Task DropdownBrokerageOnlyChange(dynamic args)
        {
            if (args is int intArg)
                await SelectBarBrokerageOnlyChanged(intArg);
        }

        protected async System.Threading.Tasks.Task ChkCoverageIssueChange(bool args)
        {
            await ChkCoverageIssueChangeAlt(args);
        }

        protected async System.Threading.Tasks.Task DropdownClaimOrIncidentChange(dynamic args)
        {
            await SelectBarClaimOrIncidentChanged(args.ParamValue);
        }

        protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
        {
            await datagrid0.Reload();
        }

        protected async System.Threading.Tasks.Task Datagrid0RowSelect(RecoCms6.Models.RecoDb.ClaimSearchList args)
        {
            if (SelectClaim == null) {
                isLoading = true;
            }

            selectedClaimID = args.ClaimID;

            if (SelectClaim == null)
            {
                var recoDbGetClaimListsResult = await RecoDb.GetClaimLists(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { args.ClaimID } });
                Globals.gblCurrentClaim = recoDbGetClaimListsResult.First();
            }

            randomParam = String.Empty;

            GenerateRndParameter();

            if (SelectClaim == null && !Security.IsInRole("Defense Counsel", "Legal Assistants") && args.Program=="Errors And Omissions")
            {
                UriHelper.NavigateTo($"edit-claim/{args.ClaimID.ToBase64()}");
            }

            if (SelectClaim == null && Security.IsInRole("Defense Counsel", "Legal Assistants"))
            {
                UriHelper.NavigateTo($"claim-report/{args.ClaimID.ToBase64()}");
            }

            if (SelectClaim == null && !Security.IsInRole("Defense Counsel", "Legal Assistants") && args.Program != "Errors And Omissions")
            {
                UriHelper.NavigateTo($"edit-commission-claim/{args.ClaimID.ToBase64()}");
            }
        }

        protected async System.Threading.Tasks.Task ButtonSelectClaimClick(MouseEventArgs args)
        {
            if (selectedClaimID == 0)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"No Claim Selected",Detail = $"Please Select a Claim First" });
            }

            if (selectedClaimID > 0) {
              DialogService.Close(selectedClaimID);
            }
        }

        protected async System.Threading.Tasks.Task ButtonCancelSelectClick(MouseEventArgs args)
        {
            DialogService.Close(selectedClaimID);
        }
    }
}
