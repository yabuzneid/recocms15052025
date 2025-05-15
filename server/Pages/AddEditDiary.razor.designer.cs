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
using Microsoft.Graph;
using Microsoft.IdentityModel.Tokens;
using RecoCms6.Models;

namespace RecoCms6.Pages
{
    public partial class AddEditDiaryComponent : ComponentBase, IDisposable
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
        public dynamic Start { get; set; }

        [Parameter]
        public dynamic End { get; set; }

        [Parameter]
        public dynamic ClaimID { get; set; }

        [Parameter]
        public dynamic DiaryID { get; set; }
        
        IEnumerable<RecoCms6.Models.RecoDb.StandardEmailAddress> _standardEmails = new List<StandardEmailAddress>();
        [Parameter]
        public IEnumerable<RecoCms6.Models.RecoDb.StandardEmailAddress> standardEmails
        {
            get
            {
                return _standardEmails;
            }
            set
            {
                if (!object.Equals(_standardEmails, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "standardEmails", NewValue = value, OldValue = _standardEmails };
                    _standardEmails = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        private List<string> _diaryRecipients = new();
        public List<string> DiaryRecipients
        {
            get => _diaryRecipients;
            set
            {
                _diaryRecipients = value ?? new List<string>();
                diary.Recipients = string.Join(EmailSeparator, _diaryRecipients);
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Claim> _getClaimsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Claim> getClaimsResult
        {
            get
            {
                return _getClaimsResult;
            }
            set
            {
                if (!object.Equals(_getClaimsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimsResult", NewValue = value, OldValue = _getClaimsResult };
                    _getClaimsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _getClaimNo;
        protected string getClaimNo
        {
            get
            {
                return _getClaimNo;
            }
            set
            {
                if (!object.Equals(_getClaimNo, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClaimNo", NewValue = value, OldValue = _getClaimNo };
                    _getClaimNo = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParameterDetailsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParameterDetailsResult
        {
            get
            {
                return _getParameterDetailsResult;
            }
            set
            {
                if (!object.Equals(_getParameterDetailsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParameterDetailsResult", NewValue = value, OldValue = _getParameterDetailsResult };
                    _getParameterDetailsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> _getDiaryTemplateResults;
        protected IEnumerable<RecoCms6.Models.RecoDb.TemplateDetail> getDiaryTemplateResults
        {
            get
            {
                return _getDiaryTemplateResults;
            }
            set
            {
                if (!object.Equals(_getDiaryTemplateResults, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDiaryTemplateResults", NewValue = value, OldValue = _getDiaryTemplateResults };
                    _getDiaryTemplateResults = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _IsEdit;
        protected bool IsEdit
        {
            get
            {
                return _IsEdit;
            }
            set
            {
                if (!object.Equals(_IsEdit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "IsEdit", NewValue = value, OldValue = _IsEdit };
                    _IsEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Diary _diary;
        protected RecoCms6.Models.RecoDb.Diary diary
        {
            get
            {
                return _diary;
            }
            set
            {
                if (!object.Equals(_diary, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "diary", NewValue = value, OldValue = _diary };
                    _diary = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<string> _Emails;
        protected IEnumerable<string> Emails
        {
            get
            {
                return _Emails;
            }
            set
            {
                if (!object.Equals(_Emails, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Emails", NewValue = value, OldValue = _Emails };
                    _Emails = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _TemplateID;
        protected int TemplateID
        {
            get
            {
                return _TemplateID;
            }
            set
            {
                if (!object.Equals(_TemplateID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "TemplateID", NewValue = value, OldValue = _TemplateID };
                    _TemplateID = value;
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
            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            getClaimsResult = recoDbGetClaimsResult;

            getClaimNo = recoDbGetClaimsResult.FirstOrDefault().ClaimNo;

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "Diary Status" }, OrderBy = $"ParamDesc asc" });
            getParameterDetailsResult = recoDbGetParameterDetailsResult.Where(x => x.ParamTypeDesc == "Diary Status").ToArray();

            var recoDbGetTemplateDetailsResult = await RecoDb.GetTemplateDetails(new Query() { Filter = $@"i => i.TemplateType == @0 || i.TemplateType == @1 || i.TemplateType == @2", FilterParameters = new object[] { "<All>", "Diary", "Diary/Email" }, OrderBy = $"Title asc" });
            getDiaryTemplateResults = recoDbGetTemplateDetailsResult;

            var recoDbGetStandardEmailAddressesResult = await RecoDb.GetStandardEmailAddresses(new Query() { OrderBy = $"EmailAddress asc" });
            standardEmails = recoDbGetStandardEmailAddressesResult;

            IsEdit = DiaryID != null;

            if (!IsEdit) {
                diary = new RecoCms6.Models.RecoDb.Diary(){};
            }

            if (!IsEdit) {
                diary.DiaryStatusID = getParameterDetailsResult.FirstOrDefault(x => x.ParamDesc == "Open").ParameterID;
            }

            if (!IsEdit) {
                diary.ID = Guid.NewGuid();
            }

            if (!IsEdit) {
                diary.ClaimID = ClaimID;
            }

            if (!IsEdit) {
                diary.EntryDate = DateTime.Now;
            }

            if (!IsEdit) {
                diary.EnteredBy = Security.User.Id;
            }

            if (!IsEdit)
            {
                var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                diary.EnteredBy = recoDbGetServiceProvidersResult.First().Name;
            }

            Emails = new List<string>();

            TemplateID = 0;

            if (IsEdit)
            {
                var recoDbGetDiaryByIdResult = await RecoDb.GetDiaryById((Guid)DiaryID);
                diary = recoDbGetDiaryByIdResult;
                DiaryRecipients = diary.Recipients
                    .Split(EmailSeparator)
                    .Select(e=>e.Trim())
                    .ToList();
            }
        }
        protected string RecpientsValidationMessage = String.Empty;

        protected async System.Threading.Tasks.Task Form0Submit(RecoCms6.Models.RecoDb.Diary args)
        {
            var invalidEmails = ValidateRecipients();
            if (invalidEmails.Count > 0)
            {
                RecpientsValidationMessage = $"Invalid Emails: The following Emails are invalid: {string.Join(EmailSeparator, invalidEmails)}";
                return;
            }
            RecpientsValidationMessage = String.Empty;

            try
            {
                if (!IsEdit)
                {
                    var recoDbCreateDiaryResult = await RecoDb.CreateDiary(diary);
                    DialogService.Close(recoDbCreateDiaryResult);
                }
            }
            catch (System.Exception recoDbCreateDiaryException)
            {
            await SaveErrorAsync(recoDbCreateDiaryException);

                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Cannot create new Diary!" });
            }

            if (IsEdit)
            {
                await UpdateDiary();
            }
        }

        protected async System.Threading.Tasks.Task DropdownTemplateChange(dynamic args)
        {
            var setFormByTemplatePropertiesResult = await SetFormByTemplateProperties();
        }

        public void DiaryRecipientsChanged(List<string> args)
        {
            DiaryRecipients = args;
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
        protected async System.Threading.Tasks.Task ButtonAddToClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<DialogSelectEmail>($"Diary Email Addresses", new Dictionary<string, object>() { {"ClaimID", ClaimID} });
            if (dialogResult is IEnumerable<string> enumerableResult && !enumerableResult.IsNullOrEmpty())
            {
                var newDiaryReciepients = enumerableResult.ToList();
                newDiaryReciepients.AddRange(DiaryRecipients);
                DiaryRecipientsChanged(newDiaryReciepients);
            }
        }
    }
}
