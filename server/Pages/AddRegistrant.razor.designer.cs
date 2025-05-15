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
    public partial class AddRegistrantComponent : ComponentBase, IDisposable
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

        bool _bDuplicateRegNo;
        protected bool bDuplicateRegNo
        {
            get
            {
                return _bDuplicateRegNo;
            }
            set
            {
                if (!object.Equals(_bDuplicateRegNo, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bDuplicateRegNo", NewValue = value, OldValue = _bDuplicateRegNo };
                    _bDuplicateRegNo = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        dynamic _newbrokerage;
        protected dynamic newbrokerage
        {
            get
            {
                return _newbrokerage;
            }
            set
            {
                if (!object.Equals(_newbrokerage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "newbrokerage", NewValue = value, OldValue = _newbrokerage };
                    _newbrokerage = value;
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

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "Method Of Communication", "Province" }, OrderBy = $"ParamDesc asc" });
            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method Of Communication");

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;

            registrant = new RecoCms6.Models.RecoDb.Registrant(){};

            registrant.ID = Guid.NewGuid();

            registrant.ProvinceID = Globals.defaultProvinceID;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Registrant args)
        {
            bDuplicateRegNo = false;

            if (Globals.generalsettings.ApplicationName == "RECO CMS")
            {
                var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantNo == @0 && i.RegistrantID != @1", FilterParameters = new object[] { registrant.RegistrantNo, registrant.RegistrantID } });
                bDuplicateRegNo = recoDbGetRegistrantsResult.Count() > 0;
            }

            try
            {
                if (!bDuplicateRegNo)
                {
                    var recoDbCreateRegistrantResult = await RecoDb.CreateRegistrant(registrant);
                    DialogService.Close(registrant);
                }
            }
            catch (System.Exception recoDbCreateRegistrantException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Registrant!" });
            }

            if (bDuplicateRegNo)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Unable to Save",Detail = $"Registrant No is already in the system" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonNewBrokerageClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null, new DialogOptions(){ Width = $"{800}px" });
            newbrokerage = dialogResult;

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            getBrokeragesResult = recoDbGetBrokeragesResult;

            if (newbrokerage != null) {
                registrant.BrokerageID = newbrokerage.BrokerageID;
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
