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
    public partial class GeneralSettingComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.GeneralSetting> grid0;

        RecoCms6.Models.RecoDb.GeneralSetting _generalsetting;
        protected RecoCms6.Models.RecoDb.GeneralSetting generalsetting
        {
            get
            {
                return _generalsetting;
            }
            set
            {
                if (!object.Equals(_generalsetting, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "generalsetting", NewValue = value, OldValue = _generalsetting };
                    _generalsetting = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.GeneralSetting> _getGeneralSettingsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.GeneralSetting> getGeneralSettingsResult
        {
            get
            {
                return _getGeneralSettingsResult;
            }
            set
            {
                if (!object.Equals(_getGeneralSettingsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGeneralSettingsResult", NewValue = value, OldValue = _getGeneralSettingsResult };
                    _getGeneralSettingsResult = value;
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
            generalsetting = new RecoCms6.Models.RecoDb.GeneralSetting(){};

            var recoDbGetGeneralSettingsResult = RecoDb.GetGeneralSettings();
            getGeneralSettingsResult = recoDbGetGeneralSettingsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.grid0.InsertRow(new RecoCms6.Models.RecoDb.GeneralSetting());
        }

        protected async System.Threading.Tasks.Task Grid0RowCreate(dynamic args)
        {
            var recoDbCreateGeneralSettingResult = await RecoDb.CreateGeneralSetting(args);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowUpdate(dynamic args)
        {
            var recoDbUpdateGeneralSettingResult = await RecoDb.UpdateGeneralSetting(args.ID, args);
            Globals.generalsettings = args;
        }

        protected async System.Threading.Tasks.Task EditButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.EditRow(data);
        }

        protected async System.Threading.Tasks.Task SaveButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.UpdateRow(data);
        }

        protected async System.Threading.Tasks.Task CancelButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.CancelEditRow(data);

            var recoDbCancelGeneralSettingChangesResult = await RecoDb.CancelGeneralSettingChanges(data);
        }
    }
}
