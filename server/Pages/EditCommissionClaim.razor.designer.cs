using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
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
    public partial class EditCommissionClaimComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> gridTotalIncurredDetailed;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory> datagridOccurenceTotalIncurred;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.OccurrenceClaimant> datagrid0;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.OccurrenceClaimTrade> datagrid1;
        protected RadzenGrid<RecoCms6.Models.RecoDb.CommissionInstallment> gridCommissionInstallments;
        protected RadzenGrid<RecoCms6.Models.RecoDb.XRefClaim> gridCrossRefFiles;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> gridTransactions;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimActivityLog> datagridActivityLog;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimActivityLog> gridActivityLog;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimFilesByUser> gridfiles;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimDiaryDetail> gridDiaries;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> gridReports;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid2;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid3;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid4;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid5;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid6;
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimReportDetail> datagrid7;
        protected RadzenDataGrid<dynamic> datagridClaimFiles;
        protected RadzenDataGrid<dynamic> datagridNotes;

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

        RecoCms6.Models.RecoDb.Claim _masterclaim;
        protected RecoCms6.Models.RecoDb.Claim masterclaim
        {
            get
            {
                return _masterclaim;
            }
            set
            {
                if (!object.Equals(_masterclaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "masterclaim", NewValue = value, OldValue = _masterclaim };
                    _masterclaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int? _claimantID;
        protected int? claimantID
        {
            get
            {
                return _claimantID;
            }
            set
            {
                if (!object.Equals(_claimantID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimantID", NewValue = value, OldValue = _claimantID };
                    _claimantID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Claimant _claimant = new();
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

        RecoCms6.Models.RecoDb.Trade _trade = new();
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
                    var args = new PropertyChangedEventArgs(){ Name = "currentStatusID", NewValue = value, OldValue = _currentStatusID };
                    _currentStatusID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ServiceProviderDetail> _getAdjustersList  = new List<ServiceProviderDetail>();
        protected IEnumerable<ServiceProviderDetail> getAdjustersList
        {
            get
            {
                return _getAdjustersList;
            }
            set
            {
                if (!object.Equals(_getAdjustersList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAdjustersList", NewValue = value, OldValue = _getAdjustersList };
                    _getAdjustersList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getFileHandlerList = new List<RecoCms6.Models.RecoDb.ServiceProviderDetail>();
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

        IEnumerable<ServiceProviderDetail> _getDefenseCounselList = new List<ServiceProviderDetail>();

        protected IEnumerable<ServiceProviderDetail> getDefenseCounselList
        {
            get
            {
                return _getDefenseCounselList;
            }
            set
            {
                if (!object.Equals(_getDefenseCounselList, value))
                {
                    var args = new PropertyChangedEventArgs()
                        { Name = "getDefenseCounselList", NewValue = value, OldValue = _getDefenseCounselList };
                    _getDefenseCounselList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private IEnumerable<ServiceProviderDetail> _getReportsToList = new List<ServiceProviderDetail>();
        protected IEnumerable<ServiceProviderDetail> getReportsToList
        {
            get
            {
                return _getReportsToList;
            }
            set
            {
                if (!object.Equals(_getReportsToList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getReportsToList", NewValue = value, OldValue = _getReportsToList };
                    _getReportsToList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProviderDetail _getFileHandler = new();
        protected RecoCms6.Models.RecoDb.ServiceProviderDetail getFileHandler
        {
            get
            {
                return _getFileHandler;
            }
            set
            {
                if (!object.Equals(_getFileHandler, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFileHandler", NewValue = value, OldValue = _getFileHandler };
                    _getFileHandler = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Brokerage> _getBrokeragesResult = new List<Models.RecoDb.Brokerage>();
        protected IEnumerable<RecoCms6.Models.RecoDb.Brokerage> getBrokeragesResult
        {
            get
            {
                return _getBrokeragesResult;
            }
            set
            {
                if (!object.Equals(_getBrokeragesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBrokeragesResult", NewValue = value, OldValue = _getBrokeragesResult };
                    _getBrokeragesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ParameterDetail> _getClaimStatusList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getClaimStatusList
        {
            get
            {
                return _getClaimStatusList;
            }
            set
            {
                if (!object.Equals(_getClaimStatusList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimStatusList", NewValue = value, OldValue = _getClaimStatusList };
                    _getClaimStatusList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ParameterDetail> _getYesNoNAList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getYesNoNAList
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

        IEnumerable<ParameterDetail> _getProvinceList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getProvinceList
        {
            get
            {
                return _getProvinceList;
            }
            set
            {
                if (!object.Equals(_getProvinceList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProvinceList", NewValue = value, OldValue = _getProvinceList };
                    _getProvinceList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ParameterDetail> _getBrokerageOnlyList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getBrokerageOnlyList
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

        IEnumerable<ParameterDetail> _getTradeTypeList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getTradeTypeList
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

        IEnumerable<ParameterDetail> _getOccurenceReasonList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getOccurenceReasonList
        {
            get
            {
                return _getOccurenceReasonList;
            }
            set
            {
                if (!object.Equals(_getOccurenceReasonList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOccurenceReasonList", NewValue = value, OldValue = _getOccurenceReasonList };
                    _getOccurenceReasonList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getCDProgramID;
        protected int getCDProgramID
        {
            get
            {
                return _getCDProgramID;
            }
            set
            {
                if (!object.Equals(_getCDProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCDProgramID", NewValue = value, OldValue = _getCDProgramID };
                    _getCDProgramID = value;
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

        int _getCPProgramID;
        protected int getCPProgramID
        {
            get
            {
                return _getCPProgramID;
            }
            set
            {
                if (!object.Equals(_getCPProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCPProgramID", NewValue = value, OldValue = _getCPProgramID };
                    _getCPProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ParameterDetail> _getRORList = new List<ParameterDetail>();
        protected IEnumerable<ParameterDetail> getRORList
        {
            get
            {
                return _getRORList;
            }
            set
            {
                if (!object.Equals(_getRORList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRORList", NewValue = value, OldValue = _getRORList };
                    _getRORList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getIndemnityTypeID;
        protected int getIndemnityTypeID
        {
            get
            {
                return _getIndemnityTypeID;
            }
            set
            {
                if (!object.Equals(_getIndemnityTypeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getIndemnityTypeID", NewValue = value, OldValue = _getIndemnityTypeID };
                    _getIndemnityTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLegalTypeID;
        protected int getLegalTypeID
        {
            get
            {
                return _getLegalTypeID;
            }
            set
            {
                if (!object.Equals(_getLegalTypeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLegalTypeID", NewValue = value, OldValue = _getLegalTypeID };
                    _getLegalTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getAdjustingTypeID;
        protected int getAdjustingTypeID
        {
            get
            {
                return _getAdjustingTypeID;
            }
            set
            {
                if (!object.Equals(_getAdjustingTypeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAdjustingTypeID", NewValue = value, OldValue = _getAdjustingTypeID };
                    _getAdjustingTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getExpenseTypeID;
        protected int getExpenseTypeID
        {
            get
            {
                return _getExpenseTypeID;
            }
            set
            {
                if (!object.Equals(_getExpenseTypeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getExpenseTypeID", NewValue = value, OldValue = _getExpenseTypeID };
                    _getExpenseTypeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getReserveCategoryID;
        protected int getReserveCategoryID
        {
            get
            {
                return _getReserveCategoryID;
            }
            set
            {
                if (!object.Equals(_getReserveCategoryID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getReserveCategoryID", NewValue = value, OldValue = _getReserveCategoryID };
                    _getReserveCategoryID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _PageSizes = new List<ParameterDetail>();
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getOccurrenceStatusList = new List<ParameterDetail>();
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getOccurrenceStatusList
        {
            get
            {
                return _getOccurrenceStatusList;
            }
            set
            {
                if (!object.Equals(_getOccurrenceStatusList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOccurrenceStatusList", NewValue = value, OldValue = _getOccurrenceStatusList };
                    _getOccurrenceStatusList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getNoteTypeList = new List<ParameterDetail>();
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getNoteTypeList
        {
            get
            {
                return _getNoteTypeList;
            }
            set
            {
                if (!object.Equals(_getNoteTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getNoteTypeList", NewValue = value, OldValue = _getNoteTypeList };
                    _getNoteTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCountryList = new List<ParameterDetail>();
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCountryList
        {
            get
            {
                return _getCountryList;
            }
            set
            {
                if (!object.Equals(_getCountryList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCountryList", NewValue = value, OldValue = _getCountryList };
                    _getCountryList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isCPProgram;
        protected bool isCPProgram
        {
            get
            {
                return _isCPProgram;
            }
            set
            {
                if (!object.Equals(_isCPProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isCPProgram", NewValue = value, OldValue = _isCPProgram };
                    _isCPProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isCDProgram;
        protected bool isCDProgram
        {
            get
            {
                return _isCDProgram;
            }
            set
            {
                if (!object.Equals(_isCDProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isCDProgram", NewValue = value, OldValue = _isCDProgram };
                    _isCDProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }


        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimantTransactionRolesList = new List<ParameterDetail>();
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getClaimantTransactionRolesList
        {
            get
            {
                return _getClaimantTransactionRolesList;
            }
            set
            {
                if (!object.Equals(_getClaimantTransactionRolesList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimantTransactionRolesList", NewValue = value, OldValue = _getClaimantTransactionRolesList };
                    _getClaimantTransactionRolesList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getPaymentsOwedList = new List<ParameterDetail>();
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getPaymentsOwedList
        {
            get
            {
                return _getPaymentsOwedList;
            }
            set
            {
                if (!object.Equals(_getPaymentsOwedList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPaymentsOwedList", NewValue = value, OldValue = _getPaymentsOwedList };
                    _getPaymentsOwedList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _filterFileType;
        protected string filterFileType
        {
            get
            {
                return _filterFileType;
            }
            set
            {
                if (!object.Equals(_filterFileType, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "filterFileType", NewValue = value, OldValue = _filterFileType };
                    _filterFileType = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _tradeBuyerCDFile;
        protected int tradeBuyerCDFile
        {
            get
            {
                return _tradeBuyerCDFile;
            }
            set
            {
                if (!object.Equals(_tradeBuyerCDFile, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tradeBuyerCDFile", NewValue = value, OldValue = _tradeBuyerCDFile };
                    _tradeBuyerCDFile = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _tradeSellerCDFile;
        protected int tradeSellerCDFile
        {
            get
            {
                return _tradeSellerCDFile;
            }
            set
            {
                if (!object.Equals(_tradeSellerCDFile, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tradeSellerCDFile", NewValue = value, OldValue = _tradeSellerCDFile };
                    _tradeSellerCDFile = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _tradeSharedAgentClaim;
        protected int tradeSharedAgentClaim
        {
            get
            {
                return _tradeSharedAgentClaim;
            }
            set
            {
                if (!object.Equals(_tradeSharedAgentClaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tradeSharedAgentClaim", NewValue = value, OldValue = _tradeSharedAgentClaim };
                    _tradeSharedAgentClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _tradeSharedAgent;
        protected int tradeSharedAgent
        {
            get
            {
                return _tradeSharedAgent;
            }
            set
            {
                if (!object.Equals(_tradeSharedAgent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tradeSharedAgent", NewValue = value, OldValue = _tradeSharedAgent };
                    _tradeSharedAgent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Claim> _getAssocCDClaimsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Claim> getAssocCDClaimsResult
        {
            get
            {
                return _getAssocCDClaimsResult;
            }
            set
            {
                if (!object.Equals(_getAssocCDClaimsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAssocCDClaimsResult", NewValue = value, OldValue = _getAssocCDClaimsResult };
                    _getAssocCDClaimsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> _getTotalIncurred;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> getTotalIncurred
        {
            get
            {
                return _getTotalIncurred;
            }
            set
            {
                if (!object.Equals(_getTotalIncurred, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTotalIncurred", NewValue = value, OldValue = _getTotalIncurred };
                    _getTotalIncurred = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> _transactions;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                if (!object.Equals(_transactions, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "transactions", NewValue = value, OldValue = _transactions };
                    _transactions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimDiaryDetail> _diaries;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimDiaryDetail> diaries
        {
            get
            {
                return _diaries;
            }
            set
            {
                if (!object.Equals(_diaries, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "diaries", NewValue = value, OldValue = _diaries };
                    _diaries = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IList<CppOtherPartyViewModel> _getOtherPartyList;
        protected IList<CppOtherPartyViewModel> getOtherPartyList
        {
            get
            {
                return _getOtherPartyList;
            }
            set
            {
                if (!object.Equals(_getOtherPartyList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOtherPartyList", NewValue = value, OldValue = _getOtherPartyList };
                    _getOtherPartyList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IList<ExpertViewModel> _getExpertList;
        protected IList<ExpertViewModel> getExpertList
        {
            get
            {
                return _getExpertList;
            }
            set
            {
                if (!object.Equals(_getExpertList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getExpertList", NewValue = value, OldValue = _getExpertList };
                    _getExpertList = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.Receiver> _getReceiversList;
        protected IEnumerable<RecoCms6.Models.RecoDb.Receiver> getReceiversList
        {
            get
            {
                return _getReceiversList;
            }
            set
            {
                if (!object.Equals(_getReceiversList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getReceiversList", NewValue = value, OldValue = _getReceiversList };
                    _getReceiversList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private List<RecoCms6.Models.RecoDb.XRefClaim> XRefClaimsListToAdd = new();
        private List<RecoCms6.Models.RecoDb.XRefClaim> XRefClaimsListToDelete = new();
        public IEnumerable<RecoCms6.Models.RecoDb.XRefClaim> ViewGetXRefClaimsList
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

        IEnumerable<RecoCms6.Models.RecoDb.Registrant> _getSharedAgent;
        protected IEnumerable<RecoCms6.Models.RecoDb.Registrant> getSharedAgent
        {
            get
            {
                return _getSharedAgent;
            }
            set
            {
                if (!object.Equals(_getSharedAgent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSharedAgent", NewValue = value, OldValue = _getSharedAgent };
                    _getSharedAgent = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "selectedTab", NewValue = value, OldValue = _selectedTab };
                    _selectedTab = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "currentTab", NewValue = value, OldValue = _currentTab };
                    _currentTab = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "NoticeOfClaimRefNum", NewValue = value, OldValue = _NoticeOfClaimRefNum };
                    _NoticeOfClaimRefNum = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Note _note;
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
                    var args = new PropertyChangedEventArgs(){ Name = "note", NewValue = value, OldValue = _note };
                    _note = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Role> _roles;
        protected IEnumerable<RecoCms6.Models.RecoDb.Role> roles
        {
            get
            {
                return _roles;
            }
            set
            {
                if (!object.Equals(_roles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "roles", NewValue = value, OldValue = _roles };
                    _roles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> _getEmailTemplateResults;
        protected IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> getEmailTemplateResults
        {
            get
            {
                return _getEmailTemplateResults;
            }
            set
            {
                if (!object.Equals(_getEmailTemplateResults, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEmailTemplateResults", NewValue = value, OldValue = _getEmailTemplateResults };
                    _getEmailTemplateResults = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> _getNoteTemplateResults;
        protected IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> getNoteTemplateResults
        {
            get
            {
                return _getNoteTemplateResults;
            }
            set
            {
                if (!object.Equals(_getNoteTemplateResults, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getNoteTemplateResults", NewValue = value, OldValue = _getNoteTemplateResults };
                    _getNoteTemplateResults = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "TemplateID", NewValue = value, OldValue = _TemplateID };
                    _TemplateID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<int> _selectedroles;
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
                    var args = new PropertyChangedEventArgs(){ Name = "selectedroles", NewValue = value, OldValue = _selectedroles };
                    _selectedroles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.CommissionInstallment> _getCommissionInstallmentsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.CommissionInstallment> getCommissionInstallmentsList
        {
            get
            {
                return _getCommissionInstallmentsList;
            }
            set
            {
                if (!object.Equals(_getCommissionInstallmentsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommissionInstallmentsList", NewValue = value, OldValue = _getCommissionInstallmentsList };
                    _getCommissionInstallmentsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Builder> _getBuildersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Builder> getBuildersResult
        {
            get
            {
                return _getBuildersResult;
            }
            set
            {
                if (!object.Equals(_getBuildersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBuildersResult", NewValue = value, OldValue = _getBuildersResult };
                    _getBuildersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<int> _Roles;
        protected IEnumerable<int> Roles
        {
            get
            {
                return _Roles;
            }
            set
            {
                if (!object.Equals(_Roles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Roles", NewValue = value, OldValue = _Roles };
                    _Roles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Registrant> _getRegistrantsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Registrant> getRegistrantsResult
        {
            get
            {
                return _getRegistrantsResult;
            }
            set
            {
                if (!object.Equals(_getRegistrantsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRegistrantsResult", NewValue = value, OldValue = _getRegistrantsResult };
                    _getRegistrantsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimant> _claimantlist;
        protected IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimant> claimantlist
        {
            get
            {
                return _claimantlist;
            }
            set
            {
                if (!object.Equals(_claimantlist, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimantlist", NewValue = value, OldValue = _claimantlist };
                    _claimantlist = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimTrade> _tradelist;
        protected IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimTrade> tradelist
        {
            get
            {
                return _tradelist;
            }
            set
            {
                if (!object.Equals(_tradelist, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tradelist", NewValue = value, OldValue = _tradelist };
                    _tradelist = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> _claimreports;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimReportDetail> claimreports
        {
            get
            {
                return _claimreports;
            }
            set
            {
                if (!object.Equals(_claimreports, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimreports", NewValue = value, OldValue = _claimreports };
                    _claimreports = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _parameterFlags = new List<ParameterDetail>();
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
        
        bool _claimIsDirty;
        protected bool claimIsDirty
        {
            get
            {
                return _claimIsDirty;
            }
            set
            {
                if (!object.Equals(_claimIsDirty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimIsDirty", NewValue = value, OldValue = _claimIsDirty };
                    _claimIsDirty = value;
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

        bool _masterIsDirty;
        protected bool masterIsDirty
        {
            get
            {
                return _masterIsDirty;
            }
            set
            {
                if (!object.Equals(_masterIsDirty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "masterIsDirty", NewValue = value, OldValue = _masterIsDirty };
                    _masterIsDirty = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _claimantIsDirty;
        protected bool claimantIsDirty
        {
            get
            {
                return _claimantIsDirty;
            }
            set
            {
                if (!object.Equals(_claimantIsDirty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimantIsDirty", NewValue = value, OldValue = _claimantIsDirty };
                    _claimantIsDirty = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _noteIsDirty;
        protected bool noteIsDirty
        {
            get
            {
                return _noteIsDirty;
            }
            set
            {
                if (!object.Equals(_noteIsDirty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "noteIsDirty", NewValue = value, OldValue = _noteIsDirty };
                    _noteIsDirty = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "claimsummary", NewValue = value, OldValue = _claimsummary };
                    _claimsummary = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.OccurrenceClaimant> _selectedclaimants = new List<OccurrenceClaimant>();
        protected List<RecoCms6.Models.RecoDb.OccurrenceClaimant> selectedclaimants
        {
            get
            {
                return _selectedclaimants;
            }
            set
            {
                if (!object.Equals(_selectedclaimants, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedclaimants", NewValue = value, OldValue = _selectedclaimants };
                    _selectedclaimants = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _claimantpagesize;
        protected int claimantpagesize
        {
            get
            {
                return _claimantpagesize;
            }
            set
            {
                if (!object.Equals(_claimantpagesize, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimantpagesize", NewValue = value, OldValue = _claimantpagesize };
                    _claimantpagesize = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "selectedFileReportIds", NewValue = value, OldValue = _selectedFileReportIds };
                    _selectedFileReportIds = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimList _claimList = new ClaimList();
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
                    var args = new PropertyChangedEventArgs(){ Name = "claimList", NewValue = value, OldValue = _claimList };
                    _claimList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private RecoCms6.Models.RecoDb.ClaimList _masterclaimList = new();
        protected RecoCms6.Models.RecoDb.ClaimList masterclaimList
        {
            get
            {
                return _masterclaimList;
            }
            set
            {
                if (!object.Equals(_masterclaimList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "masterclaimList", NewValue = value, OldValue = _masterclaimList };
                    _masterclaimList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory> _getOccurrenceTotalIncurred = new List<OccurrenceTotalIncurredByCategory>();
        protected IEnumerable<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory> getOccurrenceTotalIncurred
        {
            get
            {
                return _getOccurrenceTotalIncurred;
            }
            set
            {
                if (!object.Equals(_getOccurrenceTotalIncurred, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOccurrenceTotalIncurred", NewValue = value, OldValue = _getOccurrenceTotalIncurred };
                    _getOccurrenceTotalIncurred = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _avExtensions = new();
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
                    var args = new PropertyChangedEventArgs(){ Name = "imageExtensions", NewValue = value, OldValue = _imageExtensions };
                    _imageExtensions = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "docExtensions", NewValue = value, OldValue = _docExtensions };
                    _docExtensions = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimActivityLog> _activityLog = new List<ClaimActivityLog>();
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
                    var args = new PropertyChangedEventArgs(){ Name = "bAttachToClaim", NewValue = value, OldValue = _bAttachToClaim };
                    _bAttachToClaim = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "bFirstRender", NewValue = value, OldValue = _bFirstRender };
                    _bFirstRender = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "bNewNote", NewValue = value, OldValue = _bNewNote };
                    _bNewNote = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bCollapsedNote;
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
                    var args = new PropertyChangedEventArgs(){ Name = "bCollapsedNote", NewValue = value, OldValue = _bCollapsedNote };
                    _bCollapsedNote = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _ExpandedNotes = new();
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
                    var args = new PropertyChangedEventArgs(){ Name = "ExpandedNotes", NewValue = value, OldValue = _ExpandedNotes };
                    _ExpandedNotes = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }


        IEnumerable<RecoCms6.Models.RecoDb.StandardEmailAddress> _standardEmails;
        protected IEnumerable<RecoCms6.Models.RecoDb.StandardEmailAddress> standardEmails
        {
            get
            {
                return _standardEmails;
            }
            set
            {
                if (!object.Equals(_standardEmails, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "standardEmails", NewValue = value, OldValue = _standardEmails };
                    _standardEmails = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "bSuccessfulSave", NewValue = value, OldValue = _bSuccessfulSave };
                    _bSuccessfulSave = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "bIsNewClaimDetail", NewValue = value, OldValue = _bIsNewClaimDetail };
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
                    var args = new PropertyChangedEventArgs(){ Name = "selectedClaimStatusValue", NewValue = value, OldValue = _selectedClaimStatusValue };
                    _selectedClaimStatusValue = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal _indemnityreserve;
        protected decimal indemnityreserve
        {
            get
            {
                return _indemnityreserve;
            }
            set
            {
                if (!object.Equals(_indemnityreserve, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "indemnityreserve", NewValue = value, OldValue = _indemnityreserve };
                    _indemnityreserve = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal _legalreserve;
        protected decimal legalreserve
        {
            get
            {
                return _legalreserve;
            }
            set
            {
                if (!object.Equals(_legalreserve, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "legalreserve", NewValue = value, OldValue = _legalreserve };
                    _legalreserve = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal _adjustingreserve;
        protected decimal adjustingreserve
        {
            get
            {
                return _adjustingreserve;
            }
            set
            {
                if (!object.Equals(_adjustingreserve, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "adjustingreserve", NewValue = value, OldValue = _adjustingreserve };
                    _adjustingreserve = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        decimal _expensereserve;
        protected decimal expensereserve
        {
            get
            {
                return _expensereserve;
            }
            set
            {
                if (!object.Equals(_expensereserve, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "expensereserve", NewValue = value, OldValue = _expensereserve };
                    _expensereserve = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Transaction _zerotransaction;
        protected RecoCms6.Models.RecoDb.Transaction zerotransaction
        {
            get
            {
                return _zerotransaction;
            }
            set
            {
                if (!object.Equals(_zerotransaction, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "zerotransaction", NewValue = value, OldValue = _zerotransaction };
                    _zerotransaction = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "previousclaimstatus", NewValue = value, OldValue = _previousclaimstatus };
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
                    var args = new PropertyChangedEventArgs(){ Name = "claimstatushistory", NewValue = value, OldValue = _claimstatushistory };
                    _claimstatushistory = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Brokerage _selectedBrokerage;
        protected RecoCms6.Models.RecoDb.Brokerage selectedBrokerage
        {
            get
            {
                return _selectedBrokerage;
            }
            set
            {
                if (!object.Equals(_selectedBrokerage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedBrokerage", NewValue = value, OldValue = _selectedBrokerage };
                    _selectedBrokerage = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Brokerage _selectedbrokerage;
        protected RecoCms6.Models.RecoDb.Brokerage selectedbrokerage
        {
            get
            {
                return _selectedbrokerage;
            }
            set
            {
                if (!object.Equals(_selectedbrokerage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedbrokerage", NewValue = value, OldValue = _selectedbrokerage };
                    _selectedbrokerage = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Registrant _registrant;
        protected RecoCms6.Models.RecoDb.Registrant registrant
        {
            get
            {
                return _registrant;
            }
            set
            {
                if (!object.Equals(_registrant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "registrant", NewValue = value, OldValue = _registrant };
                    _registrant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimantSolicitor> _getClaimantSolicitorsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimantSolicitor> getClaimantSolicitorsResult
        {
            get
            {
                return _getClaimantSolicitorsResult;
            }
            set
            {
                if (!object.Equals(_getClaimantSolicitorsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimantSolicitorsResult", NewValue = value, OldValue = _getClaimantSolicitorsResult };
                    _getClaimantSolicitorsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _claimDirty;
        protected bool claimDirty
        {
            get
            {
                return _claimDirty;
            }
            set
            {
                if (!object.Equals(_claimDirty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimDirty", NewValue = value, OldValue = _claimDirty };
                    _claimDirty = value;
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

        int _buyerCDFileID;
        protected int buyerCDFileID
        {
            get
            {
                return _buyerCDFileID;
            }
            set
            {
                if (!object.Equals(_buyerCDFileID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "buyerCDFileID", NewValue = value, OldValue = _buyerCDFileID };
                    _buyerCDFileID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _sellerCDFileID;
        protected int sellerCDFileID
        {
            get
            {
                return _sellerCDFileID;
            }
            set
            {
                if (!object.Equals(_sellerCDFileID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sellerCDFileID", NewValue = value, OldValue = _sellerCDFileID };
                    _sellerCDFileID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Registrant _sharedAgent;
        protected RecoCms6.Models.RecoDb.Registrant sharedAgent
        {
            get
            {
                return _sharedAgent;
            }
            set
            {
                if (!object.Equals(_sharedAgent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sharedAgent", NewValue = value, OldValue = _sharedAgent };
                    _sharedAgent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _sharedAgentClaimID;
        protected int sharedAgentClaimID
        {
            get
            {
                return _sharedAgentClaimID;
            }
            set
            {
                if (!object.Equals(_sharedAgentClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sharedAgentClaimID", NewValue = value, OldValue = _sharedAgentClaimID };
                    _sharedAgentClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _xrefprogramid;
        protected int xrefprogramid
        {
            get
            {
                return _xrefprogramid;
            }
            set
            {
                if (!object.Equals(_xrefprogramid, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "xrefprogramid", NewValue = value, OldValue = _xrefprogramid };
                    _xrefprogramid = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ClaimFilesByUser> _claimfiles;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimFilesByUser> claimfiles
        {
            get
            {
                return _claimfiles;
            }
            set
            {
                if (!object.Equals(_claimfiles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimfiles", NewValue = value, OldValue = _claimfiles };
                    _claimfiles = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "bClearNote", NewValue = value, OldValue = _bClearNote };
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
                    var args = new PropertyChangedEventArgs(){ Name = "IsSubmitEvent", NewValue = value, OldValue = _IsSubmitEvent };
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
                    var args = new PropertyChangedEventArgs(){ Name = "isClaimEmailSubmit", NewValue = value, OldValue = _isClaimEmailSubmit };
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                // await Load();
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            await Load();
        }

        protected async System.Threading.Tasks.Task Load()
        {
            intClaimID = StringExtensions.IntegerFromBase64(ClaimID);

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"", Expand = "ClaimFileReportings" });
            claim = recoDbGetClaimsResult.FirstOrDefault();
            
            var recoDbGetClaimsResult0 = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.MasterFileID } });
            if (!claim.MasterFile) {
                masterclaim = recoDbGetClaimsResult0.FirstOrDefault();
            }
            else
            {
                masterclaim = claim;
            }

            

            claimantID = claim.ClaimantID;
            currentStatusID = claim.ClaimStatusID;

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"Name asc" });
            getFileHandler = recoDbGetServiceProviderDetailsResult.FirstOrDefault(sp=>sp.ServiceProviderID == masterclaim.FileHandlerID);

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });
            
            getCDProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamDesc=="Consumer Deposit Program").FirstOrDefault()?.ParameterID ?? 0;
            isCDProgram = claim.ProgramID == getCDProgramID;

            getEOProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamDesc=="Errors and Omissions").FirstOrDefault()?.ParameterID ?? 0;
            isEOProgram = claim.ProgramID==getEOProgramID;

            getCPProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamDesc=="Commission Protection Program").FirstOrDefault()?.ParameterID ?? 0;
            isCPProgram = claim.ProgramID == getCPProgramID;

            getIndemnityTypeID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Indemnity").FirstOrDefault()?.ParameterID ?? 0;

            getLegalTypeID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Legal").FirstOrDefault()?.ParameterID ?? 0;

            getAdjustingTypeID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Adjusting").FirstOrDefault()?.ParameterID ?? 0;

            getExpenseTypeID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Type" && p.ParamDesc=="Expense").FirstOrDefault()?.ParameterID ?? 0;

            getReserveCategoryID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Incurred Category" && p.ParamDesc=="Reserve").FirstOrDefault()?.ParameterID ?? 0;

            getClaimStatusList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Claim Status").ToList();  

            PageSizes = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Page Size").OrderBy(p=>p.ParamValue);
            
            filterFileType = String.Empty;

            var recoDbGetTradesResult0 = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"DisplayOrder asc" });
            trade = recoDbGetTradesResult0.FirstOrDefault() ?? new RecoCms6.Models.RecoDb.Trade();;

            trade.ClaimID = claim.ClaimID;

            if (trade.BuyerCDFileID != null) {
                tradeBuyerCDFile = (int)trade.BuyerCDFileID;
            }

            if (trade.BuyerCDFileID == null) {
                tradeBuyerCDFile = 0;
            }

            if (trade.SellerCDFileID != null) {
                tradeSellerCDFile = (int)trade.SellerCDFileID;
            }

            if (trade.SellerCDFileID == null) {
                tradeSellerCDFile = 0;
            }

            if (trade.SharedAgentClaimID != null) {
                tradeSharedAgentClaim = (int)trade.SharedAgentClaimID;
            }

            if (trade.SharedAgentClaimID == null) {
                tradeSharedAgentClaim = 0;
            }

            if (trade.SharedAgentID != null) {
                tradeSharedAgent = (int)trade.SharedAgentID;
            }

            if (trade.SharedAgentID == null) {
                tradeSharedAgent = 0;
            }

            var recoDbGetClaimTotalIncurredByCategoriesResult = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            getTotalIncurred = recoDbGetClaimTotalIncurredByCategoriesResult;

            claimdetails = await RecoDb.GetCdpClaimDetailByClaimId(intClaimID) ?? new();

            var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"XRefClaimNo asc" });
            getXRefClaimsList = recoDbGetXRefClaimsResult;

            selectedTab = 0;

            currentTab = 1;

            var recoDbGetNoticeOfClaimsResult = await RecoDb.GetNoticeOfClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            
            NoticeOfClaimRefNum = recoDbGetNoticeOfClaimsResult.FirstOrDefault()?.RefNum ?? "";
            
            note = new Note();

            roles = new List<Role>();

            TemplateID = 0;

            selectedroles = new int[]{1,2,5,6,7,8};
            
            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
            serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();

            claimIsDirty = false;

            tradeIsDirty = false;

            masterIsDirty = false;

            claimantIsDirty = false;

            noteIsDirty = false;

            currentTab = 2;

            if (Security.IsInRole("Accountant")) {
                currentTab = 6;
            }

            var recoDbGetClaimSummariesResult = await RecoDb.GetClaimSummaries(claim.ClaimID);
            claimsummary = (MarkupString)recoDbGetClaimSummariesResult.FirstOrDefault().ClaimSummary1;
            
            selectedFileReportIds = new List<int>();

            loadFileReports();

            var recoDbGetClaimListsResult = await RecoDb.GetClaimLists(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1", FilterParameters = new object[] { claim.ClaimID, claim.MasterFileID } });
            claimList = recoDbGetClaimListsResult.FirstOrDefault(p=>p.ClaimID==claim.ClaimID);

            if (!claim.MasterFile) {
                masterclaimList = recoDbGetClaimListsResult.FirstOrDefault(p=>p.ClaimID==claim.MasterFileID);
            }

            if (claim.MasterFile) {
                masterclaimList = claimList;
            }

            var recoDbGetOccurrenceTotalIncurredByCategoriesResult = await RecoDb.GetOccurrenceTotalIncurredByCategories(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { claim.OccurrenceID } });
            getOccurrenceTotalIncurred = recoDbGetOccurrenceTotalIncurredByCategoriesResult;

            avExtensions = new List<string>{ ".avi", ".mov", ".mp4", ".mp3", ".m4a", ".wav" };

            imageExtensions = new List<string>{ ".png", ".jpeg", ".jpg", ".gif" };

            docExtensions = new List<string>{".pdf", ".xls", ".xlsx", ".doc", ".docx"};

            await ReloadFiles();

            bAttachToClaim = true;

            saveResult = false;

            ClearEmailForm();

            bFirstRender = false;

            bNewNote = true;

            bCollapsedNote = true;

            SetPreference(true);

            ExpandedNotes = new List<string>();

            var recoDbGetStandardEmailAddressesResult = await RecoDb.GetStandardEmailAddresses(new Query() { OrderBy = $"EmailAddress asc" });
            standardEmails = recoDbGetStandardEmailAddressesResult;
        }

        protected async System.Threading.Tasks.Task ButtonSaveDetailsClick(MouseEventArgs args)
        {
            bSuccessfulSave = true;

            if (!isEOProgram) {
                bIsNewClaimDetail = claimdetails.ClaimID == 0;
            }

            if (bIsNewClaimDetail && !isEOProgram) {
                claimdetails.ClaimID = claim.ClaimID;
            }

            if (claim.OriginalFileHandlerID == null) {
                claim.OriginalFileHandlerID = claim.FileHandlerID;
            }

            var recoDbGetParametersResult = await RecoDb.GetParameters(new Query() { Filter = $@"i => i.ParameterID == @0", FilterParameters = new object[] { claim.ClaimStatusID } });
            selectedClaimStatusValue = recoDbGetParametersResult.FirstOrDefault().ParamValue;

            if (currentStatusID != claim.ClaimStatusID && selectedClaimStatusValue==0)
            {
                var recoDbGetClaimTotalIncurredByCategoriesResult = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                indemnityreserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().IndemnityReserve;

                legalreserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().LegalReserve;

                adjustingreserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().AdjustingReserve;

                expensereserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().ExpenseReserve;

                zerotransaction = new RecoCms6.Models.RecoDb.Transaction(){};

                zerotransaction.ClaimID = claim.ClaimID;

                zerotransaction.TransactionDate = DateTime.Now;

                zerotransaction.IncurredCategoryID = getReserveCategoryID;

                zerotransaction.Comments = "Claim Closed, Auto Zeroed Reserve";

                if (indemnityreserve > 0) {
                    zerotransaction.Amount = -1 * indemnityreserve;
                }

                if (indemnityreserve > 0) {
                    zerotransaction.IncurredTypeID = getIndemnityTypeID;
                }

                zerotransaction.ID = Guid.NewGuid();

                if (indemnityreserve > 0)
                {
                    var recoDbCreateTransactionResult = await RecoDb.CreateTransaction(zerotransaction);

                }

                if (adjustingreserve > 0) {
                    zerotransaction.Amount = -1 * adjustingreserve;
                }

                if (adjustingreserve > 0) {
                    zerotransaction.IncurredTypeID = getAdjustingTypeID;
                }

                zerotransaction.ID = Guid.NewGuid();

                zerotransaction.TransactionID = 0;

                if (adjustingreserve > 0)
                {
                    var recoDbCreateTransactionResult0 = await RecoDb.CreateTransaction(zerotransaction);

                }

                if (legalreserve > 0) {
                    zerotransaction.Amount = -1 * legalreserve;
                }

                if (legalreserve > 0) {
                    zerotransaction.IncurredTypeID = getLegalTypeID;
                }

                zerotransaction.ID = Guid.NewGuid();

                zerotransaction.TransactionID = 0;

                if (legalreserve > 0)
                {
                    var recoDbCreateTransactionResult01 = await RecoDb.CreateTransaction(zerotransaction);

                }

                if (expensereserve > 0) {
                    zerotransaction.Amount = -1 * expensereserve;
                }

                if (expensereserve > 0) {
                    zerotransaction.IncurredTypeID = getExpenseTypeID;
                }

                zerotransaction.ID = Guid.NewGuid();

                zerotransaction.TransactionID = 0;

                if (expensereserve > 0)
                {
                    var recoDbCreateTransactionResult012 = await RecoDb.CreateTransaction(zerotransaction);

                }

                if (adjustingreserve > 0 || expensereserve > 0 || indemnityreserve > 0 || legalreserve > 0)
                {
                    var recoDbGetClaimTotalIncurredByCategoriesResult0 = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                    getTotalIncurred = recoDbGetClaimTotalIncurredByCategoriesResult0;
                }

                if (adjustingreserve > 0 || expensereserve > 0 || indemnityreserve > 0 || legalreserve > 0)
                {
                    var recoDbGetClaimIndividualTransactionsResult = await RecoDb.GetClaimIndividualTransactions(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"TransactionDate desc" });
                    transactions = recoDbGetClaimIndividualTransactionsResult;
                }

                var recoDbRemoveFutureDiariesResult = await RecoDb.RemoveFutureDiaries(claim.ClaimID);
                var recoDbGetClaimDiaryDetailsResult = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
                diaries = recoDbGetClaimDiaryDetailsResult;
            }

            if (claim.CloseDate == null && selectedClaimStatusValue==0) {
                claim.CloseDate = DateTime.Now;
            }

            try
            {
                if (bIsNewClaimDetail && !isEOProgram)
                {
                    var recoDbCreateCdpClaimDetailResult = await RecoDb.CreateCdpClaimDetail(claimdetails);

                }
            }
            catch (System.Exception recoDbCreateCdpClaimDetailException)
            {
            await SaveErrorAsync(recoDbCreateCdpClaimDetailException);

            bSuccessfulSave = false;
            }

            try
            {
                if (!bIsNewClaimDetail && !isEOProgram)
                {
                    var recoDbUpdateCdpClaimDetailResult = await RecoDb.UpdateCdpClaimDetail(claimdetails.ClaimID, claimdetails);

                }
            }
            catch (System.Exception recoDbUpdateCdpClaimDetailException)
            {
            await SaveErrorAsync(recoDbUpdateCdpClaimDetailException);

            bSuccessfulSave = false;
            }

            try
            {
                if (occurrence is not null)
                {
                    var recoDbUpdateOccurrenceResult = await RecoDb.UpdateOccurrence(occurrence.ID, occurrence);
                    masterIsDirty = false;
                }
            }
            catch (System.Exception recoDbUpdateOccurrenceException)
            {
            await SaveErrorAsync(recoDbUpdateOccurrenceException);

            bSuccessfulSave = false;
            }

            try
            {
                if (!(bool)claim.MasterFile && claimant.ClaimantID != 0)
                {
                    claimant = await RecoDb.UpdateClaimant(claimant.ID, claimant);
                    
                    claimantIsDirty = false;
                }
            }
            catch (System.Exception recoDbUpdateClaimantException)
            {
            await SaveErrorAsync(recoDbUpdateClaimantException);

            bSuccessfulSave = false;
            }

            try
            {
                if (trade.TradeID != 0 && trade.Address1 != null)
                {
                    var recoDbUpdateTradeResult = await RecoDb.UpdateTrade(trade.TradeID, trade);
                    tradeIsDirty = false;
                }
            }
            catch (System.Exception recoDbUpdateTradeException)
            {
            await SaveErrorAsync(recoDbUpdateTradeException);

            bSuccessfulSave = false;
            }

            try
            {
                if (trade.TradeID == 0 && trade.Address1 != null)
                {
                    var recoDbCreateTradeResult = await RecoDb.CreateTrade(trade);
                    tradeIsDirty = false;
                }
            }
            catch (System.Exception recoDbCreateTradeException)
            {
            await SaveErrorAsync(recoDbCreateTradeException);
            }

            try
            {
                if (bSuccessfulSave)
                {
                    await saveFileReports();
                }
            }
            catch (System.Exception saveFileReportsException)
            {
            await SaveErrorAsync(saveFileReportsException);
            }

            try
            {
                if (bSuccessfulSave)
                {
                    var recoDbUpdateClaimResult = await RecoDb.UpdateClaim(claim.ID, claim);
                    try
                    {
                        var recoDbUpdateClaimResult0 = await RecoDb.UpdateClaim(masterclaim.ID, masterclaim);
                    }
                    catch (System.Exception recoDbUpdateClaimException)
                    {
                    await SaveErrorAsync(recoDbUpdateClaimException);

                    bSuccessfulSave = false;
                    }

                    if (bSuccessfulSave) {
                        claimIsDirty = false;
                    }

                    await UpdateXRefClaims();

                    try
                    {
                        var recoDbStoreClaimAuditTrailsResult = await RecoDb.StoreClaimAuditTrails(claim.ClaimID, $"{Security.User.Id}");
                    }
                    catch (System.Exception recoDbStoreClaimAuditTrailsException)
                    {
                    await SaveErrorAsync(recoDbStoreClaimAuditTrailsException);
                    }

                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"Claim Has Been Saved" });
                }
            }
            catch (System.Exception recoDbUpdateClaimException0)
            {
            bSuccessfulSave = false;

            await SaveErrorAsync(recoDbUpdateClaimException0);
            }

            if (bSuccessfulSave)
            {
                var recoDbGetClaimStatusHistoriesResult = await RecoDb.GetClaimStatusHistories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"StatusChangeDate desc", Top = 1 });
                if (recoDbGetClaimStatusHistoriesResult.FirstOrDefault() != null) {
                    previousclaimstatus = recoDbGetClaimStatusHistoriesResult.FirstOrDefault().ClaimStatusID;
                }

                if (recoDbGetClaimStatusHistoriesResult.FirstOrDefault() == null) {
                    previousclaimstatus = -1;
                }

                if (previousclaimstatus != claim.ClaimStatusID) {
                    claimstatushistory = new RecoCms6.Models.RecoDb.ClaimStatusHistory();
                }

                if (previousclaimstatus != claim.ClaimStatusID) {
                    claimstatushistory.ClaimID = claim.ClaimID;
                }

                if (previousclaimstatus != claim.ClaimStatusID) {
                    claimstatushistory.NewStatusID = claim.ClaimStatusID;
                }

                claimstatushistory.ChangedBy = Globals.userdetails.AbbreviatedName;

                if (previousclaimstatus != claim.ClaimStatusID)
                {
                    var recoDbCreateClaimStatusHistoryResult = await RecoDb.CreateClaimStatusHistory(claimstatushistory);

                }
            }
            else
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable to save claim" });
            }
        }

        private async Task UpdateXRefClaims()
        {
            foreach (var xrefToAdd in XRefClaimsListToAdd)
            {
                var crossRefToAdd = new CrossReferencedClaim
                {
                    ClaimID = xrefToAdd.BaseClaimID,
                    XRefClaimID = xrefToAdd.XRefClaimID,
                };
                var recoDbCreateCrossReferencedClaimResult = await RecoDb.CreateCrossReferencedClaim(crossRefToAdd);
            }

            XRefClaimsListToAdd.Clear();

            foreach (var xrefToDelete in XRefClaimsListToDelete)
            {
                var recoDbRemoveCrossReferencesResult =
                    await RecoDb.RemoveCrossReferences(xrefToDelete.BaseClaimID, xrefToDelete.XRefClaimID);
            }

            XRefClaimsListToDelete.Clear();

            var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query()
            {
                Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID },
                OrderBy = $"XRefClaimNo asc"
            });
            getXRefClaimsList = recoDbGetXRefClaimsResult.ToList();
        }

        protected async System.Threading.Tasks.Task ButtonAddNoteClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddNote>("Add Note", new Dictionary<string, object>() { {"NoteID", Guid.Empty}, {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{"60%"}",Resizable = true,Draggable = true });
            if (dialogResult != null)
            {
                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                activityLog = recoDbGetClaimActivityLogsResult;
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<CdpFileSummary>("CDP File Summary", new Dictionary<string, object>() { {"EditMode", false}, {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{"60%"}",Resizable = true,Draggable = true });
            if (dialogResult != null)
            {
                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                activityLog = recoDbGetClaimActivityLogsResult;
            }
        }

        protected async void DatagridOccurenceTotalIncurredCellRender(DataGridCellRenderEventArgs<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory> args)
        {
            OccurrenceCellRender(args);
        }

        protected async System.Threading.Tasks.Task Tabs0Change(int tabIndex)
        {
            bFirstRender = false;

            switch (tabIndex)
            {
                case 0: 
                    await LoadOccurrenceDetailsTabData();
                    break;
                case 1:
                    await LoadClaimantsTabData();
                    break;
                case 2:
                    await LoadClaimDetailsTabData();
                    break;
                case 3:
                    await LoadExpertsTabData();
                    break;
                case 4:
                    await LoadReservesPaymentsTabData();
                    break;
                case 5:
                    await LoadNotesTabData();
                    break; 
                case 6:
                    await LoadAttachmentsTabData();
                    break;
                case 7:
                    await LoadDiariesTabData();
                    break;
                case 8:
                    await LoadReportsTabData();
                    break;
                case 9:
                    await LoadEmailTabData();
                    break;
            }
        }

        protected async System.Threading.Tasks.Task ButtonResetOccurrenceClick(MouseEventArgs args)
        {
            if (await DialogService.Confirm("Are you sure you want to reset the occurrence?")==true)
            {
                var recoDbGetOccurrenceByIdResult = await RecoDb.GetOccurrenceById(occurrence.ID);
                occurrence = recoDbGetOccurrenceByIdResult;

                masterIsDirty = false;
            }


        }

        protected async System.Threading.Tasks.Task OccurrenceDateChange(DateTime? args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task OccurenceStatusIdChange(dynamic args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task AdjusterClaimNoChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown1Change(dynamic args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task OccurrenceDescriptionChange(string args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ExpectedPayoutChange(decimal? args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task AdjustedGrossClaimChange(decimal? args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task TotalClaimedAmountChange(decimal? args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task FreezeOrderChange(bool args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task FreezeOrderDateChange(DateTime? args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task BrokerageIdChange(dynamic args)
        {
            masterIsDirty = true;

            if (occurrence.BrokerageID != null)
            {
                var recoDbGetBrokerageByBrokerageIdResult = await RecoDb.GetBrokerageByBrokerageId(occurrence.BrokerageID);
                selectedBrokerage = recoDbGetBrokerageByBrokerageIdResult;

                SetBrokerageDetails();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddBrokerageClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                selectedbrokerage = dialogResult;
            }

            if (dialogResult != null) {
                masterIsDirty = true;
            }

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;

            if (dialogResult != null) {
                occurrence.BrokerageID = dialogResult.BrokerageID;
            }
        }

        protected async System.Threading.Tasks.Task ReceiverIdChange(dynamic args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonAddReceiverClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddReceiver>("Add Receiver", null);
            if (dialogResult != null) {
                masterIsDirty = true;
            }

            var recoDbGetReceiversResult = await RecoDb.GetReceivers(new Query() { OrderBy = $"Name asc" });
            getReceiversList = recoDbGetReceiversResult;

            if (dialogResult != null) {
                occurrence.ReceiverID = dialogResult.ReceiverID;
            }
        }

        protected async System.Threading.Tasks.Task Textarea0Change(string args)
        {
            masterIsDirty = true;
        }

        protected async System.Threading.Tasks.Task FileHandlerIdChange(dynamic args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task AdjusterIdChange(dynamic args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task DefenseCounselIdChange(dynamic args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Datagrid0RowExpand(RecoCms6.Models.RecoDb.OccurrenceClaimant args)
        {
            var recoDbGetOccurrenceClaimTradesResult = await RecoDb.GetOccurrenceClaimTrades(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { args.ClaimantID }, OrderBy = $"ClaimNo desc" });
            tradelist = recoDbGetOccurrenceClaimTradesResult;
        }

        protected async System.Threading.Tasks.Task ButtonConsolidateClaimantsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<ConsolidateClaimants>("Consolidate Claimants", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{"60%"}" });
            if (dialogResult != null)
            {
                var recoDbGetOccurrenceClaimantsResult = await RecoDb.GetOccurrenceClaimants(new Query() { Filter = $@"i => i.MasterFileID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"Name asc" });
                claimantlist = recoDbGetOccurrenceClaimantsResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonResetClaimantClick(MouseEventArgs args)
        {
            bSuccessfulSave = true;

            try
            {
                if (await DialogService.Confirm("Are you sure you want to undo changes to this Claimant?") == true)
                {
                    var recoDbGetClaimantByIdResult = await RecoDb.GetClaimantById(claimant.ID);
                    claimant = recoDbGetClaimantByIdResult;
                    claimantIsDirty = false;

                    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"Claimant has been reset" });
                }
            }
            catch (System.Exception recoDbGetClaimantByIdException)
            {
            bSuccessfulSave = false;
                Log.Error(recoDbGetClaimantByIdException.Message);
            }

            if (!bSuccessfulSave)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable to reset claim" });
            }
        }

        protected async System.Threading.Tasks.Task RegistrantIdChange(dynamic args)
        {
            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { claimant.RegistrantID } });
            registrant = recoDbGetRegistrantsResult.FirstOrDefault();

            claimant.Address = registrant.Address;

            claimant.BusinessPhoneNum = registrant.BusinessPhoneNum;

            claimant.CellPhoneNum = registrant.CellPhoneNum;

            claimant.EmailAddress = registrant.EmailAddress;

            claimant.Name = registrant.Name;

            claimant.PostalCode = registrant.PostalCode;

            claimant.PreferredCommunicationMethodID = registrant.PreferredCommunicationMethodID;

            claimant.ProvinceID = registrant.ProvinceID;

            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonNewRegistrantClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddRegistrant>("Add Registrant", null);
            if (dialogResult != null) {
                claimant.RegistrantID = dialogResult.RegistrantID;
            }

            if (dialogResult != null) {
                registrant = dialogResult;
            }

            if (dialogResult != null) {
                claimant.Address = registrant.Address;
            }

            if (dialogResult != null) {
                claimant.BusinessPhoneNum = registrant.BusinessPhoneNum;
            }

            if (dialogResult != null) {
                claimant.CellPhoneNum = registrant.CellPhoneNum;
            }

            if (dialogResult != null) {
                claimant.EmailAddress = registrant.CellPhoneNum;
            }

            if (dialogResult != null) {
                claimant.Name = registrant.Name;
            }

            if (dialogResult != null) {
                claimant.PostalCode = registrant.PostalCode;
            }

            if (dialogResult != null) {
                claimant.PreferredCommunicationMethodID = registrant.PreferredCommunicationMethodID;
            }

            if (dialogResult != null) {
                claimant.ProvinceID = registrant.ProvinceID;
            }

            if (dialogResult != null) {
                claimantIsDirty = true;
            }
        }

        protected async System.Threading.Tasks.Task NameChange(string args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task AddressChange(string args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task RegistrantNumChange(string args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CityChange(string args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ProvinceIdChange(dynamic args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task PostalCodeChange(string args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task BusinessPhoneNumChange(dynamic args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CellPhoneNumChange(dynamic args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task EmailAddressChange(string args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task DropdownDatagrid1Change(dynamic args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonNewSolicitorClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimantSolicitor>("Add Claimant Solicitor", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                claimant.ClaimantSolicitorID = dialogResult.SolicitorID;
            }

            if (dialogResult != null) {
                claimantIsDirty = true;
            }

            if (dialogResult != null)
            {
                var recoDbGetClaimantSolicitorsResult = await RecoDb.GetClaimantSolicitors();
                getClaimantSolicitorsResult = recoDbGetClaimantSolicitorsResult;
            }
        }

        protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CooperatingBrokerageIdChange(dynamic args)
        {
            claimantIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonNewBrokerageClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null);
            if (dialogResult != null) {
                claimant.CooperatingBrokerageID = dialogResult.BrokerageID;
            }

            if (dialogResult != null) {
                claimantIsDirty = true;
            }

            if (dialogResult != null)
            {
                var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
                getBrokeragesResult = recoDbGetBrokeragesResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddOtherPartyClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddOtherParty>("Add Other Party", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID}, {"OtherPartyID", 0} }, new DialogOptions(){ Width = $"{"60%"}" });
            //await gridOtherParties.Reload();

            var recoDbGetClaimOtherPartiesResult = await RecoDb.GetClaimOtherParties(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getOtherPartyList = Mapper.Map<IQueryable<ClaimOtherParty>, IList<CppOtherPartyViewModel>>(recoDbGetClaimOtherPartiesResult);

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task ClaimNoChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimStatusIdChange(dynamic args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CloseDateChange(DateTime? args)
        {
            claimDirty = true;
        }

        protected async System.Threading.Tasks.Task Textbox1Change(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CounselFileNoChange(string args)
        {
            claimDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric3Change(decimal? args)
        {
            claimDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonGotoMasterFileClick(MouseEventArgs args)
        {
            ClaimID = StringExtensions.ToBase64(masterclaim.ClaimID);
            // UriHelper.NavigateTo($"edit-commission-claim/{strXRefClaimID}", /* force reload */ true);

            claim.ClaimID = masterclaim.ClaimID;
            await Load();
        }

        protected async System.Threading.Tasks.Task CoverageIssueChange(bool args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ClassActionChange(bool args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task NotYetReportedChange(bool args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ReservationOfRightsIdChange(dynamic args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ReservationOfRightsOtherChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ReservationOfRightsDateChange(DateTime? args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Dropdown9Change(dynamic args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task TradeAddress1Change(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task UnitNumberChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task TradeAddress2Change(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task TradeCityChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task TradePostalCodeChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ProvinceChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CountryChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task SpisChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task PersonalInterestChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task HomeInspectionChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimTradeTypeIdChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task LeaseDateChange(DateTime? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task PriceChange(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task DealClosedChange(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task DateClosedChange(DateTime? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task DepositAmountChange(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task BuyerNameChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task BuyerCdFileIdChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonFindRelatedBuyerCdClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>($"Select CD Claim", new Dictionary<string, object>() { {"ProgramID", getCDProgramID}, {"ExcludeClaimID", 0}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if ((dialogResult ?? 0) != 0) {
                trade.BuyerCDFileID = dialogResult;

                buyerCDFileID = (int)trade.BuyerCDFileID ;

                tradeIsDirty = true;

                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { sellerCDFileID, buyerCDFileID, sharedAgentClaimID } });
                getAssocCDClaimsResult = recoDbGetClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task SellerNameChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task SellerCdFileIdChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonFindRelatedSellerCdClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>($"Select CD Claim", new Dictionary<string, object>() { {"ProgramID", getCDProgramID}, {"ExcludeClaimID", 0}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if ((dialogResult ?? 0) != 0) {
                trade.SellerCDFileID = dialogResult;
                sellerCDFileID = (int)trade.SellerCDFileID;
                tradeIsDirty = true;
                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { sellerCDFileID, buyerCDFileID, sharedAgentClaimID } });
                getAssocCDClaimsResult = recoDbGetClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task Checkbox0Change(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task BuilderReferenceNumChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task BuilderIdChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonShowBuilderDetailsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBuilder>("Add Builder", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                trade.BuilderID = dialogResult.BuilderID;
            }

            if (dialogResult != null) {
                tradeIsDirty = true;
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

        protected async System.Threading.Tasks.Task Numeric0Change(double? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric1Change(decimal? args)
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
            await DialogService.OpenAsync<AddCommissionInstallment>("Add Commission Installment", new Dictionary<string, object>() { {"TradeID", trade.TradeID} });
        }

        protected async System.Threading.Tasks.Task AmountCollectedChange(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task Datepicker0Change(DateTime? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CheckboxSharedCommissionChange(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task SharedAgentIdChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonFindSharedAgentClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Registrants>("Registrants", new Dictionary<string, object>() { {"SelectAgent", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null) {
                sharedAgent = dialogResult;
            }

            if (dialogResult != null) {
                tradeIsDirty = true;
            }

            if (dialogResult != null)
            {
                var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { dialogResult.RegistrantID } });
                getSharedAgent = recoDbGetRegistrantsResult;

                trade.SharedAgentID = sharedAgent.RegistrantID;
            }
        }

        protected async System.Threading.Tasks.Task Checkbox3Change(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task SharedAgentClaimIdChange(dynamic args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonFindSubmittedClaimClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>($"Find Submitted Claim", new Dictionary<string, object>() { {"ProgramID", claim.ProgramID}, {"ExcludeClaimID", claim.ClaimID}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if ((dialogResult ?? 0) != 0) {
                trade.SharedAgentClaimID = dialogResult;
                sharedAgentClaimID = (int)trade.SharedAgentClaimID;
                tradeIsDirty = true;
                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { sellerCDFileID, buyerCDFileID, sharedAgentClaimID } });
                getAssocCDClaimsResult = recoDbGetClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task OutstandingMoneyChange(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task OutstandingMoneyInTransitChange(bool args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task OutstandingMoneyAmountChange(decimal? args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task OutstandingMoneyActionChange(string args)
        {
            tradeIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonViewClaimClick(MouseEventArgs args, dynamic data)
        {
            strXRefClaimID = StringExtensions.ToBase64(data.XRefClaimID);

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { data.XRefClaimID } });
            xrefprogramid = recoDbGetClaimsResult.FirstOrDefault().ProgramID;

            if (getEOProgramID == xrefprogramid)
            {
                UriHelper.NavigateTo($"edit-claim/{strXRefClaimID}", /* force reload */ true);
            }

            if (getEOProgramID != xrefprogramid)
            {
                UriHelper.NavigateTo($"edit-commission-claim/{strXRefClaimID}", /* force reload */ true);
            }
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

        protected async System.Threading.Tasks.Task ClaimDateChange(DateTime? args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task AgreementDateChange(DateTime? args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ReportDateChange(DateTime? args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimVerificationChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task LiabilityChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ApportionmentChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task RealDamagesChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task LossPotentialChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CoverageIssuesChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task CurrentPlanChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimCommentsChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ClaimCalcuationChange(string args)
        {
            claimIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonResetClaimClick(MouseEventArgs args)
        {
            bSuccessfulSave = true;

            bIsNewClaimDetail = claimdetails.ClaimID == 0;

            try
            {
                if (!bIsNewClaimDetail && await DialogService.Confirm("Are you sure you want to undo changes to this Claim?") == true)
                {
                    var recoDbGetCdpClaimDetailByClaimIdResult = await RecoDb.GetCdpClaimDetailByClaimId(claim.ClaimID);
                    claimdetails = recoDbGetCdpClaimDetailByClaimIdResult;

                    try
                    {
                        var recoDbGetClaimByIdResult = await RecoDb.GetClaimById(claim.ID);
                        claim = recoDbGetClaimByIdResult;
                        
                        if (claim.MasterFile)
                        {
                            masterclaim = recoDbGetClaimByIdResult;
                        }

                        claimIsDirty = false;

                        var recoDbGetTradesResult0 = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"DisplayOrder asc" });
                        trade = recoDbGetTradesResult0.FirstOrDefault() ?? new RecoCms6.Models.RecoDb.Trade();

                        XRefClaimsListToAdd.Clear();
                        XRefClaimsListToDelete.Clear();

                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"Claim Details have been reset" });
                    }
                    catch (System.Exception recoDbGetClaimByIdException)
                    {
                    bSuccessfulSave = false;
                    }
                }
            }
            catch (System.Exception recoDbGetCdpClaimDetailByClaimIdException)
            {
            bSuccessfulSave = false;
            }

            if (!bSuccessfulSave)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable to reset claim" });
            }
        }

        protected async System.Threading.Tasks.Task BtnClaimReportClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<ClaimReport>($"Claim Report", new Dictionary<string, object>() { {"ClaimID", intClaimID.ToBase64()} }, new DialogOptions(){ Width = $"{1200}px" });
        }

        protected async System.Threading.Tasks.Task ButtonAddExpertClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddExpert>("Add Expert", new Dictionary<string, object>() { {"ExpertID", 0}, {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{1024}px" });
            //await gridInsureds.Reload();
            await ReloadExpertList();
            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task ButtonNewTransactionClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTransaction>("Add Transaction", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID}, {"TransactionID", 0} }, new DialogOptions(){ Width = $"{"60%"}" });
            if (dialogResult != null)
            {
                await gridTransactions.Reload();
            }

            if (dialogResult != null)
            {
                await gridTotalIncurredDetailed.Reload();
            }

            await datagridOccurenceTotalIncurred.Reload();

            if (dialogResult != null)
            {
                var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", claim.ClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                claimfiles = recoDbGetClaimFilesByUsersResult;
            }

            if (dialogResult != null)
            {
                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                bFirstRender = false;

                activityLog = recoDbGetClaimActivityLogsResult;
            }

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task GridTransactionsRowDoubleClick(RecoCms6.Models.RecoDb.ClaimIndividualTransaction args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTransaction>("Add Transaction", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID}, {"TransactionID", args.TransactionID} }, new DialogOptions(){ Width = $"{"60%"}",Resizable = true });
            var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", claim.ClaimID);
            claimfiles = recoDbGetClaimFilesByUsersResult;
        }

        protected async System.Threading.Tasks.Task ButtonVoidTransactionClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to void this transaction?") == true)
            {
                var recoDbVoidTransactionsResult = await RecoDb.VoidTransactions(data.TransactionID);
                await gridTransactions.Reload();

                await gridTotalIncurredDetailed.Reload();

                await InvokeAsync(() => { StateHasChanged();});
            }
        }

        protected async System.Threading.Tasks.Task FieldsetNoteExpand(dynamic args)
        {
            DialogOpen();
        }

        protected async System.Threading.Tasks.Task FormNoteInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Errors on Note Form",Detail = $"Ensure the Note Type and Subject are filled in",Duration = 6000 });
        }

        protected async System.Threading.Tasks.Task FormNoteSubmit(RecoCms6.Models.RecoDb.Note args)
        {
            SaveNote();
        }

        protected async System.Threading.Tasks.Task DropdownTemplateChange(dynamic args)
        {
            var setFormByTemplatePropertiesResult = await SetFormByTemplateProperties();
        }

        protected async System.Threading.Tasks.Task HtmlEditor0Change(string args)
        {
            noteIsDirty = true;
        }

        protected async System.Threading.Tasks.Task ButtonCancelNoteClick(MouseEventArgs args)
        {
            bClearNote = await DialogService.Confirm("Are you sure you want to clear this note?");

            if ((bool)bClearNote) {
                note = new Note();
            }

            if ((bool)bClearNote) {
                noteIsDirty = false;
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

        protected async System.Threading.Tasks.Task BtnAddFileClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFile>($"Add Document", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{"60%"}",Resizable = true });
            if (dialogResult != null)
            {
                var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", intClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                claimfiles = recoDbGetClaimFilesByUsersResult;
            }
        }

        protected async void GridfilesCellRender(CellRenderEventArgs<RecoCms6.Models.RecoDb.ClaimFilesByUser> args)
        {
            GridFileCellRender(args);
        }

        protected async System.Threading.Tasks.Task GridfilesRowDoubleClick(RecoCms6.Models.RecoDb.ClaimFilesByUser args)
        {
            var dialogResult = await DialogService.OpenAsync<EditFile>("Edit File", new Dictionary<string, object>() { {"ID", args.ID} }, new DialogOptions(){ Width = $"{"60%"}",Resizable = true,Draggable = true });
            if (dialogResult != null)
            {
                var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", claim.ClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                claimfiles = recoDbGetClaimFilesByUsersResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonDownloadFileClick(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data);
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
            var dialogResult = await DialogService.OpenAsync<AddEditDiary>($"Add Diary", new Dictionary<string, object>() { {"Start", DateTime.Today}, {"End", DateTime.Today}, {"ClaimID", intClaimID}, {"DiaryID", null} }, new DialogOptions(){ Width = $"{"60%"}" });
            await gridDiaries.Reload();

            await InvokeAsync(() => { StateHasChanged();});

            if (intClaimID==-1) {
              await DialogService.OpenAsync<DiaryCalendar>("Diary Calendar", new Dictionary<string, object>() { {"ClaimID", intClaimID} }, new DialogOptions(){ Width = $"{1024}px" });
            }
        }

        protected async System.Threading.Tasks.Task GridDiariesRowSelect(RecoCms6.Models.RecoDb.ClaimDiaryDetail args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEditDiary>($"Edit Diary", new Dictionary<string, object>() { {"Start", null}, {"End", null}, {"ClaimID", claim.ClaimID}, {"DiaryID", args.ID} }, new DialogOptions(){ Width = $"{"60%"}",Resizable = true });
            await gridDiaries.Reload();

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task ButtonDeleteDiaryClick(MouseEventArgs args, dynamic data)
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbDeleteDiaryResult = await RecoDb.DeleteDiary(data.ID);
                await gridDiaries.Reload();

                await InvokeAsync(() => { StateHasChanged();});
            }
        }

        protected async System.Threading.Tasks.Task FormReportInvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            await ShowFormErrors(args);
        }

        private static SemaphoreSlim submitionMutexLock = new SemaphoreSlim(1);
        protected async System.Threading.Tasks.Task FormReportSubmit(RecoCms6.Models.RecoDb.ClaimReport args)
        {
            if (await submitionMutexLock.WaitAsync(0))
            {
                await ShowBusyDialog();
                submitionMutexLock.Release();
            }
        }

        protected async System.Threading.Tasks.Task ButtonSaveClick(MouseEventArgs args)
        {
            IsSubmitEvent = false;

            var saveReportResult = await SaveReport();
        }

        protected async System.Threading.Tasks.Task ButtonSubmitClick(MouseEventArgs args)
        {
            IsSubmitEvent = true;
        }

        protected async System.Threading.Tasks.Task TemplateForm0InvalidSubmit(FormInvalidSubmitEventArgs args)
        {
            isClaimEmailSubmit = true;

                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Detail = $"Correct Error on Form Before Sending" });
        }

        protected async System.Threading.Tasks.Task TemplateForm0Submit(RecoCms6.Models.RecoMail args)
        {
            isClaimEmailSubmit = true;

            await SendEmail();
        }

        protected async System.Threading.Tasks.Task TextboxToChange(string args)
        {
            ToAddressessChanged();
        }

        protected async System.Threading.Tasks.Task ButtonAddToClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Claim Email Addresses", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} });
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
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Claim Email Addresses", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} });
            if (dialogResult != Enumerable.Empty<string>())
            {
                CCAddressesAdd(dialogResult);
            }
        }

        protected async System.Threading.Tasks.Task TextboxBccChange(string args)
        {
            CCAddressessChanged();
        }

        protected async System.Threading.Tasks.Task ButtonAddBccClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Claim Email Addresses", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} });
            if (dialogResult != Enumerable.Empty<string>())
            {
                BccAddressesAdd(dialogResult);
            }
        }

        protected async System.Threading.Tasks.Task DropdownEmailTemplateChange(dynamic args)
        {
            var setEmailByTemplatePropertiesResult = await SetEmailByTemplateProperties();
        }

        protected async System.Threading.Tasks.Task ButtonDeleteEmailFileClick(MouseEventArgs args, dynamic data)
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
            var dialogResult = await DialogService.OpenAsync<DialogSelectFile>($"Claim Documents", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{"50%"}",Height = $"{"80%"}" });
            if (dialogResult != null && newRecoMail.ClaimFiles != null)
            {
                newRecoMail.ClaimFiles.AddRange(dialogResult);
            }

            if (dialogResult != null && newRecoMail.ClaimFiles == null)
            {
                newRecoMail.ClaimFiles = dialogResult;
            }

            if (dialogResult != null) {
                Attachments = newRecoMail.Filenames();
            }

            await datagridClaimFiles.Reload();
        }

        protected async System.Threading.Tasks.Task ButtonClearEmailNoteClick(MouseEventArgs args, dynamic data)
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
            var dialogResult = await DialogService.OpenAsync<DialogSelectNote>($"Claim Notes", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null && newRecoMail.Notes != null)
            {
                newRecoMail.Notes.AddRange(dialogResult);
            }

            if (dialogResult != null && newRecoMail.Notes == null) {
                newRecoMail.Notes = dialogResult;
            }

            if (dialogResult != null)
            {
                Notes = newRecoMail.NoteSubjects();
            }

            datagridNotes.Reload();
        }

        protected async System.Threading.Tasks.Task BtnResetClaimantClick(MouseEventArgs args)
        {
            claimant = new Claimant
            {
                ID = claimant.ID,
                ClaimantID = claimant.ClaimantID,
                ClaimID = claimant.ClaimID,
                ClaimantOrder = claimant.ClaimantOrder,
            };

            Roles = new List<int>();
        }

        protected async System.Threading.Tasks.Task ButtonRemoveFileClick(MouseEventArgs args)
        {
            RemoveSelectedFile();
        }
    }
}
