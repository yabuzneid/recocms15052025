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
    public partial class ReserveChangeHistoryComponent : ComponentBase, IDisposable
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProgramList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProgramList
        {
            get
            {
                return _getProgramList;
            }
            set
            {
                if (!object.Equals(_getProgramList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgramList", NewValue = value, OldValue = _getProgramList };
                    _getProgramList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int? _selectedProgram;
        protected int? selectedProgram
        {
            get
            {
                return _selectedProgram;
            }
            set
            {
                if (!object.Equals(_selectedProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedProgram", NewValue = value, OldValue = _selectedProgram };
                    _selectedProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        DateTime _selectedReportDate;
        protected DateTime selectedReportDate
        {
            get
            {
                return _selectedReportDate;
            }
            set
            {
                if (!object.Equals(_selectedReportDate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedReportDate", NewValue = value, OldValue = _selectedReportDate };
                    _selectedReportDate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        DateTime _selectedStartDate;
        protected DateTime selectedStartDate
        {
            get
            {
                return _selectedStartDate;
            }
            set
            {
                if (!object.Equals(_selectedStartDate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedStartDate", NewValue = value, OldValue = _selectedStartDate };
                    _selectedStartDate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel> _getDataList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel> getDataList
        {
            get
            {
                return _getDataList;
            }
            set
            {
                if (!object.Equals(_getDataList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDataList", NewValue = value, OldValue = _getDataList };
                    _getDataList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _hiddenColumns;
        protected List<string> hiddenColumns
        {
            get
            {
                return _hiddenColumns;
            }
            set
            {
                if (!object.Equals(_hiddenColumns, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "hiddenColumns", NewValue = value, OldValue = _hiddenColumns };
                    _hiddenColumns = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
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
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "ProgramID" }, OrderBy = $"ParameterID asc" });
            getProgramList = recoDbGetParameterDetailsResult;

            selectedProgram = recoDbGetParameterDetailsResult.First().ParameterID;

            selectedReportDate = DateTime.Today;

            selectedStartDate = new DateTime(DateTime.Today.Year, 1, 1);

            var recoDbGetReserveChangeHistoriesResult = await RecoDb.GetReserveChangeHistories($"{selectedStartDate}", $"{selectedReportDate}", selectedProgram);
            getDataList = recoDbGetReserveChangeHistoriesResult;

            hiddenColumns = new List<string>(){"ClaimID","OccurrenceID","TradeID"};
        }

        protected async System.Threading.Tasks.Task ButtonRunClick(MouseEventArgs args)
        {
            var recoDbGetReserveChangeHistoriesResult = await RecoDb.GetReserveChangeHistories($"{selectedStartDate}", $"{selectedReportDate}", selectedProgram);
            getDataList = recoDbGetReserveChangeHistoriesResult;
        }
        
        protected async System.Threading.Tasks.Task ButtonExportClick(MouseEventArgs args)
        {
            var filename = "reservechangeHistory_" + DateTime.Now.ToString("yyyyMMddTHHmmss");

            var recoDbUpdateReportDatesResult = await RecoDb.UpdateReportDates($"{selectedReportDate}", $"{Security.User.Id}", null, null);

            await DownloadFileAsync();
        }
    }
}
