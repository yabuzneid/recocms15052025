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
    public partial class ClaimantSolicitorComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.ClaimantSolicitor> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
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

        string _pagetitle;
        protected string pagetitle
        {
            get
            {
                return _pagetitle;
            }
            set
            {
                if (!object.Equals(_pagetitle, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "pagetitle", NewValue = value, OldValue = _pagetitle };
                    _pagetitle = value;
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
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var recoDbGetClaimantSolicitorsResult = await RecoDb.GetClaimantSolicitors(new Query() { Filter = $@"i => i.Name.Contains(@0) || i.Address.Contains(@1) || i.City.Contains(@2) || i.PostalCode.Contains(@3) || i.EmailAddress.Contains(@4) || i.BusinessPhoneNum.Contains(@5) || i.CellPhoneNum.Contains(@6) || i.FaxNum.Contains(@7) || i.SolicitorFirm.Contains(@8)", FilterParameters = new object[] { search, search, search, search, search, search, search, search, search }, OrderBy = $"Name asc" });
            getClaimantSolicitorsResult = recoDbGetClaimantSolicitorsResult;

            pagetitle = Globals.generalsettings.ClaimantName + " Solicitor";
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClaimantSolicitor>("Add Claimant Solicitor", null, new DialogOptions(){ Width = $"{800}px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.ClaimantSolicitor> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditClaimantSolicitor>("Edit Claimant Solicitor", new Dictionary<string, object>() { {"ID", args.Data.ID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var recoDbDeleteClaimantSolicitorResult = await RecoDb.DeleteClaimantSolicitor(data.ID);
                    if (recoDbDeleteClaimantSolicitorResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception recoDbDeleteClaimantSolicitorException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete ClaimantSolicitor" });
            }
        }
    }
}
