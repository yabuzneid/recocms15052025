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
    public partial class MovementBordereauComponent : ComponentBase, IDisposable
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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParametersResults;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParametersResults
        {
            get
            {
                return _getParametersResults;
            }
            set
            {
                if (!object.Equals(_getParametersResults, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersResults", NewValue = value, OldValue = _getParametersResults };
                    _getParametersResults = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getContractYearList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getContractYearList
        {
            get
            {
                return _getContractYearList;
            }
            set
            {
                if (!object.Equals(_getContractYearList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getContractYearList", NewValue = value, OldValue = _getContractYearList };
                    _getContractYearList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _PageSizes;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> PageSizes
        {
            get
            {
                return _PageSizes;
            }
            set
            {
                if (!object.Equals(_PageSizes, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "PageSizes", NewValue = value, OldValue = _PageSizes };
                    _PageSizes = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _selectedProgramID;
        protected int selectedProgramID
        {
            get
            {
                return _selectedProgramID;
            }
            set
            {
                if (!object.Equals(_selectedProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedProgramID", NewValue = value, OldValue = _selectedProgramID };
                    _selectedProgramID = value;
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

        IEnumerable<RecoCms6.Models.RecoDb.MovementBordereau> _getDataList;
        protected IEnumerable<RecoCms6.Models.RecoDb.MovementBordereau> getDataList
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

        string _filename;
        protected string filename
        {
            get
            {
                return _filename;
            }
            set
            {
                if (!object.Equals(_filename, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "filename", NewValue = value, OldValue = _filename };
                    _filename = value;
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
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamDesc asc" });
            getParametersResults = recoDbGetParameterDetailsResult;

            getProgramList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="ProgramID");

            getContractYearList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Contract Year");

            PageSizes = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Contract Year");

            selectedProgramID = 0;

            selectedReportDate = DateTime.Today;

            selectedStartDate = selectedReportDate.AddMonths(-1);

            hiddenColumns = new List<string>(){ "ClaimID", "OccurrenceID", "TradeID" };

            var recoDbGetMovementBordereausResult = await RecoDb.GetMovementBordereaus($"{selectedReportDate}", $"{selectedStartDate}");
            getDataList = recoDbGetMovementBordereausResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var recoDbGetMovementBordereausResult = await RecoDb.GetMovementBordereaus($"{selectedReportDate}", $"{selectedStartDate}");
            getDataList = recoDbGetMovementBordereausResult;
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            filename = "movementbordereau" + selectedStartDate.ToString("MMMM yyyy") + " - " + selectedReportDate.ToString("MMMM yyyy");

            var recoDbUpdateReportDatesResult = await RecoDb.UpdateReportDates($"{selectedReportDate}", $"{Security.User.Id}", $"{selectedStartDate}", null);

            await DownloadFileAsync();
        }
    }
}
