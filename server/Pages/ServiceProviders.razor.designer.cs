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
    public partial class ServiceProvidersComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.ServiceProviderDetail> grid0;

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

        string _buttonTitle;
        protected string buttonTitle
        {
            get
            {
                return _buttonTitle;
            }
            set
            {
                if (!object.Equals(_buttonTitle, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "buttonTitle", NewValue = value, OldValue = _buttonTitle };
                    _buttonTitle = value;
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
            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"Name asc" });
            getServiceProvidersResult = recoDbGetServiceProviderDetailsResult;

            if (Globals.generalsettings.ApplicationName=="RECO CMS") {
                buttonTitle = "Add Outside Service Provider";
            }

            if (Globals.generalsettings.ApplicationName != "RECO CMS") {
                buttonTitle = "Add Service Provider";
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddOutsideSpClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddServiceProvider>("Add Service Provider", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonAddInternalSpClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddApplicationUser>("Add Application User", null, new DialogOptions(){ Width = $"{800}px",Resizable = true,Draggable = true });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        private bool _isEditServiceProviderDialogOpen = false;
        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.ServiceProviderDetail args)
        {
            if (_isEditServiceProviderDialogOpen)
                return;

            _isEditServiceProviderDialogOpen = true;
            var dialogResult = await DialogService.OpenAsync<EditServiceProvider>("Edit Service Provider", new Dictionary<string, object>() { {"ID", args.ID} });
            _isEditServiceProviderDialogOpen = false;
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
