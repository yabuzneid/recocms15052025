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
    public partial class ConsolidateClaimantsComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.OccurrenceClaimant> datagridClaimants;

        IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimant> _claimantlist;
        protected IEnumerable<RecoCms6.Models.RecoDb.OccurrenceClaimant> claimantlist
        {
            get
            {
                return _claimantlist;
            }
            set
            {
                if (!object.Equals(_claimantlist, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claimantlist", NewValue = value, OldValue = _claimantlist };
                    _claimantlist = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.OccurrenceClaimant> _selectedclaimants;
        protected List<RecoCms6.Models.RecoDb.OccurrenceClaimant> selectedclaimants
        {
            get
            {
                return _selectedclaimants;
            }
            set
            {
                if (!object.Equals(_selectedclaimants, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedclaimants", NewValue = value, OldValue = _selectedclaimants };
                    _selectedclaimants = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _chosenclaimant;
        protected int chosenclaimant
        {
            get
            {
                return _chosenclaimant;
            }
            set
            {
                if (!object.Equals(_chosenclaimant, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "chosenclaimant", NewValue = value, OldValue = _chosenclaimant };
                    _chosenclaimant = value;
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
            var recoDbGetOccurrenceClaimantsResult = await RecoDb.GetOccurrenceClaimants(new Query() { Filter = $@"i => i.MasterFileID == @0", FilterParameters = new object[] { ClaimID }, OrderBy = $"Name asc" });
            claimantlist = recoDbGetOccurrenceClaimantsResult;

            selectedclaimants = new List<OccurrenceClaimant>();

            chosenclaimant = 0;
        }

        protected async System.Threading.Tasks.Task Checkbox2Change(dynamic args, dynamic data)
        {
            if (selectedclaimants == null) {
                selectedclaimants = new List<OccurrenceClaimant>();
            }

            selectedclaimants.Add(data);
        }

        protected async System.Threading.Tasks.Task Checkbox6Change(bool args)
        {
            selectedclaimants = args ? claimantlist.ToList() : null;
        }

        protected async System.Threading.Tasks.Task ButtonConsolidateClick(MouseEventArgs args)
        {
            if (selectedclaimants == null || selectedclaimants.Count == 0)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Please select more than one claimant to consolidate" });

            }

            if (chosenclaimant == 0)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Warning,Summary = $"Must select a main claimant to consolidate to" });
            }

            if (selectedclaimants != null && selectedclaimants.Count > 0 && chosenclaimant > 0)
            {
                ConsolidateClaimants();
            }

            if (selectedclaimants != null && selectedclaimants.Count > 0 && chosenclaimant > 0) {
              DialogService.Close(chosenclaimant);
            }
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
