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
    public partial class AuditTrailComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.AuditTrailDetail> grid0;

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

        IEnumerable<RecoCms6.Models.RecoDb.AuditTrailDetail> _getAuditTrailDetailsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.AuditTrailDetail> getAuditTrailDetailsResult
        {
            get
            {
                return _getAuditTrailDetailsResult;
            }
            set
            {
                if (!object.Equals(_getAuditTrailDetailsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAuditTrailDetailsResult", NewValue = value, OldValue = _getAuditTrailDetailsResult };
                    _getAuditTrailDetailsResult = value;
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

            var recoDbGetAuditTrailDetailsResult = await RecoDb.GetAuditTrailDetails(new Query() { Filter = $@"i => i.ClaimNo.Contains(@0) || i.TableAffected.Contains(@1) || i.RowDetails.Contains(@2) || i.Name.Contains(@3)", FilterParameters = new object[] { search, search, search, search }, OrderBy = $"AuditTrailDate desc" });
            getAuditTrailDetailsResult = recoDbGetAuditTrailDetailsResult;
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await RecoDb.ExportAuditTrailDetailsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "AuditTrailDate,ClaimNo,TableAffected,RowDetails,Name" }, $"Audit Trail");

            }

            if (args?.Value == "xlsx")
            {
                await RecoDb.ExportAuditTrailDetailsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "AuditTrailDate,ClaimNo,TableAffected,RowDetails,Name" }, $"Audit Trail");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.AuditTrailDetail args)
        {
            await DialogService.OpenAsync<ViewAuditTrailDetails>("View Audit Trail Details", new Dictionary<string, object>() { {"AuditTrailID", args.AuditTrailID} }, new DialogOptions(){ Width = $"{1024}px" });
        }
    }
}
