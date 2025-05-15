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
    public partial class AddFileComponent : ComponentBase, IDisposable
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getFileTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getFileTypeList
        {
            get
            {
                return _getFileTypeList;
            }
            set
            {
                if (!object.Equals(_getFileTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFileTypeList", NewValue = value, OldValue = _getFileTypeList };
                    _getFileTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getStandardFilenames;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getStandardFilenames
        {
            get
            {
                return _getStandardFilenames;
            }
            set
            {
                if (!object.Equals(_getStandardFilenames, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStandardFilenames", NewValue = value, OldValue = _getStandardFilenames };
                    _getStandardFilenames = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getClaimReportID;
        protected int getClaimReportID
        {
            get
            {
                return _getClaimReportID;
            }
            set
            {
                if (!object.Equals(_getClaimReportID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimReportID", NewValue = value, OldValue = _getClaimReportID };
                    _getClaimReportID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.File _file;
        protected RecoCms6.Models.RecoDb.File file
        {
            get
            {
                return _file;
            }
            set
            {
                if (!object.Equals(_file, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "file", NewValue = value, OldValue = _file };
                    _file = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _fileInfo;
        protected string fileInfo
        {
            get
            {
                return _fileInfo;
            }
            set
            {
                if (!object.Equals(_fileInfo, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "fileInfo", NewValue = value, OldValue = _fileInfo };
                    _fileInfo = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _standardfilename;
        protected string standardfilename
        {
            get
            {
                return _standardfilename;
            }
            set
            {
                if (!object.Equals(_standardfilename, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "standardfilename", NewValue = value, OldValue = _standardfilename };
                    _standardfilename = value;
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
            roles = new List<Role>();

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            claim = recoDbGetClaimsResult.First();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "File Type", "Standard Filename" }, OrderBy = $"ParamDesc asc" });
            getFileTypeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="File Type");

            getStandardFilenames = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Standard Filename" && p.ParamValue==claim.ProgramID);

            getClaimReportID = recoDbGetParameterDetailsResult.FirstOrDefault(pd=>pd.ParamDesc=="Claim Report").ParameterID;

            file = new RecoCms6.Models.RecoDb.File();

            fileInfo = String.Empty;

            standardfilename = String.Empty;
        }

        protected async System.Threading.Tasks.Task DropdownStandardFilenameChange(dynamic args)
        {
            if (String.IsNullOrEmpty(file.Subject)) {
                file.Subject = standardfilename;
            }
        }

        protected async System.Threading.Tasks.Task ButtonSaveClick(MouseEventArgs args)
        {
            await UploadFiles();
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
