using System;
using System.Threading.Tasks;
using Radzen;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using RecoCms6.Data;
using RecoCms6.Models;
using Serilog;

namespace RecoCms6.Pages
{
    public partial class EditApplicationUserComponent
    {
        [Inject]
        public UserManager<ApplicationUser> userManager { get; set; }
        [Inject]
        private  ApplicationIdentityDbContext IdentityDbContext { get; set; }


        public async Task ReEnableTwoFactorAuth(MouseEventArgs args)
        {
            try
            {
                await userManager.ResetAuthenticatorKeyAsync(user);
                user.LoggedInTwoFactor = false;
                IdentityDbContext.Update(user);
                await IdentityDbContext.SaveChangesAsync();
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success, Summary = "Two Factor Auth Reset Successfully.",
                    Detail = "You can retry logging in now."
                });
            }
            catch (Exception e)
            {
                NotificationService.Notify(new NotificationMessage
                    { Severity = NotificationSeverity.Error, Summary = "Couldn't Reset Two Factor Auth" });
                Log.Error("Error Occured while trying to rest Two Factor Authentication. Details: {0}", e);
            }
            finally
            {
                DialogService.Close(null);
            }
        }
        
        public async Task<bool> IsUserInactive(ApplicationUser user)
        {
            var lockoutEnabled = await userManager.GetLockoutEnabledAsync(user);
            var lockoutEndDate = await userManager.GetLockoutEndDateAsync(user);

            if (lockoutEnabled && lockoutEndDate != null && lockoutEndDate > DateTime.Now)
                return true;

            return false;
        }

        public async Task EnableOrDisableUser(ApplicationUser user)
        {
            if (DisableUser)
            {
                await DeactivateUserAsync(user);
            }
            else
            {
                await ActivateUserAsync(user);
            }
        }

        public async Task DeactivateUserAsync(ApplicationUser user)
        {
            await userManager.SetLockoutEnabledAsync(user, true);
            await userManager.SetLockoutEndDateAsync(user, DateTime.Today.AddYears(1000));
            serviceprovider.Active = false;
        }

        public async Task ActivateUserAsync(ApplicationUser user)
        {
            await userManager.SetLockoutEnabledAsync(user, true);
            var result = await userManager.SetLockoutEndDateAsync(user, null);
            serviceprovider.Active = true;
        }
    }
}
