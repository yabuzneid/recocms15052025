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
    public partial class AddBrokerageComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.BrokerageContact> contactsGrid;

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethodsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethodsResult
        {
            get
            {
                return _getCommunicationMethodsResult;
            }
            set
            {
                if (!object.Equals(_getCommunicationMethodsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommunicationMethodsResult", NewValue = value, OldValue = _getCommunicationMethodsResult };
                    _getCommunicationMethodsResult = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getBrokerageRoleList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getBrokerageRoleList
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

        bool _bDuplicateNumber;
        protected bool bDuplicateNumber
        {
            get
            {
                return _bDuplicateNumber;
            }
            set
            {
                if (!object.Equals(_bDuplicateNumber, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bDuplicateNumber", NewValue = value, OldValue = _bDuplicateNumber };
                    _bDuplicateNumber = value;
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
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Province", "Method of Communication", "Brokerage Role" }, OrderBy = $"ParamDesc asc" });
            getCommunicationMethodsResult = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Method Of Communication");

            getProvinceList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Province");

            getBrokerageRoleList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Brokerage Role");

            var recoDbGetAdministratorsResult = await RecoDb.GetAdministrators();
            getAdministratorsResult = recoDbGetAdministratorsResult;

            brokerage = new RecoCms6.Models.RecoDb.Brokerage(){};
            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Method of Communication");

        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Brokerage args)
        {
            bDuplicateNumber = false;

            var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages(new Query() { Filter = $@"i => i.Name == @0 && i.BrokerageID != @1", FilterParameters = new object[] { brokerage.Name, brokerage.BrokerageID } });
            bDuplicateName = recoDbGetBrokeragesResult.Count() > 0;

            if (Globals.generalsettings.ApplicationName == "XLG CMS")
            {
                var recoDbGetBrokeragesResult0 = await RecoDb.GetBrokerages(new Query() { Filter = $@"i => i.RegistrantNo == @0 && i.BrokerageID != @1", FilterParameters = new object[] { brokerage.RegistrantNo, brokerage.BrokerageID } });
                bDuplicateNumber = recoDbGetBrokeragesResult0.Count() > 0;
            }

            try
            {
                if (!bDuplicateName && !bDuplicateNumber)
                {
                    var recoDbCreateBrokerageResult = await RecoDb.CreateBrokerage(brokerage);
                    DialogService.Close(brokerage);
                }
            }
            catch (System.Exception recoDbCreateBrokerageException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"{recoDbCreateBrokerageException.Message}" });
            }

            if (bDuplicateName)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Unable to Save",Detail = $"Brokerage Name Already Exists" });
            }

            if (bDuplicateNumber)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Unable to Save Brokerage",Detail = $"Brokerage Number Already In System" });
            }
        }

        protected async System.Threading.Tasks.Task ButtonAddContactClick(MouseEventArgs args)
        {
            await InsertContactRow();
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task ButtonNewAdminstratorClick(MouseEventArgs args)
        {
            var newAdministrator = await DialogService.OpenAsync<AddAdministrator>("Add Administrator", null, new DialogOptions(){ Width = $"{800}px" });
            var recoDbGetAdministratorsResult = await RecoDb.GetAdministrators();
            getAdministratorsResult = recoDbGetAdministratorsResult;
            brokerage.AdministratorID = newAdministrator.AdministratorID;
        }
    }
}
