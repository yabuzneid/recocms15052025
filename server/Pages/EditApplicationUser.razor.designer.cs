﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using RecoCms6.Models.RecoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RecoCms6.Models;

namespace RecoCms6.Pages
{
    public partial class EditApplicationUserComponent : ComponentBase, IDisposable
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
        public dynamic Id { get; set; }

        string _roleCounterpartLabel;
        protected string roleCounterpartLabel
        {
            get
            {
                return _roleCounterpartLabel;
            }
            set
            {
                if (_roleCounterpartLabel != value)
                {
                    var args = new PropertyChangedEventArgs()
                    {
                        Name = nameof(roleCounterpartLabel),
                        NewValue = value,
                        OldValue = _roleCounterpartLabel
                    };
                    _roleCounterpartLabel = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _selectedID;
        protected string selectedID
        {
            get
            {
                return _selectedID;
            }
            set
            {
                if (!object.Equals(_selectedID, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "selectedID", NewValue = value, OldValue = _selectedID };
                    _selectedID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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
                    var args = new PropertyChangedEventArgs(){ Name = "user", NewValue = value, OldValue = _user };
                    _user = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private bool _isRestTwoFaVisible;

        public bool IsRestTwoFaVisible
        {
            get => _isRestTwoFaVisible;
            set
            {
                if (!object.Equals(_user, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "IsRestTwoFaVisible", NewValue = value, OldValue = _isRestTwoFaVisible };
                    _isRestTwoFaVisible = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<IdentityRole> _roles;
        protected List<IdentityRole> roles
        {
            get
            {
                return _roles;
            }
            set
            {
                if (!object.Equals(_roles, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "roles", NewValue = value, OldValue = _roles };
                    _roles = value;
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

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getCommunicationMethodList;
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getCommunicationMethodList
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

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getProvinceList;
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getProvinceList
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

        List<RecoCms6.Models.RecoDb.ParameterDetail> _getServiceProviderRoleList;
        protected List<RecoCms6.Models.RecoDb.ParameterDetail> getServiceProviderRoleList
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

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProvidersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProvidersResult
        {
            get
            {
                return _getServiceProvidersResult;
            }
            set
            {
                _getServiceProvidersResult = value;
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> _getServiceProvidersList = [];
        protected IEnumerable<RecoCms6.Models.RecoDb.ServiceProviderDetail> getServiceProvidersList
        {
            get
            {
                return _getServiceProvidersList;
            }
            set
            {
                if (!object.Equals(_getServiceProvidersList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getServiceProvidersList", NewValue = value, OldValue = _getServiceProvidersList };
                    _getServiceProvidersList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProvider _serviceprovider;
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

        bool _bNewServiceProvider;
        protected bool bNewServiceProvider
        {
            get
            {
                return _bNewServiceProvider;
            }
            set
            {
                if (!object.Equals(_bNewServiceProvider, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "bNewServiceProvider", NewValue = value, OldValue = _bNewServiceProvider };
                    _bNewServiceProvider = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _DisableUser;
        protected bool DisableUser
        {
            get
            {
                return _DisableUser;
            }
            set
            {
                if (!object.Equals(_DisableUser, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "DisableUser", NewValue = value, OldValue = _DisableUser };
                    _DisableUser = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<RecoCms6.Models.RecoDb.Firm> _getFirmsResult;
        protected List<RecoCms6.Models.RecoDb.Firm> getFirmsResult
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

        protected async System.Threading.Tasks.Task OnRoleChanged(dynamic args)
        {
            var selected = this.user.RoleNames.ToList();

            const string defenseCounselRole = "Defense Counsel";
            const string legalAssistantsRole = "Legal Assistants";

            bool hasDefenseCounselRole = selected.Contains(defenseCounselRole);
            bool hasLegalAssistantsRole = selected.Contains(legalAssistantsRole);

            if (hasDefenseCounselRole && hasLegalAssistantsRole)
            {
                if(Security.IsInRole(defenseCounselRole))
                    selected.Remove(legalAssistantsRole);
                else
                    selected.Remove(defenseCounselRole);

                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Warning,
                    Summary = "Invalid Role Selection",
                    Detail = $"The user cannot select both {defenseCounselRole} and {legalAssistantsRole} roles",
                    Duration = 3000
                });

                user.RoleNames = selected;
                return;
            }
            roleCounterpartLabel = hasDefenseCounselRole ? legalAssistantsRole : hasLegalAssistantsRole ? defenseCounselRole : string.Empty;

            if(serviceprovider.FirmID != null)
                FilterServiceProvidersList();
        }

        protected async System.Threading.Tasks.Task OnFirmChanged(dynamic args)
        {
            FilterServiceProvidersList();
        }

        private void FilterServiceProvidersList()
        {
            if (this.user.RoleNames.Contains("Defense Counsel"))
            {
                getServiceProvidersList = getServiceProvidersResult.Where(sp => sp.SystemRole == "Legal Assistants" && sp.FirmID != null && sp.FirmID == serviceprovider.FirmID);

            }
            else if (this.user.RoleNames.Contains("Legal Assistants"))
            {
                getServiceProvidersList = getServiceProvidersResult.Where(sp => sp.SystemRole == "Defense Counsel" && sp.FirmID != null && sp.FirmID == serviceprovider.FirmID);
            }
        }

        private List<int> _serviceProviders = new();
        public List<int> ServiceProviders
        {
            get => _serviceProviders;
            set
            {
                _serviceProviders = value ?? new List<int>();
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
            selectedID = Id == "0" ? Security.User.Id : Id;

            var securityGetUserByIdResult = await Security.GetUserById($"{selectedID}");
            user = securityGetUserByIdResult;

            IsRestTwoFaVisible = user.TwoFactorEnabled && (user.LoggedInTwoFactor ?? true);
            var securityGetRolesResult = await Security.GetRoles();
            roles = securityGetRolesResult.ToList();

            RoleName = user.RoleNames.FirstOrDefault();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Method of Communication", "Province", "Service Provider Role" }, OrderBy = $"ParamDesc asc" });
            getCommunicationMethodList = await recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Method of Communication").ToListAsync();

            getProvinceList = await recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Province").ToListAsync();

            getServiceProviderRoleList = await recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Service Provider Role").ToListAsync();

            if (RoleName == "Adjuster" || RoleName == "Claims Admin" || RoleName == "Claims Manager" || RoleName == "Program Manager" || RoleName == "Defense Counsel" || RoleName == "Legal Assistants")
            {
                var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { selectedID } });
                serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();
            }

            if (serviceprovider == null)
            {
                bNewServiceProvider = true;
                serviceprovider = new RecoCms6.Models.RecoDb.ServiceProvider() { };
                serviceprovider.UserID = selectedID;
            }

            if (bNewServiceProvider)
            {
                serviceprovider.ID = Guid.NewGuid();
            }

            DisableUser = await IsUserInactive(user);

            var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
            getFirmsResult = await recoDbGetFirmsResult.ToListAsync();
            getServiceProvidersResult = await RecoDb.GetServiceProviderDetails(new Query
            {
                Filter = @"i => i.SystemRole == @0 || i.SystemRole == @1",
                FilterParameters = new object[] { "Defense Counsel", "Legal Assistants" },
                OrderBy = "NameandFirm asc"
            });


            var allowedRoles = new[] { "Defense Counsel", "Legal Assistants" };
            if (this.user.RoleNames.Any(role => allowedRoles.Contains(role)))
            {
                bool isDefense = this.user.RoleNames.Contains("Defense Counsel");
                string counterpartRole = isDefense ? "Legal Assistants" : "Defense Counsel";

                // Set label for the counterpart role
                roleCounterpartLabel = counterpartRole;

                // Filter providers by firm and counterpart role
                getServiceProvidersList = getServiceProvidersResult
                    .Where(sp => sp.SystemRole == counterpartRole
                              && sp.FirmID != null
                              && sp.FirmID == serviceprovider.FirmID).ToList();

                // Load associated counterpart service provider IDs
                ServiceProviders = isDefense
                    ? serviceprovider.AsDefenseCounsel.Select(x => x.LegalAssistantID).ToList()
                    : serviceprovider.AsLegalAssistant.Select(x => x.DefenseCounselID).ToList();
            }
        }


        protected async System.Threading.Tasks.Task Form0Submit(ApplicationUser args)
        {
            try
            {
                if (args.UserName != args.Email) //If the Email has changed, update the username to the new email
                    args.UserName = args.Email;

                var securityUpdateUserResult = await Security.UpdateUser($"{selectedID}", args);

                serviceprovider.AsDefenseCounsel?.Clear();
                serviceprovider.AsLegalAssistant?.Clear();
                if (this.user.RoleNames.Contains("Defense Counsel"))
                {
                    serviceprovider.AsDefenseCounsel = ServiceProviders.Select(legalAssistantId => new LegalAssistants
                    {
                        DefenseCounselID = serviceprovider.ServiceProviderID,
                        LegalAssistantID = legalAssistantId
                    }).ToList();
                } else if (this.user.RoleNames.Contains("Legal Assistants"))
                {
                    serviceprovider.AsLegalAssistant = ServiceProviders.Select(defenseCounselID => new LegalAssistants
                    {
                        DefenseCounselID = defenseCounselID,
                        LegalAssistantID = serviceprovider.ServiceProviderID
                    }).ToList();
                }

                var recoDbUpdateServiceProviderResult = await RecoDb.UpdateServiceProvider(serviceprovider.ID, serviceprovider);

                DialogService.Close(args);
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Success,Summary = $"User Updated Successfully"});
            }
            catch (System.Exception securityUpdateUserException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Cannot update user",Detail = $"{securityUpdateUserException.Message}" });
            }
        }

        
        protected async System.Threading.Tasks.Task ButtonNewFirmClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddFirm>("Add Firm", null, new DialogOptions(){ Width = $"{800}px" });
            if (dialogResult != null) {
                serviceprovider.FirmID = dialogResult.FirmID;
            }

            if (dialogResult != null)
            {
                var recoDbGetFirmsResult = await RecoDb.GetFirms(new Query() { OrderBy = $"Name asc" });
                getFirmsResult = await recoDbGetFirmsResult.ToListAsync();
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
