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
    public partial class DiaryTemplatesComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<RecoCms6.Models.RecoDb.TemplateDetail> grid0;

        IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> _getDiaryTemplatesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> getDiaryTemplatesResult
        {
            get
            {
                return _getDiaryTemplatesResult;
            }
            set
            {
                if (!object.Equals(_getDiaryTemplatesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDiaryTemplatesResult", NewValue = value, OldValue = _getDiaryTemplatesResult };
                    _getDiaryTemplatesResult = value;
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
            var recoDbGetTemplateDetailsResult = await RecoDb.GetTemplateDetails(new Query() { OrderBy = $"Title asc" });
            getDiaryTemplatesResult = recoDbGetTemplateDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddDiaryTemplate>("Add Diary Template", null, new DialogOptions(){ Width = $"{1024}px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(RecoCms6.Models.RecoDb.TemplateDetail args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDiaryTemplate>("Edit Diary Template", new Dictionary<string, object>() { {"DiaryTemplateID", args.DiaryTemplateID} }, new DialogOptions(){ Width = $"{1024}px" });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var recoDbDeleteDiaryTemplateResult = await RecoDb.DeleteDiaryTemplate(data.DiaryTemplateID);
                if (recoDbDeleteDiaryTemplateResult != null)
                {
                    await grid0.Reload();
                }
            }
            catch (System.Exception recoDbDeleteDiaryTemplateException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete DiaryTemplate" });
            }
        }
    }
}
