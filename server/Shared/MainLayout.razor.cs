using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Radzen;
using System.Timers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RecoCms6.Models.RecoDb;

namespace RecoCms6.Layouts;

public partial class MainLayoutComponent
{

    private Timer _keepAliveTimer;

    [Inject]
    protected HttpClient HttpClient { get; set; }

    protected override void OnInitialized()
    {
        _keepAliveTimer = new Timer(60000); // every 60 seconds
        _keepAliveTimer.Elapsed += async (sender, args) => await PingServer();
        _keepAliveTimer.AutoReset = true;
        _keepAliveTimer.Start();
    }

    private async Task PingServer()
    {
        try
        {
            await HttpClient.GetAsync("health");
        }
        catch
        {
            // ignored
        }
    }

    public void Dispose()
    {
        if (_keepAliveTimer is null)
            return;

        _keepAliveTimer.Stop();
        _keepAliveTimer.Dispose();
    }

    protected ErrorBoundary ErrorBoundary { get; set; }

    string _notice;
    protected string notice
    {
        get
        {
            return _notice;
        }
        set
        {
            if (!object.Equals(_notice, value))
            {
                _notice = value;
                InvokeAsync(() => { StateHasChanged(); });
            }
        }
    }

    Timer timer;
    private bool StartTimer()
    {
        if (timer == null)
        {

            timer = new Timer(300000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            return true;
        }
        else
        {
            timer.Stop();
            timer.Start();
            return true;
        }

    }
    string _txtSearch;
    protected string txtSearch
    {
        get
        {
            return _txtSearch;
        }
        set
        {
            if (!object.Equals(_txtSearch, value))
            {
                _txtSearch = value;
                InvokeAsync(() => { StateHasChanged(); });
            }
        }
    }
    protected async System.Threading.Tasks.Task TxtSearchChange(string args)
    {
        try
        {
            await SearchForClaimNo($"{args}");
        }
        catch (System.Exception searchForClaimNoException)
        {
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"File Not Found", Duration = 2500 });
        }
    }

    protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
    {
        await SearchForClaimNo($"{args}");
    }

    private async Task SearchForClaimNo(string args)
    {
        Query query;
        
        if (Globals.userdetails == null || Globals.userdetails.ServiceProviderID == 0)
            await GetCurrentServiceProvider();

        String searchText = args.Trim();
        query = BuildQuery(searchText);

        var recoDbGetClaimListsResult = await RecoDb.GetClaimRapidSearchLists(query);

        var getClaimListsResult = recoDbGetClaimListsResult;

        if (getClaimListsResult.Count() == 1) //Go directly to 
        {
            txtSearch = String.Empty;

            var claim = getClaimListsResult.First();

            if (!Security.IsInRole("Defense Counsel"))
                if (claim.Program == "Errors And Omissions")
                    UriHelper.NavigateTo($"edit-claim/{claim.ClaimID.ToBase64()}",true);
                else
                    UriHelper.NavigateTo($"edit-commission-claim/{claim.ClaimID.ToBase64()}", true);
            else
                UriHelper.NavigateTo($"claim-report/{claim.ClaimID.ToBase64()}", true);
        }
        else if (getClaimListsResult.Count() > 1)
        {
            throw new Exception("More than one file with entered information found.  Very likely there's an adjuster or counsel file number with the same identifier.");
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    private Query BuildQuery(string search)
    {
        Query query;

        var searchQuery = String.Empty;

        if (search != String.Empty)
            searchQuery = $@"i => (i.ClaimNo == ""{search}""
                    || i.AdjusterClaimNo == ""{search}""
                    || i.CounselFileNo == ""{search}"") ";

        var filterQuery = String.Empty;


        if (Security.IsInRole("Defense Counsel"))
            if (Globals.userdetails.PrimeUser == true)
                filterQuery = filterQuery + $@"&& i.DefenseCounselFirmID == {Globals.userdetails.FirmID} ";
            else
                filterQuery = filterQuery + $@"&& i.DefenseCounselID == {Globals.userdetails.ServiceProviderID} ";

        if (searchQuery == String.Empty && filterQuery != String.Empty) //Remove the first 2 ampersands if there's no search criteria
        {
            filterQuery = filterQuery.Substring(3);
            filterQuery = $@"i => " + filterQuery;
        }
        else
            filterQuery = searchQuery + filterQuery;

        query = new Query() { Filter = filterQuery, OrderBy = $"ClaimNo desc" };

        return query;
    }

    protected async Task<UserDetail> GetCurrentServiceProvider()
    {
        var recoDbGetUsersResult = await RecoDb.GetUserDetails(new Query { Filter = $@"i=> i.UserName == @0", FilterParameters = new object[] { Security.Principal.Identity.Name } });
        var userdetail = recoDbGetUsersResult.FirstOrDefault();

        Globals.userdetails = userdetail;

        return userdetail;
    }

    private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {

        await InvokeAsync(async () =>
        {
            await Load();
        });


    }
    private void HandleError(Exception exception)
    {
        NotificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = exception.Message });
    }
    protected async void CheckSystemNotice()
    {
        try
        {
            if (!Security.IsAuthenticated())
                return;

            var recoDbGetCheckSystemNoticesResult = await RecoDb.GetCheckSystemNotices($"{Security.User.Id}");
            if (recoDbGetCheckSystemNoticesResult.First().SystemNotice != null && recoDbGetCheckSystemNoticesResult.First().SystemNotice != String.Empty)
            {
                notice = recoDbGetCheckSystemNoticesResult.First().SystemNotice;
            }

            if (recoDbGetCheckSystemNoticesResult.First().SystemNotice != null && recoDbGetCheckSystemNoticesResult.First().SystemNotice != String.Empty)
            {
                await BusyDialog($"{notice}");
            }
        }
        catch { }

        var startTimerResult = StartTimer();
    }

    // Busy dialog from string
    async Task BusyDialog(string message)
    {
        await DialogService.OpenAsync("System Notice", ds =>
        {
            RenderFragment content = b =>
            {
                b.OpenElement(0, "div");
                b.AddAttribute(1, "class", "row");

                b.OpenElement(2, "div");
                b.AddAttribute(3, "class", "col-md-12");

                b.AddContent(4, message);

                b.CloseElement();
                b.CloseElement();
            };
            return content;
        }, new DialogOptions() { ShowTitle = true, Style = "min-height:auto;min-width:auto;width:auto", CloseDialogOnOverlayClick = true });
    }
}