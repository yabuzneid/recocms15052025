using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using RecoCms6.Data;
using RecoCms6.Models.RecoDb;
using RecoCms6.Shared;
using RecoCms6.Models;
using RecoCms6.Services.TemplateEngine;
using System.Linq;
using Radzen;
using System.Threading.Tasks;
using Radzen.Blazor;
using RecoCms6.Services;
using RecoCms6.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using System.Web;
using Microsoft.Graph;
using Agno.BlazorInputFile;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Dynamic;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;


namespace RecoCms6.Pages
{
    public partial class EditCommissionClaimComponent
    {
        [Inject]
        protected IMapper Mapper { get; set; }

        [Inject]
        public MacroService MacroService { get; set; }

        [Inject]
        protected RecoDbContext _RecoDbContext { get; set; }

        [Inject]
        protected MailService _MailService { get; set; }

        RecoCms6.Models.RecoMail _newRecoMail;
        protected RichTextEditor RteObj;
        protected RecoCms6.Models.RecoMail newRecoMail
        {
            get
            {
                return _newRecoMail;
            }
            set
            {
                if (!object.Equals(_newRecoMail, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "newRecoMail", NewValue = value, OldValue = _newRecoMail };
                    _newRecoMail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _fromMail;
        protected string fromMail
        {
            get
            {
                return _fromMail;
            }
            set
            {
                if (!object.Equals(_fromMail, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "fromMail", NewValue = value, OldValue = _fromMail };
                    _fromMail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _ClaimTitle;
        protected string ClaimTitle
        {
            get
            {
                return _ClaimTitle;
            }
            set
            {
                if (!object.Equals(_ClaimTitle, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "ClaimTitle", NewValue = value, OldValue = _ClaimTitle };
                    _ClaimTitle = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public bool isToEmailsValid { get { return ValidateEmails(ToAddresses); } }
        public bool isToEmailsFilled { get { return ToAddresses != null && ToAddresses.Count > 0; } }
        public bool isCcEmailsValid { get { return ValidateEmails(CCAddresses); } }
        public bool isBccEmailsValid { get { return ValidateEmails(BCCAddresses); } }
        public bool isAllEmailsValid { get { return isToEmailsValid && isBccEmailsValid && isCcEmailsValid; } }
        bool ValidateEmails(List<string> emails)
        {
            bool isValid = true;
            if (emails != null)
            {
                foreach (var item in emails)
                {
                    if (!IsValidEmail(item))
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = SplitAndTrim(email);

            try
            {
                foreach (var item in trimmedEmail)
                {
                    var emailaddress = item.Trim();
                    if (emailaddress.EndsWith(".") || !emailaddress.Contains("."))
                        return false; // suggested by @TK-421

                    var addr = new System.Net.Mail.MailAddress(emailaddress);
                    if (addr.Address != emailaddress)
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        public void ToAddressChanged(List<string> args)
        {
            ToAddresses = args;
            ToAddressessChanged();
        }
        List<string> _ToAddresses;
        protected List<string> ToAddresses
        {
            get
            {
                return _ToAddresses;
            }
            set
            {

                if (!object.Equals(_ToAddresses, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "ToAddresses", NewValue = value, OldValue = _ToAddresses };
                    _ToAddresses = value;
                    OnPropertyChanged(args);
                    ToAddressessChanged();
                    Reload();
                }
            }
        }

        public void CCAddressChanged(List<string> args)
        {
            CCAddresses = args;
            CCAddressessChanged();
        }
        List<string> _CCAddresses;
        protected List<string> CCAddresses
        {
            get
            {
                return _CCAddresses;
            }
            set
            {
                if (!object.Equals(_CCAddresses, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "CCAddresses", NewValue = value, OldValue = _CCAddresses };
                    _CCAddresses = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public void BCCAddressChanged(List<string> args)
        {
            BCCAddresses = args;
            BCCAddressessChanged();
        }
        List<string> _BCCAddresses;
        protected List<string> BCCAddresses
        {
            get
            {
                return _BCCAddresses;
            }
            set
            {
                if (!object.Equals(_BCCAddresses, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "BCAddresses", NewValue = value, OldValue = _BCCAddresses };
                    _BCCAddresses = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _AttachmentContent;
        protected string AttachmentContent
        {
            get
            {
                return _AttachmentContent;
            }
            set
            {
                if (!object.Equals(_AttachmentContent, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "AttachmentContent", NewValue = value, OldValue = _AttachmentContent };
                    _AttachmentContent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _showprogressbar;
        protected bool showprogressbar
        {
            get
            {
                return _showprogressbar;
            }
            set
            {
                if (!object.Equals(_showprogressbar, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "showprogressbar", NewValue = value, OldValue = _showprogressbar };
                    _showprogressbar = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.ServiceProviderClaimPreference _claimpreference;
        protected RecoCms6.Models.RecoDb.ServiceProviderClaimPreference claimpreference
        {
            get
            {
                return _claimpreference;
            }
            set
            {
                if (!object.Equals(_claimpreference, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "claimpreference", NewValue = value, OldValue = _claimpreference };
                    _claimpreference = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }
        protected string selectedFile { get;  set; }

        /// <summary>
        /// It coverrs all the 2 scenarios for the claim report page
        ///         - new fresh report (initial report)
        ///         - resume working on saved (not submitted report)
        ///         - new subsequent report created from the last report submitted
        /// </summary>
        /// <param name="ClaimID"></param>
        /// <returns>
        /// A report object prepared for the specific needs.
        /// </returns>
        public async Task<RecoCms6.Models.RecoDb.ClaimReport> getClaimReport(int ClaimID)
        {
            if (serviceprovider == null)
                await GetCurrentServiceProvider();

            if (serviceprovider.FirmID == null || serviceprovider.FirmID == 0)
                return DefaultReport(ClaimID);

            var filter = $@"i => i.ClaimID == {ClaimID}" + 
                         (serviceprovider.FirmID != null ? $" && i.HandlingFirmID == {serviceprovider.FirmID}" : string.Empty);
            
            var reports = await RecoDb.GetClaimReports(new Radzen.Query() { Filter = filter});

            //no report created so far, just create the initial report
            if (reports.Count() == 0)
                return DefaultReport(ClaimID);

            //resume working on a saved report => get the last report which wasn't submitted yet
            var lastNotsubbmittedReport = reports.Where(x => x.DateSubmitted == null)
                .OrderByDescending(x => x.DateCreated)
                .ThenByDescending(x => x.DateLastModified)
                .FirstOrDefault();

            if (lastNotsubbmittedReport != null)
            {
                return lastNotsubbmittedReport;
            }

            //create new subsequenct report => each report is submitted so we need to create a new copy of the last one and unmark it as initial report
            if (!reports.Any(x => x.DateSubmitted == null))
            {
                var lastSubmitedReport = reports.OrderByDescending(x => x.DateSubmitted)
                    .AsNoTracking()
                    .FirstOrDefault();

                var lastSubmitedReportCopy = RecoDb.CloneClaimReport(lastSubmitedReport);

                lastSubmitedReportCopy.InitialReport = false;
                lastSubmitedReportCopy.Incremental = true;
                lastSubmitedReportCopy.ActionPlan = String.Empty;
                lastSubmitedReportCopy.Coverage = String.Empty;
                lastSubmitedReportCopy.Damages = String.Empty;
                lastSubmitedReportCopy.Facts = String.Empty;
                lastSubmitedReportCopy.Liability = String.Empty;
                lastSubmitedReportCopy.Recommendations = String.Empty;
                lastSubmitedReportCopy.ClaimReportFlagID = null;

                return lastSubmitedReportCopy;
            }

            //if non of the above fresh start.
            return DefaultReport(ClaimID);

        }

        private Models.RecoDb.ClaimReport DefaultReport(int ClaimID)
        {
            return new RecoCms6.Models.RecoDb.ClaimReport()
            {
                InitialReport = true,
                ClaimID = ClaimID,
                Incremental = false,
                HandlingFirmID = serviceprovider?.FirmID
            };
        }

        async Task ShowBusyDialog()
        {
            
            var dialogTask = BusyDialog(IsSubmitEvent ? "Submitting ..." : "Saving ...");

            Task.Run(async () =>
            {
                saveResult = await SaveReport();
                
                DialogService.Close(dialogTask);
            });

            await dialogTask;
            
            
            if (saveResult && !IsSubmitEvent)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Report is saved" });
            }

            if (saveResult && IsSubmitEvent)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Report Has been Submitted" });
                report = await getClaimReport(claim.ClaimID);
            }
        }


        // Busy dialog from string
        async Task BusyDialog(string message)
        {
            await DialogService.OpenAsync("", ds =>
            {
                RenderFragment content = b =>
                {
                    b.OpenElement(0, "div");
                    b.AddAttribute(1, "class", "row");

                    b.OpenElement(2, "div");
                    b.AddAttribute(3, "class", "col-md-12");

                    b.AddContent(4, message);

                    b.CloseElement();
                    b.CloseElement();
                };
                return content;
            }, new DialogOptions() { ShowTitle = false, Style = "min-height:auto;min-width:auto;width:auto", CloseDialogOnOverlayClick = false });
        }

        protected async Task<bool> SaveReport()
        {
            try
            {
                if (IsSubmitEvent)
                {
                    report.DateSubmitted = DateTime.Now;
                    var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                    report.SubmittedBy = recoDbGetServiceProviderDetailsResult.First().Name;
                }
                report.DateLastModified = DateTime.Now;
                if (claim.CounselFileNo != String.Empty)
                    await RecoDb.UpdateCounselClaimNums(claim.ClaimID, $"{claim.CounselFileNo}");

                //fresh report
                if (report.ClaimReportID == 0)
                {
                    report.DateCreated = DateTime.Now;
                    await this.RecoDb.CreateClaimReport(report);                        
                }
                else
                    await this.RecoDb.UpdateClaimReport(report.ClaimReportID, report);
                    

                if (IsSubmitEvent)
                    await handleReport(report.ClaimReportID);

                if (!IsSubmitEvent)
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Claim Report Successfully Saved" });

                return true;
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Problem Saving Claim Report", Detail = $"{ex.Message}" });
                return false;
            }
            
        }

        private async Task handleReport(int claimreportid)
        {
            var innerReport = (RecoCms6.Models.RecoDb.ClaimReport)report;
            var reportDetail = this._RecoDbContext.ClaimReportDetails.Where(rpd => rpd.ClaimReportID == claimreportid).FirstOrDefault();

            //var reportHtml = await TemplateBuilder.Build(Templates.ClaimReport, reportDetail);
            var reportHtml = TemplateBuilder.BuildClaimReport(reportDetail);
            var reportPdf = reportHtml.ToPDFByteArray();

            var file = this._RecoDbContext.Files.Add(new Models.RecoDb.File()
            {
                ID = Guid.NewGuid(),
                ClaimID = reportDetail.ClaimID,
                Extension = ".pdf",
                Subject = $"Claim Report Filed By {reportDetail.SubmittedByName}",
                Filename = $"Claimreport_{claimreportid.ToString("D6")}.pdf",
                EntryDate = DateTime.Now,
                StoredDocument = reportPdf,
                UploadedById = Security.User.Id,
                ContentType = "application/pdf"
            });
            this._RecoDbContext.SaveChanges();

            if (Security.IsInRole("DefenseCounsel"))
            {
                var template = this._RecoDbContext.DiaryTemplates.Where(x => x.Title == "Update Request").FirstOrDefault();
                var days = reportDetail.ReportingDays ?? 90; //Default to 90 Days if Reporting Days is null
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                string enteredBy = recoDbGetServiceProviderDetailsResult.First().Name;

                this._RecoDbContext.Diaries.Add(new Models.RecoDb.Diary()
                {
                    ClaimID = reportDetail.ClaimID,
                    Subject = await MacroService.Replace(reportDetail.ClaimID, template.Subject),
                    Details = await MacroService.Replace(reportDetail.ClaimID, template.TemplateText),
                    AbeyanceDate = DateTime.Now.AddDays(days),
                    EntryDate = DateTime.Now,
                    EnteredBy = enteredBy,
                    DiaryStatusID = 145, // Open Status
                    Recipients = reportDetail.DefenseCounselEmailAddress
                });
                this._RecoDbContext.SaveChanges();
            }

            if (getFileHandler != null)
                await _MailService.SendReportMail(reportDetail, Security.User, reportHtml,masterclaimList);

            var reports = await RecoDb.GetClaimReports(new Radzen.Query() { Filter = $@"i => i.ClaimID == {claim.ClaimID} && i.HandlingFirmID == {serviceprovider.FirmID}" });
        }

        private bool ValidateReport()
        {
            var fieldValidation = new List<Func<string>>()
            {
                () => string.IsNullOrWhiteSpace(report.ExecutiveSummary) ? "ExecutiveSummary required!" : string.Empty,
                () => string.IsNullOrWhiteSpace(report.Facts) ? "Facts required!" : string.Empty,
                () => string.IsNullOrWhiteSpace(report.Coverage) ? "Coverage required!" : string.Empty,
                () => string.IsNullOrWhiteSpace(report.Liability) ? "Liability required!" : string.Empty,
                () => string.IsNullOrWhiteSpace(report.Damages) ? "Damages required!" : string.Empty,
                () => string.IsNullOrWhiteSpace(report.Recommendations) ? "Recommendations required!" : string.Empty
            };

            if (!report.InitialReport)
            {
                fieldValidation.Add(() => string.IsNullOrWhiteSpace(report.ActionPlan) ? "Update required!" : string.Empty);
            }

            fieldValidation.Select(func => func())
                .Where(x => x.Length > 0).ToList()
                .ForEach(x => NotificationService.Notify(NotificationSeverity.Error, $"Validation Error", $"{x}"));


            return !fieldValidation.Any(func => func().Length > 0);
        }

        protected CppClaimantGrid<CppClaimantViewModel, Claimant, AddClaimantComponent> gridClaimant;

        protected CppClaimantGrid<EOClaimantViewModel, Claimant, AddClaimantComponent> gridEOClaimant;

        protected RadzenCheckBoxList<Role> chkBoxRoles;


        protected async void loadFileReports()
        {
            List<int> fileReportIds = new List<int>();

            var recoDbGetClaimFileReportsResult = await RecoDb.GetClaimFileReportings(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { masterclaim.ClaimID } });

            foreach (ClaimFileReporting fileReport in recoDbGetClaimFileReportsResult)
                fileReportIds.Add(fileReport.ServiceProviderID);

            selectedFileReportIds = fileReportIds;
        }

        protected async Task saveFileReports()
        {

            claim.ClaimFileReportings = selectedFileReportIds.Select(r => new ClaimFileReporting() { ClaimID = masterclaim.ClaimID, ServiceProviderID = r }).ToList();
        }

        protected void UpdateDisplayOrder(List<Claimant> entities)
        {
            short order = 1;
            foreach (var entity in entities)
            {
                entity.ClaimantOrder = order++;
            }
        }
        protected void UpdateInsuredsDisplayOrder(List<RecoCms6.Models.RecoDb.Insured> entities)
        {
            short order = 1;
            foreach (var entity in entities)
            {
                entity.DisplayOrder = order++;
            }
        }

        protected void UpdateOtherPartyDisplayOrder(List<RecoCms6.Models.RecoDb.OtherParty> entities)
        {
            short order = 1;
            foreach (var entity in entities)
            {
                entity.DisplayOrder = order++;
            }
        }

        protected void UpdateExpertsDisplayOrder(List<RecoCms6.Models.RecoDb.Expert> entities)
        {
            short order = 1;
            foreach (var entity in entities)
            {
                entity.DisplayOrder = order++;
            }
        }

        protected void UpdateTradesDisplayOrder(List<RecoCms6.Models.RecoDb.Trade> entities)
        {
            short order = 1;
            foreach (var entity in entities)
            {
                entity.DisplayOrder = order++;
            }
        }

        protected async void ReloadClaim()
        {
            intClaimID = StringExtensions.IntegerFromBase64(ClaimID);

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"", Expand = "ClaimFileReportings" });
            claim = recoDbGetClaimsResult.First(); ;

            if (claim.MasterFile)
                masterclaim = recoDbGetClaimsResult.First();
            else
            {
                var recoDbGetClaimsResult0 = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.MasterFileID } });
                masterclaim = recoDbGetClaimsResult0.First();
            }

            if (claim.ClaimantID != null)
                claimantID = claim.ClaimantID;

            var recoDbGetClaimantsResult = await RecoDb.GetClaimants(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { claimantID } });
            claimant = recoDbGetClaimantsResult.FirstOrDefault();

            var recoDbGetTradesResult = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            trade = recoDbGetTradesResult.FirstOrDefault();


        }

        private async Task ReloadFiles()
        {
            var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", intClaimID);
            claimfiles = recoDbGetClaimFilesByUsersResult.OrderBy(cf => cf.Sticky).ThenByDescending(cf => cf.EntryDate);

            var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            activityLog = recoDbGetClaimActivityLogsResult;
        }

        protected async void ReloadOtherPartyList()
        {
            var recoDbGetClaimOtherPartiesResult = await RecoDb.GetClaimOtherParties(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getOtherPartyList = Mapper.Map<IQueryable<ClaimOtherParty>, IList<CppOtherPartyViewModel>>(recoDbGetClaimOtherPartiesResult);

            await ReloadExpertList();
        }

        protected async Task ReloadExpertList()
        {
            var recoDbGetClaimExpertsResult = await RecoDb.GetClaimExperts(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getExpertList = Mapper.Map<IQueryable<ClaimExpert>, IList<ExpertViewModel>>(recoDbGetClaimExpertsResult);
        }

        protected void SaveNoteRoles()
        {

            //Id  Name
            //1   Program Manager - Default
            //2   Claims Admin    - Default
            //3   Defense Counsel 
            //4   Coverage Counsel    
            //5   Claims Manager  - Default
            //6   Adjuster    - Default
            //7   System Admin    - Default
            //8   Auditor - Default
            //9    Accountant  

            note.NoteRoles = new List<NoteRole>();

            foreach (int i in selectedroles)
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = i });

            if (!selectedroles.Contains(7))
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = 7 }); //All notes are accessible to the System Admin
            if (!Security.IsInRole("System Admin") && !selectedroles.Contains(1))
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = 1 }); //Only System Admins can turn off Program Manager access
            if (Security.IsInRole("Claims Admin") && !selectedroles.Contains(2))
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = 2 }); //Claims Admin can see their own notes
            if (Security.IsInRole("Claims Manager") && !selectedroles.Contains(5))
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = 5 }); //Claims Managers can see their own notes
            if (Security.IsInRole("Adjuster") && !selectedroles.Contains(6))
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = 6 }); //Adjusters can see their own notes
            if (Security.IsInRole("Accountant") && !selectedroles.Contains(9))
                note.NoteRoles.Add(new NoteRole() { NoteId = note.NoteID, RoleId = 9 }); //Accountants can see their own notes
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!bFirstRender && activityLog != null && datagridActivityLog != null)
            {
                var claimOpened = false;
                if (claimpreference == null)
                    claimpreference = await GetPreferenceAsync();
                if (claimpreference != null && claimpreference.JsonPreference != null)
                {
                    try
                    {
                        var expandoConverter = new ExpandoObjectConverter();
                        IDictionary<String, Object> preferences = JsonConvert.DeserializeObject<ExpandoObject>(claimpreference.JsonPreference, expandoConverter);
                        ExpandedNotes = preferences["ExpandedNotes"].ToString().Split(',').ToList();
                        claimOpened = true;
                    }
                    catch (Exception ex)
                    {
                        ExpandedNotes = new List<string>();
                    }
                }
                foreach (ClaimActivityLog log in activityLog)
                {

                    if (!claimOpened && log.LogType != "Diary" && !log.Subject.StartsWith("Diary Sent")) //Do not expand Diary on open
                    {
                        ExpandedNotes.Add(log.ID.ToString());
                    }
                    if (ExpandedNotes.Contains(log.ID.ToString()))
                    {
                        await datagridActivityLog.ExpandRow(log);
                    }
                }


                bFirstRender = true;
                if (!claimOpened)
                {
                    SetPreference(false);
                }
                StateHasChanged();
            }

            base.OnAfterRender(firstRender);
        }
        protected void RowRender(RowRenderEventArgs<ClaimActivityLog> args)
        {
            if (args.Data.Confidential == true)
                args.Attributes.Add("style", $"background-color: #ffe6e6");
            else if (args.Data.LargeLoss == true)
                args.Attributes.Add("style", $"background-color: #ffffe6");
            else if (args.Data.NoteType == "Diary")
                if (args.Data.AbeyanceDate > DateTime.Today)
                    args.Attributes.Add("style", $"foreground-color: #e6fff2");

            args.Expandable = true;
        }

        protected void OccurrenceCellRender(DataGridCellRenderEventArgs<OccurrenceTotalIncurredByCategory> args)
        {
                args.Attributes.Add("style", $"background-color: #ffffe0");
        }

        protected void OccurrenceHeaderCellRender(DataGridCellRenderEventArgs<OccurrenceTotalIncurredByCategory> args)
        {
            args.Attributes.Add("style", $"display:none");
        }

        protected void CellRender(DataGridCellRenderEventArgs<ClaimActivityLog> args)
        {
            if (args.Data.Confidential == true)
                args.Attributes.Add("style", $"background-color: #ffe6e6");
            else if (args.Data.LargeLoss == true)
                args.Attributes.Add("style", $"background-color: #ffffe6");
            else if (args.Data.NoteType == "Diary")
                if (args.Data.AbeyanceDate > DateTime.Today)
                    args.Attributes.Add("style", $"foreground-color: #e6fff2");
        }

        protected void FileCellRender(CellRenderEventArgs<ClaimActivityLog> args)
        {
            if (args.Data.Confidential == true)
                args.Attributes.Add("style", $"background-color: #ffe6e6");
            else if (args.Data.LargeLoss == true)
                args.Attributes.Add("style", $"background-color: #ffffe6");
            else if (args.Data.NoteType == "Diary")
                if (args.Data.AbeyanceDate > DateTime.Today)
                    args.Attributes.Add("style", $"foreground-color: #e6fff2");
        }

        protected void GridFileCellRender(CellRenderEventArgs<ClaimFilesByUser> args)
        {
            if (args.Data.Confidential == true)
                args.Attributes.Add("style", $"background-color: #ffe6e6");
            else if (args.Data.LargeLoss == true)
                args.Attributes.Add("style", $"background-color: #ffffe6");
        }

        protected async void SaveNote()
        {
            //Remove Non HTML Carriage Returns
            if (!String.IsNullOrEmpty(note.Details))
                note.Details = note.Details.Replace("\n", " ").Replace("\r", " ");

            if (bNewNote)
            {
                note.ID = Guid.NewGuid();
                note.EnteredByID = Security.User.Name;
                note.ClaimID = claim.ClaimID;
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                note.EnteredByID = recoDbGetServiceProviderDetailsResult.First().Name;
            }

            try
            {
                if (bNewNote)
                {
                    var recoDbCreateNoteResult = await RecoDb.CreateNote(note);
                }
                else
                {
                    var recoDbCreateNoteResult = await RecoDb.UpdateNote(note.ID, note);
                }

                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Note has been saved" });

                note = new Note();
                
                var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });
                note.NoteTypeID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="Note Type" && p.ParamDesc=="Note")?.ParameterID ?? 0;
                bNewNote = true;

                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                bFirstRender = true;
                TemplateID = 0;
                activityLog = recoDbGetClaimActivityLogsResult;
            }
            catch (System.Exception recoDbCreateNoteException)
            {
                await SaveErrorAsync(recoDbCreateNoteException);
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new Note!" });
            }
        }

        protected async Task SaveErrorAsync(System.Exception exception)
        {
            try
            {
                var errorLog = new ErrorLog();
                errorLog.ClaimID = claim.ClaimID;
                errorLog.ErrorMessage = JsonConvert.SerializeObject(exception);
                errorLog.UserID = Security.User.Id;
                await RecoDb.CreateErrorLog(errorLog);
            }
            catch { }
        }


        protected async void LaunchActivityLogItem(RecoCms6.Models.RecoDb.ClaimActivityLog args)
        {
            if (args.LogType == "Note")
            {
                //var dialogResult = await DialogService.OpenAsync<AddNote>($"Edit Note", new Dictionary<string, object>() { { "NoteID", args.ID } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true, Draggable = true });
                //if (dialogResult != null)
                //{
                //    var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                //    activityLog = recoDbGetClaimActivityLogsResult;
                //}

                var recoDbGetNoteByIdResult = await RecoDb.GetNoteById(args.ID);
                note = recoDbGetNoteByIdResult;
                bNewNote = false;
                bCollapsedNote = false;
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = $"Edit Note", Detail = $"Scroll to top to edit selected note" });
            }

            if (args.LogType == "Diary")
            {
                var dialogResult0 = await DialogService.OpenAsync<AddEditDiary>("Edit Diary", new Dictionary<string, object>() { { "Start", null }, { "End", null }, { "ClaimID", claim.ClaimID }, { "DiaryID", args.ID } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true });
                if (dialogResult0 != null)
                {
                    var recoDbGetClaimActivityLogsResult0 = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                    activityLog = recoDbGetClaimActivityLogsResult0;
                }
            }

            if (args.LogType == "File")
            {
                var dialogResult01 = await DialogService.OpenAsync<EditFile>($"Edit File", new Dictionary<string, object>() { { "ID", args.ID } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true });
                if (dialogResult01 != null)
                {
                    var recoDbGetClaimActivityLogsResult01 = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                    activityLog = recoDbGetClaimActivityLogsResult01;
                }
            }
        }

        protected async void ResetNotesRoles()
        {
            //Reset Selected Roles to Default
            // "Program Manager" || "Claims Manager" || "Adjuster" || "Claims Admin" || "Auditor" || "System Admin"
            selectedroles = new int[] { 1, 2, 5, 6, 7, 8 };
        }

        public async Task<bool> SetFormByTemplateProperties()
        {
            if (TemplateID == 0)
                return true;
            var template = getNoteTemplateResults.FirstOrDefault(x => x.DiaryTemplateID == TemplateID);

            if (MacroService == null)
                MacroService = new MacroService(RecoDb);

            note.Subject = await MacroService.Replace(claim.ClaimID, template.Subject);
            note.Details = await MacroService.Replace(claim.ClaimID, template.TemplateText);

            return true;
        }

        protected async Task ShowFormErrors(FormInvalidSubmitEventArgs args)
        {
            foreach (var error in args.Errors)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"{error}");
            }
            ValidateReport();
        }

        public async Task OnInputFileChange(InputFileChangeEventArgs files)
        {
            newRecoMail.Files = files
                .GetMultipleFiles(files.FileCount)
                .Select(f=>f.ToIFileListEntry())
                .ToList();
        }

        async Task ShowBusyEmailDialog()
        {

            await InvokeAsync(async () =>
            {
                await Task.Delay(50);
                await SendEmail();
            });

            await BusyDialog("Sending ...");
        }

        public async Task SendEmail()
        {
            try
            {
                //showprogressbar = true;
                newRecoMail.Claimlist = claimList;


                await _MailService.SendMail(newRecoMail, Security.User, bAttachToClaim);

                if (bAttachToClaim)
                    await AttachEmail();

                DialogService.Close();

                NotificationService.Notify(NotificationSeverity.Success, "Email Has Been Sent", "");
                ClearEmailForm();

            }
            catch (ServiceException ex) when (ex.StatusCode == System.Net.HttpStatusCode.RequestEntityTooLarge)
            {
                DialogService.Close();
                NotificationService.Notify(NotificationSeverity.Error, "Attachment(s) are too large.", "");
                showprogressbar = false;
            }
            catch (Exception ex)
            {
                DialogService.Close();

                if (ex.Message.Contains("SendAsDenied"))
                    NotificationService.Notify(NotificationSeverity.Error, "System not allowed to send out email from your account.  Please contact admin", "");
                else
                {
                    string jsonMessage = JsonConvert.SerializeObject(ex);
                    await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
                    NotificationService.Notify(NotificationSeverity.Error, ex.Message, "");
                }
                    
                showprogressbar = false;
            }
        }

        public async Task AttachEmail()
        {
            try
            {
                var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });

                newRecoMail.From = Security.User.Email;
                //var emailHtml = await TemplateBuilder.Build(Templates.AttachMailToClaim, newRecoMail);
                var emailHtml = TemplateBuilder.BuildAttachMailToClaim(newRecoMail);
                var reportPdf = emailHtml.ToPDFByteArray();

                var file = this._RecoDbContext.Files.Add(new Models.RecoDb.File()
                {
                    ID = Guid.NewGuid(),
                    ClaimID = claim.ClaimID,
                    Extension = ".pdf",
                    Subject = $"{newRecoMail.Subject}",
                    Filename = $"Mail_As_Pdf_{claim.ClaimID}_{Guid.NewGuid()}.pdf",
                    EntryDate = DateTime.Now,
                    FileTypeID = recoDbGetParameterDetailsResult.FirstOrDefault(p=>p.ParamTypeDesc=="File Type" && p.ParamDesc=="Email")?.ParameterID ?? 0,
                    StoredDocument = reportPdf,
                    UploadedById = Security.User.Id,
                    ContentType = "application/pdf"
                });
                this._RecoDbContext.SaveChanges();
                await ReloadFiles();
            }
            catch (Exception ex){
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
            }

        }

        public void ConnectEmailAccount()
        {
            var returnUrl = HttpUtility.UrlEncode(UriHelper.ToBaseRelativePath(UriHelper.Uri));
            UriHelper.NavigateTo($"/MS?returnUrl={returnUrl}", true);
        }

        public void ToAddressessChanged()
            => this.newRecoMail.To = ToAddresses;

        public void CCAddressessChanged()
            => this.newRecoMail.CC = CCAddresses;

        public void BCCAddressessChanged()
            => this.newRecoMail.BCC = BCCAddresses;

        private IEnumerable<string> SplitAndTrim(string input)
        {
            if (input == String.Empty)
                return new List<string>();

            input = input.Replace(";", ",");
            return input.Split(",").Select(x => x.Trim()).ToList();
        }


        public async Task<bool> SetEmailByTemplateProperties()
        {
            if (TemplateID == 0)
                return true;

            var template = getEmailTemplateResults.FirstOrDefault(x => x.DiaryTemplateID == TemplateID);

            if (MacroService == null)
                MacroService = new MacroService(RecoDb);

            newRecoMail.Subject = await MacroService.Replace(claim.ClaimID, template.Subject);
            newRecoMail.Message = await MacroService.Replace(claim.ClaimID, template.TemplateText);

            return true;
        }

        public void ClearEmailForm()
        {
            newRecoMail = new RecoMail();
            
            fromMail = "";
            ClaimTitle = "";
            ToAddresses = new List<string>() { };

            if (getFileHandler != null && getFileHandler.EmailAddress != null)
            {
                CCAddresses = new List<string> { getFileHandler.EmailAddress };
                CCAddressessChanged();
            }
            else
                CCAddresses = new List<string> { };

            BCCAddresses = new List<string> { };
            Attachments = "";
            Notes = "";
            AttachmentContent = String.Empty;
            TemplateID = 0;

            showprogressbar = false;
            bAttachToClaim = false;
            isClaimEmailSubmit = false;
        }

        protected async void RemoveSelectedFile()
        {
            try
            {
                var getFile = newRecoMail.Files.Find(x => x.Name == selectedFile);
                if (getFile != null)
                    newRecoMail.Files.Remove(getFile);
            }
            catch { }

        }
        public void ToAddressesAdd(dynamic args)
        {
            List<string> addedEmails = new List<string>();

            foreach (string item in args)
                addedEmails.Add(item);
            if (ToAddresses != null)
                foreach (string item in ToAddresses)
                addedEmails.Add(item);

            ToAddresses = new List<string>(addedEmails);
            ToAddressChanged(ToAddresses);
        }
        public void CCAddressesAdd(dynamic args)
        {
            List<string> addedEmails = new List<string>();

            foreach (string item in args)
                addedEmails.Add(item);

            if (CCAddresses != null)
                foreach (string item in CCAddresses)
                addedEmails.Add(item);

            CCAddresses = new List<string>(addedEmails);
            CCAddressChanged(CCAddresses);
        }
        public void BccAddressesAdd(dynamic args)
        {
            List<string> addedEmails = new List<string>();

            foreach (string item in args)
                addedEmails.Add(item);
            if (BCCAddresses != null)
                foreach (string item in BCCAddresses)
                addedEmails.Add(item);

            BCCAddresses = new List<string>(addedEmails);
            BCCAddressChanged(BCCAddresses);
        }
        protected async System.Threading.Tasks.Task DownloadFileAsync(Models.RecoDb.ClaimFilesByUser file)
        {
            string[] docExtensions = { ".pdf", ".xls", ".xlsx", ".doc", ".docx" };
            string[] imageExtensions = { ".png", ".jpeg", ".jpg", ".gif" };
            string[] avExtensions = { ".avi", ".mov", ".mp4", ".mp3", ".m4a", ".wav" };

            try
            {
                    UriHelper.NavigateTo($"/downloadfullfile/FileID={file.FileID}", true);
            }
            catch { }
        }

        protected bool IsDocument(string extension = null)
        {
            if (String.IsNullOrEmpty(extension))
                return false;
            else
                return docExtensions.Contains(extension.ToLower());
        }

        protected bool IsImage(string extension = null)
        {
            if (String.IsNullOrEmpty(extension))
                return false;
            else
                return imageExtensions.Contains(extension.ToLower());
        }
        protected void NoteDetailsChanged(string args)
        {
            note.Details = args;
        }
        private void DialogOpen()
        {
            this.RteObj.DialogOpen();
        }

        protected async Task<ServiceProviderClaimPreference> GetPreferenceAsync()
        {
            try
            {
                var recoDbGetServiceProviderClaimPreferencesResult = await RecoDb.GetServiceProviderClaimPreferences(new Query() { Filter = $@"i => i.ServiceProviderID == @0 && i.ClaimID == @1", FilterParameters = new object[] { serviceprovider.ServiceProviderID, claim.ClaimID } });
                claimpreference = recoDbGetServiceProviderClaimPreferencesResult.FirstOrDefault();
                if (claimpreference != null)
                {
                    return claimpreference;
                }
                return new ServiceProviderClaimPreference();
            }
            catch
            {
                return new ServiceProviderClaimPreference();
            }

        }

        protected async Task<ServiceProvider> GetCurrentServiceProvider()
        {
            var recoDbGetUsersResult = await RecoDb.GetUserDetails(new Query { Filter = $@"i=> i.UserName == @0", FilterParameters = new object[] { Security.Principal.Identity.Name } });
            var userdetail = recoDbGetUsersResult.FirstOrDefault();

            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { userdetail.Id } });
            serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();

            return serviceprovider;
        }

        protected async void SetPreference(bool isPageLoad)
        {
            //if (!bFirstRender)
            //    return;
            try
            {
                if (serviceprovider == null || serviceprovider?.ServiceProviderID == 0)
                    await GetCurrentServiceProvider();

                var recoDbGetServiceProviderClaimPreferencesResult = await RecoDb.GetServiceProviderClaimPreferences(new Query() { Filter = $@"i => i.ServiceProviderID == @0 && i.ClaimID == @1", FilterParameters = new object[] { serviceprovider.ServiceProviderID, claim.ClaimID } });
                claimpreference = recoDbGetServiceProviderClaimPreferencesResult.FirstOrDefault();
                if (claimpreference == null)
                {
                    claimpreference = new RecoCms6.Models.RecoDb.ServiceProviderClaimPreference();
                    claimpreference.ClaimID = claim.ClaimID;
                    claimpreference.ServiceProviderID = serviceprovider.ServiceProviderID;
                    claimpreference.DateLastAccessed = DateTime.Now;
                    if (!isPageLoad)
                    {
                        claimpreference.JsonPreference = GetJsonPreference();
                        if (claimpreference.JsonPreference == "{\"ExpandedNotes\":\"\"}")
                            claimpreference.JsonPreference = null;
                    }
                        
                    await RecoDb.CreateServiceProviderClaimPreference(claimpreference);
                }
                else
                {
                    claimpreference.DateLastAccessed = DateTime.Now;
                    if (!isPageLoad)
                    {
                        claimpreference.JsonPreference = GetJsonPreference();
                        if (claimpreference.JsonPreference == "{\"ExpandedNotes\":\"\"}")
                            claimpreference.JsonPreference = null;
                    }
                    await RecoDb.UpdateServiceProviderClaimPreference(serviceprovider.ServiceProviderID, claim.ClaimID, claimpreference);
                }
                recoDbGetServiceProviderClaimPreferencesResult = await RecoDb.GetServiceProviderClaimPreferences(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { serviceprovider.ServiceProviderID }, OrderBy = $"DateLastAccessed desc", Top = 10 });
                Globals.ServiceProviderClaims = recoDbGetServiceProviderClaimPreferencesResult;
            }
            catch { }

        }

        protected void SetBrokerageDetails()
        {
            occurrence.BrokerageName = selectedbrokerage.Name;

            occurrence.BrokerageStreet1 = selectedbrokerage.Street1;

            occurrence.BrokerageStreet2 = selectedbrokerage.Street2;

            occurrence.BrokerageUnitNumber = selectedbrokerage.UnitNumber;

            occurrence.BrokerageProvinceID = selectedbrokerage.ProvinceID;

            occurrence.BrokerageCity = selectedbrokerage.City;

            occurrence.BrokeragePostalCode = selectedbrokerage.PostalCode;

            occurrence.BrokerageEmailAddress = selectedbrokerage.EmailAddress;

            occurrence.BrokerageContactPerson = selectedbrokerage.ContactPerson;

            occurrence.BrokerageContactEmail = selectedbrokerage.ContactPersonEmail;

            occurrence.BrokerageContactPhone = selectedbrokerage.ContactPersonPhoneNum;
        }
        protected string GetJsonPreference()
        {
            dynamic preferences = new ExpandoObject();
            if (ExpandedNotes == null)
                ExpandedNotes = new List<string>();

            preferences.ExpandedNotes = string.Join(',', ExpandedNotes);
            return JsonConvert.SerializeObject(preferences);
        }
        
        private bool _occurrenceDetailsTabLoaded = false;
        private async Task LoadOccurrenceDetailsTabData()
        {
            if (_occurrenceDetailsTabLoaded)
            {
                return;
            }

            _occurrenceDetailsTabLoaded = true;
            
            var recoDbGetOccurrencesResult = await RecoDb.GetOccurrences(new Query() { Filter = $@"i => i.OccurrenceID == @0", FilterParameters = new object[] { claim.OccurrenceID } });
            occurrence = recoDbGetOccurrencesResult.FirstOrDefault() ?? new Occurrence();
            
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });
            getOccurenceReasonList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="OccurrenceReason");

            if (getBrokeragesResult?.IsNullOrEmpty() ?? true)
            {
                getBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            }

            getReceiversList = await RecoDb.GetReceivers(new Query() { OrderBy = $"Name asc" });
            
            var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { OrderBy = $"Name asc" });
            getDefenseCounselList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FirmType=="Defense Counsel");
            
            getFileHandlerList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FileHandler==true);

            getReportsToList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.ServiceProviderRole=="Program Manager" || sp.ServiceProviderRole=="Adjuster" || sp.ServiceProviderRole=="Claims Manager");

            getAdjustersList = recoDbGetServiceProviderDetailsResult.Where(sp=>sp.FirmType=="Adjusters");

            getOccurrenceStatusList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Occurrence Status");
        }

        private bool _claimantsTabLoaded = false;
        private async Task LoadClaimantsTabData()
        {
            if (_claimantsTabLoaded)
            {
                return;
            }
            _claimantsTabLoaded = true;
            
            var recoDbGetClaimantsResult = await RecoDb.GetClaimants(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { claimantID } });
            claimant = recoDbGetClaimantsResult.FirstOrDefault() ?? new();

            if (!claim.MasterFile)
            {
                var recoDbGetOccurrenceClaimantsResult = await RecoDb.GetOccurrenceClaimants(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { claimantID }, OrderBy = $"Name asc" });
                claimantlist = recoDbGetOccurrenceClaimantsResult;

                var recoDbGetOccurrenceClaimTradesResult = await RecoDb.GetOccurrenceClaimTrades(new Query() { Filter = $@"i => i.ClaimantID == @0", FilterParameters = new object[] { claimantID }, OrderBy = $"Address1 asc" });
                tradelist = recoDbGetOccurrenceClaimTradesResult;
            }
            else
            {
                var recoDbGetOccurrenceClaimantsResult0 = await RecoDb.GetOccurrenceClaimants(new Query() { Filter = $@"i => i.MasterFileID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"Name asc" });
                claimantlist = recoDbGetOccurrenceClaimantsResult0;
            }
            
            claimantpagesize = claim.MasterFile ? 25 : 5;
            
            getRegistrantsResult = await RecoDb.GetRegistrants(new Query() { OrderBy = $"Name asc" });
            
            Roles = claimant.ClaimantID > 0 ? (await RecoDb.GetClaimantLitigationRoles())
                .Where(x => x.ClaimantID == claimant.ClaimantID)
                .Select(x => x.LitigationRole)
                .ToArray()
                : new int[] {};
            
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });
            
            if(getProvinceList?.IsNullOrEmpty() ?? true)
            {
                getProvinceList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Province");
            }

            if (isCDProgram) {
                getClaimantTransactionRolesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claimant Transaction Role" && p.ParentParameterDesc=="Consumer Deposit Program" );
            }
            if (isCPProgram) {
                getClaimantTransactionRolesList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claimant Transaction Role" && p.ParentParameterDesc=="Commission Protection Program" );
            }

            if (getBrokeragesResult?.IsNullOrEmpty() ?? true)
            {
                getBrokeragesResult = await RecoDb.GetBrokerages(new Query() { OrderBy = $"Name asc" });
            }
            
            getClaimantSolicitorsResult = await RecoDb.GetClaimantSolicitors();

            var recoDbGetClaimOtherPartiesResult = await RecoDb.GetClaimOtherParties(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getOtherPartyList = Mapper.Map<IQueryable<ClaimOtherParty>, IList<CppOtherPartyViewModel>>(recoDbGetClaimOtherPartiesResult);
        }
        
        private bool _claimDetailsTabLoaded = false;
        private async Task LoadClaimDetailsTabData()
        {
            if (_claimDetailsTabLoaded)
            {
                return;
            }
            _claimDetailsTabLoaded = true;
            
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });
            getClaimStatusList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Claim Status");

            getRORList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Reservation of Rights");

            getBrokerageOnlyList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="BrokerageOnly");
            
            if(getProvinceList?.IsNullOrEmpty() ?? true)
            {
                getProvinceList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Province");
            }

            getCountryList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Country").OrderBy(p => p.ParamDesc);

            getYesNoNAList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="YesNoNA");

            getTradeTypeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Trade Type");

            getPaymentsOwedList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="PaymentsOwedBy");

            if (!isEOProgram)
            {
                getAssocCDClaimsResult  = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { tradeBuyerCDFile, tradeSellerCDFile, tradeSharedAgentClaim } });

                getSharedAgent = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { tradeSharedAgent } });
            }
            
            getBuildersResult = await RecoDb.GetBuilders(new Query() { OrderBy = $"Name asc" });
            
            getCommissionInstallmentsList = await RecoDb.GetCommissionInstallments(new Query() { Filter = $@"i => i.TradeID == @0", FilterParameters = new object[] { trade.TradeID }, OrderBy = $"DatePaid desc" });
        }

        private bool _expertsTabLoaded = false;
        private async Task LoadExpertsTabData()
        {
            if (_expertsTabLoaded)
            {
                return;
            }
            _expertsTabLoaded = true;

            await ReloadExpertList();
        }

        private bool _reservesPaymentsTabLoaded = false;
        private async Task LoadReservesPaymentsTabData()
        {
            if (_reservesPaymentsTabLoaded)
            {
                return;
            }
            _reservesPaymentsTabLoaded = true;
            
            transactions = Globals.generalsettings.ApplicationName switch
            {
                "REIX CMS" => await RecoDb.GetClaimIndividualTransactions(new Query()
                {
                    Filter = $@"i => i.ClaimID == @0",
                    FilterParameters = new object[] { intClaimID },
                    OrderBy = $"TransactionDate desc,TransactionID desc"
                }),
                "RECO CMS" => await RecoDb.GetClaimIndividualTransactions(new Query()
                {
                    Filter = $@"i => i.ClaimID == @0",
                    FilterParameters = new object[] { claim.ClaimID },
                    OrderBy = $"TransactionDate desc"
                }),
                _ => transactions
            };
        }
        
        private bool _notesTabLoaded = false;
        private async Task LoadNotesTabData()
        {
            if (_notesTabLoaded)
            {
                return;
            }
            _notesTabLoaded = true;

            var recoDbGetTemplateDetailsResult = await RecoDb.GetTemplateDetails(new Query() { OrderBy = $"Title asc" });
            getNoteTemplateResults = recoDbGetTemplateDetailsResult.Where(td=>td.TemplateType=="<All>"||td.TemplateType=="Note");
            
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamValue asc,ParamDesc asc" });
            getNoteTypeList = recoDbGetParameterDetailsResult.Where(p=>p.ParamTypeDesc=="Note Type");

            activityLog = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}");
        }
        
        private bool _attachmentsTabLoaded = false;
        private async Task LoadAttachmentsTabData()
        {
            if (_attachmentsTabLoaded)
            {
                return;
            }
            _attachmentsTabLoaded = true;
            
        }
        
        private bool _diariesTabLoaded = false;
        private async Task LoadDiariesTabData()
        {
            if (_diariesTabLoaded)
            {
                return;
            }
            _diariesTabLoaded = true;
            
            diaries = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
        }
        
        private bool _reportsTabLoaded = false;
        private async Task LoadReportsTabData()
        {
            if (_reportsTabLoaded)
            {
                return;
            }
            _reportsTabLoaded = true;
            
            report = await getClaimReport(claim.ClaimID);
            
            parameterFlags = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0", FilterParameters = new object[] { "Claim Report Flag" } });

            var defenseCounselsResult = await RecoDb.GetServiceProviders(new Query()
            {
                Filter = "i => @0.Contains(i.ServiceProviderID)",
                FilterParameters = [serviceprovider.AsLegalAssistant
                .Select(la => la.DefenseCounselID)
                .Distinct()
                .ToList()]
            });
            defenseCounsels = [.. defenseCounselsResult];

            claimreports = await RecoDb.GetClaimReportDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"ClaimReportID desc" });
            previousClaimReports = claimreports.Where(cr=>cr.DateSubmitted != null && cr.HandlingFirmID==serviceprovider.FirmID).ToList();
            previousFacts = previousClaimReports.Where(cr=>!string.IsNullOrEmpty(cr.Facts));
            previousCoverage = previousClaimReports.Where(cr=>!string.IsNullOrEmpty(cr.Coverage));
            previousDamages = previousClaimReports.Where(cr=>!string.IsNullOrEmpty(cr.Damages));
            previousActionPlans = previousClaimReports.Where(cr=>!string.IsNullOrEmpty(cr.ActionPlan));
            previousRecommendations = previousClaimReports.Where(cr=>!string.IsNullOrEmpty(cr.Recommendations));
        }
        
        private bool _emailTabLoaded = false;
        private async Task LoadEmailTabData()
        {
            if (_emailTabLoaded)
            {
                return;
            }
            _emailTabLoaded = true;
            
            var recoDbGetTemplateDetailsResult = await RecoDb.GetTemplateDetails(new Query() { OrderBy = $"Title asc" });
            getEmailTemplateResults = recoDbGetTemplateDetailsResult.Where(td=>td.TemplateType=="<All>"||td.TemplateType=="Diary/Email"||td.TemplateType=="Email");
        }
    }
}
