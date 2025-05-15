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
    public partial class AddClaimLitigationDateComponent : ComponentBase, IDisposable
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

        [Parameter]
        public dynamic LitigationDateID { get; set; }

        int _intClaimID;
        protected int intClaimID
        {
            get
            {
                return _intClaimID;
            }
            set
            {
                if (!object.Equals(_intClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intClaimID", NewValue = value, OldValue = _intClaimID };
                    _intClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ClaimLitigationDate _claimlitigationdate;
        protected RecoCms6.Models.RecoDb.ClaimLitigationDate claimlitigationdate
        {
            get
            {
                return _claimlitigationdate;
            }
            set
            {
                if (!object.Equals(_claimlitigationdate, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimlitigationdate", NewValue = value, OldValue = _claimlitigationdate };
                    _claimlitigationdate = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _intLitigationDateID;
        protected int intLitigationDateID
        {
            get
            {
                return _intLitigationDateID;
            }
            set
            {
                if (!object.Equals(_intLitigationDateID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intLitigationDateID", NewValue = value, OldValue = _intLitigationDateID };
                    _intLitigationDateID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getLitigationDateTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getLitigationDateTypeList
        {
            get
            {
                return _getLitigationDateTypeList;
            }
            set
            {
                if (!object.Equals(_getLitigationDateTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLitigationDateTypeList", NewValue = value, OldValue = _getLitigationDateTypeList };
                    _getLitigationDateTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getLitigationDateStatusList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getLitigationDateStatusList
        {
            get
            {
                return _getLitigationDateStatusList;
            }
            set
            {
                if (!object.Equals(_getLitigationDateStatusList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLitigationDateStatusList", NewValue = value, OldValue = _getLitigationDateStatusList };
                    _getLitigationDateStatusList = value;
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
            intClaimID = StringExtensions.IntegerFromBase64(ClaimID);

            claimlitigationdate = new RecoCms6.Models.RecoDb.ClaimLitigationDate(){};

            claimlitigationdate.ClaimID = intClaimID;

            intLitigationDateID = LitigationDateID;

            if (intLitigationDateID != 0)
            {
                var recoDbGetClaimLitigationDateByLitigationDateIdResult = await RecoDb.GetClaimLitigationDateByLitigationDateId(intLitigationDateID);
                claimlitigationdate = recoDbGetClaimLitigationDateByLitigationDateIdResult;
            }

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1", FilterParameters = new object[] { "Litigation Date Type", "Litigation Date Status" }, OrderBy = $"ParamDesc asc" });
            getLitigationDateTypeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Litigation Date Type");

            getLitigationDateStatusList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Litigation Date Status");
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.ClaimLitigationDate args)
        {
            try
            {
                claimlitigationdate.Parameter = await RecoDb.GetParameterByParameterId(claimlitigationdate.LitigationDateTypeID);
                claimlitigationdate.Parameter1 = await RecoDb.GetParameterByParameterId(claimlitigationdate.LitigationStatusID);
                DialogService.Close(claimlitigationdate);
            }
            catch (System.Exception recoDbCreateClaimLitigationDateException)
            {
            await SaveErrorAsync(recoDbCreateClaimLitigationDateException);

                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Litigation Date!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
