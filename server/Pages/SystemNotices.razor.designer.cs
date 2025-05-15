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
    public partial class SystemNoticesComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.SystemNotice> grid0;

        IEnumerable<RecoCms6.Models.RecoDb.SystemNotice> _getSystemNoticesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.SystemNotice> getSystemNoticesResult
        {
            get
            {
                return _getSystemNoticesResult;
            }
            set
            {
                if (!object.Equals(_getSystemNoticesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSystemNoticesResult", NewValue = value, OldValue = _getSystemNoticesResult };
                    _getSystemNoticesResult = value;
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
            var recoDbGetSystemNoticesResult = await RecoDb.GetSystemNotices();
            getSystemNoticesResult = recoDbGetSystemNoticesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSystemNotice>("Add System Notice", null, new DialogOptions(){ Width = $"{"50%"}" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task ButtonClearNoticeClick(MouseEventArgs args)
        {
            var recoDbClearSystemNoticesResult = await RecoDb.ClearSystemNotices();
            await grid0.Reload();
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.SystemNotice args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSystemNotice>("Edit System Notice", new Dictionary<string, object>() { {"SystemNoticeID", args.SystemNoticeID} });
            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
