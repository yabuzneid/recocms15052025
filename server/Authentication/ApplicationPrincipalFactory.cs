using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using RecoCms6.Models;
using RecoCms6.Data;

namespace RecoCms6.Authentication
{
    public partial class ApplicationPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private ApplicationIdentityDbContext identityContext;

        public ApplicationPrincipalFactory(ApplicationIdentityDbContext identityContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
            this.identityContext = identityContext;
        }
        partial void OnCreatePrincipal(ClaimsPrincipal principal, ApplicationUser user);

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            this.OnCreatePrincipal(principal, user);

            return principal;
        }
    }
}
