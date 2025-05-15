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
    public partial class AutoReservingsComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.AutoReserving> grid0;

        IEnumerable<RecoCms6.Models.RecoDb.AutoReserving> _getAutoReservingsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.AutoReserving> getAutoReservingsResult
        {
            get
            {
                return _getAutoReservingsResult;
            }
            set
            {
                if (!object.Equals(_getAutoReservingsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAutoReservingsResult", NewValue = value, OldValue = _getAutoReservingsResult };
                    _getAutoReservingsResult = value;
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
            var recoDbGetAutoReservingsResult = await RecoDb.GetAutoReservings();
            getAutoReservingsResult = recoDbGetAutoReservingsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddAutoReserving>("Add Auto Reserving", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.AutoReserving args)
        {
            var dialogResult = await DialogService.OpenAsync<EditAutoReserving>("Edit Auto Reserving", new Dictionary<string, object>() { {"ProgramID", args.ProgramID}, {"ClaimInitiationID", args.ClaimInitiationID}, {"ClaimOrIncident", args.ClaimOrIncident} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var recoDbDeleteAutoReservingResult = await RecoDb.DeleteAutoReserving(data.ProgramID, data.ClaimInitiationID, data.ClaimOrIncident);
                if (recoDbDeleteAutoReservingResult != null)
                {
                    await grid0.Reload();
                }
            }
            catch (System.Exception recoDbDeleteAutoReservingException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete AutoReserving" });
            }
        }
    }
}
