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
    public partial class EditBrokerageComponent : ComponentBase, IDisposable
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
        public dynamic BrokerageID { get; set; }

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

        RecoCms6.Models.RecoDb.Brokerage _origBrokerage;
        protected RecoCms6.Models.RecoDb.Brokerage origBrokerage
        {
            get
            {
                return _origBrokerage;
            }
            set
            {
                if (!object.Equals(_origBrokerage, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "origBrokerage", NewValue = value, OldValue = _origBrokerage };
                    _origBrokerage = value;
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

        dynamic _getBrokerageRoleList;
        protected dynamic getBrokerageRoleList
        {
            get
            {
                return _getBrokerageRoleList;
            }
            set
            {
                if (!object.Equals(_getBrokerageRoleList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBrokerageRoleList", NewValue = value, OldValue = _getBrokerageRoleList };
                    _getBrokerageRoleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Administrator> _getAdministratorsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Administrator> getAdministratorsResult
        {
            get
            {
                return _getAdministratorsResult;
            }
            set
            {
                if (!object.Equals(_getAdministratorsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAdministratorsResult", NewValue = value, OldValue = _getAdministratorsResult };
                    _getAdministratorsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bRegNumberChanged;
        protected bool bRegNumberChanged
        {
            get
            {
                return _bRegNumberChanged;
            }
            set
            {
                if (!object.Equals(_bRegNumberChanged, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bRegNumberChanged", NewValue = value, OldValue = _bRegNumberChanged };
                    _bRegNumberChanged = value;
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

        bool _bDuuplicateName;
        protected bool bDuuplicateName
        {
            get
            {
                return _bDuuplicateName;
            }
            set
            {
                if (!object.Equals(_bDuuplicateName, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bDuuplicateName", NewValue = value, OldValue = _bDuuplicateName };
                    _bDuuplicateName = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bDuplicateName;
        protected bool bDuplicateName
        {
            get
            {
                return _bDuplicateName;
            }
            set
            {
                if (!object.Equals(_bDuplicateName, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bDuplicateName", NewValue = value, OldValue = _bDuplicateName };
                    _bDuplicateName = value;
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
            var recoDbGetBrokerageByBrokerageIdResult = await RecoDb.GetBrokerageByBrokerageId(BrokerageID);
            brokerage = recoDbGetBrokerageByBrokerageIdResult;

            origBrokerage = recoDbGetBrokerageByBrokerageIdResult;

            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants();
            getRegistrantsResult = recoDbGetRegistrantsResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Province", "Method of Communication", "Brokerage Role" }, OrderBy = $"ParamDesc asc" });
            getProvinceList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Province");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Method of Communication");

            getBrokerageRoleList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Brokerage Role");

            var recoDbGetAdministratorsResult = await RecoDb.GetAdministrators();
            getAdministratorsResult = recoDbGetAdministratorsResult;

            bRegNumberChanged = false;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Brokerage args)
        {
            bDuplicateRegNo = false;

            bDuuplicateName = false;

            if (Globals.generalsettings.ApplicationName == "RECO CMS" && origBrokerage.RegistrantNo != brokerage.RegistrantNo)
            {
                var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { Filter = $@"i => i.RegistrantNo == @0 && i.BrokerageID != @1", FilterParameters = new object[] { brokerage.RegistrantNo, brokerage.BrokerageID } });
                bDuplicateRegNo = recoDbGetBrokeragesResult.Count() > 0;
            }

            if (origBrokerage.Name != brokerage.Name)
            {
                var recoDbGetBrokeragesResult0 = await RecoDb.GetBrokerages(new Query() { Filter = $@"i => i.Name == @0 && i.BrokerageID != @1", FilterParameters = new object[] { brokerage.Name, brokerage.BrokerageID } });
                bDuplicateName = recoDbGetBrokeragesResult0.Count() > 0;
            }

            try
            {
                if (!bDuplicateRegNo && !bDuplicateName)
                {
                    var recoDbUpdateBrokerageResult = await RecoDb.UpdateBrokerage(BrokerageID, brokerage);
                    DialogService.Close(brokerage);
                }
            }
            catch (System.Exception recoDbUpdateBrokerageException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Brokerage" });
            }

            if (bDuplicateRegNo)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Unable to save changes",Detail = $"Registrant Number already exists in database" });
            }

            if (bDuplicateName)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Unable to Save Changes",Detail = $"Brokerage Name already exists in the database" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonNewAdminstratorClick(MouseEventArgs args)
        {
            var newAdministrator = await DialogService.OpenAsync<AddAdministrator>("Add Administrator", null, new DialogOptions(){ Width = $"{800}px" });
            var recoDbGetAdministratorsResult = await RecoDb.GetAdministrators();
            getAdministratorsResult = recoDbGetAdministratorsResult;
            brokerage.AdministratorID = newAdministrator.AdministratorID;
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
