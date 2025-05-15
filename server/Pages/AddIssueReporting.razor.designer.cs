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
    public partial class AddIssueReportingComponent : ComponentBase, IDisposable
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParametersForIssueStatusIDResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParametersForIssueStatusIDResult
        {
            get
            {
                return _getParametersForIssueStatusIDResult;
            }
            set
            {
                if (!object.Equals(_getParametersForIssueStatusIDResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersForIssueStatusIDResult", NewValue = value, OldValue = _getParametersForIssueStatusIDResult };
                    _getParametersForIssueStatusIDResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _newStatusID;
        protected int newStatusID
        {
            get
            {
                return _newStatusID;
            }
            set
            {
                if (!object.Equals(_newStatusID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newStatusID", NewValue = value, OldValue = _newStatusID };
                    _newStatusID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.IssueReporting _issuereporting;
        protected RecoCms6.Models.RecoDb.IssueReporting issuereporting
        {
            get
            {
                return _issuereporting;
            }
            set
            {
                if (!object.Equals(_issuereporting, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "issuereporting", NewValue = value, OldValue = _issuereporting };
                    _issuereporting = value;
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
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "Issue Status" }, OrderBy = $"ParameterID asc" });
            getParametersForIssueStatusIDResult = recoDbGetParameterDetailsResult;

            newStatusID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamDesc == "New Issue").ParameterID;

            issuereporting = new RecoCms6.Models.RecoDb.IssueReporting(){};

            issuereporting.EnteredById = Security.User.Id;

            issuereporting.IssueStatusID = newStatusID;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.IssueReporting args)
        {
            issuereporting.DateEntered = DateTime.Now;

            try
            {
                var recoDbCreateIssueReportingResult = await RecoDb.CreateIssueReporting(issuereporting);
                DialogService.Close(issuereporting);
            }
            catch (System.Exception recoDbCreateIssueReportingException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new IssueReporting!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
