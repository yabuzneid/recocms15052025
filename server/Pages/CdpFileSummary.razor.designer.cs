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
    public partial class CdpFileSummaryComponent : ComponentBase, IDisposable
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
        public dynamic EditMode { get; set; }

        [Parameter]
        public dynamic ClaimID { get; set; }
        protected RadzenGrid<RecoCms6.Models.RecoDb.XRefClaim> gridCrossRefFiles;
        protected RadzenGrid<RecoCms6.Models.RecoDb.CommissionInstallment> gridCommissionInstallments;
        protected RadzenGrid<RecoCms6.Models.RecoDb.XRefClaim> grid0;
        protected RadzenGrid<RecoCms6.Models.RecoDb.CommissionInstallment> grid1;

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

        string _title;
        protected string title
        {
            get
            {
                return _title;
            }
            set
            {
                if (!object.Equals(_title, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "title", NewValue = value, OldValue = _title };
                    _title = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal? _indemnityReserves;
        protected decimal? indemnityReserves
        {
            get
            {
                return _indemnityReserves;
            }
            set
            {
                if (!object.Equals(_indemnityReserves, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "indemnityReserves", NewValue = value, OldValue = _indemnityReserves };
                    _indemnityReserves = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Trade _trade;
        protected RecoCms6.Models.RecoDb.Trade trade
        {
            get
            {
                return _trade;
            }
            set
            {
                if (!object.Equals(_trade, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "trade", NewValue = value, OldValue = _trade };
                    _trade = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _newtrade;
        protected bool newtrade
        {
            get
            {
                return _newtrade;
            }
            set
            {
                if (!object.Equals(_newtrade, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newtrade", NewValue = value, OldValue = _newtrade };
                    _newtrade = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Claimant _claimant;
        protected RecoCms6.Models.RecoDb.Claimant claimant
        {
            get
            {
                return _claimant;
            }
            set
            {
                if (!object.Equals(_claimant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimant", NewValue = value, OldValue = _claimant };
                    _claimant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _newclaimant;
        protected bool newclaimant
        {
            get
            {
                return _newclaimant;
            }
            set
            {
                if (!object.Equals(_newclaimant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newclaimant", NewValue = value, OldValue = _newclaimant };
                    _newclaimant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _parameterList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> parameterList
        {
            get
            {
                return _parameterList;
            }
            set
            {
                if (!object.Equals(_parameterList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "parameterList", NewValue = value, OldValue = _parameterList };
                    _parameterList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimInitiationList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getClaimInitiationList
        {
            get
            {
                return _getClaimInitiationList;
            }
            set
            {
                if (!object.Equals(_getClaimInitiationList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimInitiationList", NewValue = value, OldValue = _getClaimInitiationList };
                    _getClaimInitiationList = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getFileOutcomeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getFileOutcomeList
        {
            get
            {
                return _getFileOutcomeList;
            }
            set
            {
                if (!object.Equals(_getFileOutcomeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFileOutcomeList", NewValue = value, OldValue = _getFileOutcomeList };
                    _getFileOutcomeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getRECOComplaintOutcomeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getRECOComplaintOutcomeList
        {
            get
            {
                return _getRECOComplaintOutcomeList;
            }
            set
            {
                if (!object.Equals(_getRECOComplaintOutcomeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRECOComplaintOutcomeList", NewValue = value, OldValue = _getRECOComplaintOutcomeList };
                    _getRECOComplaintOutcomeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getTradeTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getTradeTypeList
        {
            get
            {
                return _getTradeTypeList;
            }
            set
            {
                if (!object.Equals(_getTradeTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTradeTypeList", NewValue = value, OldValue = _getTradeTypeList };
                    _getTradeTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getDeductibleList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getDeductibleList
        {
            get
            {
                return _getDeductibleList;
            }
            set
            {
                if (!object.Equals(_getDeductibleList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeductibleList", NewValue = value, OldValue = _getDeductibleList };
                    _getDeductibleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getFirstDemandFormList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getFirstDemandFormList
        {
            get
            {
                return _getFirstDemandFormList;
            }
            set
            {
                if (!object.Equals(_getFirstDemandFormList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFirstDemandFormList", NewValue = value, OldValue = _getFirstDemandFormList };
                    _getFirstDemandFormList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getLitigationRoleList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getLitigationRoleList
        {
            get
            {
                return _getLitigationRoleList;
            }
            set
            {
                if (!object.Equals(_getLitigationRoleList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLitigationRoleList", NewValue = value, OldValue = _getLitigationRoleList };
                    _getLitigationRoleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getYesNoNAList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getYesNoNAList
        {
            get
            {
                return _getYesNoNAList;
            }
            set
            {
                if (!object.Equals(_getYesNoNAList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getYesNoNAList", NewValue = value, OldValue = _getYesNoNAList };
                    _getYesNoNAList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getInsuredRole;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getInsuredRole
        {
            get
            {
                return _getInsuredRole;
            }
            set
            {
                if (!object.Equals(_getInsuredRole, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInsuredRole", NewValue = value, OldValue = _getInsuredRole };
                    _getInsuredRole = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimantTransactionRoleList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getClaimantTransactionRoleList
        {
            get
            {
                return _getClaimantTransactionRoleList;
            }
            set
            {
                if (!object.Equals(_getClaimantTransactionRoleList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimantTransactionRoleList", NewValue = value, OldValue = _getClaimantTransactionRoleList };
                    _getClaimantTransactionRoleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isEdit;
        protected bool isEdit
        {
            get
            {
                return _isEdit;
            }
            set
            {
                if (!object.Equals(_isEdit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isEdit", NewValue = value, OldValue = _isEdit };
                    _isEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.XRefClaim> _getXRefClaimsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.XRefClaim> getXRefClaimsList
        {
            get
            {
                return _getXRefClaimsList;
            }
            set
            {
                if (!object.Equals(_getXRefClaimsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getXRefClaimsList", NewValue = value, OldValue = _getXRefClaimsList };
                    _getXRefClaimsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimLitigationDate> _getClaimLitigationDatesList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimLitigationDate> getClaimLitigationDatesList
        {
            get
            {
                return _getClaimLitigationDatesList;
            }
            set
            {
                if (!object.Equals(_getClaimLitigationDatesList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimLitigationDatesList", NewValue = value, OldValue = _getClaimLitigationDatesList };
                    _getClaimLitigationDatesList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.CostAward> _getCostAwardsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.CostAward> getCostAwardsList
        {
            get
            {
                return _getCostAwardsList;
            }
            set
            {
                if (!object.Equals(_getCostAwardsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCostAwardsList", NewValue = value, OldValue = _getCostAwardsList };
                    _getCostAwardsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Occurrence _occurrence;
        protected RecoCms6.Models.RecoDb.Occurrence occurrence
        {
            get
            {
                return _occurrence;
            }
            set
            {
                if (!object.Equals(_occurrence, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "occurrence", NewValue = value, OldValue = _occurrence };
                    _occurrence = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Brokerage> _getBrokerageList;
        protected IEnumerable<RecoCms6.Models.RecoDb.Brokerage> getBrokerageList
        {
            get
            {
                return _getBrokerageList;
            }
            set
            {
                if (!object.Equals(_getBrokerageList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBrokerageList", NewValue = value, OldValue = _getBrokerageList };
                    _getBrokerageList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.CdpClaimDetail _claimdetails;
        protected RecoCms6.Models.RecoDb.CdpClaimDetail claimdetails
        {
            get
            {
                return _claimdetails;
            }
            set
            {
                if (!object.Equals(_claimdetails, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimdetails", NewValue = value, OldValue = _claimdetails };
                    _claimdetails = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.CommissionInstallment> _getCommissionInstallments;
        protected IEnumerable<RecoCms6.Models.RecoDb.CommissionInstallment> getCommissionInstallments
        {
            get
            {
                return _getCommissionInstallments;
            }
            set
            {
                if (!object.Equals(_getCommissionInstallments, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommissionInstallments", NewValue = value, OldValue = _getCommissionInstallments };
                    _getCommissionInstallments = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _strXRefClaimID;
        protected string strXRefClaimID
        {
            get
            {
                return _strXRefClaimID;
            }
            set
            {
                if (!object.Equals(_strXRefClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "strXRefClaimID", NewValue = value, OldValue = _strXRefClaimID };
                    _strXRefClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.CrossReferencedClaim _crossRefClaim;
        protected RecoCms6.Models.RecoDb.CrossReferencedClaim crossRefClaim
        {
            get
            {
                return _crossRefClaim;
            }
            set
            {
                if (!object.Equals(_crossRefClaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "crossRefClaim", NewValue = value, OldValue = _crossRefClaim };
                    _crossRefClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _tradeIsDirty;
        protected bool tradeIsDirty
        {
            get
            {
                return _tradeIsDirty;
            }
            set
            {
                if (!object.Equals(_tradeIsDirty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tradeIsDirty", NewValue = value, OldValue = _tradeIsDirty };
                    _tradeIsDirty = value;
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
            intClaimID = StringExtensions.IntegerFromBase64(ClaimID);

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID } });
            claim = recoDbGetClaimsResult.First();

            title = String.Concat("File Summary - ",claim.ClaimNo);

            var recoDbGetClaimCurrentReservesResult = await RecoDb.GetClaimCurrentReserves(new Query() { Filter = $@"i => i.ClaimID == @0 && i.IncurredType == @1", FilterParameters = new object[] { claim.ClaimID, "Indemnity" } });
            if (recoDbGetClaimCurrentReservesResult.FirstOrDefault() != null) {
                indemnityReserves = recoDbGetClaimCurrentReservesResult.FirstOrDefault().TotalReserve;
            }

            if (recoDbGetClaimCurrentReservesResult.FirstOrDefault() == null) {
                indemnityReserves = Convert.ToDecimal(0.00);
            }

            var recoDbGetTradesResult = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"DisplayOrder asc" });
            trade = recoDbGetTradesResult.FirstOrDefault();

            newtrade = trade == null;

            if (trade == null) {
                trade = new Trade();
            }

            var recoDbGetClaimantsResult = await RecoDb.GetClaimants(new Query() { Filter = $@"i => i.ClaimID == @0 && i.ClaimantOrder == @1", FilterParameters = new object[] { claim.ClaimID, 1 } });
            claimant = recoDbGetClaimantsResult.FirstOrDefault();

            newclaimant = claimant== null;

            if (claimant == null) {
                claimant = new Claimant();
            }

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails();
            parameterList = recoDbGetParameterDetailsResult;

            getClaimInitiationList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Claim Initiation");

            PageSizes = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Page Size").OrderBy(p=>p.ParamValue);

            getFileOutcomeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="File Outcome");

            getRECOComplaintOutcomeList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="RECO Complaint Outcome");

            getTradeTypeList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Trade Type");

            getDeductibleList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Deductible");

            getFirstDemandFormList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="First Demand Form");

            getLitigationRoleList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Litigation Role");

            getYesNoNAList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="YesNoNA");

            getInsuredRole = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Insured Transaction Role");

            getClaimantTransactionRoleList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Claimant Transaction Role" && pd.ParamValue==claim.ProgramID);

            isEdit = bool.Parse(EditMode.ToString());



            var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"XRefClaimNo asc" });
            getXRefClaimsList = recoDbGetXRefClaimsResult;

            var recoDbGetClaimLitigationDatesResult = await RecoDb.GetClaimLitigationDates(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"LitigationDate desc" });
            getClaimLitigationDatesList = recoDbGetClaimLitigationDatesResult;

            var recoDbGetCostAwardsResult = await RecoDb.GetCostAwards(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"CostAwardDate desc" });
            getCostAwardsList = recoDbGetCostAwardsResult;

            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { claim.OccurrenceID } });
            occurrence = recoDbGetOccurrencesResult.FirstOrDefault();

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokerageList = recoDbGetBrokeragesResult;

            var recoDbGetCdpClaimDetailsResult = await RecoDb.GetCdpClaimDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            claimdetails = recoDbGetCdpClaimDetailsResult.FirstOrDefault();

            var recoDbGetCommissionInstallmentsResult = await RecoDb.GetCommissionInstallments(new Query() { Filter = $@"i => i.TradeID == @0", FilterParameters = new object[] { trade.TradeID }, OrderBy = $"DatePaid desc" });
            getCommissionInstallments = recoDbGetCommissionInstallmentsResult;
        }

        protected async System.Threading.Tasks.Task ButtonViewClaim1Click(MouseEventArgs args, dynamic data)
        {
            strXRefClaimID = StringExtensions.ToBase64(data.XRefClaimID);

            UriHelper.NavigateTo($"edit-claim/{strXRefClaimID}", /* force reload */ true);
        }

        protected async System.Threading.Tasks.Task ButtonDeleteCrossRef1Click(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbRemoveCrossReferencesResult = await RecoDb.RemoveCrossReferences(claim.ClaimID, data.XRefClaimID);

            }

            await gridCrossRefFiles.Reload();
        }

        protected async System.Threading.Tasks.Task ButtonAddCrossReferenceClaimsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>("Claims", new Dictionary<string, object>() { {"ProgramID", claim.ProgramID}, {"ExcludeClaimID", intClaimID}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{"90%"}",Height = $"{"80%"}" });
            if (dialogResult != null && dialogResult != 0) {
                crossRefClaim = new RecoCms6.Models.RecoDb.CrossReferencedClaim();
            }

            if (dialogResult != null && dialogResult != 0) {
                crossRefClaim.ClaimID = claim.ClaimID;
            }

            if (dialogResult != null && dialogResult != 0) {
                crossRefClaim.XRefClaimID = dialogResult;
            }

            if (dialogResult != null && dialogResult != 0)
            {
                var recoDbCreateCrossReferencedClaimResult = await RecoDb.CreateCrossReferencedClaim(crossRefClaim);
                var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"XRefClaimNo asc" });
                getXRefClaimsList = recoDbGetXRefClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task CommissionPercentageChange(double? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CommissionGrossChange(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric3Change(double? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric4Change(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Checkbox1Change(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task GridCommissionInstallmentsRowSelect(RecoCms6.Models.RecoDb.CommissionInstallment args)
        {
            var dialogResult = await DialogService.OpenAsync<EditCommissionInstallment>("Edit Commission Installment", new Dictionary<string, object>() { {"CommissionInstallmentID", args.CommissionInstallmentID} });
            await gridCommissionInstallments.Reload();

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task ButtonAddInstallmentClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddCommissionInstallment>("Add Commission Installment", new Dictionary<string, object>() { {"TradeID", trade.TradeID} });
            var recoDbGetCommissionInstallmentsResult = await RecoDb.GetCommissionInstallments(new Query() { Filter = $@"i => i.TradeID == @0", FilterParameters = new object[] { trade.TradeID }, OrderBy = $"DatePaid desc" });
            getCommissionInstallments = recoDbGetCommissionInstallmentsResult;
        }

        protected async System.Threading.Tasks.Task ButtonViewClaimClick(MouseEventArgs args, dynamic data)
        {
            strXRefClaimID = StringExtensions.ToBase64(data.XRefClaimID);

            UriHelper.NavigateTo($"edit-claim/{strXRefClaimID}", /* force reload */ true);
        }

        protected async System.Threading.Tasks.Task ButtonDeleteCrossRefClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbRemoveCrossReferencesResult = await RecoDb.RemoveCrossReferences(claim.ClaimID, data.XRefClaimID);

            }

            await gridCrossRefFiles.Reload();
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>("Claims", new Dictionary<string, object>() { {"ProgramID", claim.ProgramID}, {"ExcludeClaimID", intClaimID}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{"90%"}",Height = $"{"80%"}" });
            if (dialogResult != null && dialogResult != 0) {
                crossRefClaim = new RecoCms6.Models.RecoDb.CrossReferencedClaim();
            }

            if (dialogResult != null && dialogResult != 0) {
                crossRefClaim.ClaimID = claim.ClaimID;
            }

            if (dialogResult != null && dialogResult != 0) {
                crossRefClaim.XRefClaimID = dialogResult;
            }

            if (dialogResult != null && dialogResult != 0)
            {
                var recoDbCreateCrossReferencedClaimResult = await RecoDb.CreateCrossReferencedClaim(crossRefClaim);
                var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"XRefClaimNo asc" });
                getXRefClaimsList = recoDbGetXRefClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task Numeric8Change(double? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric9Change(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric10Change(double? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric11Change(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Checkbox0Change(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(RecoCms6.Models.RecoDb.CommissionInstallment args)
        {
            var dialogResult = await DialogService.OpenAsync<EditCommissionInstallment>("Edit Commission Installment", new Dictionary<string, object>() { {"CommissionInstallmentID", args.CommissionInstallmentID} });
            await gridCommissionInstallments.Reload();

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddCommissionInstallment>("Add Commission Installment", new Dictionary<string, object>() { {"TradeID", trade.TradeID} });
            var recoDbGetCommissionInstallmentsResult = await RecoDb.GetCommissionInstallments(new Query() { Filter = $@"i => i.TradeID == @0", FilterParameters = new object[] { trade.TradeID }, OrderBy = $"DatePaid desc" });
            getCommissionInstallments = recoDbGetCommissionInstallmentsResult;
        }

        protected async System.Threading.Tasks.Task ButtonSaveSummaryClick(MouseEventArgs args)
        {
            try
            {
                await SaveSummary();
            }
            catch (System.Exception saveSummaryException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"System Error",Detail = $"{saveSummaryException.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonCancelClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
