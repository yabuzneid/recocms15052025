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
    public partial class EditDiaryTemplateComponent : ComponentBase, IDisposable
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
        public dynamic DiaryTemplateID { get; set; }

        RecoCms6.Models.RecoDb.DiaryTemplate _diarytemplate;
        protected RecoCms6.Models.RecoDb.DiaryTemplate diarytemplate
        {
            get
            {
                return _diarytemplate;
            }
            set
            {
                if (!object.Equals(_diarytemplate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "diarytemplate", NewValue = value, OldValue = _diarytemplate };
                    _diarytemplate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getDefaultSendToList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getDefaultSendToList
        {
            get
            {
                return _getDefaultSendToList;
            }
            set
            {
                if (!object.Equals(_getDefaultSendToList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDefaultSendToList", NewValue = value, OldValue = _getDefaultSendToList };
                    _getDefaultSendToList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getTemplateTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getTemplateTypeList
        {
            get
            {
                return _getTemplateTypeList;
            }
            set
            {
                if (!object.Equals(_getTemplateTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTemplateTypeList", NewValue = value, OldValue = _getTemplateTypeList };
                    _getTemplateTypeList = value;
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
            var recoDbGetDiaryTemplateByDiaryTemplateIdResult = await RecoDb.GetDiaryTemplateByDiaryTemplateId(DiaryTemplateID);
            diarytemplate = recoDbGetDiaryTemplateByDiaryTemplateIdResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "Send To", "Diary Template Type" }, OrderBy = $"ParamDesc asc" });
            getDefaultSendToList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc == "Send To");

            getTemplateTypeList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc == "Diary Template Type");
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.DiaryTemplate args)
        {
            try
            {
                var recoDbUpdateDiaryTemplateResult = await RecoDb.UpdateDiaryTemplate(DiaryTemplateID, diarytemplate);
                DialogService.Close(diarytemplate);
            }
            catch (System.Exception recoDbUpdateDiaryTemplateException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update DiaryTemplate" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
