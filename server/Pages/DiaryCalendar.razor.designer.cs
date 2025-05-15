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
    public partial class DiaryCalendarComponent : ComponentBase, IDisposable
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
        protected RadzenScheduler<RecoCms6.Models.RecoDb.Diary> scheduler0;

        IEnumerable<RecoCms6.Models.RecoDb.Diary> _getDiariesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Diary> getDiariesResult
        {
            get
            {
                return _getDiariesResult;
            }
            set
            {
                if (!object.Equals(_getDiariesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDiariesResult", NewValue = value, OldValue = _getDiariesResult };
                    _getDiariesResult = value;
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
            var recoDbGetDiariesResult = await RecoDb.GetDiaries(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            getDiariesResult = recoDbGetDiariesResult;
        }

        protected async System.Threading.Tasks.Task Scheduler0AppointmentSelect(SchedulerAppointmentSelectEventArgs<RecoCms6.Models.RecoDb.Diary> args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEditDiary>($"Edit Diary", new Dictionary<string, object>() { {"Start", null}, {"End", null}, {"ClaimID", ClaimID}, {"DiaryID", args.Data.ID} }, new DialogOptions(){ Width = $"{900}px" });
            if (dialogResult != null)
            {
                await scheduler0.Reload();
            }
        }

        protected async System.Threading.Tasks.Task Scheduler0SlotSelect(SchedulerSlotSelectEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddEditDiary>($"Add Diary", new Dictionary<string, object>() { {"Start", args.Start}, {"End", args.End}, {"ClaimID", ClaimID}, {"DiaryID", null} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null)
            {
                await scheduler0.Reload();
            }
        }
    }
}
