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
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Graph;
using RecoCms6.Models;
using RecoCms6.Services;
using System.Web;

namespace RecoCms6.Pages
{
    public partial class AddApplicationUserComponent : ComponentBase, IDisposable
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }
        [Inject]
        public UserManager<ApplicationUser> UserManager { get; set; }

        [Inject]
        public MailService MailService { get; set; }

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

        ApplicationUser _user;
        protected ApplicationUser user
        {
            get
            {
                return _user;
            }
            set
            {
                if (!object.Equals(_user, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "user", NewValue = value, OldValue = _user };
                    _user = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProvider _serviceprovider = new RecoCms6.Models.RecoDb.ServiceProvider
        {
            ID = Guid.NewGuid(),
        };
        protected RecoCms6.Models.RecoDb.ServiceProvider serviceprovider
        {
            get
            {
                return _serviceprovider;
            }
            set
            {
                if (!object.Equals(_serviceprovider, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "serviceprovider", NewValue = value, OldValue = _serviceprovider };
                    _serviceprovider = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<IdentityRole> _roles;
        protected IEnumerable<IdentityRole> roles
        {
            get
            {
                return _roles;
            }
            set
            {
                if (!object.Equals(_roles, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "roles", NewValue = value, OldValue = _roles };
                    _roles = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProvinceList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProvinceList
        {
            get
            {
                return _getProvinceList;
            }
            set
            {
                if (!object.Equals(_getProvinceList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getProvinceList", NewValue = value, OldValue = _getProvinceList };
                    _getProvinceList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethodList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethodList
        {
            get
            {
                return _getCommunicationMethodList;
            }
            set
            {
                if (!object.Equals(_getCommunicationMethodList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getCommunicationMethodList", NewValue = value, OldValue = _getCommunicationMethodList };
                    _getCommunicationMethodList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getServiceProviderRoleList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getServiceProviderRoleList
        {
            get
            {
                return _getServiceProviderRoleList;
            }
            set
            {
                if (!object.Equals(_getServiceProviderRoleList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getServiceProviderRoleList", NewValue = value, OldValue = _getServiceProviderRoleList };
                    _getServiceProviderRoleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Firm> _getFirmsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Firm> getFirmsResult
        {
            get
            {
                return _getFirmsResult;
            }
            set
            {
                if (!object.Equals(_getFirmsResult, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getFirmsResult", NewValue = value, OldValue = _getFirmsResult };
                    _getFirmsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _RoleName;
        protected string RoleName
        {
            get
            {
                return _RoleName;
            }
            set
            {
                if (!object.Equals(_RoleName, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "RoleName", NewValue = value, OldValue = _RoleName };
                    _RoleName = value;
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
            user = new ApplicationUser();

            var securityGetRolesResult = await Security.GetRoles();
            roles = securityGetRolesResult;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Province", "Method of Communication", "Service Provider Role" }, OrderBy = $"ParamDesc asc" });
            getProvinceList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Province");

            getCommunicationMethodList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Method of Communication");

            getServiceProviderRoleList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Service Provider Role");

            var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = recoDbGetFirmsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(ApplicationUser args)
        {
            user.RoleNames = new List<string>() { this.RoleName };

            var recoDbGetUserDetailsResult = await RecoDb.GetUserDetails(new Query() { Filter = $@"i => i.Email == @0", FilterParameters = new object[] { user.Email } });
            if (recoDbGetUserDetailsResult.Count() > 0)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable to Save ", Detail = $"Email Address already exists in system" });
                return;
            }
            var serviceProvidersQuery = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.EmailAddress == @0", FilterParameters = new object[] { user.Email } });
            var serviceProviderByEmail = await serviceProvidersQuery.FirstOrDefaultAsync();

            if (serviceProviderByEmail is not null)
            {
                serviceprovider = serviceProviderByEmail;
            }

            try
            {

                user.LoggedInTwoFactor = false;
                var securityCreateUserResult = await Security.CreateUser(args);

                serviceprovider.UserID = securityCreateUserResult.Id;

                if (Globals.defaultProvinceID != 0)
                {
                    serviceprovider.ProvinceID = Globals.defaultProvinceID;
                }

                serviceprovider.EmailAddress = user.Email;

                if (RoleName == "Adjuster" || RoleName == "Claims Admin" || RoleName == "Defense Counsel" ||
                    RoleName == "Claims Manager" || RoleName == "Program Manager" || RoleName == "Accountant" || RoleName == "Coverage Counsel" || RoleName == "Actuary")
                {
                    serviceprovider.ServiceProviderRoleID = getServiceProviderRoleList.Where(sp => sp.ParamDesc == RoleName).First().ParameterID;
                }
                if (RoleName == "Adjuster" || RoleName == "Claims Admin" || RoleName == "Defense Counsel" || RoleName == "Claims Manager" || RoleName == "Program Manager" || RoleName == "Accountant" || RoleName == "Coverage Counsel" || RoleName == "Actuary")
                {
                    if (serviceProviderByEmail is null)
                    {
                        var recoDbCreateServiceProviderResult = await RecoDb.CreateServiceProvider(serviceprovider);
                    }
                    else
                    {
                        await RecoDb.UpdateServiceProvider(serviceprovider.ID, serviceprovider);
                    }
                    if (RoleName == "Adjuster" || RoleName == "Claims Admin" || RoleName == "Defense Counsel" || RoleName == "Claims Manager" || RoleName == "Program Manager" || RoleName == "Accountant" || RoleName == "Coverage Counsel" || RoleName == "Actuary")
                    {
                        DialogService.Close(serviceprovider);
                    }
                }

                if (RoleName != "Adjuster" && RoleName != "Claims Admin" && RoleName != "Defense Counsel" && RoleName != "Claims Manager" && RoleName != "Program Manager" && RoleName != "Accountant" && RoleName != "Coverage Counsel" && RoleName != "Actuary")
                {
                    DialogService.Close(null);
                }

                await SendConfirmationEmail(securityCreateUserResult);
            }
            catch (System.Exception securityCreateUserException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Cannot add user", Detail = $"{securityCreateUserException.Message}" });
            }

        }
        public async Task SendConfirmationEmail(ApplicationUser user)
        {
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = $"{UriHelper.BaseUri}set-password?userId={user.Id}&code={HttpUtility.UrlEncode(code)}";

            await SendEmail(user, code, callbackUrl, "RECO CMS Please confirm your email address", "Click link to confirm your email address");
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
            await MailService.SendMail(message, "");
        }

        protected async System.Threading.Tasks.Task RoleNamesChange(dynamic args)
        {
            RoleName = args;
        }
        protected async System.Threading.Tasks.Task ButtonNewFirmClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFirm>("Add Firm", null, new DialogOptions() { Width = $"{800}px" });
            if (dialogResult != null)
            {
                serviceprovider.FirmID = dialogResult.FirmID;
            }

            if (dialogResult != null)
            {
                var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
                getFirmsResult = recoDbGetFirmsResult;
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
