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
    public partial class DialogSelectEmailComponent : ComponentBase, IDisposable
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

        IEnumerable<string> _result;
        protected IEnumerable<string> result
        {
            get
            {
                return _result;
            }
            set
            {
                if (!object.Equals(_result, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "result", NewValue = value, OldValue = _result };
                    _result = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ClaimEmailAddress> _getClaimEmailAddressesResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ClaimEmailAddress> getClaimEmailAddressesResult
        {
            get
            {
                return _getClaimEmailAddressesResult;
            }
            set
            {
                if (!object.Equals(_getClaimEmailAddressesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimEmailAddressesResult", NewValue = value, OldValue = _getClaimEmailAddressesResult };
                    _getClaimEmailAddressesResult = value;
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
            result = new List<string>();

            var recoDbGetClaimEmailAddressesResult = await RecoDb.GetClaimEmailAddresses((int)ClaimID, new Query() { OrderBy = $"EmailAddress asc" });
            getClaimEmailAddressesResult = recoDbGetClaimEmailAddressesResult;
        }

        protected async System.Threading.Tasks.Task ButtonAddClick(MouseEventArgs args)
        {
            DialogService.Close(result);
        }

        protected async System.Threading.Tasks.Task ButtonCancelClick(MouseEventArgs args)
        {
            result = Enumerable.Empty<string>();

            DialogService.Close(result);
        }
    }
}
