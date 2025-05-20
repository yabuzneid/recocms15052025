using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Layouts
{
    public partial class MainLayoutComponent : LayoutComponentBase, IDisposable
    {
        [Inject]
        protected GlobalsService Globals { get; set; }

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
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected RecoDbService RecoDb { get; set; }

        protected RadzenBody body0;
        protected RadzenSidebar sidebar0;

        private void Authenticated()
        {
             StateHasChanged();
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
             if (Security != null)
             {
                  Security.Authenticated += Authenticated;

                  await Security.InitializeAsync(AuthenticationStateProvider);
             }
             await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            try
            {

                if (Security.IsAuthenticated() != true)
                {
                    UriHelper.NavigateTo("login");
                }

                Globals.Uri = String.Empty;

                var executeResult = await Task.Run(() => { return UriHelper.BaseUri; });
                Globals.Uri = executeResult;

                if (Globals.userdetails == null)
                {
                    var recoDbGetUserDetailsResult = await RecoDb.GetUserDetails(new Query()
                        { Filter = $@"i => i.Id == @0", FilterParameters = new object[] { Security.User.Id } });
                    ;
                    Globals.userdetails = recoDbGetUserDetailsResult.FirstOrDefault();
                }

                Globals.claimantsolicitortitle = Globals.generalsettings.ClaimantName + " Solicitor";

                if (Security.IsAuthenticated())
                {
                    CheckSystemNotice();
                }

                Globals.txtSearch = String.Empty;

                if (Security.IsAuthenticated())
                {
                    var recoDbGetServiceProviderClaimPreferencesResult =
                        await RecoDb.GetServiceProviderClaimPreferences(new Query()
                        {
                            Filter = $@"i => i.ServiceProviderID == @0",
                            FilterParameters = new object[] { Globals.userdetails.ServiceProviderID },
                            OrderBy = $"DateLastAccessed desc", Top = 10
                        });
                    Globals.ServiceProviderClaims = recoDbGetServiceProviderClaimPreferencesResult;

                    if (Globals.userdetails != null && Globals.userdetails.Role == "Legal Assistants")
                    {
                        Globals.DefenseCounsels = (await RecoDb.GetDefenseCounselsForLegalAssistance(Globals.userdetails.ServiceProviderID.Value)).Select(s => s.DefenseCounsel).ToList();
                    }
                }

            }
            catch
            {
                
            }
        }

        protected async System.Threading.Tasks.Task SidebarToggle0Click(dynamic args)
        {
            await InvokeAsync(() => { sidebar0.Toggle(); });

            await InvokeAsync(() => { body0.Toggle(); });
        }

        protected async System.Threading.Tasks.Task Profilemenu0Click(dynamic args)
        {
            if (args.Value == "Logout")
            {
                await Security.Logout();
            }
        }
    }
}
