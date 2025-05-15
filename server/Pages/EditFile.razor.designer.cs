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
    public partial class EditFileComponent : ComponentBase, IDisposable
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
        public dynamic ID { get; set; }

        RecoCms6.Models.RecoDb.FileDetail _file;
        protected RecoCms6.Models.RecoDb.FileDetail file
        {
            get
            {
                return _file;
            }
            set
            {
                if (!object.Equals(_file, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "file", NewValue = value, OldValue = _file };
                    _file = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getFileTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getFileTypeList
        {
            get
            {
                return _getFileTypeList;
            }
            set
            {
                if (!object.Equals(_getFileTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getFileTypeList", NewValue = value, OldValue = _getFileTypeList };
                    _getFileTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getClaimReportID;
        protected int getClaimReportID
        {
            get
            {
                return _getClaimReportID;
            }
            set
            {
                if (!object.Equals(_getClaimReportID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimReportID", NewValue = value, OldValue = _getClaimReportID };
                    _getClaimReportID = value;
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
            var recoDbGetFileDetailsResult = await RecoDb.GetFileDetails(new Query() { Filter = $@"i => i.ID == @0", FilterParameters = new object[] { ID } });
            file = recoDbGetFileDetailsResult.FirstOrDefault();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "File Type" }, OrderBy = $"ParamDesc asc" });
            getFileTypeList = recoDbGetParameterDetailsResult;

            getClaimReportID = recoDbGetParameterDetailsResult.FirstOrDefault(pd=>pd.ParamDesc=="Claim Report").ParameterID;
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.FileDetail args)
        {
            file.Filename = file.Subject + file.Extension;

            var recoDbUpdateFileDetailsResult = await RecoDb.UpdateFileDetails(file.FileID, $"{file.Subject}", $"{file.Filename}", file.LargeLoss, file.Sticky, file.Confidential, file.VisibleToCounsel, file.FileTypeID, $"{file.Comments}", $"{file.FileDescription}");
            DialogService.Close(file);
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
