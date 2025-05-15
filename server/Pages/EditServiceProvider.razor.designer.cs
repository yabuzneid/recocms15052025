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
using Serilog;

namespace RecoCms6.Pages
{
    public partial class EditServiceProviderComponent : ComponentBase, IDisposable
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

        RecoCms6.Models.RecoDb.ServiceProvider _serviceprovider;
        protected RecoCms6.Models.RecoDb.ServiceProvider serviceprovider
        {
            get
            {
                return _serviceprovider;
            }
            set
            {
                if (!object.Equals(_serviceprovider, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "serviceprovider", NewValue = value, OldValue = _serviceprovider };
                    _serviceprovider = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProvinceList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProvinceList
        {
            get
            {
                return _getProvinceList;
            }
            set
            {
                if (!object.Equals(_getProvinceList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProvinceList", NewValue = value, OldValue = _getProvinceList };
                    _getProvinceList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethodList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethodList
        {
            get
            {
                return _getCommunicationMethodList;
            }
            set
            {
                if (!object.Equals(_getCommunicationMethodList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommunicationMethodList", NewValue = value, OldValue = _getCommunicationMethodList };
                    _getCommunicationMethodList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getServiceProviderRoleList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getServiceProviderRoleList
        {
            get
            {
                return _getServiceProviderRoleList;
            }
            set
            {
                if (!object.Equals(_getServiceProviderRoleList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServiceProviderRoleList", NewValue = value, OldValue = _getServiceProviderRoleList };
                    _getServiceProviderRoleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.FirmDetail> _getFirmsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.FirmDetail> getFirmsResult
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
            var recoDbGetServiceProviderByIdResult = await RecoDb.GetServiceProviderById(ID);
            serviceprovider = recoDbGetServiceProviderByIdResult;

            if (serviceprovider == null) {
                serviceprovider = new RecoCms6.Models.RecoDb.ServiceProvider(){};
            }

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Province", "Method of Communication", "Service Provider Role" }, OrderBy = $"ParamDesc asc" });
            getParametersResult = recoDbGetParameterDetailsResult;

            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method of Communication");

            getServiceProviderRoleList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Service Provider Role");

            var recoDbGetFirmDetailsResult = await RecoDb.GetFirmDetails(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmDetailsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.ServiceProvider args)
        {
            try
            {
                var recoDbUpdateServiceProviderResult = await RecoDb.UpdateServiceProvider(serviceprovider.ID, serviceprovider);
                DialogService.Close(serviceprovider);
            }
            catch (System.Exception recoDbUpdateServiceProviderException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update ServiceProvider!" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonNewFirmClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFirm>("Add Firm", null);
            if (dialogResult != null) {
                serviceprovider.FirmID = dialogResult.FirmID;
            }

            var recoDbGetFirmDetailsResult = await RecoDb.GetFirmDetails(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
