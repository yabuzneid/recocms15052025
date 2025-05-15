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
    public partial class FirmsComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.Firm> grid0;

        IEnumerable<RecoCms6.Models.RecoDb.Firm> _getFirmsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Firm> getFirmsResult
        {
            get
            {
                return _getFirmsResult;
            }
            set
            {
                if (!object.Equals(_getFirmsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFirmsResult", NewValue = value, OldValue = _getFirmsResult };
                    _getFirmsResult = value;
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
            var recoDbGetFirmsResult = await RecoDb.GetFirms();
            getFirmsResult = recoDbGetFirmsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFirm>("Add Firm", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.Firm args)
        {
            var dialogResult = await DialogService.OpenAsync<EditFirm>("Edit Firm", new Dictionary<string, object>() { {"ID", args.ID} });
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var recoDbDeleteFirmResult = await RecoDb.DeleteFirm(data.ID);
                if (recoDbDeleteFirmResult != null)
                {
                    await grid0.Reload();
                }
            }
            catch (System.Exception recoDbDeleteFirmException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Firm" });
            }
        }
    }
}
