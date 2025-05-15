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
    public partial class AddExpertComponent : ComponentBase, IDisposable
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
        public dynamic ExpertID { get; set; }

        [Parameter]
        public dynamic ClaimID { get; set; }

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

        int _intExpertID;
        protected int intExpertID
        {
            get
            {
                return _intExpertID;
            }
            set
            {
                if (!object.Equals(_intExpertID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intExpertID", NewValue = value, OldValue = _intExpertID };
                    _intExpertID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Expert _expert;
        protected RecoCms6.Models.RecoDb.Expert expert
        {
            get
            {
                return _expert;
            }
            set
            {
                if (!object.Equals(_expert, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "expert", NewValue = value, OldValue = _expert };
                    _expert = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        bool _bUpdateExpert;
        protected bool bUpdateExpert
        {
            get
            {
                return _bUpdateExpert;
            }
            set
            {
                if (!object.Equals(_bUpdateExpert, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bUpdateExpert", NewValue = value, OldValue = _bUpdateExpert };
                    _bUpdateExpert = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Firm> _getFirmsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.Firm> getFirmsList
        {
            get
            {
                return _getFirmsList;
            }
            set
            {
                if (!object.Equals(_getFirmsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFirmsList", NewValue = value, OldValue = _getFirmsList };
                    _getFirmsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvExpert;
        protected bool rfvExpert
        {
            get
            {
                return _rfvExpert;
            }
            set
            {
                if (!object.Equals(_rfvExpert, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvExpert", NewValue = value, OldValue = _rfvExpert };
                    _rfvExpert = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvRole;
        protected bool rfvRole
        {
            get
            {
                return _rfvRole;
            }
            set
            {
                if (!object.Equals(_rfvRole, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvRole", NewValue = value, OldValue = _rfvRole };
                    _rfvRole = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvName;
        protected bool rfvName
        {
            get
            {
                return _rfvName;
            }
            set
            {
                if (!object.Equals(_rfvName, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvName", NewValue = value, OldValue = _rfvName };
                    _rfvName = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvPostalCode;
        protected bool rfvPostalCode
        {
            get
            {
                return _rfvPostalCode;
            }
            set
            {
                if (!object.Equals(_rfvPostalCode, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvPostalCode", NewValue = value, OldValue = _rfvPostalCode };
                    _rfvPostalCode = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _rfvEmail;
        protected bool rfvEmail
        {
            get
            {
                return _rfvEmail;
            }
            set
            {
                if (!object.Equals(_rfvEmail, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "rfvEmail", NewValue = value, OldValue = _rfvEmail };
                    _rfvEmail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bPageIsValid;
        protected bool bPageIsValid
        {
            get
            {
                return _bPageIsValid;
            }
            set
            {
                if (!object.Equals(_bPageIsValid, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bPageIsValid", NewValue = value, OldValue = _bPageIsValid };
                    _bPageIsValid = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getRegistrantsResults;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getRegistrantsResults
        {
            get
            {
                return _getRegistrantsResults;
            }
            set
            {
                if (!object.Equals(_getRegistrantsResults, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRegistrantsResults", NewValue = value, OldValue = _getRegistrantsResults };
                    _getRegistrantsResults = value;
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
            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails();
            getServiceProvidersResult = recoDbGetServiceProviderDetailsResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Service Provider Role", "Province", "Method of Communication" }, OrderBy = $"ParamDesc asc" });
            getTransactionRoles = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Service Provider Role");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method of Communication");

            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            intExpertID = (int)ExpertID;

            if (intExpertID == 0) {
                expert = new RecoCms6.Models.RecoDb.Expert();
            }

            if (intExpertID > 0)
            {
                var recoDbGetExpertsResult = await RecoDb.GetExperts(new Query() { Filter = $@"i => i.ExpertID == @0", FilterParameters = new object[] { intExpertID } });
                expert = recoDbGetExpertsResult.FirstOrDefault();
            }

            if (intExpertID == 0) {
                expert.ClaimID = ClaimID;
            }

            if (expert.ServiceProviderID > 0)
            {
                var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { expert.ServiceProviderID } });
                serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();
            }

            bUpdateExpert = false;

            var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
            getFirmsList = recoDbGetFirmsResult;

            if (intExpertID == 0) {
                expert.ProvinceID = Globals.defaultProvinceID;
            }

            rfvExpert = false;

            rfvRole = false;

            rfvName = false;

            rfvPostalCode = false;

            rfvEmail = false;

            bPageIsValid = false;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Expert args)
        {
            Validate();

            if (bPageIsValid)
            {
                var recoDbGetNextClaimDisplayOrdersResult = await RecoDb.GetNextClaimDisplayOrders(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
                if (expert.ExpertID == 0) {
                    expert.DisplayOrder = (short)recoDbGetNextClaimDisplayOrdersResult.First().NextExpertDisplayOrder;
                }

                serviceprovider.Name = expert.Name;

                serviceprovider.Address = expert.Address;

                serviceprovider.CellPhoneNum = expert.CellPhoneNum;

                serviceprovider.BusinessPhoneNum = expert.BusinessPhoneNum;

                serviceprovider.City = expert.City;

                serviceprovider.EmailAddress = expert.EmailAddress;

                serviceprovider.FirmID = expert.FirmID;

                serviceprovider.PostalCode = expert.PostalCode;

                serviceprovider.PreferredCommunicationMethodID = expert.PreferredCommunicationMethodID;

                serviceprovider.ProvinceID = expert.ProvinceID;
            }

            try
            {
                if (bUpdateExpert && bPageIsValid)
                {
                    var recoDbUpdateServiceProviderResult = await RecoDb.UpdateServiceProvider(serviceprovider.ID, serviceprovider);

                }
            }
            catch (System.Exception recoDbUpdateServiceProviderException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable to Update Service Provider Contact Details",Detail = $"{recoDbUpdateServiceProviderException.Message}" });
            }

            try
            {
                if (expert.ExpertID > 0 && bPageIsValid)
                {
                    var recoDbUpdateExpertResult = await RecoDb.UpdateExpert(expert.ExpertID, expert);
                    DialogService.Close(recoDbUpdateExpertResult);
                }
            }
            catch (System.Exception recoDbUpdateExpertException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable To Save Expert ",Detail = $"{recoDbUpdateExpertException.Message}" });
            }

            try
            {
                if (expert.ExpertID == 0 && bPageIsValid)
                {
                    var recoDbCreateExpertResult = await RecoDb.CreateExpert(expert);
                    DialogService.Close(recoDbCreateExpertResult);
                }
            }
            catch (System.Exception recoDbCreateExpertException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Unable To Create Expert ",Detail = $"{recoDbCreateExpertException.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task ServiceProviderIdChange(dynamic args)
        {
            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { expert.ServiceProviderID }, OrderBy = $"Name asc" });
            serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();

            expert = new Expert();

            if (serviceprovider != null) {
                expert.ServiceProviderID = serviceprovider.ServiceProviderID;
            }

            if (serviceprovider != null) {
                expert.Name = serviceprovider.Name;
            }

            if (serviceprovider != null) {
                expert.Address = serviceprovider.Address;
            }

            expert.ClaimID = ClaimID;

            if (serviceprovider != null) {
                expert.PostalCode = serviceprovider.PostalCode;
            }

            if (serviceprovider != null) {
                expert.BusinessPhoneNum = serviceprovider.BusinessPhoneNum;
            }

            if (serviceprovider != null) {
                expert.CellPhoneNum = serviceprovider.CellPhoneNum;
            }

            if (serviceprovider != null) {
                expert.PreferredCommunicationMethodID = serviceprovider.PreferredCommunicationMethodID;
            }

            if (serviceprovider != null) {
                expert.City = serviceprovider.City;
            }

            if (serviceprovider != null) {
                expert.FirmID = serviceprovider.FirmID;
            }

            bUpdateExpert = false;
        }

        protected async System.Threading.Tasks.Task ButtonNewServiceProviderClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddServiceProvider>($"Add Expert", new Dictionary<string, object>() { {"Role", null} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null) {
                serviceprovider = dialogResult;
            }

            if (dialogResult != null)
            {
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"Name asc" });
                getRegistrantsResults = recoDbGetServiceProviderDetailsResult;
            }

            if (dialogResult != null) {
                expert.ServiceProviderID = dialogResult.ServiceProviderID;
            }

            if (dialogResult != null)
            {
                await ServiceProviderIdChange(args);
            }

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task ButtonSaveClick(MouseEventArgs args)
        {
            await Form0Submit(expert);
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
