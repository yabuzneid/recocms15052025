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
    public partial class AddOtherPartyComponent : ComponentBase, IDisposable
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
        public dynamic ClaimID { get; set; }

        [Parameter]
        public dynamic OtherPartyID { get; set; }

        int _intOtherParty;
        protected int intOtherParty
        {
            get
            {
                return _intOtherParty;
            }
            set
            {
                if (!object.Equals(_intOtherParty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intOtherParty", NewValue = value, OldValue = _intOtherParty };
                    _intOtherParty = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getTransactionRoles;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getTransactionRoles
        {
            get
            {
                return _getTransactionRoles;
            }
            set
            {
                if (!object.Equals(_getTransactionRoles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTransactionRoles", NewValue = value, OldValue = _getTransactionRoles };
                    _getTransactionRoles = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCountryList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCountryList
        {
            get
            {
                return _getCountryList;
            }
            set
            {
                if (!object.Equals(_getCountryList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCountryList", NewValue = value, OldValue = _getCountryList };
                    _getCountryList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethods;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethods
        {
            get
            {
                return _getCommunicationMethods;
            }
            set
            {
                if (!object.Equals(_getCommunicationMethods, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommunicationMethods", NewValue = value, OldValue = _getCommunicationMethods };
                    _getCommunicationMethods = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _otherTransactionRoleID;
        protected int otherTransactionRoleID
        {
            get
            {
                return _otherTransactionRoleID;
            }
            set
            {
                if (!object.Equals(_otherTransactionRoleID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "otherTransactionRoleID", NewValue = value, OldValue = _otherTransactionRoleID };
                    _otherTransactionRoleID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.OtherParty _otherparty;
        protected RecoCms6.Models.RecoDb.OtherParty otherparty
        {
            get
            {
                return _otherparty;
            }
            set
            {
                if (!object.Equals(_otherparty, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "otherparty", NewValue = value, OldValue = _otherparty };
                    _otherparty = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProvidersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProvidersResult
        {
            get
            {
                return _getServiceProvidersResult;
            }
            set
            {
                if (!object.Equals(_getServiceProvidersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServiceProvidersResult", NewValue = value, OldValue = _getServiceProvidersResult };
                    _getServiceProvidersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProvider _solicitor;
        protected RecoCms6.Models.RecoDb.ServiceProvider solicitor
        {
            get
            {
                return _solicitor;
            }
            set
            {
                if (!object.Equals(_solicitor, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "solicitor", NewValue = value, OldValue = _solicitor };
                    _solicitor = value;
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
            intOtherParty = OtherPartyID;

            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
            getRegistrantsResult = recoDbGetRegistrantsResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails();
            getParametersResult = recoDbGetParameterDetailsResult;

            getTransactionRoles = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Other Party Transaction Role");

            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getCountryList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Country");

            getCommunicationMethods = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method Of Communication");

            otherTransactionRoleID = recoDbGetParameterDetailsResult.First(pd=>pd.ParamDesc=="Other" && pd.ParamTypeDesc=="Other Party Transaction Role").ParameterID;

            otherparty = intOtherParty > 0 ? Get(intOtherParty) : new RecoCms6.Models.RecoDb.OtherParty(){};;

            otherparty.ClaimID = ClaimID;

            if (intOtherParty == 0) {
                otherparty.ID = Guid.NewGuid();
            }

            if (intOtherParty == 0 && Globals.defaultProvinceID != 0) {
                otherparty.ProvinceID = Globals.defaultProvinceID;
            }

            if (intOtherParty == 0 && Globals.defaultProvinceID != 0) {
                otherparty.CountryID = Globals.defaultCountryID;
            }

            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.ServiceProviderRole == @0", FilterParameters = new object[] { "Outside Counsel" }, OrderBy = $"Name asc" });
            getServiceProvidersResult = recoDbGetServiceProviderDetailsResult;

            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { otherparty.SolicitorID } });
            if (otherparty.SolicitorID != null) {
                solicitor = recoDbGetServiceProvidersResult.First();
            }

            var recoDbGetFirmDetailsResult = await RecoDb.GetFirmDetails(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmDetailsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.OtherParty args)
        {
            var recoDbGetNextClaimDisplayOrdersResult = await RecoDb.GetNextClaimDisplayOrders(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            if (intOtherParty == 0) {
                otherparty.DisplayOrder = (short)recoDbGetNextClaimDisplayOrdersResult.First().NextOtherDisplayOrder;
            }

            var executeResult = await Task.Run(() =>
            {
                return Upsert();
            });
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task ButtonNewSolicitorClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddServiceProvider>($"Add Outside Counsel", new Dictionary<string, object>() { {"Role", "Outside Counsel"} }, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                otherparty.SolicitorID = dialogResult.ServiceProviderID;
            }

            if (dialogResult != null)
            {
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.ServiceProviderRole == @0", FilterParameters = new object[] { "Outside Counsel" }, OrderBy = $"Name asc" });

            }

            if (dialogResult != null)
            {
                var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { otherparty.SolicitorID } });
                solicitor = recoDbGetServiceProvidersResult.First();
            }
        }

        protected async System.Threading.Tasks.Task ButtonNewFirmClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFirm>("Add Firm", null);
            if (dialogResult != null) {
                solicitor.FirmID = dialogResult.FirmID;
            }

            var recoDbGetFirmDetailsResult = await RecoDb.GetFirmDetails(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
