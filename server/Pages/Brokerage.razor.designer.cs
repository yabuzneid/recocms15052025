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
    public partial class BrokerageComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.Brokerage> grid0;

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
            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null, new DialogOptions(){ Width = $"{1024}px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        private bool _isEditBrokerageDialogOpen = false;
        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.Brokerage args)
        {
            if(_isEditBrokerageDialogOpen)
                return;

            _isEditBrokerageDialogOpen = true;
            var dialogResult = await DialogService.OpenAsync<EditBrokerage>("Edit Brokerage", new Dictionary<string, object>() { {"BrokerageID", args.BrokerageID} }, new DialogOptions(){ Width = $"{1024}px" });
            _isEditBrokerageDialogOpen = false;

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var recoDbDeleteBrokerageResult = await RecoDb.DeleteBrokerage(data.BrokerageID);
                    if (recoDbDeleteBrokerageResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception recoDbDeleteBrokerageException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Brokerage" });
            }
        }
    }
}
