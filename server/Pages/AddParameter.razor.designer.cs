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
    public partial class AddParameterComponent : ComponentBase, IDisposable
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
        public dynamic ParamTypeID { get; set; }

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

        RecoCms6.Models.RecoDb.Parameter _parameter;
        protected RecoCms6.Models.RecoDb.Parameter parameter
        {
            get
            {
                return _parameter;
            }
            set
            {
                if (!object.Equals(_parameter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "parameter", NewValue = value, OldValue = _parameter };
                    _parameter = value;
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
            var recoDbGetParamTypesResult = await RecoDb.GetParamTypes();
            getParamTypesResult = recoDbGetParamTypesResult;

            parameter = new RecoCms6.Models.RecoDb.Parameter(){};

            parameter.ParamTypeID = ParamTypeID;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Parameter args)
        {
            var recoDbCreateParameterResult = await RecoDb.CreateParameter(parameter);

            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
