

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecoCms6.Data;
using RecoCms6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using RecoCms6.Services;
using RecoCms6.Utility;


namespace RecoCms6
{
    public partial class AccountController(IWebHostEnvironment env, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            ApplicationIdentityDbContext identityDbContext, MailService mailService)
        : Controller
    {
        private IActionResult RedirectWithError(string error, string redirectUrl)
        {
            if (!string.IsNullOrEmpty(redirectUrl))
            {
                return Redirect($"~/Login?error={error}&redirectUrl={Uri.EscapeDataString(redirectUrl)}");
            }
            else
            {
                return Redirect($"~/Login?error={error}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string redirectUrl)
        {
            if (env.EnvironmentName == "Development" && userName == "admin" && password == "admin")
            {
                var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Email, "admin")
                };

                roleManager.Roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));
                await signInManager.SignInWithClaimsAsync(new ApplicationUser { UserName = userName, Email = userName }, isPersistent: false, claims);

                return Redirect($"~/{redirectUrl}");
            }

            var user = await userManager.FindByNameAsync(userName);

            if (user is null || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return RedirectWithError("Invalid user or password", redirectUrl);
            
            if (!await userManager.IsEmailConfirmedAsync(user))
                return RedirectWithError("user email isn't confirmed yet.", redirectUrl);

            var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

            if (result.Succeeded)
            {
                return Redirect($"~/{redirectUrl}");
            }
            if (result.RequiresTwoFactor)
            {
                return (await TrySignInWithIp(userName, redirectUrl)) ??
                             Redirect($"~/login/{userName.Encode()}/validate2fa");
            }
            return RedirectWithError("Invalid user or password", redirectUrl);
        }

        private async Task<IActionResult?> TrySignInWithIp(string userName, string redirectUrl)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user?.TwofaIpAddress is null)
                return null;

            var rememberIpExpired = DateTime.Compare(DateTime.Now.AddDays(-60), user.UseIpFor2faSince) > 0;

            if (!rememberIpExpired && object.Equals(user.TwofaIpAddress, await TryGetClientIp()))
            {
                identityDbContext.Update(user);
                await identityDbContext.SaveChangesAsync();
                await signInManager.SignInAsync(user, true);
                return Redirect($"~/{redirectUrl}");
            }

            user.TwofaIpAddress = null;
            user.UseIpFor2faSince = default;
            identityDbContext.Update(user);
            await identityDbContext.SaveChangesAsync();

            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Redirect("~/Login?error=Invalid user or password");
            }

            var user = new ApplicationUser { UserName = userName, Email = userName };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect("~/");
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect($"~/Login?error={message}");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == null || newPassword == null)
            {
                return Redirect($"~/Profile?error=Invalid old or new password");
            }

            var id = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);

                return Redirect("~/");
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect($"~/Profile?error={message}");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Activate2Fa(string validationCode)
        {
            if (string.IsNullOrWhiteSpace(validationCode))
            {
                return Redirect("/Profile");
            }

            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await userManager.FindByIdAsync(id);
            validationCode = validationCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var is2faTokenValid = await userManager.VerifyTwoFactorTokenAsync(user,
                userManager.Options.Tokens.AuthenticatorTokenProvider, validationCode);

            if (!is2faTokenValid)
            {
                return Redirect("/Profile?error=Invalid Code");
            }
            await userManager.SetTwoFactorEnabledAsync(user, true);

            return Redirect("/Profile");
        }

        [HttpPost]
        public async Task<IActionResult> Validate2fa(string validationCode, bool rememberIp, string redirectUrl = "/", bool rememberMe = false)
        {
            var result = await signInManager.TwoFactorAuthenticatorSignInAsync(validationCode, rememberMe, rememberMe);

            if (rememberIp)
            {
                _ = SaveUserIpInfo();
            }
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();

            if (result.Succeeded)
            {
                user.LoggedInTwoFactor = true;
                identityDbContext.Update(user);
                await identityDbContext.SaveChangesAsync();
                return Redirect(redirectUrl);
            }

            return Redirect($"/login/{user?.UserName}/validate2fa?redirectUrl={redirectUrl}&error=Invalid Code");
        }

        private async Task SaveUserIpInfo()
        {
            var user = await GetTrying2faUser();
            if (user is null)
            {
                return;
            }

            var clientIp = await TryGetClientIp();
            if (clientIp is null)
            {
                return;
            }

            user.TwofaIpAddress = clientIp;
            user.UseIpFor2faSince = DateTime.Now;
        }

        private async Task<ApplicationUser> GetTrying2faUser()
        {
            var result = await base.HttpContext.AuthenticateAsync(IdentityConstants.TwoFactorUserIdScheme);
            if (result?.Principal is null)
            {
                return null;
            }

            var userId = result.Principal.FindFirstValue(ClaimTypes.Name);
            return await userManager.FindByIdAsync(userId);
        }

        private async Task<IPAddress> TryGetClientIp()
        {
            var clientRemoteIp = HttpContext.Connection.RemoteIpAddress;
            if (clientRemoteIp is not null)
            {
                return HttpContext.Connection.RemoteIpAddress;
            }
            string xForwardedFor = HttpContext.Request.Headers["X-Forwarded-For"];
            string[] ipAddresses = xForwardedFor?.Split(',').Select(s => s.Trim()).ToArray();
            string clientIpAddressString = ipAddresses?.FirstOrDefault();

            IPAddress.TryParse(clientIpAddressString, out var clientIp);
            return clientIp;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Redirect("~/Login?error=Invalid user");
            }

            if (!user.EmailConfirmed)
            {
                return Redirect("~/Login?error=User email not confirmed");
            }

            await SendResetPasswordEmail(userManager, user, Url, Request.Scheme);

            return Redirect("~/Login");
        }

        public async Task SendResetPasswordEmail(UserManager<ApplicationUser> userManager, ApplicationUser user,
            IUrlHelper url, string scheme)
        {
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = url.Action("ConfirmResetPassword", "Account", new { userId = user.Id, code = code },
                protocol: scheme);

            await SendEmail(user, code, callbackUrl, "RECO CMS Confirm password reset",
                "Click link to confirm password reset.  A password will be sent to you");
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmResetPassword(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Redirect("~/Login?error=Invalid user");
            }

            var newPassword = GenerateRandomPassword();

            OnConfirmResetPassword(userId, code, newPassword);

            var result = await userManager.ResetPasswordAsync(user, code, newPassword);
            if (result.Succeeded)
            {
                await SendEmail(user, code, null, "RECO CMS New password", newPassword);
                return Redirect("~/Login");
            }

            return Redirect("~/Login?error=Invalid user Id or confirmation code");
        }

        public async Task SendEmail(ApplicationUser user, string code, string callbackUrl, string subject, string text)
        {

            var message = new Message
            {
                Subject = subject,
                Body = new ItemBody
                {
                    Content = callbackUrl != null ? string.Format(@"<a href=""{0}"">{1}</a>", callbackUrl, text) : text,
                    ContentType = BodyType.Html,
                },
                ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = user.Email,
                        },
                    },
                },
            };
            OnSendEmail(message);
            await mailService.SendMail(message, "");
        }

        public static string GenerateRandomPassword(PasswordOptions options = null)
        {
            if (options == null)
            {
                options = new PasswordOptions()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 4,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };
            }

            var randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz",
                "0123456789",
                "!@$?_-"
            };

            var rand = new Random(Environment.TickCount);
            var chars = new List<char>();

            if (options.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (options.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (options.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (options.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < options.RequiredLength
                                      || chars.Distinct().Count() < options.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string userId, string code, string currentPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user is null || !await userManager.CheckPasswordAsync(user, currentPassword))
            {
                return Redirect("~/Login?error=Invalid user Id or confirmation code");
            }

            var confirmEmailResult = await userManager.ConfirmEmailAsync(user, code);
            var changePasswordResult = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (changePasswordResult.Succeeded && confirmEmailResult.Succeeded)
            {
                return Redirect("~/Login");
            }

            return Redirect("~/Login?error=Invalid user Id or confirmation code");
        }

        partial void OnSendEmail(Message message);
        partial void OnConfirmResetPassword(string userId, string code, string newPassword);
    }
}
