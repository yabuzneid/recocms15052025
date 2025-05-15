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
    public partial class EditRegistrantComponent : ComponentBase, IDisposable
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
        public dynamic ID { get; set; }

        RecoCms6.Models.RecoDb.Registrant _registrant;
        protected RecoCms6.Models.RecoDb.Registrant registrant
        {
            get
            {
                return _registrant;
            }
            set
            {
                if (!object.Equals(_registrant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "registrant", NewValue = value, OldValue = _registrant };
                    _registrant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        IEnumerable<RecoCms6.Models.RecoDb.Parameter> _getParametersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Parameter> getParametersResult
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
            var recoDbGetRegistrantByIdResult = await RecoDb.GetRegistrantById(ID);
            registrant = recoDbGetRegistrantByIdResult;

            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants();
            getRegistrantsResult = recoDbGetRegistrantsResult;

            var recoDbGetParametersResult = await RecoDb.GetParameters();
            getParametersResult = recoDbGetParametersResult;

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages();
            getBrokeragesResult = recoDbGetBrokeragesResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Registrant args)
        {
            try
            {
                var recoDbUpdateRegistrantResult = await RecoDb.UpdateRegistrant(ID, registrant);
                DialogService.Close(registrant);
            }
            catch (System.Exception recoDbUpdateRegistrantException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Registrant" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
