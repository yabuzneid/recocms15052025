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
    public partial class AddClaimComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.Occurrence> occurrenceId;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimInsured> gridInsureds;
        protected RadzenGrid<RecoCms6.Models.RecoDb.XRefClaim> gridCrossRefFiles;
        protected RadzenGrid<RecoCms6.Models.RecoDb.ClaimClaimant> gridClaimants;

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

        RecoCms6.Models.RecoDb.Trade _claimtrade;
        protected RecoCms6.Models.RecoDb.Trade claimtrade
        {
            get
            {
                return _claimtrade;
            }
            set
            {
                if (!object.Equals(_claimtrade, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimtrade", NewValue = value, OldValue = _claimtrade };
                    _claimtrade = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.EoClaimDetail _claimdetails;
        protected RecoCms6.Models.RecoDb.EoClaimDetail claimdetails
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProgramsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProgramsList
        {
            get
            {
                return _getProgramsList;
            }
            set
            {
                if (!object.Equals(_getProgramsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgramsList", NewValue = value, OldValue = _getProgramsList };
                    _getProgramsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getOpenStatusID;
        protected int getOpenStatusID
        {
            get
            {
                return _getOpenStatusID;
            }
            set
            {
                if (!object.Equals(_getOpenStatusID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOpenStatusID", NewValue = value, OldValue = _getOpenStatusID };
                    _getOpenStatusID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getContractYearList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getContractYearList
        {
            get
            {
                return _getContractYearList;
            }
            set
            {
                if (!object.Equals(_getContractYearList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getContractYearList", NewValue = value, OldValue = _getContractYearList };
                    _getContractYearList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProvincesList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProvincesList
        {
            get
            {
                return _getProvincesList;
            }
            set
            {
                if (!object.Equals(_getProvincesList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProvincesList", NewValue = value, OldValue = _getProvincesList };
                    _getProvincesList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getYesNoList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getYesNoList
        {
            get
            {
                return _getYesNoList;
            }
            set
            {
                if (!object.Equals(_getYesNoList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getYesNoList", NewValue = value, OldValue = _getYesNoList };
                    _getYesNoList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _EOProgramID;
        protected int EOProgramID
        {
            get
            {
                return _EOProgramID;
            }
            set
            {
                if (!object.Equals(_EOProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "EOProgramID", NewValue = value, OldValue = _EOProgramID };
                    _EOProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _defaultProvinceID;
        protected int defaultProvinceID
        {
            get
            {
                return _defaultProvinceID;
            }
            set
            {
                if (!object.Equals(_defaultProvinceID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "defaultProvinceID", NewValue = value, OldValue = _defaultProvinceID };
                    _defaultProvinceID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _defaultContractYearID;
        protected int defaultContractYearID
        {
            get
            {
                return _defaultContractYearID;
            }
            set
            {
                if (!object.Equals(_defaultContractYearID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "defaultContractYearID", NewValue = value, OldValue = _defaultContractYearID };
                    _defaultContractYearID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _defaultCountryID;
        protected int defaultCountryID
        {
            get
            {
                return _defaultCountryID;
            }
            set
            {
                if (!object.Equals(_defaultCountryID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "defaultCountryID", NewValue = value, OldValue = _defaultCountryID };
                    _defaultCountryID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedProvince;
        protected int selectedProvince
        {
            get
            {
                return _selectedProvince;
            }
            set
            {
                if (!object.Equals(_selectedProvince, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedProvince", NewValue = value, OldValue = _selectedProvince };
                    _selectedProvince = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getLossCauseResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getLossCauseResult
        {
            get
            {
                return _getLossCauseResult;
            }
            set
            {
                if (!object.Equals(_getLossCauseResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLossCauseResult", NewValue = value, OldValue = _getLossCauseResult };
                    _getLossCauseResult = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getLitigationTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getLitigationTypeList
        {
            get
            {
                return _getLitigationTypeList;
            }
            set
            {
                if (!object.Equals(_getLitigationTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLitigationTypeList", NewValue = value, OldValue = _getLitigationTypeList };
                    _getLitigationTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getAllegationList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getAllegationList
        {
            get
            {
                return _getAllegationList;
            }
            set
            {
                if (!object.Equals(_getAllegationList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAllegationList", NewValue = value, OldValue = _getAllegationList };
                    _getAllegationList = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProvinceList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProvinceList
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCountryList;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCityList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCityList
        {
            get
            {
                return _getCityList;
            }
            set
            {
                if (!object.Equals(_getCityList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCityList", NewValue = value, OldValue = _getCityList };
                    _getCityList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getBoardJurisdictionList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getBoardJurisdictionList
        {
            get
            {
                return _getBoardJurisdictionList;
            }
            set
            {
                if (!object.Equals(_getBoardJurisdictionList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBoardJurisdictionList", NewValue = value, OldValue = _getBoardJurisdictionList };
                    _getBoardJurisdictionList = value;
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

        int _getInitialDeductibleID;
        protected int getInitialDeductibleID
        {
            get
            {
                return _getInitialDeductibleID;
            }
            set
            {
                if (!object.Equals(_getInitialDeductibleID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInitialDeductibleID", NewValue = value, OldValue = _getInitialDeductibleID };
                    _getInitialDeductibleID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProvider> _getServiceProvidersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProvider> getServiceProvidersResult
        {
            get
            {
                return _getServiceProvidersResult;
            }
            set
            {
                if (!object.Equals(_getServiceProvidersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServiceProvidersResult", NewValue = value, OldValue = _getServiceProvidersResult };
                    _getServiceProvidersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Brokerage> _getBrokeragesResult;
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

        IEnumerable<RecoCms6.Models.RecoDb.Occurrence> _getOccurrencesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Occurrence> getOccurrencesResult
        {
            get
            {
                return _getOccurrencesResult;
            }
            set
            {
                if (!object.Equals(_getOccurrencesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOccurrencesResult", NewValue = value, OldValue = _getOccurrencesResult };
                    _getOccurrencesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _currentStep;
        protected int currentStep
        {
            get
            {
                return _currentStep;
            }
            set
            {
                if (!object.Equals(_currentStep, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "currentStep", NewValue = value, OldValue = _currentStep };
                    _currentStep = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _previousStep;
        protected int previousStep
        {
            get
            {
                return _previousStep;
            }
            set
            {
                if (!object.Equals(_previousStep, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "previousStep", NewValue = value, OldValue = _previousStep };
                    _previousStep = value;
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

        bool _newClaim;
        protected bool newClaim
        {
            get
            {
                return _newClaim;
            }
            set
            {
                if (!object.Equals(_newClaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newClaim", NewValue = value, OldValue = _newClaim };
                    _newClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimInsured> _getInsuredsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimInsured> getInsuredsList
        {
            get
            {
                return _getInsuredsList;
            }
            set
            {
                if (!object.Equals(_getInsuredsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInsuredsList", NewValue = value, OldValue = _getInsuredsList };
                    _getInsuredsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimClaimant> _getClaimantsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimClaimant> getClaimantsList
        {
            get
            {
                return _getClaimantsList;
            }
            set
            {
                if (!object.Equals(_getClaimantsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimantsList", NewValue = value, OldValue = _getClaimantsList };
                    _getClaimantsList = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.TradeDetail> _getTradesList;
        protected IEnumerable<RecoCms6.Models.RecoDb.TradeDetail> getTradesList
        {
            get
            {
                return _getTradesList;
            }
            set
            {
                if (!object.Equals(_getTradesList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTradesList", NewValue = value, OldValue = _getTradesList };
                    _getTradesList = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.Occurrence> _getOccurrencesList;
        protected IEnumerable<RecoCms6.Models.RecoDb.Occurrence> getOccurrencesList
        {
            get
            {
                return _getOccurrencesList;
            }
            set
            {
                if (!object.Equals(_getOccurrencesList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOccurrencesList", NewValue = value, OldValue = _getOccurrencesList };
                    _getOccurrencesList = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "isDirty", NewValue = value, OldValue = _isDirty };
                    _isDirty = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Trade _occurrencetrade;
        protected RecoCms6.Models.RecoDb.Trade occurrencetrade
        {
            get
            {
                return _occurrencetrade;
            }
            set
            {
                if (!object.Equals(_occurrencetrade, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "occurrencetrade", NewValue = value, OldValue = _occurrencetrade };
                    _occurrencetrade = value;
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
            claim = new RecoCms6.Models.RecoDb.Claim(){};

            occurrence = new RecoCms6.Models.RecoDb.Occurrence();

            claimtrade = new RecoCms6.Models.RecoDb.Trade();

            claimdetails = new RecoCms6.Models.RecoDb.EoClaimDetail();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamDesc asc" });
            getProgramsList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="EO");

            getOpenStatusID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claim Status" && p.ParamDesc=="Open").First().ParameterID;

            getContractYearList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Contract Year");

            getProvincesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province" && p.ParamValue>0);

            getYesNoList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="YesNoNA");

            EOProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="EO").First().ParameterID;

            defaultProvinceID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province" && p.ParamValue==1).First().ParameterID;

            claimtrade.Province = defaultProvinceID;

            claim.ProgramID = EOProgramID;

            if (DateTime.Now.Month >= (Globals.generalsettings.FiscalYear.Month)) {
                defaultContractYearID = getContractYearList.Where(cy=>cy.ParamValue == DateTime.Now.Year).FirstOrDefault()?.ParameterID ?? 0;
            }

            if (DateTime.Now.Month < (Globals.generalsettings.FiscalYear.Month)) {
                defaultContractYearID = getContractYearList.Where(cy=>cy.ParamValue == (DateTime.Now.Year - 1)).FirstOrDefault().ParameterID;
            }

            if (defaultContractYearID > 0) {
                claim.ContractYearID = defaultContractYearID;
            }

            defaultCountryID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Country" && p.ParamDesc=="Canada").First().ParameterID;

            claimtrade.Country = defaultCountryID;

            selectedProvince = defaultProvinceID;

            getLossCauseResult = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Loss Cause");

            getTradeTypeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Trade Type");

            getLitigationTypeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Litigation Type");

            getAllegationList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Allegation");

            if (Globals.generalsettings.ApplicationName=="RECO CMS") {
                getDeductibleList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Deductible");
            }

            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getCountryList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Country");

            getCityList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="City" && p.ParentParameterID==defaultProvinceID);

          claim.PolicyID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="Policy No" && p.ParamValue==claim.ContractYearID)?.ParameterID;

            if (Globals.generalsettings.ApplicationName=="REIX CMS") {
                getDeductibleList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Deductible" && p.ParamDesc != "2500");
            }

            getBoardJurisdictionList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Board Jurisdiction");

            getClaimInitiationList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claim Initiation");

            getInitialDeductibleID = getDeductibleList.First().ParameterID;

            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders();
            getServiceProvidersResult = recoDbGetServiceProvidersResult;

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages();
            getBrokeragesResult = recoDbGetBrokeragesResult;

            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences();
            getOccurrencesResult = recoDbGetOccurrencesResult;

            claim.ClaimStatusID = getOpenStatusID;

            claim.ID = Guid.NewGuid();

            currentStep = 0;

            previousStep = 0;

            isEOProgram = true;

            claimdetails.ClaimOrIncident = true;

            claim.Deductible = getInitialDeductibleID;

            newClaim = true;

            var recoDbGetGenerateClaimNumbersResult = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, null, claimdetails.ClaimOrIncident);
            claim.ClaimNo = recoDbGetGenerateClaimNumbersResult.First().NewNumber;
        }

        protected async System.Threading.Tasks.Task Steps0Change(int args)
        {
            previousStep = currentStep;

            currentStep = args;

            if (currentStep == 1)
            {
                var recoDbGetClaimInsuredsResult = await RecoDb.GetClaimInsureds(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getInsuredsList = recoDbGetClaimInsuredsResult;
            }

            if (currentStep == 2)
            {
                var recoDbGetClaimClaimantsResult = await RecoDb.GetClaimClaimants(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"ClaimantOrder asc" });
                getClaimantsList = recoDbGetClaimClaimantsResult;
            }

            try
            {
                if (claim.ClaimID == 0)
                {
                    var recoDbCreateClaimResult = await RecoDb.CreateClaim(claim);
                    if (isEOProgram) {
                        claimdetails.ClaimID = claim.ClaimID;
                    }

                    if (Globals.generalsettings.ApplicationName=="RECO CMS") {
                        claim.Deductible = getInitialDeductibleID;
                    }

                    var recoDbStoreClaimAuditTrailsResult = await RecoDb.StoreClaimAuditTrails(claim.ClaimID, $"{Security.User.Id}");

                    var recoDbSetProgramManagerAsReportsResult = await RecoDb.SetProgramManagerAsReports(claim.ClaimID);
                }
            }
            catch (System.Exception recoDbCreateClaimException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable To Save Claim",Detail = $"Please select Program, Contract Year and Claim Number" });
                Log.Error("Exception occured while trying to move to step 2 of create E&O claim. Details {0}", recoDbCreateClaimException);
            }

            if (isEOProgram && newClaim)
            {
                var recoDbCreateEoClaimDetailResult = await RecoDb.CreateEoClaimDetail(claimdetails);
                var recoDbSetAutoResizesResult = await RecoDb.SetAutoResizes(claim.ClaimID, $"{Security.User.Id}");
            }

            if (newClaim) {
                claimstatushistory = new RecoCms6.Models.RecoDb.ClaimStatusHistory() ;
            }

            if (newClaim) {
                claimstatushistory.ClaimID = claim.ClaimID;
            }

            if (newClaim) {
                claimstatushistory.NewStatusID = claim.ClaimStatusID;
            }

            if (newClaim)
            {
                var recoDbCreateClaimStatusHistoryResult = await RecoDb.CreateClaimStatusHistory(claimstatushistory);

            }

            newClaim = false;

            if (currentStep == 3)
            {
                var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getTradesList = recoDbGetTradeDetailsResult;
            }

            if (currentStep == 1)
            {
                var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query() { Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"XRefClaimNo asc" });
                getXRefClaimsList = recoDbGetXRefClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task ProgramIdChange(dynamic args)
        {
            if (claim.ContractYearID != 0 && claim.ProgramID == EOProgramID)
            {
                var recoDbGetGenerateClaimNumbersResult = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, null, claimdetails.ClaimOrIncident);
                claim.ClaimNo = recoDbGetGenerateClaimNumbersResult.First().NewNumber;
            }

            if (claim.ContractYearID != 0 && claim.ProgramID != 0)
            {
                var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.ProgramID == @0 && i.ContractYearID == @1", FilterParameters = new object[] { claim.ProgramID, claim.ContractYearID }, OrderBy = $"OccurrenceNo desc" });
                getOccurrencesList = recoDbGetOccurrencesResult;
            }

            if (claim.ContractYearID != 0 && claim.ProgramID != EOProgramID && claim.ProgramID != 0 && claim.OccurrenceID != 0)
            {
                var recoDbGetGenerateClaimNumbersResult0 = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, claim.OccurrenceID, null);
                claim.ClaimNo = recoDbGetGenerateClaimNumbersResult0.First().NewNumber;
            }

            isEOProgram = claim.ProgramID == EOProgramID;
        }

        protected async System.Threading.Tasks.Task ClaimOrIncidentChange(bool args)
        {
            if (claim.ContractYearID != 0 && claim.ProgramID == EOProgramID)
            {
                var recoDbGetGenerateClaimNumbersResult = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, null, claimdetails.ClaimOrIncident);
                claim.ClaimNo = recoDbGetGenerateClaimNumbersResult.First().NewNumber;
            }

            if (Globals.generalsettings.ApplicationName=="REIX CMS" && selectedProvince != defaultProvinceID) {
                claim.ClaimNo = claim.ClaimNo + "SK";
            }
        }

        protected async System.Threading.Tasks.Task ContractYearIdChange(dynamic args)
        {
            if (claim.ContractYearID != 0 && claim.ProgramID != 0 && claim.ProgramID != EOProgramID)
            {
                var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.ProgramID == @0 && i.ContractYearID == @1", FilterParameters = new object[] { claim.ProgramID, claim.ContractYearID }, OrderBy = $"OccurrenceNo desc" });
                getOccurrencesList = recoDbGetOccurrencesResult;
            }

            if (claim.ContractYearID != 0 && claim.ProgramID == EOProgramID)
            {
                var recoDbGetGenerateClaimNumbersResult = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, null, claimdetails.ClaimOrIncident);
                claim.ClaimNo = recoDbGetGenerateClaimNumbersResult.First().NewNumber;
            }
        }

        protected async System.Threading.Tasks.Task ReportDateChange(DateTime? args)
        {
            claim.ClaimDate = claim.ReportDate;
        }

        protected async System.Threading.Tasks.Task ClaimTypeIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task BoardJurisdictionIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LitigationTypeIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task DeductibleChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task AllegationIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task LossCauseIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task Numeric7Change(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task MisrepresentationChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task PunitiveAmountChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NegligentMisrepChange(decimal? args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task NegligenceChange(decimal? args)
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

        protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
        {
            if (Globals.generalsettings.ApplicationName=="REIX CMS" && selectedProvince != defaultProvinceID) {
                claim.ClaimNo = claim.ClaimNo + "SK";
            }

            if (selectedProvince == defaultProvinceID)
            {
                var recoDbGetGenerateClaimNumbersResult = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, null, claimdetails.ClaimOrIncident);
                claim.ClaimNo = recoDbGetGenerateClaimNumbersResult.First().NewNumber;
            }
        }

        protected async System.Threading.Tasks.Task ClaimInitiationIdChange(dynamic args)
        {
            isDirty = true;
        }

        protected async System.Threading.Tasks.Task OccurrenceIdRowSelect(RecoCms6.Models.RecoDb.Occurrence args)
        {
            claim.OccurrenceID = args.OccurrenceID;

            var recoDbGetGenerateClaimNumbersResult = await RecoDb.GetGenerateClaimNumbers(claim.ProgramID, claim.ContractYearID, claim.OccurrenceID, null);
            claim.ClaimNo = recoDbGetGenerateClaimNumbersResult.First().NewNumber;

            var recoDbGetTradesResult = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { args.OccurrenceID } });
            if (recoDbGetTradesResult.FirstOrDefault() != null) {
                occurrencetrade = recoDbGetTradesResult.FirstOrDefault();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddOccurrenceClick(MouseEventArgs args)
        {
            var recoDbGetGenerateNewOccurrencesResult = await RecoDb.GetGenerateNewOccurrences(claim.ProgramID, claim.ContractYearID, $"{Security.User.Id}");
            await occurrenceId.Reload();

            claim.OccurrenceID = Int32.Parse(recoDbGetGenerateNewOccurrencesResult.First().NewOccurrenceID.ToString());

            await InvokeAsync(() => {StateHasChanged();});

            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { claim.OccurrenceID } });
            occurrenceId.Value = recoDbGetOccurrencesResult.First();
        }

        protected async System.Threading.Tasks.Task ButtonAddInsuredClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInsured>("Add Insured", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID}, {"InsuredID", 0} }, new DialogOptions(){ Width = $"{1024}px" });
            var recoDbGetClaimInsuredsResult = await RecoDb.GetClaimInsureds(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getInsuredsList = recoDbGetClaimInsuredsResult;

            await InvokeAsync(() => {StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task GridInsuredsRowSelect(RecoCms6.Models.RecoDb.ClaimInsured args)
        {
            var dialogResult = await DialogService.OpenAsync<AddInsured>("Add Insured", new Dictionary<string, object>() { {"ClaimID", claim.ClaimID}, {"InsuredID", args.InsuredID} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null)
            {
                var recoDbGetClaimInsuredsResult = await RecoDb.GetClaimInsureds(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getInsuredsList = recoDbGetClaimInsuredsResult;
            }

            if (dialogResult != null)
            {
                await InvokeAsync(() => {StateHasChanged();});
            }
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

        protected async System.Threading.Tasks.Task ButtonAddCrossReferenceClaimsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>("Claims", new Dictionary<string, object>() { {"ProgramID", claim.ProgramID}, {"ExcludeClaimID", claim.ClaimID}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
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

            }

            if (dialogResult != null && dialogResult != 0)
            {
                await gridCrossRefFiles.Reload();
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddClaimantClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimant>($"Add {Globals.generalsettings.ClaimantName}", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "ClaimantID", 0 } }, new DialogOptions() { Width = $"{800}px" });
            var recoDbGetClaimClaimantsResult = await RecoDb.GetClaimClaimants(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"ClaimantOrder asc" });
            getClaimantsList = recoDbGetClaimClaimantsResult;

            await InvokeAsync(() => { StateHasChanged(); });
        }

        private bool _updateClaimantOpened;
        protected async System.Threading.Tasks.Task GridClaimantsRowSelect(RecoCms6.Models.RecoDb.ClaimClaimant args)
        {
            if (_updateClaimantOpened)
            {
                return;
            }

            _updateClaimantOpened = true;

            var dialogResult = await DialogService.OpenAsync<AddClaimant>("Add Claimant", new Dictionary<string, object>() { { "ClaimID", claim.ClaimID }, { "ClaimantID", args.ClaimantID } }, new DialogOptions() { Width = $"{1024}px" });
            if (dialogResult != null)
            {
                var recoDbGetClaimClaimantsResult = await RecoDb.GetClaimClaimants(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"ClaimantOrder asc" });
                getClaimantsList = recoDbGetClaimClaimantsResult;

                await InvokeAsync(() => { StateHasChanged(); });
            }

            _updateClaimantOpened = false;
        }


        protected async System.Threading.Tasks.Task ButtonAddTradeClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTrade>($"{Globals.generalsettings.LocationName}", new Dictionary<string, object>() { {"TradeID", 0}, {"ClaimID", claim.ClaimID} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null)
            {
                var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getTradesList = recoDbGetTradeDetailsResult;
            }
        }

        protected async System.Threading.Tasks.Task TradePostalCodeChange(string args)
        {
            if (claimtrade.PostalCode.Length == 7)
            {
                GetPostalCodeDetails();
            }
        }

        protected async System.Threading.Tasks.Task TradeProvinceChange(dynamic args)
        {
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 && i.ParentParameterID == @1", FilterParameters = new object[] { "City", claimtrade.Province }, OrderBy = $"ParamDesc asc" });
            getCityList = recoDbGetParameterDetailsResult;
        }

        protected async System.Threading.Tasks.Task ButtonSaveTradeClick(MouseEventArgs args)
        {
            if (claimtrade.Address1 == null)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Address is required" });
                return;
            }

            var saveTradeResult = await SaveTrade();
        }

        protected async System.Threading.Tasks.Task ButtonCloseFormClick(MouseEventArgs args)
        {
            if (claimtrade.Address1 != null && claimtrade.Address1 != String.Empty)
            {
                var saveTradeResult = await SaveTrade();
            }

            DialogService.Close(claim);

            UriHelper.NavigateTo($"edit-claim/{claim.ClaimID.ToBase64()}");
        }
    }
}
