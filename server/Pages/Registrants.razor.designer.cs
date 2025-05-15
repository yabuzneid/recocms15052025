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
    public partial class RegistrantsComponent : ComponentBase, IDisposable
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
        public dynamic SelectAgent { get; set; }
        protected RadzenGrid<RecoCms6.Models.RecoDb.Registrant> grid0;

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

        RecoCms6.Models.RecoDb.Registrant _selectedRegistrant;
        protected RecoCms6.Models.RecoDb.Registrant selectedRegistrant
        {
            get
            {
                return _selectedRegistrant;
            }
            set
            {
                if (!object.Equals(_selectedRegistrant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedRegistrant", NewValue = value, OldValue = _selectedRegistrant };
                    _selectedRegistrant = value;
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
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
            getRegistrantsResult = recoDbGetRegistrantsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddRegistrant>("Add Registrant", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.Registrant args)
        {
            selectedRegistrant = args;

            if (SelectAgent == null) {
              var dialogResult = await DialogService.OpenAsync<EditRegistrant>("Edit Registrant", new Dictionary<string, object>() { {"ID", args.ID} });
                await InvokeAsync(() => { StateHasChanged(); });
            }
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var recoDbDeleteRegistrantResult = await RecoDb.DeleteRegistrant(data.ID);
                if (recoDbDeleteRegistrantResult != null)
                {
                    await grid0.Reload();
                }
            }
            catch (System.Exception recoDbDeleteRegistrantException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Registrant" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonSelectClick(MouseEventArgs args)
        {
            if (selectedRegistrant == null)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"No Registrant Selected",Detail = $"Please select a registrant first" });
            }

            if (selectedRegistrant != null) {
              DialogService.Close(selectedRegistrant);
            }
        }

        protected async System.Threading.Tasks.Task ButtonCancelClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
