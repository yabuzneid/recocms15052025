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
    public partial class EditClaimComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> gridIncurred = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.XRefClaim> gridCrossRefFiles = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity> gridOtherClaims = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimLitigationDate> gridLitigationDates = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.CostAward> gridCostAwards = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.TradeDetail> datagridTrades = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimInsured> datagridInsureds = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimInsured> datagrid8 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimClaimant> datagridClaimants = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimOtherParty> datagridOthers = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimExpert> datagridExperts = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> gridTotalIncurredDetailed = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> gridTransactions = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimActivityLog> datagridActivityLog = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimActivityLog> gridActivityLog = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimFilesByUser> gridfiles = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimDiaryDetail> gridDiaries = new();
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> gridReports = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid0 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid1 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid2 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid3 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid5 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid4 = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.File> datagridClaimFiles = new();
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimActivityLog> datagridNotes = new();

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
                    var args = new PropertyChangedEventArgs() { Name = "intClaimID", NewValue = value, OldValue = _intClaimID };
                    _intClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Claim _claim = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "claim", NewValue = value, OldValue = _claim };
                    _claim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _currentStatusID;
        protected int currentStatusID
        {
            get
            {
                return _currentStatusID;
            }
            set
            {
                if (!object.Equals(_currentStatusID, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "currentStatusID", NewValue = value, OldValue = _currentStatusID };
                    _currentStatusID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimList _claimList = new();
        protected RecoCms6.Models.RecoDb.ClaimList claimList
        {
            get
            {
                return _claimList;
            }
            set
            {
                if (!object.Equals(_claimList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimList", NewValue = value, OldValue = _claimList };
                    _claimList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _claimTitle;
        protected string claimTitle
        {
            get
            {
                return _claimTitle;
            }
            set
            {
                if (!object.Equals(_claimTitle, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimTitle", NewValue = value, OldValue = _claimTitle };
                    _claimTitle = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.GetAvailableServiceProvider> _getAdjustersList = new List<GetAvailableServiceProvider>();
        protected List<RecoCms6.Models.RecoDb.GetAvailableServiceProvider> getAdjustersList
        {
            get
            {
                return _getAdjustersList;
            }
            set
            {
                if (!object.Equals(_getAdjustersList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getAdjustersList", NewValue = value, OldValue = _getAdjustersList };
                    _getAdjustersList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<GetAvailableServiceProvider> _getCoverageCounselList = new List<GetAvailableServiceProvider>();
        protected List<GetAvailableServiceProvider> getCoverageCounselList
        {
            get
            {
                return _getCoverageCounselList;
            }
            set
            {
                if (!object.Equals(_getCoverageCounselList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getCoverageCounselList", NewValue = value, OldValue = _getCoverageCounselList };
                    _getCoverageCounselList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.GetAvailableServiceProvider> _getFileHandlerList = new List<GetAvailableServiceProvider>();
        protected List<RecoCms6.Models.RecoDb.GetAvailableServiceProvider> getFileHandlerList
        {
            get
            {
                return _getFileHandlerList;
            }
            set
            {
                if (!object.Equals(_getFileHandlerList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getFileHandlerList", NewValue = value, OldValue = _getFileHandlerList };
                    _getFileHandlerList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<GetAvailableServiceProvider> _getDefenseCounselList = new List<GetAvailableServiceProvider>();
        protected List<GetAvailableServiceProvider> getDefenseCounselList
        {
            get
            {
                return _getDefenseCounselList;
            }
            set
            {
                if (!object.Equals(_getDefenseCounselList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDefenseCounselList", NewValue = value, OldValue = _getDefenseCounselList };
                    _getDefenseCounselList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        
        List<GetAvailableServiceProvider> _getReportsToList = new List<GetAvailableServiceProvider>();
        protected List<GetAvailableServiceProvider> getReportsToList
        {
            get
            {
                return _getReportsToList;
            }
            set
            {
                if (!object.Equals(_getReportsToList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getReportsToList", NewValue = value, OldValue = _getReportsToList };
                    _getReportsToList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.GetAvailableServiceProvider _getFileHandler = new();
        protected RecoCms6.Models.RecoDb.GetAvailableServiceProvider getFileHandler
        {
            get
            {
                return _getFileHandler;
            }
            set
            {
                if (!object.Equals(_getFileHandler, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getFileHandler", NewValue = value, OldValue = _getFileHandler };
                    _getFileHandler = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getClaimStatusList = new List<ParameterDetail>();
        protected List<ParameterDetail> getClaimStatusList
        {
            get
            {
                return _getClaimStatusList;
            }
            set
            {
                if (!object.Equals(_getClaimStatusList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getClaimStatusList", NewValue = value, OldValue = _getClaimStatusList };
                    _getClaimStatusList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getClaimInitiationList = new List<ParameterDetail>();
        protected List<ParameterDetail> getClaimInitiationList
        {
            get
            {
                return _getClaimInitiationList;
            }
            set
            {
                if (!object.Equals(_getClaimInitiationList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getClaimInitiationList", NewValue = value, OldValue = _getClaimInitiationList };
                    _getClaimInitiationList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getLossCauseResult = new List<ParameterDetail>();
        protected List<ParameterDetail> getLossCauseResult
        {
            get
            {
                return _getLossCauseResult;
            }
            set
            {
                if (!object.Equals(_getLossCauseResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getLossCauseResult", NewValue = value, OldValue = _getLossCauseResult };
                    _getLossCauseResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getDenialCodeList = new List<ParameterDetail>();
        protected List<ParameterDetail> getDenialCodeList
        {
            get
            {
                return _getDenialCodeList;
            }
            set
            {
                if (!object.Equals(_getDenialCodeList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDenialCodeList", NewValue = value, OldValue = _getDenialCodeList };
                    _getDenialCodeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getBrokerageOnlyList = new List<ParameterDetail>();
        protected List<ParameterDetail> getBrokerageOnlyList
        {
            get
            {
                return _getBrokerageOnlyList;
            }
            set
            {
                if (!object.Equals(_getBrokerageOnlyList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getBrokerageOnlyList", NewValue = value, OldValue = _getBrokerageOnlyList };
                    _getBrokerageOnlyList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getTradeTypeList = new List<ParameterDetail>();
        protected List<ParameterDetail> getTradeTypeList
        {
            get
            {
                return _getTradeTypeList;
            }
            set
            {
                if (!object.Equals(_getTradeTypeList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTradeTypeList", NewValue = value, OldValue = _getTradeTypeList };
                    _getTradeTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getStageSettledList = new List<ParameterDetail>();
        protected List<ParameterDetail> getStageSettledList
        {
            get
            {
                return _getStageSettledList;
            }
            set
            {
                if (!object.Equals(_getStageSettledList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getStageSettledList", NewValue = value, OldValue = _getStageSettledList };
                    _getStageSettledList = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "getEOProgramID", NewValue = value, OldValue = _getEOProgramID };
                    _getEOProgramID = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "isEOProgram", NewValue = value, OldValue = _isEOProgram };
                    _isEOProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getFileOutcomeList = new List<ParameterDetail>();
        protected List<ParameterDetail> getFileOutcomeList
        {
            get
            {
                return _getFileOutcomeList;
            }
            set
            {
                if (!object.Equals(_getFileOutcomeList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getFileOutcomeList", NewValue = value, OldValue = _getFileOutcomeList };
                    _getFileOutcomeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getDeductibleList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getDeductibleList
        {
            get
            {
                return _getDeductibleList;
            }
            set
            {
                if (!object.Equals(_getDeductibleList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDeductibleList", NewValue = value, OldValue = _getDeductibleList };
                    _getDeductibleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<ParameterDetail> _getRORList = new List<ParameterDetail>();
        protected List<ParameterDetail> getRORList
        {
            get
            {
                return _getRORList;
            }
            set
            {
                if (!object.Equals(_getRORList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getRORList", NewValue = value, OldValue = _getRORList };
                    _getRORList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getLitigationTypeList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getLitigationTypeList
        {
            get
            {
                return _getLitigationTypeList;
            }
            set
            {
                if (!object.Equals(_getLitigationTypeList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getLitigationTypeList", NewValue = value, OldValue = _getLitigationTypeList };
                    _getLitigationTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getDeductibleHandlingList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getDeductibleHandlingList
        {
            get
            {
                return _getDeductibleHandlingList;
            }
            set
            {
                if (!object.Equals(_getDeductibleHandlingList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getDeductibleHandlingList", NewValue = value, OldValue = _getDeductibleHandlingList };
                    _getDeductibleHandlingList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }


        List<RecoCms6.Models.RecoDb.ParameterDetail> _getNoteTypeList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getNoteTypeList
        {
            get
            {
                return _getNoteTypeList;
            }
            set
            {
                if (!object.Equals(_getNoteTypeList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getNoteTypeList", NewValue = value, OldValue = _getNoteTypeList };
                    _getNoteTypeList = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "getDefaultNoteTypeID", NewValue = value, OldValue = _getDefaultNoteTypeID };
                    _getDefaultNoteTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getRecoveryList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getRecoveryList
        {
            get
            {
                return _getRecoveryList;
            }
            set
            {
                if (!object.Equals(_getRecoveryList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getRecoveryList", NewValue = value, OldValue = _getRecoveryList };
                    _getRecoveryList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getRECOOutcomeList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getRECOOutcomeList
        {
            get
            {
                return _getRECOOutcomeList;
            }
            set
            {
                if (!object.Equals(_getRECOOutcomeList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getRECOOutcomeList", NewValue = value, OldValue = _getRECOOutcomeList };
                    _getRECOOutcomeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _parameterFlags = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> parameterFlags
        {
            get
            {
                return _parameterFlags;
            }
            set
            {
                if (!object.Equals(_parameterFlags, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "parameterFlags", NewValue = value, OldValue = _parameterFlags };
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

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getYesNoPendingList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getYesNoPendingList
        {
            get
            {
                return _getYesNoPendingList;
            }
            set
            {
                if (!object.Equals(_getYesNoPendingList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getYesNoPendingList", NewValue = value, OldValue = _getYesNoPendingList };
                    _getYesNoPendingList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getEndOfDealList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getEndOfDealList
        {
            get
            {
                return _getEndOfDealList;
            }
            set
            {
                if (!object.Equals(_getEndOfDealList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getEndOfDealList", NewValue = value, OldValue = _getEndOfDealList };
                    _getEndOfDealList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getUrbanOrRuralList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getUrbanOrRuralList
        {
            get
            {
                return _getUrbanOrRuralList;
            }
            set
            {
                if (!object.Equals(_getUrbanOrRuralList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getUrbanOrRuralList", NewValue = value, OldValue = _getUrbanOrRuralList };
                    _getUrbanOrRuralList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getTransactionValueList = new List<ParameterDetail>();
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getTransactionValueList
        {
            get
            {
                return _getTransactionValueList;
            }
            set
            {
                if (!object.Equals(_getTransactionValueList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTransactionValueList", NewValue = value, OldValue = _getTransactionValueList };
                    _getTransactionValueList = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "trade", NewValue = value, OldValue = _trade };
                    _trade = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> _getTotalIncurred = new List<ClaimTotalIncurredByCategory>();
        protected List<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> getTotalIncurred
        {
            get
            {
                return _getTotalIncurred;
            }
            set
            {
                if (!object.Equals(_getTotalIncurred, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTotalIncurred", NewValue = value, OldValue = _getTotalIncurred };
                    _getTotalIncurred = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> _transactions = new List<ClaimIndividualTransaction>();
        protected List<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                if (!object.Equals(_transactions, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "transactions", NewValue = value, OldValue = _transactions };
                    _transactions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimDiaryDetail> _diaries = new List<ClaimDiaryDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimDiaryDetail> diaries
        {
            get
            {
                return _diaries;
            }
            set
            {
                if (!object.Equals(_diaries, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "diaries", NewValue = value, OldValue = _diaries };
                    _diaries = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.CdpClaimDetail _claimdetails = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "claimdetails", NewValue = value, OldValue = _claimdetails };
                    _claimdetails = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.EoClaimDetail _eoclaimdetails = new();
        protected RecoCms6.Models.RecoDb.EoClaimDetail eoclaimdetails
        {
            get
            {
                return _eoclaimdetails;
            }
            set
            {
                if (!object.Equals(_eoclaimdetails, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "eoclaimdetails", NewValue = value, OldValue = _eoclaimdetails };
                    _eoclaimdetails = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private List<RecoCms6.Models.RecoDb.XRefClaim> XRefClaimsListToAdd = new();
        private List<RecoCms6.Models.RecoDb.XRefClaim> XRefClaimsListToDelete = new();
        
        public List<RecoCms6.Models.RecoDb.XRefClaim> ViewGetXRefClaimsList
        {
            get
            {
                return getXRefClaimsList
                    .Concat(XRefClaimsListToAdd)
                    .ExceptBy(XRefClaimsListToDelete.Select(xref=>new{xref.BaseClaimID, xref.XRefClaimID}), 
                        xref => new{xref.BaseClaimID, xref.XRefClaimID} )
                    .ToList();
            }
        }

        List<RecoCms6.Models.RecoDb.XRefClaim> _getXRefClaimsList = new List<XRefClaim>();
        protected List<RecoCms6.Models.RecoDb.XRefClaim> getXRefClaimsList
        {
            get
            {
                return _getXRefClaimsList;
            }
            set
            {
                if (!object.Equals(_getXRefClaimsList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getXRefClaimsList", NewValue = value, OldValue = _getXRefClaimsList };
                    _getXRefClaimsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.BuilderDetail> _getBuildersList = new List<BuilderDetail>();
        protected List<RecoCms6.Models.RecoDb.BuilderDetail> getBuildersList
        {
            get
            {
                return _getBuildersList;
            }
            set
            {
                if (!object.Equals(_getBuildersList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getBuildersList", NewValue = value, OldValue = _getBuildersList };
                    _getBuildersList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedTab;
        protected int selectedTab
        {
            get
            {
                return _selectedTab;
            }
            set
            {
                if (!object.Equals(_selectedTab, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "selectedTab", NewValue = value, OldValue = _selectedTab };
                    _selectedTab = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimFilesByUser> _claimfiles = new List<ClaimFilesByUser>();
        protected List<RecoCms6.Models.RecoDb.ClaimFilesByUser> claimfiles
        {
            get
            {
                return _claimfiles;
            }
            set
            {
                if (!object.Equals(_claimfiles, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimfiles", NewValue = value, OldValue = _claimfiles };
                    _claimfiles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _NoticeOfClaimRefNum;
        protected string NoticeOfClaimRefNum
        {
            get
            {
                return _NoticeOfClaimRefNum;
            }
            set
            {
                if (!object.Equals(_NoticeOfClaimRefNum, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "NoticeOfClaimRefNum", NewValue = value, OldValue = _NoticeOfClaimRefNum };
                    _NoticeOfClaimRefNum = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public List<ClaimLitigationDate> ViewGetClaimLitigationDatesList
        {
            get
            {
                return getClaimLitigationDatesList;
            }
        }

        private List<ClaimLitigationDate> ModifyClaimLitigationDatesList = new();
        List<RecoCms6.Models.RecoDb.ClaimLitigationDate> _getClaimLitigationDatesList = new List<ClaimLitigationDate>();
        protected List<RecoCms6.Models.RecoDb.ClaimLitigationDate> getClaimLitigationDatesList
        {
            get
            {
                return _getClaimLitigationDatesList;
            }
            set
            {
                if (!object.Equals(_getClaimLitigationDatesList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getClaimLitigationDatesList", NewValue = value, OldValue = _getClaimLitigationDatesList };
                    _getClaimLitigationDatesList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Note _note = new();
        protected RecoCms6.Models.RecoDb.Note note
        {
            get
            {
                return _note;
            }
            set
            {
                if (!object.Equals(_note, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "note", NewValue = value, OldValue = _note };
                    _note = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.TemplateDetail> _getNoteTemplateResults = new List<TemplateDetail>();
        protected List<RecoCms6.Models.RecoDb.TemplateDetail> getNoteTemplateResults
        {
            get
            {
                return _getNoteTemplateResults;
            }
            set
            {
                if (!object.Equals(_getNoteTemplateResults, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getNoteTemplateResults", NewValue = value, OldValue = _getNoteTemplateResults };
                    _getNoteTemplateResults = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.TemplateDetail> _getEmailTemplateResults = new List<TemplateDetail>();
        protected List<RecoCms6.Models.RecoDb.TemplateDetail> getEmailTemplateResults
        {
            get
            {
                return _getEmailTemplateResults;
            }
            set
            {
                if (!object.Equals(_getEmailTemplateResults, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getEmailTemplateResults", NewValue = value, OldValue = _getEmailTemplateResults };
                    _getEmailTemplateResults = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _TemplateID;
        protected int TemplateID
        {
            get
            {
                return _TemplateID;
            }
            set
            {
                if (!object.Equals(_TemplateID, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "TemplateID", NewValue = value, OldValue = _TemplateID };
                    _TemplateID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<int> _selectedroles = new List<int>();
        protected IEnumerable<int> selectedroles
        {
            get
            {
                return _selectedroles;
            }
            set
            {
                if (!object.Equals(_selectedroles, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "selectedroles", NewValue = value, OldValue = _selectedroles };
                    _selectedroles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity> _getSevenYearIndemnitiesResult = new List<GetSevenYearsClaimIndemnity>();
        protected List<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity> getSevenYearIndemnitiesResult
        {
            get
            {
                return _getSevenYearIndemnitiesResult;
            }
            set
            {
                if (!object.Equals(_getSevenYearIndemnitiesResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getSevenYearIndemnitiesResult", NewValue = value, OldValue = _getSevenYearIndemnitiesResult };
                    _getSevenYearIndemnitiesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private List<CostAward> ModifyCostAwardsList = new();
        List<RecoCms6.Models.RecoDb.CostAward> _getCostAwardsList = new List<CostAward>();
        protected List<RecoCms6.Models.RecoDb.CostAward> getCostAwardsList
        {
            get
            {
                return _getCostAwardsList;
            }
            set
            {
                if (!object.Equals(_getCostAwardsList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getCostAwardsList", NewValue = value, OldValue = _getCostAwardsList };
                    _getCostAwardsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProvider _serviceprovider = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "serviceprovider", NewValue = value, OldValue = _serviceprovider };
                    _serviceprovider = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _claimreports = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> claimreports
        {
            get
            {
                return _claimreports;
            }
            set
            {
                if (!object.Equals(_claimreports, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimreports", NewValue = value, OldValue = _claimreports };
                    _claimreports = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousClaimReports = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousClaimReports
        {
            get
            {
                return _previousClaimReports;
            }
            set
            {
                if (!object.Equals(_previousClaimReports, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousClaimReports", NewValue = value, OldValue = _previousClaimReports };
                    _previousClaimReports = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousActionPlans = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousActionPlans
        {
            get
            {
                return _previousActionPlans;
            }
            set
            {
                if (!object.Equals(_previousActionPlans, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousActionPlans", NewValue = value, OldValue = _previousActionPlans };
                    _previousActionPlans = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousFacts = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousFacts
        {
            get
            {
                return _previousFacts;
            }
            set
            {
                if (!object.Equals(_previousFacts, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousFacts", NewValue = value, OldValue = _previousFacts };
                    _previousFacts = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousCoverage = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousCoverage
        {
            get
            {
                return _previousCoverage;
            }
            set
            {
                if (!object.Equals(_previousCoverage, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousCoverage", NewValue = value, OldValue = _previousCoverage };
                    _previousCoverage = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousLiability = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousLiability
        {
            get
            {
                return _previousLiability;
            }
            set
            {
                if (!object.Equals(_previousLiability, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousLiability", NewValue = value, OldValue = _previousLiability };
                    _previousLiability = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousDamages = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousDamages
        {
            get
            {
                return _previousDamages;
            }
            set
            {
                if (!object.Equals(_previousDamages, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousDamages", NewValue = value, OldValue = _previousDamages };
                    _previousDamages = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimReportDetail> _previousRecommendations = new List<ClaimReportDetail>();
        protected List<RecoCms6.Models.RecoDb.ClaimReportDetail> previousRecommendations
        {
            get
            {
                return _previousRecommendations;
            }
            set
            {
                if (!object.Equals(_previousRecommendations, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousRecommendations", NewValue = value, OldValue = _previousRecommendations };
                    _previousRecommendations = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimReport _report = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "report", NewValue = value, OldValue = _report };
                    _report = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _incurredtypefilter;
        protected string incurredtypefilter
        {
            get
            {
                return _incurredtypefilter;
            }
            set
            {
                if (!object.Equals(_incurredtypefilter, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "incurredtypefilter", NewValue = value, OldValue = _incurredtypefilter };
                    _incurredtypefilter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _incurredcategoryfilter;
        protected string incurredcategoryfilter
        {
            get
            {
                return _incurredcategoryfilter;
            }
            set
            {
                if (!object.Equals(_incurredcategoryfilter, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "incurredcategoryfilter", NewValue = value, OldValue = _incurredcategoryfilter };
                    _incurredcategoryfilter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _reservereasonfilter;
        protected string reservereasonfilter
        {
            get
            {
                return _reservereasonfilter;
            }
            set
            {
                if (!object.Equals(_reservereasonfilter, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "reservereasonfilter", NewValue = value, OldValue = _reservereasonfilter };
                    _reservereasonfilter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimActivityLog> _activityLog = new List<ClaimActivityLog>();
        protected List<RecoCms6.Models.RecoDb.ClaimActivityLog> activityLog
        {
            get
            {
                return _activityLog;
            }
            set
            {
                if (!object.Equals(_activityLog, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "activityLog", NewValue = value, OldValue = _activityLog };
                    _activityLog = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isDirty;
        protected bool isDirty
        {
            get
            {
                return _isDirty;
            }
            set
            {
                if (!object.Equals(_isDirty, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "isDirty", NewValue = value, OldValue = _isDirty };
                    _isDirty = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _currentTab;
        protected int currentTab
        {
            get
            {
                return _currentTab;
            }
            set
            {
                if (!object.Equals(_currentTab, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "currentTab", NewValue = value, OldValue = _currentTab };
                    _currentTab = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        MarkupString _claimsummary;
        protected MarkupString claimsummary
        {
            get
            {
                return _claimsummary;
            }
            set
            {
                if (!object.Equals(_claimsummary, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimsummary", NewValue = value, OldValue = _claimsummary };
                    _claimsummary = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<int> _selectedFileReportIds = new List<int>();
        protected IEnumerable<int> selectedFileReportIds
        {
            get
            {
                return _selectedFileReportIds;
            }
            set
            {
                if (!object.Equals(_selectedFileReportIds, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "selectedFileReportIds", NewValue = value, OldValue = _selectedFileReportIds };
                    _selectedFileReportIds = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _statusRequired;
        protected bool statusRequired
        {
            get
            {
                return _statusRequired;
            }
            set
            {
                if (!object.Equals(_statusRequired, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "statusRequired", NewValue = value, OldValue = _statusRequired };
                    _statusRequired = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _claimNumRequired;
        protected bool claimNumRequired
        {
            get
            {
                return _claimNumRequired;
            }
            set
            {
                if (!object.Equals(_claimNumRequired, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimNumRequired", NewValue = value, OldValue = _claimNumRequired };
                    _claimNumRequired = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _invalidAdjusterNum;
        protected bool invalidAdjusterNum
        {
            get
            {
                return _invalidAdjusterNum;
            }
            set
            {
                if (!object.Equals(_invalidAdjusterNum, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "invalidAdjusterNum", NewValue = value, OldValue = _invalidAdjusterNum };
                    _invalidAdjusterNum = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _contractYearRequired;
        protected bool contractYearRequired
        {
            get
            {
                return _contractYearRequired;
            }
            set
            {
                if (!object.Equals(_contractYearRequired, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "contractYearRequired", NewValue = value, OldValue = _contractYearRequired };
                    _contractYearRequired = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "isValid", NewValue = value, OldValue = _isValid };
                    _isValid = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bAttachToClaim;
        protected bool bAttachToClaim
        {
            get
            {
                return _bAttachToClaim;
            }
            set
            {
                if (!object.Equals(_bAttachToClaim, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bAttachToClaim", NewValue = value, OldValue = _bAttachToClaim };
                    _bAttachToClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _docExtensions = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "docExtensions", NewValue = value, OldValue = _docExtensions };
                    _docExtensions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _imageExtensions = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "imageExtensions", NewValue = value, OldValue = _imageExtensions };
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
                    var args = new PropertyChangedEventArgs() { Name = "avExtensions", NewValue = value, OldValue = _avExtensions };
                    _avExtensions = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "saveResult", NewValue = value, OldValue = _saveResult };
                    _saveResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bFirstRender;
        protected bool bFirstRender
        {
            get
            {
                return _bFirstRender;
            }
            set
            {
                if (!object.Equals(_bFirstRender, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bFirstRender", NewValue = value, OldValue = _bFirstRender };
                    _bFirstRender = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "randomParam", NewValue = value, OldValue = _randomParam };
                    _randomParam = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bCollapsedNote = true;
        protected bool bCollapsedNote
        {
            get
            {
                return _bCollapsedNote;
            }
            set
            {
                if (!object.Equals(_bCollapsedNote, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bCollapsedNote", NewValue = value, OldValue = _bCollapsedNote };
                    _bCollapsedNote = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bNewNote;
        protected bool bNewNote
        {
            get
            {
                return _bNewNote;
            }
            set
            {
                if (!object.Equals(_bNewNote, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bNewNote", NewValue = value, OldValue = _bNewNote };
                    _bNewNote = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bEditNote;
        protected bool bEditNote
        {
            get
            {
                return _bEditNote;
            }
            set
            {
                if (!object.Equals(_bEditNote, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bEditNote", NewValue = value, OldValue = _bEditNote };
                    _bEditNote = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "bReadOnly", NewValue = value, OldValue = _bReadOnly };
                    _bReadOnly = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.StandardEmailAddress> _standardEmails = new List<StandardEmailAddress>();
        protected List<RecoCms6.Models.RecoDb.StandardEmailAddress> standardEmails
        {
            get
            {
                return _standardEmails;
            }
            set
            {
                if (!object.Equals(_standardEmails, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "standardEmails", NewValue = value, OldValue = _standardEmails };
                    _standardEmails = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _ExpandedNotes;
        protected List<string> ExpandedNotes
        {
            get
            {
                return _ExpandedNotes;
            }
            set
            {
                if (!object.Equals(_ExpandedNotes, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "ExpandedNotes", NewValue = value, OldValue = _ExpandedNotes };
                    _ExpandedNotes = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bSuccessfulSave;
        protected bool bSuccessfulSave
        {
            get
            {
                return _bSuccessfulSave;
            }
            set
            {
                if (!object.Equals(_bSuccessfulSave, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bSuccessfulSave", NewValue = value, OldValue = _bSuccessfulSave };
                    _bSuccessfulSave = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bCloseClaim;
        protected bool bCloseClaim
        {
            get
            {
                return _bCloseClaim;
            }
            set
            {
                if (!object.Equals(_bCloseClaim, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bCloseClaim", NewValue = value, OldValue = _bCloseClaim };
                    _bCloseClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bIsNewClaimDetail;
        protected bool bIsNewClaimDetail
        {
            get
            {
                return _bIsNewClaimDetail;
            }
            set
            {
                if (!object.Equals(_bIsNewClaimDetail, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bIsNewClaimDetail", NewValue = value, OldValue = _bIsNewClaimDetail };
                    _bIsNewClaimDetail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal? _selectedClaimStatusValue;
        protected decimal? selectedClaimStatusValue
        {
            get
            {
                return _selectedClaimStatusValue;
            }
            set
            {
                if (!object.Equals(_selectedClaimStatusValue, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "selectedClaimStatusValue", NewValue = value, OldValue = _selectedClaimStatusValue };
                    _selectedClaimStatusValue = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _previousclaimstatus;
        protected int previousclaimstatus
        {
            get
            {
                return _previousclaimstatus;
            }
            set
            {
                if (!object.Equals(_previousclaimstatus, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "previousclaimstatus", NewValue = value, OldValue = _previousclaimstatus };
                    _previousclaimstatus = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimStatusHistory _claimstatushistory;
        protected RecoCms6.Models.RecoDb.ClaimStatusHistory claimstatushistory
        {
            get
            {
                return _claimstatushistory;
            }
            set
            {
                if (!object.Equals(_claimstatushistory, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimstatushistory", NewValue = value, OldValue = _claimstatushistory };
                    _claimstatushistory = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "strXRefClaimID", NewValue = value, OldValue = _strXRefClaimID };
                    _strXRefClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.CrossReferencedClaim _crossRefClaim = new();
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
                    var args = new PropertyChangedEventArgs() { Name = "crossRefClaim", NewValue = value, OldValue = _crossRefClaim };
                    _crossRefClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.TradeDetail> _getTradesList = new List<TradeDetail>();
        protected List<RecoCms6.Models.RecoDb.TradeDetail> getTradesList
        {
            get
            {
                return _getTradesList;
            }
            set
            {
                if (!object.Equals(_getTradesList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getTradesList", NewValue = value, OldValue = _getTradesList };
                    _getTradesList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.ClaimExpert> _getExpertList = new List<ClaimExpert>();
        protected List<RecoCms6.Models.RecoDb.ClaimExpert> getExpertList
        {
            get
            {
                return _getExpertList;
            }
            set
            {
                if (!object.Equals(_getExpertList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getExpertList", NewValue = value, OldValue = _getExpertList };
                    _getExpertList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool? _bClearNote;
        protected bool? bClearNote
        {
            get
            {
                return _bClearNote;
            }
            set
            {
                if (!object.Equals(_bClearNote, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bClearNote", NewValue = value, OldValue = _bClearNote };
                    _bClearNote = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "IsSubmitEvent", NewValue = value, OldValue = _IsSubmitEvent };
                    _IsSubmitEvent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isClaimEmailSubmit;

        protected bool isClaimEmailSubmit
        {
            get
            {
                return _isClaimEmailSubmit;
            }
            set
            {
                if (!object.Equals(_isClaimEmailSubmit, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "isClaimEmailSubmit", NewValue = value, OldValue = _isClaimEmailSubmit };
                    _isClaimEmailSubmit = value;
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
                    var args = new PropertyChangedEventArgs() { Name = "Attachments", NewValue = value, OldValue = _Attachments };
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
                    var args = new PropertyChangedEventArgs() { Name = "Notes", NewValue = value, OldValue = _Notes };
                    _Notes = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
                await LoadClaimDetailsTabData();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamDesc asc" });
            intClaimID = StringExtensions.IntegerFromBase64(ClaimID);

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, Expand = "ClaimFileReportings" });
            claim = recoDbGetClaimsResult.First();

            currentStatusID = claim.ClaimStatusID;

            claimTitle = claim.ClaimNo;
            
            var recoDbGetGetAvailableServiceProvidersResult = 
                (await RecoDb.GetGetAvailableServiceProviders(claim.ClaimID, new Query() { OrderBy = $"NameandFirm asc" }))
                .ToList();

            getFileHandler = recoDbGetGetAvailableServiceProvidersResult.FirstOrDefault(sp => sp.ServiceProviderID == claim.FileHandlerID);

            ReloadInsuredList();

            var recoDbGetClaimTotalIncurredByCategoriesResult = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            getTotalIncurred = recoDbGetClaimTotalIncurredByCategoriesResult.ToList();

            var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"XRefClaimNo asc" });
            getXRefClaimsList = recoDbGetXRefClaimsResult.ToList();

            selectedTab = 0;

            TemplateID = 0;

            selectedroles = new int[] { 1, 2, 5, 6, 7, 8 };

            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault() ?? new ServiceProvider();

            var recoDbGetClaimReportDetailsResult =  (await RecoDb.GetClaimReportDetails(new Query()
            {
                Filter = $@"i => i.ClaimID == @0",FilterParameters = new object[] { claim.ClaimID },
                OrderBy = $"ClaimReportID desc"
            })).ToList();
            claimreports = recoDbGetClaimReportDetailsResult;

            previousClaimReports = recoDbGetClaimReportDetailsResult.Where(cr => cr.DateSubmitted != null && cr.HandlingFirmID == serviceprovider?.FirmID).ToList();

            previousActionPlans = previousClaimReports.Where(cr => cr.ActionPlan != null && cr.ActionPlan != string.Empty).ToList();

            previousFacts = previousClaimReports.Where(cr => cr.Facts != null && cr.Facts != string.Empty).ToList();

            previousCoverage = previousClaimReports.Where(cr => cr.Coverage != null && cr.Coverage != string.Empty).ToList();

            previousLiability = previousClaimReports.Where(cr => cr.Liability != null && cr.Liability != string.Empty).ToList();

            previousDamages = previousClaimReports.Where(cr => cr.Damages != null && cr.Damages != string.Empty).ToList();

            previousRecommendations = previousClaimReports.Where(cr => cr.Recommendations != null && cr.Recommendations != string.Empty).ToList();

            incurredtypefilter = String.Empty;

            incurredcategoryfilter = String.Empty;

            reservereasonfilter = String.Empty;

            isDirty = false;

            currentTab = 0;

            if (Security.IsInRole("Accountant") && Security.IsInRole("Auditor"))
            {
                currentTab = 7;
            }

            var recoDbGetClaimSummariesResult = await RecoDb.GetClaimSummaries(claim.ClaimID);
            claimsummary = (MarkupString)recoDbGetClaimSummariesResult.FirstOrDefault().ClaimSummary1;

            selectedFileReportIds = new List<int>();

            loadFileReports();

            statusRequired = false;

            claimNumRequired = false;

            invalidAdjusterNum = false;

            contractYearRequired = false;

            isValid = false;

            bAttachToClaim = true;

            docExtensions = new List<string> { ".pdf", ".xls", ".xlsx", ".doc", ".docx" };

            imageExtensions = new List<string> { ".png", ".jpeg", ".jpg", ".gif" };

            avExtensions = new List<string> { ".avi", ".mov", ".mp4", ".mp3", ".m4a", ".wav" };

            saveResult = false;

            ClearEmailForm();

            bFirstRender = true;

            randomParam = String.Empty;

            bCollapsedNote = true;

            bNewNote = true;

            bEditNote = true;

            bReadOnly = false;

            SetPreference(true);

            ExpandedNotes = new List<string>();
        }

        protected async System.Threading.Tasks.Task ButtonAddNoteClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddNote>("Add Note", new Dictionary<string, object>() { { "NoteID", Guid.Empty }, { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"75%"}", Resizable = true, Draggable = true });
            if (dialogResult != null)
            {
                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                activityLog =  recoDbGetClaimActivityLogsResult.ToList();
            }
        }

        protected async System.Threading.Tasks.Task ButtonSaveDetails2Click(MouseEventArgs args)
        {
            await ButtonSaveDetailsClick(args);
        }

        protected async System.Threading.Tasks.Task Tabs0Change(int tabIndex)
        {
            bFirstRender = true;
            
            switch (tabIndex)
            {
                case 0: 
                    await LoadClaimDetailsTabData();
                    break;
                case 1:
                    await LoadContactInfoTabData();
                    break;
                case 2:
                    await LoadReservesPaymentsTabData();
                    break;
                case 3:
                    await LoadNotesTabData();
                    break;
                case 4:
                    await LoadAttachmentsTabData();
                    break;
                case 5:
                    await LoadDiariesTabData();
                    break; 
                case 6:
                    await LoadClaimReportsTabData();
                    break;
                case 7:
                    await LoadEmailTabData();
                    break;
            }
        }

        protected async System.Threading.Tasks.Task ButtonSaveDetailsClick(MouseEventArgs args)
        {
            var validateResult = Validate();
            if (!isValid)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error on form.  Please Correct" });
                return;
            }

            bSuccessfulSave = true;

            bCloseClaim = false;

            if (!isEOProgram)
            {
                bIsNewClaimDetail = claimdetails.ClaimID == 0;
            }

            if (isEOProgram)
            {
                bIsNewClaimDetail = eoclaimdetails.ClaimID == 0;
            }

            if (bIsNewClaimDetail && !isEOProgram)
            {
                claimdetails.ClaimID = claim.ClaimID;
            }

            if (bIsNewClaimDetail && isEOProgram)
            {
                eoclaimdetails.ClaimID = claim.ClaimID;
            }

            if (claim.OriginalFileHandlerID == null)
            {
                claim.OriginalFileHandlerID = claim.FileHandlerID;
            }

            var recoDbGetParametersResult = await RecoDb.GetParameters(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { claim.ClaimStatusID } });
            selectedClaimStatusValue = recoDbGetParametersResult.FirstOrDefault().ParamValue;

            if (currentStatusID != claim.ClaimStatusID && selectedClaimStatusValue == 0)
            {
                await CloseClaim();
            }

            try
            {
                if (bIsNewClaimDetail && isEOProgram)
                {
                    var recoDbCreateEoClaimDetailResult = await RecoDb.CreateEoClaimDetail(eoclaimdetails);

                }

                if (!bIsNewClaimDetail && isEOProgram)
                {
                    var recoDbUpdateEoClaimDetailResult = await RecoDb.UpdateEoClaimDetail(claim.ClaimID, eoclaimdetails);
                }
            }
            catch (System.Exception recoDbUpdateEoClaimDetailException)
            {
                await SaveErrorAsync(recoDbUpdateEoClaimDetailException);

                bSuccessfulSave = false;
            }

            if (bSuccessfulSave)
            {
                await saveFileReports();
            }

            try
            {
                if (bSuccessfulSave)
                {
                    var recoDbUpdateClaimResult = await RecoDb.UpdateClaim(claim.ID, claim);
                    var recoDbStoreClaimAuditTrailsResult = await RecoDb.StoreClaimAuditTrails(claim.ClaimID, $"{Security.User.Id}");

                    try
                    {
                        if (trade != null)
                        {
                            var recoDbUpdateTradeResult = await RecoDb.UpdateTrade(trade.TradeID, trade);
                        }

                        await RecoDb.UpdateEoClaimDetail(eoclaimdetails.ClaimID, eoclaimdetails);

                        await UpdateXRefClaims();
                        await UpdateCostAwards();
                        await UpdateClaimLitigationDates();

                    }
                    catch (System.Exception recoDbEoClaimDetailsException)
                    {
                        await SaveErrorAsync(recoDbEoClaimDetailsException);

                        bSuccessfulSave = false;
                    }
                    
                    isDirty = !bSuccessfulSave;

                    if (bSuccessfulSave)
                    {
                        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Claim Has Been Saved" });
                    }
                }
            }
            catch (System.Exception recoDbUpdateClaimException)
            {
                await SaveErrorAsync(recoDbUpdateClaimException);

                bSuccessfulSave = false;
            }

            if (bSuccessfulSave)
            {
                var recoDbGetClaimStatusHistoriesResult = await RecoDb.GetClaimStatusHistories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"StatusChangeDate desc", Top = 1 });
                previousclaimstatus = recoDbGetClaimStatusHistoriesResult.FirstOrDefault()?.ClaimStatusID ?? -1;

                if (previousclaimstatus != claim.ClaimStatusID)
                {
                    claimstatushistory = new RecoCms6.Models.RecoDb.ClaimStatusHistory();
                    claimstatushistory.ClaimID = claim.ClaimID;
                    claimstatushistory.NewStatusID = claim.ClaimStatusID;
                    claimstatushistory.ChangedBy = Globals.userdetails.AbbreviatedName;

                    var recoDbCreateClaimStatusHistoryResult = await RecoDb.CreateClaimStatusHistory(claimstatushistory);
                }
            }
            else
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable to save claim" });
            }

            var recoDbGetClaimSummariesResult = await RecoDb.GetClaimSummaries(claim.ClaimID);
            claimsummary = (MarkupString)recoDbGetClaimSummariesResult.FirstOrDefault().ClaimSummary1;

            if (bCloseClaim && Globals.generalsettings.ApplicationName == "RECO CMS")
            {
                SendSurveyEmail();
            }
        }

        
        private async Task UpdateCostAwards()
        {
            var costAwardsToDelete = ModifyCostAwardsList.Except(getCostAwardsList).ToList();
            var costAwardsModify = ModifyCostAwardsList.Except(costAwardsToDelete).ToList();

            foreach (var costAward in costAwardsToDelete)
            {
                if (costAward.CostAwardID != 0)
                {
                    var recoDbDeleteCostAwardResult = await RecoDb.DeleteCostAward(costAward.CostAwardID);
                }
            }

            foreach (var costAward in costAwardsModify)
            {
                if (costAward.CostAwardID == 0)
                {
                    var recoDbCreateCostAwardResult = await RecoDb.CreateCostAward(costAward);
                }
                else
                {
                    var recoDbUpdateCostAwardResult = await RecoDb.UpdateCostAward(costAward.CostAwardID, costAward);
                }
            }
            ModifyCostAwardsList.Clear();
            var recoDbGetCostAwardsResult = await RecoDb.GetCostAwards(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"CostAwardDate desc" });
            getCostAwardsList = recoDbGetCostAwardsResult.ToList();
        }
        
        private async Task UpdateClaimLitigationDates()
        {
            var claimLitigationDatesToDelete = ModifyClaimLitigationDatesList.Except(getClaimLitigationDatesList).ToList();
            var claimLitigationDatesModify = ModifyClaimLitigationDatesList.Except(claimLitigationDatesToDelete).ToList();

            foreach (var claimLitigationDate in claimLitigationDatesToDelete)
            {
                if (claimLitigationDate.LitigationDateID != 0)
                {
                    var recoDbDeleteCostAwardResult = await RecoDb.DeleteClaimLitigationDate(claimLitigationDate.LitigationDateID);
                }
            }

            foreach (var claimLitigationDate in claimLitigationDatesModify)
            {
                if (claimLitigationDate.LitigationDateID == 0)
                {
                    var recoDbCreateCostAwardResult = await RecoDb.CreateClaimLitigationDate(claimLitigationDate);
                }
                else
                {
                    var recoDbCreateCostAwardResult = await RecoDb.UpdateClaimLitigationDate(claimLitigationDate.LitigationDateID, claimLitigationDate);
                }
            }
            ModifyClaimLitigationDatesList.Clear();
            var recoDbGetClaimLitigationDatesResult = await RecoDb.GetClaimLitigationDates(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"LitigationDate asc" });
            getClaimLitigationDatesList =  recoDbGetClaimLitigationDatesResult.ToList();
            
        }
        
        
        protected async Task DeleteExpertButton(ClaimExpert row)
        {
            await RecoDb.DeleteExpert(row.ExpertID);
            await ReloadExpertList();
        }

        protected async System.Threading.Tasks.Task ButtonResetClaimClick(MouseEventArgs args)
        {
            bSuccessfulSave = true;

            bIsNewClaimDetail = eoclaimdetails.ClaimID == 0;

            if (bIsNewClaimDetail)
            {
                return;
            }

            try
            {
                if (!bIsNewClaimDetail)
                {
                    eoclaimdetails = await RecoDb.GetEoClaimDetailByClaimId(claim.ClaimID);
                }

                if (bSuccessfulSave)
                {
                    var recoDbGetClaimByIdResult = await RecoDb.GetClaimById(claim.ID);
                    claim = recoDbGetClaimByIdResult;

                    var recoDbGetTradesResult = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"DisplayOrder asc" });
                    trade = recoDbGetTradesResult.FirstOrDefault();
                    
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Claim Has Been Reset" });
                    isDirty = false;
                }

                XRefClaimsListToAdd.Clear();
                XRefClaimsListToDelete.Clear();
                
                ModifyCostAwardsList.Clear();
                var recoDbGetCostAwardsResult = await RecoDb.GetCostAwards(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"CostAwardDate desc" });
                getCostAwardsList = recoDbGetCostAwardsResult.ToList();
                
                ModifyClaimLitigationDatesList.Clear();
                var recoDbGetClaimLitigationDatesResult = await RecoDb.GetClaimLitigationDates(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"LitigationDate asc" });
                getClaimLitigationDatesList =  recoDbGetClaimLitigationDatesResult.ToList();
            }
            catch (System.Exception recoDbGetClaimByIdException)
            {
                bSuccessfulSave = false;
            }

            if (!bSuccessfulSave)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable to reset claim" });
            }
        }

        protected async System.Threading.Tasks.Task ClaimStatusIdChange(dynamic args)
        {
            isDirty = true;

            if (claim.ClaimStatusID == 4)
            {
                claim.CloseDate = DateTime.Today;
            }
        }

        protected async System.Threading.Tasks.Task CloseDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimNoChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task FileOutcomeIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ReportDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task SurveyOnCloseChange(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task AdjusterIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task AdjusterClaimNoChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task FileHandlerIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DefenseCounselIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task CounselFileNoChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task CoverageCounselIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonViewClaimClick(MouseEventArgs args, dynamic data)
        {
            strXRefClaimID = StringExtensions.ToBase64(data.XRefClaimID);

            if (data.ProgramID == getEOProgramID)
                UriHelper.NavigateTo($"edit-claim/{strXRefClaimID}", true);
            else
                UriHelper.NavigateTo($"edit-commission-claim/{strXRefClaimID}", true);
        }

        protected async System.Threading.Tasks.Task ButtonDeleteCrossRefClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var xrefToAdd = XRefClaimsListToAdd
                    .FirstOrDefault(xref => xref.BaseClaimID == claim.ClaimID && xref.XRefClaimID == data.XRefClaimID);
                if (xrefToAdd is not null)
                {
                    XRefClaimsListToAdd.Remove(xrefToAdd);
                }
                else
                {
                    XRefClaimsListToDelete.Add(new XRefClaim
                    {
                        BaseClaimID = claim.ClaimID,
                        XRefClaimID = data.XRefClaimID,
                    });
                }
            }

            Reload();
            await gridCrossRefFiles.Reload();
        }

        protected async System.Threading.Tasks.Task ButtonAddCrossReferenceClaimsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>("Claims", new Dictionary<string, object>() { { "ProgramID", claim.ProgramID }, { "ExcludeClaimID", intClaimID }, { "SelectClaim", true } }, new DialogOptions() { Width = $"{"90%"}", Height = $"{"80%"}" });
            if (dialogResult != null && dialogResult != 0)
            {
                var xrefId = (int)dialogResult;
                var claimList = (await RecoDb.GetClaimLists())
                    .FirstOrDefault(cl => cl.ClaimID == xrefId);
                var ClaimPrincipal = (await RecoDb.GetClaimPrincipals())
                    .FirstOrDefault(cp => cp.ClaimID == xrefId);
                var newXrefClaim = new RecoCms6.Models.RecoDb.XRefClaim
                {
                    BaseClaimID = claim.ClaimID,
                    XRefClaimID = xrefId,
                    XRefClaimNo = claimList?.ClaimNo,
                    XRefInsureds = ClaimPrincipal?.Insureds,
                    FileHandler = claimList?.FileHandler,
                    DefenceCounsel = claimList?.DefenceCounsel,
                    
                };

                XRefClaimsListToAdd.Add(newXrefClaim);

                Reload();
                await gridCrossRefFiles.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ClaimDescriptionChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task CoverageIssueChange(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ReservationOfRightsIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ReservationOfRightsOtherChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ReservationOfRightsDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DeniedChange(bool? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DenialCodeIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DenialLetterDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DenialCommentsChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task RecoComplaintChange(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown3Change(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textarea2Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Radiobuttonlist0Change(int? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NotYetReportedChange(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NotYetReportedByIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NumericDaysReminderChange(int? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LossCauseIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task BtnLossCauseTagsClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddLossCauseTag>("Add Loss Cause Tag", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "LossCauseID", claim.LossCauseID } }, new DialogOptions() { Width = $"{800}px" });
        }

        protected async System.Threading.Tasks.Task BoardJurisdictionIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimInitiationIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimConvertedToIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ConvertedToLitigationChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LeaseDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task PriceChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown6Change(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown5Change(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DateClosedChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DepositAmountChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task TradeTypeIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task UrbanOrRuralIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown4Change(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonViewOtherClaimClick(MouseEventArgs args, dynamic data)
        {
            strXRefClaimID = StringExtensions.ToBase64(data.ClaimID);

            UriHelper.NavigateTo($"edit-claim/{strXRefClaimID}", /* force reload */ true);
        }

        protected async System.Threading.Tasks.Task IncreasedDeductibleChange(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DeductibleChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textarea0Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task MisrepresentationChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NegligenceChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NegligentMisrepChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task PunitiveAmountChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task FraudChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task OtherAmountChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimVerificationChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LiabilityChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ApportionmentChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task RealDamagesChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LossPotentialChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task CoverageIssuesChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task CurrentPlanChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textbox0Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimCalcuationChange(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Checkbox5Change(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LitigationTypeIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task MatterSetForTrialChange(bool args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task PretrialDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task TrialDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LitigationDateChange(DateTime? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task TypeOfActionIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textbox2Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textbox3Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textbox4Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Textbox5Change(string args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown1Change(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task StageSettledChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonAddLitigationDateClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimLitigationDate>($"New Claim Litigation Date", new Dictionary<string, object>() { { "ClaimID", ClaimID }, { "LitigationDateID", 0 } }, new DialogOptions() { Width = $"{"50%"}" });
            if (dialogResult != null)
            {
                getClaimLitigationDatesList.Add((ClaimLitigationDate) dialogResult);
                ModifyClaimLitigationDatesList.Add((ClaimLitigationDate) dialogResult);

                await gridLitigationDates.Reload();
            }
        }

        protected async System.Threading.Tasks.Task GridLitigationDatesRowDoubleClick(RecoCms6.Models.RecoDb.ClaimLitigationDate args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimLitigationDate>("Add Claim Litigation Date", new Dictionary<string, object>() { { "ClaimID", ClaimID }, { "LitigationDateID", args.LitigationDateID } }, new DialogOptions() { Width = $"{800}px", Resizable = true });
            if (dialogResult != null)
            {
                var updatedLitigationDate = (ClaimLitigationDate) dialogResult;
                getClaimLitigationDatesList[getClaimLitigationDatesList.IndexOf(args)] = updatedLitigationDate;
                ModifyClaimLitigationDatesList.Add(updatedLitigationDate);

                await gridLitigationDates.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonDeleteLitigationDateClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var deleteClaimLitigationDate = (ClaimLitigationDate)data;
                getClaimLitigationDatesList.Remove(deleteClaimLitigationDate);
                ModifyClaimLitigationDatesList.Add(deleteClaimLitigationDate);
                await gridLitigationDates.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddCostAwardClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddCostAward>($"New Cost Award", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "CostAwardID", 0 } }, new DialogOptions() { Width = $"{"50%"}" });
            if (dialogResult != null)
            {
                getCostAwardsList.Add((CostAward) dialogResult);
                ModifyCostAwardsList.Add((CostAward) dialogResult);

                await gridCostAwards.Reload();
            }
        }

        protected async System.Threading.Tasks.Task GridCostAwardsRowDoubleClick(RecoCms6.Models.RecoDb.CostAward args)
        {
            var dialogResult = await DialogService.OpenAsync<AddCostAward>("Add Cost Award", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "CostAwardID", args.CostAwardID } }, new DialogOptions() { Width = $"{800}px", Resizable = true });
            if (dialogResult != null)
            {
                var updatedCostAward = (CostAward) dialogResult;
                getCostAwardsList[getCostAwardsList.IndexOf(args)] = updatedCostAward;
                ModifyCostAwardsList.Add(updatedCostAward);
                await gridCostAwards.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonDeleteCostAwardClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var deleteCostAward = (CostAward) data;
                getCostAwardsList.Remove(deleteCostAward);
                ModifyCostAwardsList.Add(deleteCostAward);
                gridCostAwards.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddTrade0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTrade>($"Add Trade", new Dictionary<string, object>() { { "TradeID", 0 }, { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"80%"}" });
            if (dialogResult != null)
            {
                var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getTradesList =  recoDbGetTradeDetailsResult.ToList();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddInsured0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInsured>("Add Insured", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "InsuredID", 0 } }, new DialogOptions() { Width = $"{"75%"}", Height = $"{"90%"}" });
            ReloadInsuredList();

            await InvokeAsync(() => { StateHasChanged(); });
        }
		
        protected async System.Threading.Tasks.Task DeleteInsured(ClaimInsured row)
        {
            await RecoDb.DeleteInsured(row.ID);
            await datagrid8.Reload();
        }

        protected async Task DeleteTrade(TradeDetail row)
        {
            await RecoDb.DeleteTrade(row.TradeID);
            var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getTradesList =  recoDbGetTradeDetailsResult.ToList();
        }

        protected async System.Threading.Tasks.Task ButtonAddClaimant1Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimant>("Add Claimant", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "ClaimantID", 0 } }, new DialogOptions() { Width = $"{"80%"}" });
            //await gridClaimants.Reload();

            if (dialogResult != null)
                ReloadClaimantList();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonAddOtherParty2Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddOtherParty>("Add Other Party", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "OtherPartyID", 0 } }, new DialogOptions() { Width = $"{"60%"}" });

            if (dialogResult != null)
                ReloadOtherPartyList();

            await InvokeAsync(() => { StateHasChanged(); });
			await datagridOthers.Reload();
        }

        protected async System.Threading.Tasks.Task ButtonAddExpert3Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddExpert>("Add Expert", new Dictionary<string, object>() { { "ExpertID", 0 }, { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"80%"}" });
            //await gridInsureds.Reload();
            if (dialogResult != null)
                await ReloadExpertList();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonNewTransactionClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTransaction>("Add Transaction", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "TransactionID", 0 } }, new DialogOptions() { Width = $"{"90%"}" });
            //if (dialogResult != null)
            //{
            //    await gridTransactions.Reload();
            //}

            if (dialogResult != null)
            {
                var recoDbGetClaimIndividualTransactionsResult0 = await RecoDb.GetClaimIndividualTransactions(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"TransactionDate desc,TransactionID desc" });
                transactions = recoDbGetClaimIndividualTransactionsResult0.ToList();
                var recoDbGetClaimTotalIncurredByCategoriesResult = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                getTotalIncurred = recoDbGetClaimTotalIncurredByCategoriesResult.ToList();
            }


            if (dialogResult != null)
            {
                var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", claim.ClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                claimfiles =  recoDbGetClaimFilesByUsersResult.ToList();
            }

            if (dialogResult != null)
            {
                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                bFirstRender = false;

                activityLog =  recoDbGetClaimActivityLogsResult.ToList();
            }

            await InvokeAsync(() => { StateHasChanged(); });
            _reservesPaymentsTabLoaded = false;
            await LoadReservesPaymentsTabData();
        }

        protected async System.Threading.Tasks.Task GridTransactionsRowDoubleClick(RecoCms6.Models.RecoDb.ClaimIndividualTransaction args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTransaction>("Add Transaction", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "TransactionID", args.TransactionID } }, new DialogOptions() { Width = $"{"60%"}" });
            if (dialogResult != null)
            {
                var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", claim.ClaimID);
                claimfiles =  recoDbGetClaimFilesByUsersResult.ToList();
            }
        }

        protected async System.Threading.Tasks.Task ButtonVoidTransactionClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to void this transaction?") == true)
            {
                var recoDbVoidTransactionsResult = await RecoDb.VoidTransactions(data.TransactionID);
                await gridTransactions.Reload();

                await gridIncurred.Reload();

                await gridTotalIncurredDetailed.Reload();

                await InvokeAsync(() => { StateHasChanged(); });
            }
        }

        protected async System.Threading.Tasks.Task FieldsetEditNoteExpand(dynamic args)
        {
            DialogOpen();
        }

        protected async System.Threading.Tasks.Task FormNoteInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error on Saving Note", Detail = $"Ensure the Note Type and Subject are filled in", Duration = 6000 });
        }

        protected async System.Threading.Tasks.Task FormNoteSubmit(RecoCms6.Models.RecoDb.Note args)
        {
            SaveNote();
        }

        protected async System.Threading.Tasks.Task DropdownTemplateChange(dynamic args)
        {
            var setFormByTemplatePropertiesResult = await SetFormByTemplateProperties();
        }

        protected async System.Threading.Tasks.Task HtmlEditor0Paste(HtmlEditorPasteEventArgs args)
        {
            args.Html = args.Html.Replace("\n", " ").Replace("\r", " ");
        }

        protected async System.Threading.Tasks.Task ButtonCancelNoteClick(MouseEventArgs args)
        {
            bClearNote = await DialogService.Confirm("Are you sure you want to clear this note?");

            if ((bool)bClearNote)
            {
                note = new Note();
            }

            if ((bool)bClearNote)
            {
                ResetNotesRoles();
            }
        }

        protected async void DatagridActivityLogCellRender(DataGridCellRenderEventArgs<RecoCms6.Models.RecoDb.ClaimActivityLog> args)
        {
            CellRender(args);
        }

        protected async System.Threading.Tasks.Task DatagridActivityLogRowCollapse(dynamic args)
        {
            if (ExpandedNotes.Contains(args.ID.ToString()))
            {
                ExpandedNotes.Remove(args.ID.ToString());
                SetPreference(false);
            }
        }

        protected async System.Threading.Tasks.Task DatagridActivityLogRowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.ClaimActivityLog> args)
        {
            LaunchActivityLogItem(args.Data);
        }

        protected async System.Threading.Tasks.Task DatagridActivityLogRowExpand(RecoCms6.Models.RecoDb.ClaimActivityLog args)
        {
            if (!ExpandedNotes.Contains(args.ID.ToString()))
            {
                ExpandedNotes.Add(args.ID.ToString());
                SetPreference(false);
            }
        }

        protected async void DatagridActivityLogRowRender(RowRenderEventArgs<RecoCms6.Models.RecoDb.ClaimActivityLog> args)
        {
            RowRender(args);
        }

        protected async System.Threading.Tasks.Task GridActivityLogRowDoubleClick(RecoCms6.Models.RecoDb.ClaimActivityLog args)
        {
            LaunchActivityLogItem(args);
        }

        protected async void GridActivityLogRowRender(RowRenderEventArgs<RecoCms6.Models.RecoDb.ClaimActivityLog> args)
        {
            RowRender(args);
        }

        protected async System.Threading.Tasks.Task BtnAddFileClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFile>($"Add Document", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"60%"}" });
            var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", intClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            claimfiles =  recoDbGetClaimFilesByUsersResult.ToList();

            var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            activityLog =  recoDbGetClaimActivityLogsResult.ToList();
        }

        protected async void GridfilesCellRender(CellRenderEventArgs<RecoCms6.Models.RecoDb.ClaimFilesByUser> args)
        {
            GridFileCellRender(args);
        }

        protected async System.Threading.Tasks.Task GridfilesRowDoubleClick(RecoCms6.Models.RecoDb.ClaimFilesByUser args)
        {
            var dialogResult = await DialogService.OpenAsync<EditFile>("Edit File", new Dictionary<string, object>() { { "ID", args.ID } }, new DialogOptions() { Width = $"{"60%"}" });
            if (dialogResult != null)
            {
                var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", claim.ClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                claimfiles =  recoDbGetClaimFilesByUsersResult.ToList();
            }
        }

        protected async System.Threading.Tasks.Task ButtonDownloadFileClick(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data.FileID);
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbDeleteFileResult = await RecoDb.DeleteFile(data.ID);
                await ReloadFiles();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddDiaryClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEditDiary>($"Add Diary", new Dictionary<string, object>() { { "Start", DateTime.Today }, { "End", DateTime.Today }, { "ClaimID", intClaimID }, { "DiaryID", null } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true, Draggable = true });

            var recoDbGetClaimDiaryDetailsResult = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
            diaries = recoDbGetClaimDiaryDetailsResult.ToList();

            await gridDiaries.Reload();

            await InvokeAsync(() => { StateHasChanged(); });

            if (intClaimID == -1)
            {
                await DialogService.OpenAsync<DiaryCalendar>("Diary Calendar", new Dictionary<string, object>() { { "ClaimID", intClaimID } }, new DialogOptions() { Width = $"{1024}px" });
            }
        }

        protected async System.Threading.Tasks.Task GridDiariesRowDoubleClick(RecoCms6.Models.RecoDb.ClaimDiaryDetail args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEditDiary>($"Edit Diary", new Dictionary<string, object>() { { "Start", null }, { "End", null }, { "ClaimID", claim.ClaimID }, { "DiaryID", args.ID } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true, Draggable = true });
            if (dialogResult != null)
            {
                var recoDbGetClaimDiaryDetailsResult = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
                diaries = recoDbGetClaimDiaryDetailsResult.ToList();

                await gridDiaries.Reload();
            }

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task DataGridTradesRowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.TradeDetail> args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTrade>($"Add Trade", new Dictionary<string, object>() { { "TradeID", args.Data.TradeID }, { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"80%"}" });
            if (dialogResult != null)
            {
                var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getTradesList = recoDbGetTradeDetailsResult.ToList();
            }

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task DataGridClaimantsRowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.ClaimClaimant> args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimant>("Add Claimant", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "ClaimantID", args.Data.ClaimantID } }, new DialogOptions() { Width = $"{"80%"}" });

            if (dialogResult != null)
                ReloadClaimantList();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task DataGridInsuredsRowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.ClaimInsured> args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInsured>("Add Insured", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "InsuredID", args.Data.InsuredID } }, new DialogOptions() { Width = $"{"75%"}", Height = $"{"90%"}" });

            if (dialogResult != null)
                ReloadInsuredList();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task DataGridOthersRowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.ClaimOtherParty> args)
        {
            var dialogResult = await DialogService.OpenAsync<AddOtherParty>("Add Other Party", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "OtherPartyID", args.Data.OtherPartyID } }, new DialogOptions() { Width = $"{"60%"}" });
            if (dialogResult != null)
                ReloadOtherPartyList();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task DataGridExpertsRowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.ClaimExpert> args)
        {
            var dialogResult = await DialogService.OpenAsync<AddExpert>("Add Expert", new Dictionary<string, object>() { { "ExpertID", args.Data.ExpertID }, { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"80%"}" });
            //await gridInsureds.Reload();
            if (dialogResult != null)
                await ReloadExpertList();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonDeleteDiaryClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbDeleteDiaryResult = await RecoDb.DeleteDiary(data.ID);
                var recoDbGetClaimDiaryDetailsResult = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
                diaries = recoDbGetClaimDiaryDetailsResult.ToList();
                await gridDiaries.Reload();

                await InvokeAsync(() => { StateHasChanged(); });
            }
        }

        protected async System.Threading.Tasks.Task FormReportInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            await ShowFormErrors(args);
        }

        protected async System.Threading.Tasks.Task FormReportSubmit(RecoCms6.Models.RecoDb.ClaimReport args)
        {
            await ShowBusyDialog();
        }

        protected async System.Threading.Tasks.Task ButtonSaveClick(MouseEventArgs args)
        {
            IsSubmitEvent = false;

            try
            {
                var saveReportResult = await SaveReport();
                if (saveReportResult == true)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Claim Report Successfully Saved" });
                }

                if (saveReportResult == false)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable to save Claim Report" });
                }
            }
            catch (System.Exception saveReportException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Problem Saving Claim Report", Detail = $"{saveReportException.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonSubmitClick(MouseEventArgs args)
        {
            IsSubmitEvent = true;
        }

        protected async System.Threading.Tasks.Task TemplateFormEmailInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            isClaimEmailSubmit = true;

            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Detail = $"Correct Error on Form Before Sending" });
        }

        protected async System.Threading.Tasks.Task TemplateFormEmailSubmit(RecoCms6.Models.RecoMail args)
        {
            isClaimEmailSubmit = true;

            await ShowBusyEmailDialog();
        }

        protected async System.Threading.Tasks.Task TextboxToChange(string args)
        {
            ToAddressessChanged();
        }

        protected async System.Threading.Tasks.Task ButtonAddToClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Claim Email Addresses", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID } });
            if (dialogResult != Enumerable.Empty<string>())
            {
                ToAddressesAdd(dialogResult);
            }
        }

        protected async System.Threading.Tasks.Task TextboxCcChange(string args)
        {
            CCAddressessChanged();
        }

        protected async System.Threading.Tasks.Task ButtonAddCcClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Claim Email Addresses", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID } });
            if (dialogResult != Enumerable.Empty<string>())
            {
                CCAddressesAdd(dialogResult);
            }
        }

        protected async System.Threading.Tasks.Task TextboxBccChange(string args)
        {
            BCCAddressesChanged();
        }

        protected async System.Threading.Tasks.Task ButtonAddBccClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Claim Email Addresses", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID } });
            if (dialogResult != Enumerable.Empty<string>())
            {
                BccAddressesAdd(dialogResult);
            }
        }

        protected async System.Threading.Tasks.Task Dropdown2Change(dynamic args)
        {
            var setEmailByTemplatePropertiesResult = await SetEmailByTemplateProperties();
        }

        protected async System.Threading.Tasks.Task ButtonClearEmailClick(MouseEventArgs args)
        {
            ClearEmailForm();
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
            var dialogResult = await DialogService.OpenAsync<DialogSelectFile>($"Claim Documents", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"80%"}", Height = $"{"80%"}" });
            if (dialogResult != null && newRecoMail.ClaimFiles != null)
            {
                newRecoMail.ClaimFiles.AddRange(dialogResult);
            }

            if (dialogResult != null && newRecoMail.ClaimFiles == null)
            {
                newRecoMail.ClaimFiles = dialogResult;
            }

            if (dialogResult != null)
            {
                Attachments = newRecoMail.Filenames();
            }

            if (dialogResult != null)
            {
                await datagridClaimFiles.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonDeleteNoteClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to remove this note?") == true)
            {
                newRecoMail.Notes.Remove(data);
            }

            await datagridNotes.Reload();

            Notes = newRecoMail.NoteSubjects();
        }

        protected async System.Threading.Tasks.Task ButtonAddNotesClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectNote>($"Claim Notes", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID } }, new DialogOptions() { Width = $"{"80%"}", Height = $"{"80%"}" });
            if (dialogResult != null && newRecoMail.Notes != null)
            {
                newRecoMail.Notes.AddRange(dialogResult);
            }

            if (dialogResult != null && newRecoMail.Notes == null)
            {
                newRecoMail.Notes = dialogResult;
            }

            if (dialogResult != null)
            {
                Notes = newRecoMail.NoteSubjects();
            }

            if (dialogResult != null)
            {
                await datagridNotes.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonRemoveFileClick(MouseEventArgs args)
        {
            RemoveSelectedFile();
        }

        public async Task OnTradeClick(DataGridRowMouseEventArgs<TradeDetail> row)
        {
            var updatedTrade = await DialogService.OpenAsync<AddTrade>("Edit Trade",
                new Dictionary<string, object>() { { "TradeID", row.Data.TradeID}, { "ClaimID", intClaimID } }, 
                new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });
            if (updatedTrade != null)
            {
                var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getTradesList = recoDbGetTradeDetailsResult.ToList();
            }

            await InvokeAsync(() => { StateHasChanged(); });
            await datagridTrades.Reload();
        }
        
        public async Task OnInsuredClick(DataGridRowMouseEventArgs<ClaimInsured> row)
        {
            var updated = await DialogService.OpenAsync<AddInsured>("Edit Insured",
                new Dictionary<string, object>() { { "ID", row.Data.ID}, { "ClaimID", intClaimID }, { "InsuredID", row.Data.InsuredID } }, 
                new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });

            ReloadInsuredList();
            await datagridInsureds.Reload();
        }
        
        public async Task OnClaimantClick(DataGridRowMouseEventArgs<ClaimClaimant> row)
        {
            var updated = await DialogService.OpenAsync<AddClaimant>("Edit Claimant",
                new Dictionary<string, object>() { { "ID", row.Data.ID}, { "ClaimID", intClaimID }, { "ClaimantID", row.Data.ClaimantID } }, 
                new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });

            ReloadClaimantList();
            await datagridClaimants.Reload();
        }
        
        public async Task OnOtherPartyClick(DataGridRowMouseEventArgs<ClaimOtherParty> row)
        {
            var updated = await DialogService.OpenAsync<AddOtherParty>("Edit Other Party",
                new Dictionary<string, object>(){ { "ID", row.Data.ID}, { "ClaimID", intClaimID }, { "OtherPartyID", row.Data.OtherPartyID } }, 
                new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });
            ReloadOtherPartyList();
            await datagridOthers.Reload();
        }
        
        public async Task OnExpertsClick(DataGridRowMouseEventArgs<ClaimExpert> row)
        {
            var updated = await DialogService.OpenAsync<AddExpert>("Edit Expert",
                new Dictionary<string, object>(){ { "ExpertID", row.Data.ExpertID}, { "ClaimID", intClaimID } }, 
                new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });
            await ReloadExpertList();
            await datagridExperts.Reload();
        }
    }
}
