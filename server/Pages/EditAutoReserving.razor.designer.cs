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
    public partial class EditAutoReservingComponent : ComponentBase, IDisposable
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
        public dynamic ProgramID { get; set; }

        [Parameter]
        public dynamic ClaimInitiationID { get; set; }

        [Parameter]
        public dynamic ClaimOrIncident { get; set; }

        RecoCms6.Models.RecoDb.AutoReserving _autoreserving;
        protected RecoCms6.Models.RecoDb.AutoReserving autoreserving
        {
            get
            {
                return _autoreserving;
            }
            set
            {
                if (!object.Equals(_autoreserving, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "autoreserving", NewValue = value, OldValue = _autoreserving };
                    _autoreserving = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParametersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParametersResult
        {
            get
            {
                return _getParametersResult;
            }
            set
            {
                if (!object.Equals(_getParametersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersResult", NewValue = value, OldValue = _getParametersResult };
                    _getParametersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProgramList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProgramList
        {
            get
            {
                return _getProgramList;
            }
            set
            {
                if (!object.Equals(_getProgramList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgramList", NewValue = value, OldValue = _getProgramList };
                    _getProgramList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getClaimInitiationList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getClaimInitiationList
        {
            get
            {
                return _getClaimInitiationList;
            }
            set
            {
                if (!object.Equals(_getClaimInitiationList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimInitiationList", NewValue = value, OldValue = _getClaimInitiationList };
                    _getClaimInitiationList = value;
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
            var recoDbGetAutoReservingByProgramIdAndClaimInitiationIdAndClaimOrIncidentResult = await RecoDb.GetAutoReservingByProgramIdAndClaimInitiationIdAndClaimOrIncident(ProgramID, ClaimInitiationID, ClaimOrIncident);
            autoreserving = recoDbGetAutoReservingByProgramIdAndClaimInitiationIdAndClaimOrIncidentResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "ProgramID", "Claim Initiation" }, OrderBy = $"ParamDesc asc" });
            getParametersResult = recoDbGetParameterDetailsResult;

            getProgramList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID");

            getClaimInitiationList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claim Initiation");
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.AutoReserving args)
        {
            try
            {
                var recoDbUpdateAutoReservingResult = await RecoDb.UpdateAutoReserving(ProgramID, ClaimInitiationID, ClaimOrIncident, autoreserving);
                DialogService.Close(autoreserving);
            }
            catch (System.Exception recoDbUpdateAutoReservingException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update AutoReserving" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
