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
    public partial class ParamTypeComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.ParamType> grid0;
        protected RadzenGrid<RecoCms6.Models.RecoDb.Parameter> grid1;

        IEnumerable<RecoCms6.Models.RecoDb.ParamType> _getParamTypesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParamType> getParamTypesResult
        {
            get
            {
                return _getParamTypesResult;
            }
            set
            {
                if (!object.Equals(_getParamTypesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParamTypesResult", NewValue = value, OldValue = _getParamTypesResult };
                    _getParamTypesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _bShowParentID;
        protected bool bShowParentID
        {
            get
            {
                return _bShowParentID;
            }
            set
            {
                if (!object.Equals(_bShowParentID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "bShowParentID", NewValue = value, OldValue = _bShowParentID };
                    _bShowParentID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ParamType _master;
        protected RecoCms6.Models.RecoDb.ParamType master
        {
            get
            {
                return _master;
            }
            set
            {
                if (!object.Equals(_master, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "master", NewValue = value, OldValue = _master };
                    _master = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Parameter> _Parameters;
        protected IEnumerable<RecoCms6.Models.RecoDb.Parameter> Parameters
        {
            get
            {
                return _Parameters;
            }
            set
            {
                if (!object.Equals(_Parameters, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Parameters", NewValue = value, OldValue = _Parameters };
                    _Parameters = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParentParameterList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParentParameterList
        {
            get
            {
                return _getParentParameterList;
            }
            set
            {
                if (!object.Equals(_getParentParameterList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParentParameterList", NewValue = value, OldValue = _getParentParameterList };
                    _getParentParameterList = value;
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
            var recoDbGetParamTypesResult = await RecoDb.GetParamTypes(new Query() { OrderBy = $"ParamTypeDesc asc" });
            getParamTypesResult = recoDbGetParamTypesResult;

            bShowParentID = false;
        }

        protected async System.Threading.Tasks.Task ButtonNewParamTypeClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddParamTypes>($"New Param Type", null, new DialogOptions(){ Width = $"{500}px" });
            await grid0.Reload();
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.ParamType args)
        {
            master = args;

            var recoDbGetParametersResult = await RecoDb.GetParameters(new Query() { Filter = $@"i => i.ParamTypeID == @0", FilterParameters = new object[] { args.ParamTypeID }, OrderBy = $"ParamDesc asc" });
            Parameters = recoDbGetParametersResult;

            bShowParentID = master.ParentParamTypeID != null;

            if (bShowParentID)
            {
                var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeID == @0", FilterParameters = new object[] { master.ParentParamTypeID }, OrderBy = $"ParamDesc asc" });
                getParentParameterList = recoDbGetParameterDetailsResult;
            }
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args, dynamic data)
        {
            var dialogResult = await DialogService.OpenAsync<AddParameter>("Add Parameter", new Dictionary<string, object>() { {"ParamTypeID", data.ParamTypeID} });
            await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args, dynamic data)
        {
            EditParamType(data);
        }

        protected async System.Threading.Tasks.Task SaveButton01Click(MouseEventArgs args, dynamic data)
        {
            UpdateParamType(data);
        }

        protected async System.Threading.Tasks.Task CancelButton01Click(MouseEventArgs args, dynamic data)
        {
            CancelEditParamType(data);
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args, dynamic data)
        {
            EditRow(data);
        }

        protected async System.Threading.Tasks.Task ButtonDeleteRowClick(MouseEventArgs args, dynamic data)
        {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var recoDbDeleteParameterResult = await RecoDb.DeleteParameter(data.ParameterID);
                    await grid1.Reload();
                }

            Reload();
        }

        protected async System.Threading.Tasks.Task SaveButtonClick(MouseEventArgs args, dynamic data)
        {
            UpdateRow(data);
        }

        protected async System.Threading.Tasks.Task CancelButtonClick(MouseEventArgs args, dynamic data)
        {
            CancelEdit(data);
        }
    }
}
