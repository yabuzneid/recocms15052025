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
    public partial class AddCommissionClaimComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.OccurrenceClaimTrade> grid0;

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

        RecoCms6.Models.RecoDb.Claim _parentclaim;
        protected RecoCms6.Models.RecoDb.Claim parentclaim
        {
            get
            {
                return _parentclaim;
            }
            set
            {
                if (!object.Equals(_parentclaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "parentclaim", NewValue = value, OldValue = _parentclaim };
                    _parentclaim = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getOccurenceReasonList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getOccurenceReasonList
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethodList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethodList
        {
            get
            {
                return _getCommunicationMethodList;
            }
            set
            {
                if (!object.Equals(_getCommunicationMethodList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommunicationMethodList", NewValue = value, OldValue = _getCommunicationMethodList };
                    _getCommunicationMethodList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getTransactionRoles;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getTransactionRoles
        {
            get
            {
                return _getTransactionRoles;
            }
            set
            {
                if (!object.Equals(_getTransactionRoles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTransactionRoles", NewValue = value, OldValue = _getTransactionRoles };
                    _getTransactionRoles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getOccurrenceStatusList;
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

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProvidersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProvidersResult
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

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getOutsideCounselList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getOutsideCounselList
        {
            get
            {
                return _getOutsideCounselList;
            }
            set
            {
                if (!object.Equals(_getOutsideCounselList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOutsideCounselList", NewValue = value, OldValue = _getOutsideCounselList };
                    _getOutsideCounselList = value;
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

        bool _newMasterClaim;
        protected bool newMasterClaim
        {
            get
            {
                return _newMasterClaim;
            }
            set
            {
                if (!object.Equals(_newMasterClaim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newMasterClaim", NewValue = value, OldValue = _newMasterClaim };
                    _newMasterClaim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedOccurrenceID;
        protected int selectedOccurrenceID
        {
            get
            {
                return _selectedOccurrenceID;
            }
            set
            {
                if (!object.Equals(_selectedOccurrenceID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedOccurrenceID", NewValue = value, OldValue = _selectedOccurrenceID };
                    _selectedOccurrenceID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedProgramID;
        protected int selectedProgramID
        {
            get
            {
                return _selectedProgramID;
            }
            set
            {
                if (!object.Equals(_selectedProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedProgramID", NewValue = value, OldValue = _selectedProgramID };
                    _selectedProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedContractYearID;
        protected int selectedContractYearID
        {
            get
            {
                return _selectedContractYearID;
            }
            set
            {
                if (!object.Equals(_selectedContractYearID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedContractYearID", NewValue = value, OldValue = _selectedContractYearID };
                    _selectedContractYearID = value;
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

        int _selectedRegistrantID;
        protected int selectedRegistrantID
        {
            get
            {
                return _selectedRegistrantID;
            }
            set
            {
                if (!object.Equals(_selectedRegistrantID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedRegistrantID", NewValue = value, OldValue = _selectedRegistrantID };
                    _selectedRegistrantID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bUpdateRegistrant;
        protected bool bUpdateRegistrant
        {
            get
            {
                return _bUpdateRegistrant;
            }
            set
            {
                if (!object.Equals(_bUpdateRegistrant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bUpdateRegistrant", NewValue = value, OldValue = _bUpdateRegistrant };
                    _bUpdateRegistrant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedClaimantID;
        protected int selectedClaimantID
        {
            get
            {
                return _selectedClaimantID;
            }
            set
            {
                if (!object.Equals(_selectedClaimantID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedClaimantID", NewValue = value, OldValue = _selectedClaimantID };
                    _selectedClaimantID = value;
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

        RecoCms6.Models.RecoDb.Insured _insured;
        protected RecoCms6.Models.RecoDb.Insured insured
        {
            get
            {
                return _insured;
            }
            set
            {
                if (!object.Equals(_insured, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "insured", NewValue = value, OldValue = _insured };
                    _insured = value;
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

        bool _bNewOccurrence;
        protected bool bNewOccurrence
        {
            get
            {
                return _bNewOccurrence;
            }
            set
            {
                if (!object.Equals(_bNewOccurrence, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bNewOccurrence", NewValue = value, OldValue = _bNewOccurrence };
                    _bNewOccurrence = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _currentindex;
        protected int currentindex
        {
            get
            {
                return _currentindex;
            }
            set
            {
                if (!object.Equals(_currentindex, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "currentindex", NewValue = value, OldValue = _currentindex };
                    _currentindex = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bNewInsured;
        protected bool bNewInsured
        {
            get
            {
                return _bNewInsured;
            }
            set
            {
                if (!object.Equals(_bNewInsured, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bNewInsured", NewValue = value, OldValue = _bNewInsured };
                    _bNewInsured = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimant> _getClaimantsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimant> getClaimantsList
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

        bool _showRequiredClaimant;
        protected bool showRequiredClaimant
        {
            get
            {
                return _showRequiredClaimant;
            }
            set
            {
                if (!object.Equals(_showRequiredClaimant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "showRequiredClaimant", NewValue = value, OldValue = _showRequiredClaimant };
                    _showRequiredClaimant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Trade> _getTradesList;
        protected IEnumerable<RecoCms6.Models.RecoDb.Trade> getTradesList
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

        bool _showRequiredAddress;
        protected bool showRequiredAddress
        {
            get
            {
                return _showRequiredAddress;
            }
            set
            {
                if (!object.Equals(_showRequiredAddress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "showRequiredAddress", NewValue = value, OldValue = _showRequiredAddress };
                    _showRequiredAddress = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _showRequiredReportDate;
        protected bool showRequiredReportDate
        {
            get
            {
                return _showRequiredReportDate;
            }
            set
            {
                if (!object.Equals(_showRequiredReportDate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "showRequiredReportDate", NewValue = value, OldValue = _showRequiredReportDate };
                    _showRequiredReportDate = value;
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

        string _viewclaimid;
        protected string viewclaimid
        {
            get
            {
                return _viewclaimid;
            }
            set
            {
                if (!object.Equals(_viewclaimid, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "viewclaimid", NewValue = value, OldValue = _viewclaimid };
                    _viewclaimid = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        dynamic _selectedBrokerage;
        protected dynamic selectedBrokerage
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

            masterclaim = new Claim();

            parentclaim = new Claim();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails();
            getProgramsList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev!="EO") ;

            getOpenStatusID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claim Status" && p.ParamDesc=="Open").First().ParameterID;

            getContractYearList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Contract Year");

            getProvincesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getYesNoList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="YesNoNA");

            defaultProvinceID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province" && p.ParamValue==1).First().ParameterID;

            claimtrade.Province = defaultProvinceID;

            getOccurenceReasonList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="OccurrenceReason");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method of Communication");

            getTransactionRoles = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Insured Transaction Role");

            getOccurrenceStatusList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Occurrence Status");

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"NameandFirm asc" });
            getServiceProvidersResult = recoDbGetServiceProviderDetailsResult;

            getOutsideCounselList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FirmType=="Outside Counsel" || sp.ServiceProviderRole=="Outside Counsel");

            getDefenseCounselList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FirmType=="Defense Counsel");

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages();
            getBrokeragesResult = recoDbGetBrokeragesResult;

            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences();
            getOccurrencesResult = recoDbGetOccurrencesResult;

            claim.ClaimStatusID = getOpenStatusID;

            claim.ID = Guid.NewGuid();

            currentStep = 0;

            previousStep = 0;

            claimdetails = new RecoCms6.Models.RecoDb.EoClaimDetail();

            isEOProgram = false;

            claimdetails.ClaimOrIncident = false;

            newClaim = true;

            newMasterClaim = false;

            selectedOccurrenceID = 0;

            selectedProgramID = 0;

            selectedContractYearID = 0;

            selectedClaimID = 0;

            selectedRegistrantID = 0;

            bUpdateRegistrant = false;

            selectedClaimantID = 0;

            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
            getRegistrantsResult = recoDbGetRegistrantsResult;

            insured = new Insured();

            registrant = new Registrant();

            insured.ProvinceID = Globals.defaultProvinceID;

            bNewOccurrence = false;

            currentindex = 0;
        }

        protected async System.Threading.Tasks.Task Steps0Change(int args)
        {
            previousStep = currentStep;

            currentStep = args;

            if (previousStep == 1)
            {
                var recoDbUpdateOccurrenceResult = await RecoDb.UpdateOccurrence(occurrence.ID, occurrence);

            }

            if (previousStep == 2) {
                bNewInsured = insured.ID == Guid.Empty;
            }

            if (previousStep == 2 && bNewInsured) {
                insured.ID = Guid.NewGuid();
            }

            if (previousStep == 2 && insured.RegistrantID != 0 && insured.Name != null && insured.BrokerageID != null && bNewInsured)
            {
                var recoDbCreateInsuredResult = await RecoDb.CreateInsured(insured);

            }

            if (previousStep == 2 && insured.RegistrantID != 0 && insured.Name != null && insured.BrokerageID != null && !bNewInsured)
            {
                var recoDbUpdateInsuredResult = await RecoDb.UpsertInsured(insured.ID, insured);
            }

            if (currentStep == 3)
            {
                var recoDbGetOccurrenceClaimantsResult = await RecoDb.GetOccurrenceClaimants(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { occurrence.OccurrenceID }, OrderBy = $"ClaimantDisplay asc" });
                getClaimantsList = recoDbGetOccurrenceClaimantsResult;

                showRequiredClaimant = false;
            }

            if (currentStep == 3)
            {
                var recoDbGetTradesResult = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
                getTradesList = recoDbGetTradesResult;

                showRequiredAddress = false;

                showRequiredReportDate = false;

                showRequiredClaimant = false;
            }

            if (currentStep == 3) {
                claimtrade.Province = Globals.defaultProvinceID;
            }
        }

        protected async System.Threading.Tasks.Task ProgramIdChange(dynamic args)
        {
            if (selectedContractYearID != 0 && selectedProgramID != 0)
            {
                var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.ProgramID == @0 && i.ContractYearID == @1", FilterParameters = new object[] { selectedProgramID, selectedContractYearID }, OrderBy = $"OccurrenceNo desc" });
                getOccurrencesResult = recoDbGetOccurrencesResult;
            }
        }

        protected async System.Threading.Tasks.Task ContractYearIdChange(dynamic args)
        {
            if (selectedContractYearID != 0 && selectedProgramID != 0)
            {
                var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.ProgramID == @0 && i.ContractYearID == @1", FilterParameters = new object[] { selectedProgramID, selectedContractYearID }, OrderBy = $"OccurrenceNo desc" });
                getOccurrencesResult = recoDbGetOccurrencesResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddOccurrenceClick(MouseEventArgs args)
        {
            var recoDbGetGenerateNewOccurrencesResult = await RecoDb.GetGenerateNewOccurrences(selectedProgramID, selectedContractYearID, $"{Security.User.Id}");
            selectedOccurrenceID = Int32.Parse(recoDbGetGenerateNewOccurrencesResult.First().NewOccurrenceID.ToString());

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { recoDbGetGenerateNewOccurrencesResult.First().NewClaimID.ToString() } });
            masterclaim = recoDbGetClaimsResult.FirstOrDefault();

            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.ProgramID == @0 && i.ContractYearID == @1", FilterParameters = new object[] { selectedProgramID, selectedContractYearID }, OrderBy = $"OccurrenceNo desc" });
            getOccurrencesResult = recoDbGetOccurrencesResult;

            occurrence = recoDbGetOccurrencesResult.First(x=>x.OccurrenceID == selectedOccurrenceID);

            insured = new Insured();

            await InvokeAsync(() => {StateHasChanged();});

            bNewOccurrence = true;
        }

        protected async System.Threading.Tasks.Task SelectedOccurrenceChange(dynamic args)
        {
            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { selectedOccurrenceID } });
            occurrence = recoDbGetOccurrencesResult.First();

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.OccurrenceID == @0 && (i.MasterFile == @1 || i.MasterFileID==i.ClaimID)", FilterParameters = new object[] { selectedOccurrenceID, true } });
            masterclaim = recoDbGetClaimsResult.First();

            var recoDbGetInsuredsResult = await RecoDb.GetInsureds(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { masterclaim.ClaimID } });
            if (recoDbGetInsuredsResult.Count() > 0) {
                insured = recoDbGetInsuredsResult.First();
            }

            if (recoDbGetInsuredsResult.Count() == 0) {
                insured = new Insured();
            }
        }

        protected async System.Threading.Tasks.Task ButtonNewClaimClick(MouseEventArgs args)
        {
            currentindex = 3;

            await Steps0Change(currentindex);
        }

        protected async System.Threading.Tasks.Task ReportDateChange(DateTime? args)
        {
            claim.ClaimDate = claim.ReportDate;
        }

        protected async System.Threading.Tasks.Task ButtonAddBrokerageClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                selectedbrokerage = dialogResult;
            }

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;

            if (dialogResult != null) {
                occurrence.BrokerageID = dialogResult.BrokerageID;
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddReceiverClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddReceiver>("Add Receiver", null);
            var recoDbGetReceiversResult = await RecoDb.GetReceivers(new Query() { OrderBy = $"Name asc" });
            getReceiversList = recoDbGetReceiversResult;

            if (dialogResult != null) {
                occurrence.ReceiverID = dialogResult.ReceiverID;
            }
        }

        protected async System.Threading.Tasks.Task ButtonGotoMasterFile0Click(MouseEventArgs args)
        {
            viewclaimid = StringExtensions.ToBase64(masterclaim.ClaimID);

            DialogService.Close(masterclaim);

            UriHelper.NavigateTo($"edit-commission-claim/{viewclaimid}");
        }

        protected async System.Threading.Tasks.Task RegistrantIdChange(dynamic args)
        {
            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { selectedRegistrantID } });
            registrant = recoDbGetRegistrantsResult.FirstOrDefault();

            insured.RegistrantID = registrant.RegistrantID;

            insured.Name = registrant.Name;

            insured.Address = registrant.Address;

            insured.ClaimID = masterclaim.ClaimID;

            insured.PostalCode = registrant.PostalCode;

            insured.BusinessPhoneNum = registrant.BusinessPhoneNum;

            insured.CellPhoneNum = registrant.CellPhoneNum;

            insured.PreferredCommunicationMethodID = registrant.PreferredCommunicationMethodID;

            insured.City = registrant.City;

            insured.ProvinceID = registrant.ProvinceID;

            insured.BrokerageID = registrant.BrokerageID;

            insured.EmailAddress = registrant.EmailAddress;

            insured.DisplayOrder = 1;
        }

        protected async System.Threading.Tasks.Task ButtonNewRegistrantClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddRegistrant>("Add Registrant", null, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null) {
                registrant = dialogResult;
            }

            if (dialogResult != null)
            {
                var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
                getRegistrantsResult = recoDbGetRegistrantsResult;
            }

            if (dialogResult != null) {
                selectedRegistrantID = dialogResult.RegistrantID;
            }

            if (dialogResult != null)
            {
                await RegistrantIdChange(args);
            }

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task InsuredBrokerageIdChange(dynamic args)
        {
            var recoDbGetBrokerageByBrokerageIdResult = await RecoDb.GetBrokerageByBrokerageId(args);
            insured.BrokerageName = recoDbGetBrokerageByBrokerageIdResult.Name;

            insured.BrokerageAddress = recoDbGetBrokerageByBrokerageIdResult.Name;

            insured.BrokerageProvinceID = recoDbGetBrokerageByBrokerageIdResult.ProvinceID;

            insured.BrokerageCity = recoDbGetBrokerageByBrokerageIdResult.City;

            insured.BrokeragePostalCode = recoDbGetBrokerageByBrokerageIdResult.PostalCode;

            insured.EmailAddress = recoDbGetBrokerageByBrokerageIdResult.EmailAddress;

            insured.BrokerageBusinessPhoneNum = recoDbGetBrokerageByBrokerageIdResult.BusinessPhoneNum;

            insured.BrokerOfRecord = recoDbGetBrokerageByBrokerageIdResult.BrokerOfRecordName;
        }

        protected async System.Threading.Tasks.Task ButtonNewBrokerageClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null);
            if (dialogResult != null) {
                selectedBrokerage = dialogResult;
            }

            if (dialogResult != null)
            {
                var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages();
                getBrokeragesResult = recoDbGetBrokeragesResult;

                insured.BrokerageID = selectedbrokerage.BrokerageID;
            }

            if (dialogResult != null) {
                insured.BrokerageName = dialogResult.Name;
            }

            if (dialogResult != null) {
                insured.BrokerageAddress = dialogResult.Address;
            }

            if (dialogResult != null) {
                insured.BrokerageProvinceID = dialogResult.ProvinceID;
            }

            if (dialogResult != null) {
                insured.BrokerageCity = dialogResult.City;
            }

            if (dialogResult != null) {
                insured.BrokeragePostalCode = dialogResult.PostalCode;
            }

            if (dialogResult != null) {
                insured.BrokerageEmailAddress = dialogResult.EmailAddress;
            }

            if (dialogResult != null) {
                insured.BrokerageBusinessPhoneNum = dialogResult.BusinessPhoneNum;
            }

            if (dialogResult != null) {
                insured.BrokerOfRecord = dialogResult.BrokerOfRecordName;
            }
        }

        protected async System.Threading.Tasks.Task DropdownDatagrid2Change(dynamic args)
        {
            var recoDbGetClaimantsResult = await RecoDb.GetClaimants(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { selectedClaimantID }, OrderBy = $"Name asc" });
            if (recoDbGetClaimantsResult != null) {
                claimant = recoDbGetClaimantsResult.First();
            }

            if (recoDbGetClaimantsResult == null) {
                claimant = new Claimant();
            }

            if (recoDbGetClaimantsResult == null) {
                selectedClaimantID = 0;
            }

            showRequiredClaimant = recoDbGetClaimantsResult == null;

            var recoDbGetOccurrenceClaimTradesResult = await RecoDb.GetOccurrenceClaimTrades(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { selectedClaimantID }, OrderBy = $"ClaimNo desc" });
            tradelist = recoDbGetOccurrenceClaimTradesResult;
        }

        protected async System.Threading.Tasks.Task ButtonNewClaimantClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimant>($"Add Claimant", new Dictionary<string, object>() { {"ClaimID", masterclaim.ClaimID}, {"ClaimantID", 0} }, new DialogOptions(){ Width = $"{"75%"}" });
            if (dialogResult != null) {
                claimant = dialogResult;
            }

            if (dialogResult != null) {
                selectedClaimantID = claimant.ClaimantID;
            }

            if (dialogResult != null)
            {
                var recoDbGetOccurrenceClaimantsResult = await RecoDb.GetOccurrenceClaimants(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { occurrence.OccurrenceID }, OrderBy = $"ClaimantDisplay asc" });
                getClaimantsList = recoDbGetOccurrenceClaimantsResult;
            }

            if (dialogResult != null)
            {
                var recoDbGetOccurrenceClaimTradesResult = await RecoDb.GetOccurrenceClaimTrades(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { claimant.ClaimantID }, OrderBy = $"TradeDisplay asc" });
                tradelist = recoDbGetOccurrenceClaimTradesResult;
            }
        }

        protected async System.Threading.Tasks.Task OccurrenceTradeAddress1Change(string args)
        {
            showRequiredAddress = claimtrade.Address1 == String.Empty || claimtrade.Address1 == null;
        }

        protected async System.Threading.Tasks.Task Datepicker0Change(DateTime? args)
        {
            claim.ClaimDate = claim.ReportDate;
        }

        protected async System.Threading.Tasks.Task ButtonNewTradeClick(MouseEventArgs args)
        {
            showRequiredAddress = false;

            if (claimtrade.Address1 == String.Empty || claimtrade.Address1 == null) {
                showRequiredAddress = true;
            }

            showRequiredClaimant = selectedClaimantID == 0;

            showRequiredReportDate = claim.ReportDate == null;

            if (showRequiredAddress || showRequiredClaimant || showRequiredReportDate)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Must Enter An Address, Select a Claimant and Enter Report Date" });
            }

            if (!showRequiredAddress && !showRequiredClaimant && !showRequiredReportDate)
            {
                var recoDbGetGenerateNewClaimantTradeClaimsResult = await RecoDb.GetGenerateNewClaimantTradeClaims(masterclaim.ClaimID, claimant.ClaimantID, $"{claim.ReportDate}", $"{Security.User.Id}");
                claimtrade.ClaimID = (int)recoDbGetGenerateNewClaimantTradeClaimsResult.First().NewClaimID;

                var recoDbCreateTradeResult = await RecoDb.CreateTrade(claimtrade);
                viewclaimid = StringExtensions.ToBase64(claimtrade.ClaimID);

                DialogService.Close(parentclaim);

                UriHelper.NavigateTo($"edit-commission-claim/{viewclaimid}");
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.OccurrenceClaimTrade args)
        {
            viewclaimid = StringExtensions.ToBase64(args.ClaimID);

            DialogService.Close(parentclaim);

            UriHelper.NavigateTo($"edit-commission-claim/{viewclaimid}");
        }

        protected async System.Threading.Tasks.Task ButtonOpenClaimClick(MouseEventArgs args, dynamic data)
        {
            viewclaimid = StringExtensions.ToBase64(data.ClaimID);

            DialogService.Close(null);

            UriHelper.NavigateTo($"edit-commission-claim/{viewclaimid}");
        }

        protected async System.Threading.Tasks.Task ButtonOpenMasterClaimClick(MouseEventArgs args)
        {
            viewclaimid = StringExtensions.ToBase64(masterclaim.ClaimID);

            DialogService.Close(masterclaim);

            UriHelper.NavigateTo($"edit-commission-claim/{viewclaimid}");
        }

        protected async System.Threading.Tasks.Task ButtonCloseFormClick(MouseEventArgs args)
        {
            DialogService.Close(parentclaim);
        }
    }
}
