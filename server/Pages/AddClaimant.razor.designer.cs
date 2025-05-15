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
    public partial class AddClaimantComponent : ComponentBase, IDisposable
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

        [Parameter]
        public dynamic ClaimantID { get; set; }

        protected RadzenDataGrid<Claimant> datagrid0;

        List<Claimant> _getClaimantList;
        protected List<Claimant> getClaimantList
        {
            get
            {
                return _getClaimantList;
            }
            set
            {
                if (!object.Equals(_getClaimantList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getClaimantList", NewValue = value, OldValue = _getClaimantList };
                    _getClaimantList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected async System.Threading.Tasks.Task NameChange(string args)
        {
            if (getClaimantList.Count(c => c.Name == claimant.Name) > 0)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = $"Duplicate Claimant Name", Detail = $"Please be advised that this claimant name may already exist for this occurrence" });
            }
            rfvClaimantName = string.IsNullOrEmpty(claimant.Name);
        }

        int _intClaimantID;
        protected int intClaimantID
        {
            get
            {
                return _intClaimantID;
            }
            set
            {
                if (!object.Equals(_intClaimantID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intClaimantID", NewValue = value, OldValue = _intClaimantID };
                    _intClaimantID = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimantLitigationRolesList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getClaimantLitigationRolesList
        {
            get
            {
                return _getClaimantLitigationRolesList;
            }
            set
            {
                if (!object.Equals(_getClaimantLitigationRolesList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimantLitigationRolesList", NewValue = value, OldValue = _getClaimantLitigationRolesList };
                    _getClaimantLitigationRolesList = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimantTransactionRolesList;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethodsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethodsList
        {
            get
            {
                return _getCommunicationMethodsList;
            }
            set
            {
                if (!object.Equals(_getCommunicationMethodsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommunicationMethodsList", NewValue = value, OldValue = _getCommunicationMethodsList };
                    _getCommunicationMethodsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _CDProgramID;
        protected int CDProgramID
        {
            get
            {
                return _CDProgramID;
            }
            set
            {
                if (!object.Equals(_CDProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CDProgramID", NewValue = value, OldValue = _CDProgramID };
                    _CDProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _CPProgramID;
        protected int CPProgramID
        {
            get
            {
                return _CPProgramID;
            }
            set
            {
                if (!object.Equals(_CPProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "CPProgramID", NewValue = value, OldValue = _CPProgramID };
                    _CPProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getPaymentsOwedByList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getPaymentsOwedByList
        {
            get
            {
                return _getPaymentsOwedByList;
            }
            set
            {
                if (!object.Equals(_getPaymentsOwedByList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPaymentsOwedByList", NewValue = value, OldValue = _getPaymentsOwedByList };
                    _getPaymentsOwedByList = value;
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

        RecoCms6.Models.RecoDb.ClaimantSolicitor _solicitor;
        protected RecoCms6.Models.RecoDb.ClaimantSolicitor solicitor
        {
            get
            {
                return _solicitor;
            }
            set
            {
                if (!object.Equals(_solicitor, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "solicitor", NewValue = value, OldValue = _solicitor };
                    _solicitor = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.File> _getFilesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.File> getFilesResult
        {
            get
            {
                return _getFilesResult;
            }
            set
            {
                if (!object.Equals(_getFilesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFilesResult", NewValue = value, OldValue = _getFilesResult };
                    _getFilesResult = value;
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

        int _progress;
        protected int progress
        {
            get
            {
                return _progress;
            }
            set
            {
                if (!object.Equals(_progress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "progress", NewValue = value, OldValue = _progress };
                    _progress = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles0;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles0
        {
            get
            {
                return _uploadedFiles0;
            }
            set
            {
                if (!object.Equals(_uploadedFiles0, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles0", NewValue = value, OldValue = _uploadedFiles0 };
                    _uploadedFiles0 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles1;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles1
        {
            get
            {
                return _uploadedFiles1;
            }
            set
            {
                if (!object.Equals(_uploadedFiles1, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles1", NewValue = value, OldValue = _uploadedFiles1 };
                    _uploadedFiles1 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles2;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles2
        {
            get
            {
                return _uploadedFiles2;
            }
            set
            {
                if (!object.Equals(_uploadedFiles2, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles2", NewValue = value, OldValue = _uploadedFiles2 };
                    _uploadedFiles2 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles3;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles3
        {
            get
            {
                return _uploadedFiles3;
            }
            set
            {
                if (!object.Equals(_uploadedFiles3, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles3", NewValue = value, OldValue = _uploadedFiles3 };
                    _uploadedFiles3 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles4;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles4
        {
            get
            {
                return _uploadedFiles4;
            }
            set
            {
                if (!object.Equals(_uploadedFiles4, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles4", NewValue = value, OldValue = _uploadedFiles4 };
                    _uploadedFiles4 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles5;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles5
        {
            get
            {
                return _uploadedFiles5;
            }
            set
            {
                if (!object.Equals(_uploadedFiles5, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles5", NewValue = value, OldValue = _uploadedFiles5 };
                    _uploadedFiles5 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles6;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles6
        {
            get
            {
                return _uploadedFiles6;
            }
            set
            {
                if (!object.Equals(_uploadedFiles6, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles6", NewValue = value, OldValue = _uploadedFiles6 };
                    _uploadedFiles6 = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Radzen.FileInfo> _uploadedFiles7;
        protected IEnumerable<Radzen.FileInfo> uploadedFiles7
        {
            get
            {
                return _uploadedFiles7;
            }
            set
            {
                if (!object.Equals(_uploadedFiles7, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "uploadedFiles7", NewValue = value, OldValue = _uploadedFiles7 };
                    _uploadedFiles7 = value;
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

        IEnumerable<int> _OriginalRoles;
        protected IEnumerable<int> OriginalRoles
        {
            get
            {
                return _OriginalRoles;
            }
            set
            {
                if (!object.Equals(_OriginalRoles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "OriginalRoles", NewValue = value, OldValue = _OriginalRoles };
                    _OriginalRoles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvClaimantName;
        protected bool rfvClaimantName
        {
            get
            {
                return _rfvClaimantName;
            }
            set
            {
                if (!object.Equals(_rfvClaimantName, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvClaimantName", NewValue = value, OldValue = _rfvClaimantName };
                    _rfvClaimantName = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }
        bool _rfvClaimantSolicitor;
        protected bool rfvClaimantSolicitor
        {
            get
            {
                return _rfvClaimantSolicitor;
            }
            set
            {
                if (!object.Equals(_rfvClaimantSolicitor, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvClaimantSolicitor", NewValue = value, OldValue = _rfvClaimantSolicitor };
                    _rfvClaimantSolicitor = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvClaimantPostalCode;
        protected bool rfvClaimantPostalCode
        {
            get
            {
                return _rfvClaimantPostalCode;
            }
            set
            {
                if (!object.Equals(_rfvClaimantPostalCode, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvClaimantPostalCode", NewValue = value, OldValue = _rfvClaimantPostalCode };
                    _rfvClaimantPostalCode = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvClaimantEmail;
        protected bool rfvClaimantEmail
        {
            get
            {
                return _rfvClaimantEmail;
            }
            set
            {
                if (!object.Equals(_rfvClaimantEmail, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvClaimantEmail", NewValue = value, OldValue = _rfvClaimantEmail };
                    _rfvClaimantEmail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvSolicitorEmail;
        protected bool rfvSolicitorEmail
        {
            get
            {
                return _rfvSolicitorEmail;
            }
            set
            {
                if (!object.Equals(_rfvSolicitorEmail, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvSolicitorEmail", NewValue = value, OldValue = _rfvSolicitorEmail };
                    _rfvSolicitorEmail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bPageIsValid;
        protected bool bPageIsValid
        {
            get
            {
                return _bPageIsValid;
            }
            set
            {
                if (!object.Equals(_bPageIsValid, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bPageIsValid", NewValue = value, OldValue = _bPageIsValid };
                    _bPageIsValid = value;
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
            intClaimantID = ClaimantID;

            claimant = intClaimantID > 0 ? Get(intClaimantID) : new RecoCms6.Models.RecoDb.Claimant(){};
;

            isEOProgram = false;

            claimant.ClaimID = ClaimID;

            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc,RegistrantNo asc" });
            getRegistrantsResult = recoDbGetRegistrantsResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2 || i.ParamTypeDesc == @3 || i.ParamTypeDesc == @4 || i.ParamTypeDesc == @5", FilterParameters = new object[] { "ProgramID", "Claimant Litigation Role", "Province", "Method Of Communication", "Claimant Transaction Role", "PaymentsOwedBy" }, OrderBy = $"ParamDesc asc" });
            getParametersResult = recoDbGetParameterDetailsResult;

            EOProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="EO").First().ParameterID;

            getClaimantLitigationRolesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claimant Litigation Role");

            getProvincesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getClaimantTransactionRolesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claimant Transaction Role");

            getCommunicationMethodsList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method Of Communication");

            CDProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="CDP").First().ParameterID;

            CPProgramID = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID" && p.ParamAbbrev=="CPP").First().ParameterID;

            getPaymentsOwedByList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="PaymentsOwedBy");

            var recoDbGetClaimantSolicitorsResult = await RecoDb.GetClaimantSolicitors();
            getClaimantSolicitorsResult = recoDbGetClaimantSolicitorsResult;

            if (claimant.ClaimantSolicitorID != null) {
                solicitor = recoDbGetClaimantSolicitorsResult.First(cs=>cs.SolicitorID == claimant.ClaimantSolicitorID);
            }

            if (claimant.ClaimantSolicitorID == null) {
                solicitor = new RecoCms6.Models.RecoDb.ClaimantSolicitor();
            }

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;

            var recoDbGetFilesResult = await RecoDb.GetFiles();
            getFilesResult = recoDbGetFilesResult;

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            isEOProgram = recoDbGetClaimsResult.First().ProgramID == EOProgramID;

            isCPProgram = recoDbGetClaimsResult.First().ProgramID == CPProgramID;

            isCDProgram = recoDbGetClaimsResult.First().ProgramID == CDProgramID;

            claim = recoDbGetClaimsResult.First();

            progress = 0;

            uploadedFiles0 = new List<FileInfo>();

            uploadedFiles1 = new List<FileInfo>();

            uploadedFiles2 = new List<FileInfo>();

            uploadedFiles3 = new List<FileInfo>();

            uploadedFiles4 = new List<FileInfo>();

            uploadedFiles5 = new List<FileInfo>();

            uploadedFiles6 = new List<FileInfo>();

            uploadedFiles7 = new List<FileInfo>();

            if (intClaimantID == 0 && Globals.defaultProvinceID != 0) {
                claimant.ProvinceID = Globals.defaultProvinceID;
            }

            if (intClaimantID != 0)
            {
                var recoDbGetClaimantLitigationRolesResult = await RecoDb.GetClaimantLitigationRoles(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { intClaimantID } });
                Roles = recoDbGetClaimantLitigationRolesResult.Select(x=>x.LitigationRole).ToArray();
            }

            if (intClaimantID ==0) {
                Roles = new int[] {};;
            }

            OriginalRoles = Roles;

            var recoDbGetParameterDetailsResult0 = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "Claimant Transaction Role" }, OrderBy = $"ParamDesc asc" });
            if (isEOProgram) {
                getClaimantTransactionRolesList = recoDbGetParameterDetailsResult0.Where(p=>p.ParamTypeDesc=="Claimant Transaction Role" && p.ParamValue==null);
            }

            if (isCPProgram) {
                getClaimantTransactionRolesList = recoDbGetParameterDetailsResult0.Where(p=>p.ParamTypeDesc=="Claimant Transaction Role" && p.ParamValue==CPProgramID);
            }

            if (isCDProgram) {
                getClaimantTransactionRolesList = recoDbGetParameterDetailsResult0.Where(p=>p.ParamTypeDesc=="Claimant Transaction Role" && p.ParamValue==CDProgramID);
            }

            var recoDbGetClaimantsResult = await RecoDb.GetClaimants(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID }, OrderBy = $"Name asc" });
            getClaimantList = recoDbGetClaimantsResult.ToList();

            rfvClaimantName = false;

            rfvClaimantSolicitor = false;

            rfvClaimantPostalCode = false;

            rfvClaimantEmail = false;

            rfvSolicitorEmail = false;

            bPageIsValid = false;
        }

        protected async System.Threading.Tasks.Task ButtonNewBrokerageClick(MouseEventArgs args)
        {
            var brokerage = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null);
            if (brokerage?.BrokerageID is null)
                return;

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;
            claimant.CooperatingBrokerageID = brokerage.BrokerageID;
        }

        protected async System.Threading.Tasks.Task ClaimantSolicitorIdChange(dynamic args)
        {
            if (claimant.ClaimantSolicitorID != null)
            {
                var recoDbGetClaimantSolicitorsResult = await RecoDb.GetClaimantSolicitors(new Query() { Filter = $@"i => i.SolicitorID == @0", FilterParameters = new object[] { claimant.ClaimantSolicitorID } });
                solicitor = recoDbGetClaimantSolicitorsResult.First();
            }
            rfvClaimantSolicitor = claimant.ClaimantSolicitorID is null;
        }

        protected async System.Threading.Tasks.Task ButtonNewSolicitorClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimantSolicitor>("Add Claimant Solicitor", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                claimant.ClaimantSolicitorID = dialogResult.SolicitorID;
            }

            if (dialogResult != null)
            {
                var recoDbGetClaimantSolicitorsResult = await RecoDb.GetClaimantSolicitors();
                getClaimantSolicitorsResult = recoDbGetClaimantSolicitorsResult;

                solicitor = recoDbGetClaimantSolicitorsResult.First(cp=>cp.SolicitorID == claimant.ClaimantSolicitorID);
            }
        }

        protected async System.Threading.Tasks.Task ButtonSaveClick(MouseEventArgs args)
        {
            Validate();

            if (intClaimantID == 0 && bPageIsValid) {
                claimant.ID = Guid.NewGuid();;
            }

            if (intClaimantID == 0 && bPageIsValid)
            {
                var recoDbGetNextClaimDisplayOrdersResult = await RecoDb.GetNextClaimDisplayOrders(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
                claimant.ClaimantOrder = (short)recoDbGetNextClaimDisplayOrdersResult.First().NextClaimantDisplayOrder;
            }

            if (bPageIsValid)
            {
                CreateAndLinkLitigationRoles();
            }

            if (intClaimantID == 0 && bPageIsValid)
            {
                var recoDbCreateClaimantResult = await RecoDb.CreateClaimant(claimant);
                if (claimant.ClaimantSolicitorID != null)
                {
                    var recoDbUpdateClaimantSolicitorResult = await RecoDb.UpdateClaimantSolicitor(solicitor.ID, solicitor);

                }

                DialogService.Close(claimant);
            }

            if (intClaimantID != 0 && bPageIsValid)
            {
                var recoDbUpdateClaimantResult = await RecoDb.UpdateClaimant(claimant.ID, claimant);
                if (claimant.ClaimantSolicitorID != null)
                {
                    var recoDbUpdateClaimantSolicitorResult0 = await RecoDb.UpdateClaimantSolicitor(solicitor.ID, solicitor);

                }

                DialogService.Close(claimant);
            }
        }

        protected async System.Threading.Tasks.Task ButtonCancelClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
