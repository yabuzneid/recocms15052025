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

namespace RecoCms6.Pages;

public partial class IssueReportingComponent : ComponentBase, IDisposable
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
    protected RadzenDataGrid<RecoCms6.Models.RecoDb.IssueReporting> grid0;

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

    IEnumerable<RecoCms6.Models.RecoDb.IssueReporting> _getIssueReportingsResult;
    protected IEnumerable<RecoCms6.Models.RecoDb.IssueReporting> getIssueReportingsResult
    {
        get
        {
            return _getIssueReportingsResult;
        }
        set
        {
            if (!object.Equals(_getIssueReportingsResult, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "getIssueReportingsResult", NewValue = value, OldValue = _getIssueReportingsResult };
                _getIssueReportingsResult = value;
                OnPropertyChanged(args);
                Reload();
            }
        }
    }

    IEnumerable<RecoCms6.Models.RecoDb.ServiceProvider> _getServiceProviderList;
    protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProvider> getServiceProviderList
    {
        get
        {
            return _getServiceProviderList;
        }
        set
        {
            if (!object.Equals(_getServiceProviderList, value))
            {
                var args = new PropertyChangedEventArgs(){ Name = "getServiceProviderList", NewValue = value, OldValue = _getServiceProviderList };
                _getServiceProviderList = value;
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

        var recoDbGetIssueReportingsResult = await RecoDb.GetIssueReportings(new Query() { Filter = $@"i => i.EnteredById.Contains(@0) || i.Subject.Contains(@1) || i.Issue.Contains(@2) || i.Filename.Contains(@3)", FilterParameters = new object[] { search, search, search, search }, OrderBy = $"DateEntered desc", Expand = "Parameter" });
        getIssueReportingsResult = recoDbGetIssueReportingsResult;

        var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders();
        getServiceProviderList = recoDbGetServiceProvidersResult;
    }

    protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
    {
        var dialogResult = await DialogService.OpenAsync<AddIssueReporting>("Add Issue Reporting", null);
        await grid0.Reload();

        await InvokeAsync(() => { StateHasChanged(); });
    }

    protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
    {
        if (args?.Value == "csv")
        {
            await RecoDb.ExportIssueReportingsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Parameter", Select = "IssueReportingID,DateEntered,EnteredById,Subject,Issue,Filename,Parameter.ParamAbbrev as ParameterParamAbbrev" }, $"Issue Reporting");

        }

        if (args == null || args.Value == "xlsx")
        {
            await RecoDb.ExportIssueReportingsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Parameter", Select = "IssueReportingID,DateEntered,EnteredById,Subject,Issue,Filename,Parameter.ParamAbbrev as ParameterParamAbbrev" }, $"Issue Reporting");

        }
    }

    protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<RecoCms6.Models.RecoDb.IssueReporting> args)
    {
        var dialogResult = await DialogService.OpenAsync<EditIssueReporting>("Edit Issue Reporting", new Dictionary<string, object>() { {"IssueReportingID", args.Data.IssueReportingID} });
        await grid0.Reload();

        await InvokeAsync(() => { StateHasChanged(); });
    }

    protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
    {
        try
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var recoDbDeleteIssueReportingResult = await RecoDb.DeleteIssueReporting(data.IssueReportingID);
                if (recoDbDeleteIssueReportingResult != null)
                {
                    await grid0.Reload();
                }
            }
        }
        catch (System.Exception recoDbDeleteIssueReportingException)
        {
            NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete IssueReporting" });
        }
    }
}