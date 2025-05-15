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
    public partial class AddCostAwardComponent : ComponentBase, IDisposable
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
        public dynamic CostAwardID { get; set; }

        RecoCms6.Models.RecoDb.CostAward _costaward;
        protected RecoCms6.Models.RecoDb.CostAward costaward
        {
            get
            {
                return _costaward;
            }
            set
            {
                if (!object.Equals(_costaward, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "costaward", NewValue = value, OldValue = _costaward };
                    _costaward = value;
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
            if (CostAwardID == 0) {
                costaward = new RecoCms6.Models.RecoDb.CostAward(){};
            }

            if (CostAwardID == 0) {
                costaward.ClaimID = (int)ClaimID;
            }

            if (CostAwardID > 0)
            {
                var recoDbGetCostAwardsResult = await RecoDb.GetCostAwards(new Query() { Filter = $@"i => i.CostAwardID == @0", FilterParameters = new object[] { CostAwardID } });
                costaward = recoDbGetCostAwardsResult.First();
            }
        }

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.CostAward args)
        {
            try
            {
                DialogService.Close(costaward);
            }
            catch (System.Exception recoDbCreateCostAwardException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new CostAward!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
