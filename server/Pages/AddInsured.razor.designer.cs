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
    public partial class AddInsuredComponent : ComponentBase, IDisposable
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
        public dynamic InsuredID { get; set; }

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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getLitigationRoles;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getLitigationRoles
        {
            get
            {
                return _getLitigationRoles;
            }
            set
            {
                if (!object.Equals(_getLitigationRoles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLitigationRoles", NewValue = value, OldValue = _getLitigationRoles };
                    _getLitigationRoles = value;
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

        int _intInsuredID;
        protected int intInsuredID
        {
            get
            {
                return _intInsuredID;
            }
            set
            {
                if (!object.Equals(_intInsuredID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intInsuredID", NewValue = value, OldValue = _intInsuredID };
                    _intInsuredID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Insured _insured;
        protected RecoCms6.Models.RecoDb.Insured insured
        {
            get
            {
                return _insured;
            }
            set
            {
                if (!object.Equals(_insured, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "insured", NewValue = value, OldValue = _insured };
                    _insured = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        bool _bUpdateRegistrant;
        protected bool bUpdateRegistrant
        {
            get
            {
                return _bUpdateRegistrant;
            }
            set
            {
                if (!object.Equals(_bUpdateRegistrant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bUpdateRegistrant", NewValue = value, OldValue = _bUpdateRegistrant };
                    _bUpdateRegistrant = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bUpdateBroker;
        protected bool bUpdateBroker
        {
            get
            {
                return _bUpdateBroker;
            }
            set
            {
                if (!object.Equals(_bUpdateBroker, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bUpdateBroker", NewValue = value, OldValue = _bUpdateBroker };
                    _bUpdateBroker = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Brokerage _brokerage;
        protected RecoCms6.Models.RecoDb.Brokerage brokerage
        {
            get
            {
                return _brokerage;
            }
            set
            {
                if (!object.Equals(_brokerage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "brokerage", NewValue = value, OldValue = _brokerage };
                    _brokerage = value;
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
            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
            getRegistrantsResult = recoDbGetRegistrantsResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2 || i.ParamTypeDesc == @3", FilterParameters = new object[] { "Insured Transaction Role", "Insured Litigation Role", "Province", "Method of Communication" }, OrderBy = $"ParamDesc asc" });
            getTransactionRoles = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Insured Transaction Role");

            getLitigationRoles = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Insured Litigation Role");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method of Communication");

            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;

            intInsuredID = (int)InsuredID;

            insured = intInsuredID > 0 ? Get(intInsuredID) : new RecoCms6.Models.RecoDb.Insured(){ID = Guid.NewGuid()};;

            insured.ClaimID = ClaimID;

            if (insured.InsuredID > 0) {
                registrant = getRegistrantsResult.Where(r=>r.RegistrantID == insured.RegistrantID).FirstOrDefault();
            }

            if (registrant == null) {
                registrant =  new RecoCms6.Models.RecoDb.Registrant(){ID = Guid.NewGuid()};;
            }

            bUpdateRegistrant = false;

            if (intInsuredID == 0) {
                insured.ProvinceID = Globals.defaultProvinceID;
            }

            bUpdateBroker = false;

            if (insured.PrimaryInsured == null) {
                insured.PrimaryInsured = false;
            }
            
            
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Insured args)
        {
            try
            {
                await SaveInsured();
            }
            catch (System.Exception saveInsuredException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"System Error",Detail = $"{saveInsuredException.Message}" });
            }
        }

        protected async System.Threading.Tasks.Task RegistrantIdChange(dynamic args)
        {
            if (args is null)
            {
                registrant = new RecoCms6.Models.RecoDb.Registrant() { ID = Guid.NewGuid() };

                insured = new RecoCms6.Models.RecoDb.Insured() { ID = Guid.NewGuid() };

                insured.ClaimID = ClaimID;

                insured.ProvinceID = Globals.defaultProvinceID;
            }
            else
            {
                await RegistrantIDChange();
            }
        }

            protected async System.Threading.Tasks.Task ButtonNewRegistrantClick(MouseEventArgs args)
        {
            if (Globals.generalsettings.ApplicationName == "XLG CMS") {
              var dialogResult = await DialogService.OpenAsync<AddRegistrant>("Add Registrant", null, new DialogOptions(){ Width = $"{1200}px" });
                if (dialogResult != null) {
                    registrant = dialogResult;
                }

                if (dialogResult != null)
                {
                    var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
                    getRegistrantsResult = recoDbGetRegistrantsResult;
                }

                if (dialogResult != null) {
                    insured.RegistrantID = dialogResult.RegistrantID;
                }

                if (dialogResult != null)
                {
                    await RegistrantIdChange(args);
                }

                await InvokeAsync(() => { StateHasChanged();});
            }

            registrant = new RecoCms6.Models.RecoDb.Registrant(){ID = Guid.NewGuid()};

            insured = new RecoCms6.Models.RecoDb.Insured(){ID = Guid.NewGuid()};

            insured.ClaimID = ClaimID;

            insured.ProvinceID = Globals.defaultProvinceID;
        }

        protected async System.Threading.Tasks.Task BrokerageIdChange(dynamic args)
        {
            var recoDbGetBrokerageByBrokerageIdResult = await RecoDb.GetBrokerageByBrokerageId(args);
            insured.BrokerageName = recoDbGetBrokerageByBrokerageIdResult.Name;

            insured.BrokerageAddress = recoDbGetBrokerageByBrokerageIdResult.Address;

            insured.BrokerageProvinceID = recoDbGetBrokerageByBrokerageIdResult.ProvinceID;

            insured.BrokerageCity = recoDbGetBrokerageByBrokerageIdResult.City;

            insured.BrokeragePostalCode = recoDbGetBrokerageByBrokerageIdResult.PostalCode;

            insured.BrokerageEmailAddress = recoDbGetBrokerageByBrokerageIdResult.EmailAddress;

            insured.BrokerageBusinessPhoneNum = recoDbGetBrokerageByBrokerageIdResult.BusinessPhoneNum;

            insured.BrokerOfRecord = recoDbGetBrokerageByBrokerageIdResult.BrokerOfRecordName;

            brokerage = recoDbGetBrokerageByBrokerageIdResult;
        }

        protected async System.Threading.Tasks.Task ButtonNewBrokerageClick(MouseEventArgs args)
        {
            await NewBrokerageClick();
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
