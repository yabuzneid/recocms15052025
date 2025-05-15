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
    public partial class DialogSelectFileComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.File> datagrid0;

        IEnumerable<RecoCms6.Models.RecoDb.File> _claimFiles;
        protected IEnumerable<RecoCms6.Models.RecoDb.File> claimFiles
        {
            get
            {
                return _claimFiles;
            }
            set
            {
                if (!object.Equals(_claimFiles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimFiles", NewValue = value, OldValue = _claimFiles };
                    _claimFiles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<int> _SelectedFiles;
        protected IEnumerable<int> SelectedFiles
        {
            get
            {
                return _SelectedFiles;
            }
            set
            {
                if (!object.Equals(_SelectedFiles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "SelectedFiles", NewValue = value, OldValue = _SelectedFiles };
                    _SelectedFiles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IList<RecoCms6.Models.RecoDb.File> _ChosenFiles;
        protected IList<RecoCms6.Models.RecoDb.File> ChosenFiles
        {
            get
            {
                return _ChosenFiles;
            }
            set
            {
                if (!object.Equals(_ChosenFiles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "ChosenFiles", NewValue = value, OldValue = _ChosenFiles };
                    _ChosenFiles = value;
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

        IEnumerable<string> _imageExtensions;
        protected IEnumerable<string> imageExtensions
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

        IEnumerable<string> _avExtensions;
        protected IEnumerable<string> avExtensions
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
            var recoDbGetFilesResult = await RecoDb.GetFiles(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID }, OrderBy = $"EntryDate desc" });
            claimFiles = recoDbGetFilesResult;

            SelectedFiles = Enumerable.Empty<int>();;

            ChosenFiles = new List<RecoCms6.Models.RecoDb.File>();

            docExtensions = new List<string>{".pdf", ".xls", ".xlsx", ".doc", ".docx"};

            imageExtensions = new List<string>{ ".png", ".jpeg", ".jpg", ".gif" };

            avExtensions = new List<string>{ ".avi", ".mov", ".mp4", ".mp3", ".m4a", ".wav" };
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args, dynamic data)
        {
            await DownloadFileAsync(data);
        }

        protected async System.Threading.Tasks.Task ButtonAddClick(MouseEventArgs args)
        {
            DialogService.Close(ChosenFiles);
        }

        protected async System.Threading.Tasks.Task ButtonCancekClick(MouseEventArgs args)
        {
            DialogService.Close(new List<File>());
        }
    }
}
