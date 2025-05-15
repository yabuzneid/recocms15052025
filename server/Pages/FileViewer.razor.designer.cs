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
    public partial class FileViewerComponent : ComponentBase, IDisposable
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
        public dynamic ID { get; set; }

        string _DocumentPath;
        protected string DocumentPath
        {
            get
            {
                return _DocumentPath;
            }
            set
            {
                if (!object.Equals(_DocumentPath, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "DocumentPath", NewValue = value, OldValue = _DocumentPath };
                    _DocumentPath = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _viewerVisible;
        protected bool viewerVisible
        {
            get
            {
                return _viewerVisible;
            }
            set
            {
                if (!object.Equals(_viewerVisible, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "viewerVisible", NewValue = value, OldValue = _viewerVisible };
                    _viewerVisible = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.File _ViewFile;
        protected RecoCms6.Models.RecoDb.File ViewFile
        {
            get
            {
                return _ViewFile;
            }
            set
            {
                if (!object.Equals(_ViewFile, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "ViewFile", NewValue = value, OldValue = _ViewFile };
                    _ViewFile = value;
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
            DocumentPath = string.Empty;

            viewerVisible = true;

            var recoDbGetFileByIdResult = await RecoDb.GetFileById(new Guid(ID));
            ViewFile = recoDbGetFileByIdResult;

            if (ViewFile != null)
            {
                await ShowFileAsync(ViewFile);
            }
        }
    }
}
