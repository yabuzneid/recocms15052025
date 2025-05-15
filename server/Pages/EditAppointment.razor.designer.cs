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
    public partial class EditAppointmentComponent : ComponentBase, IDisposable
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

        RecoCms6.Models.RecoDb.Appointment _appointment;
        protected RecoCms6.Models.RecoDb.Appointment appointment
        {
            get
            {
                return _appointment;
            }
            set
            {
                if (!object.Equals(_appointment, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "appointment", NewValue = value, OldValue = _appointment };
                    _appointment = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Claim> _getClaimsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Claim> getClaimsResult
        {
            get
            {
                return _getClaimsResult;
            }
            set
            {
                if (!object.Equals(_getClaimsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimsResult", NewValue = value, OldValue = _getClaimsResult };
                    _getClaimsResult = value;
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
            var recoDbGetAppointmentByIdResult = await RecoDb.GetAppointmentById(ID);
            appointment = recoDbGetAppointmentByIdResult;

            var recoDbGetClaimsResult = await RecoDb.GetClaims();
            getClaimsResult = recoDbGetClaimsResult;

            var recoDbGetParametersResult = await RecoDb.GetParameters();
            getParametersResult = recoDbGetParametersResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Appointment args)
        {
            try
            {
                var recoDbUpdateAppointmentResult = await RecoDb.UpdateAppointment(ID, appointment);
                DialogService.Close(appointment);
            }
            catch (System.Exception recoDbUpdateAppointmentException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Appointment" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
