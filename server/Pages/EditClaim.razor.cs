using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using AutoMapper;
using RecoCms6.Services;
using RecoCms6.Shared;
using RecoCms6.Models;
using RecoCms6.Models.RecoDb;
using System.Dynamic;
using Newtonsoft.Json;
using RecoCms6.Data;
using Microsoft.AspNetCore.Components.Authorization;
using RecoCms6.Services.TemplateEngine;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using Microsoft.Graph;
using Agno.BlazorInputFile;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json.Converters;
using System.Web;
using RecoCms6.Extensions;
using Microsoft.JSInterop;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace RecoCms6.Pages
{
    public partial class EditClaimComponent
    {
        [Inject]
        protected IMapper Mapper { get; set; }
        
        [Inject]
        public MacroService MacroService { get; set; }

        [Inject]
        protected MailService mailService { get; set; }

        protected CppClaimantGrid<CppClaimantViewModel, Claimant, AddClaimantComponent> gridClaimant;
        protected CppClaimantGrid<EOClaimantViewModel, Claimant, AddClaimantComponent> gridEOClaimant;
        protected CppClaimantGrid<CppInsuredViewModel, Insured, AddInsuredComponent> gridInsured;
        protected RadzenCheckBoxList<Role> chkBoxRoles;
        protected IList<CppClaimantViewModel> getClaimantList;
        protected IList<EOClaimantViewModel> getEOClaimantList;
        protected IList<CppInsuredViewModel> getInsuredList;
        protected IList<CppBrokerageViewModel> getBrokerageList;
        protected RichTextEditor RteObj;
        protected RichTextEditor rteCoverage;
        protected RichTextEditor rteFacts;
        protected RichTextEditor rteExecutiveSummary;
        protected RichTextEditor rteLiability;
        protected RichTextEditor rteDamages;
        protected RichTextEditor rteActionPlan;
        protected RichTextEditor rteRecommendations;
        IEnumerable<ClaimInsured> _getInsureds;
        IEnumerable<ClaimOtherParty> _getOtherPartyList;

        protected IEnumerable<ClaimInsured> getInsureds
        {
            get
            {
                return _getInsureds;
            }
            set
            {
                if (!object.Equals(_getInsureds, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getInsureds", NewValue = value, OldValue = _getInsureds };
                    _getInsureds = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected IEnumerable<ClaimOtherParty> getOtherPartyList
        {
            get
            {
                return _getOtherPartyList;
            }
            set
            {
                if (!object.Equals(_getOtherPartyList, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getOtherPartyList", NewValue = value, OldValue = _getOtherPartyList };
                    _getOtherPartyList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<ClaimClaimant> _getClaimants;
        protected string selectedFile;

        protected IEnumerable<ClaimClaimant> getClaimants
        {
            get
            {
                return _getClaimants;
            }
            set
            {
                if (!object.Equals(_getClaimants, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getClaimants", NewValue = value, OldValue = _getClaimants };
                    _getClaimants = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoMail _newRecoMail;
        protected RecoMail newRecoMail
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

        public void newRecoMailMessageChanged(string args)
        {
            newRecoMail.Message = args;
        }
        public bool isToEmailsValid { get { return ValidateEmails(ToAddresses); } }
        public bool isToEmailsFilled { get { return ToAddresses != null && ToAddresses.Count > 0; } }
        public bool isCcEmailsValid { get { return ValidateEmails(CCAddresses); } }
        public bool isBccEmailsValid { get { return ValidateEmails(BCCAddresses); } }
        public bool isAllEmailsValid { get { return isToEmailsValid && isBccEmailsValid && isCcEmailsValid; } }

        protected bool createNoteCollasped = true;

        
        bool ValidateEmails(List<string>emails)
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
            BCCAddressesChanged();
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
            [Inject]
        protected RecoDbContext _RecoDbContext { get; set; }

        [Inject]
        protected MacroService _MacroService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }
        public string FileSummary { get; private set; }

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

            var reports = await RecoDb.GetClaimReports(new Radzen.Query() { Filter = $@"i => i.ClaimID == {ClaimID} && i.HandlingFirmID == {serviceprovider.FirmID}" });

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

            //create new subsequent report => each report is submitted so we need to create a new copy of the last one and unmark it as initial report
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
            var openProcessingTabSemaphoreSlim = new SemaphoreSlim(1);
            var savingIsDone = false;
            
            InvokeAsync(async () =>
            {
                await Task.Delay(50);
                try
                {
                    saveResult = await SaveReport();
                    savingIsDone = true;
                }
                catch (Exception ex)
                {
                    Log.Error("Error occured while saving report. details: {0}", ex);
                }
                await openProcessingTabSemaphoreSlim.WaitAsync();
                // Close the dialog
                DialogService.Close();
                openProcessingTabSemaphoreSlim.Release();
            });

            if(!savingIsDone)
            {
                await openProcessingTabSemaphoreSlim.WaitAsync();
                var waitingProcessingTask = BusyDialog(IsSubmitEvent ? "Submitting ..." : "Saving ...");
                openProcessingTabSemaphoreSlim.Release();
                await waitingProcessingTask;
            }

            if (saveResult && !IsSubmitEvent)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Report is saved" });
            }

            if (saveResult && IsSubmitEvent)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Report Has been Submitted" });
                report = await getClaimReport(claim.ClaimID);
            }
            
            var recoDbGetClaimReportDetailsResult =  (await RecoDb.GetClaimReportDetails(new Query()
            {
                Filter = $@"i => i.ClaimID == @0",FilterParameters = new object[] { claim.ClaimID },
                OrderBy = $"ClaimReportID desc"
            })).ToList();
            claimreports = recoDbGetClaimReportDetailsResult;
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

            report.DateLastModified = DateTime.Now;
            if (IsSubmitEvent)
            {
                //if (!ValidateReport())
                //    return false;

                report.DateSubmitted = DateTime.Now;
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                report.SubmittedBy = recoDbGetServiceProviderDetailsResult.FirstOrDefault()?.Name;
            }

            if (claim.CounselFileNo != String.Empty)
                await RecoDb.UpdateCounselClaimNums(claim.ClaimID, $"{claim.CounselFileNo}");

            //fresh report
            if (report.ClaimReportID == 0)
            {
                report.DateCreated = DateTime.Now;
                report.ClaimID = claim.ClaimID;
                await this.RecoDb.CreateClaimReport(report);
                if (!IsSubmitEvent)
                    return true;
            }

            //update
            await this.RecoDb.UpdateClaimReport(report.ClaimReportID, report);

            if (IsSubmitEvent)
                await handleReport(report.ClaimReportID);

            return true;
        }


        private async Task handleReport(int claimreportid)
        {
            var reportDetail = this._RecoDbContext.ClaimReportDetails.FirstOrDefault(rpd => rpd.ClaimReportID == claimreportid);

            var reportHtml = TemplateBuilder.BuildClaimReport(reportDetail);
            var reportPdf = Utility.PdfConverter.ToPDFByteArray(reportHtml);

            //Save PDF
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
                ContentType = "application/pdf",
                FileTypeID = recoDbGetParameterDetailsResult.FirstOrDefault(p => p.ParamTypeDesc == "File Type" && p.ParamDesc == "Claim Report")?.ParameterID,
            });
            this._RecoDbContext.SaveChanges();

            //Save the file id with the claim report
            report.FileId = file.Entity.FileID;
            await this.RecoDb.UpdateClaimReport(report.ClaimReportID, report);

            claimreports = (await RecoDb.GetClaimReportDetails(new Radzen.Query()
            { Filter = $@"i => i.ClaimID == {claim.ClaimID}" })).ToList();

            try
            {
                //Send Email
                if (getFileHandler != null)
                    await mailService.SendReportMail(reportDetail, Security.User, reportHtml);

                //Create Diary for Defense Counsel
                if (Security.IsInRole("DefenseCounsel"))
                {
                    var template = this._RecoDbContext.DiaryTemplates.FirstOrDefault(x => x.Title == "Update Request");
                    var days = reportDetail.ReportingDays ?? 90; //Default to 90 Days if Reporting Days is null
                    var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query()
                        { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                    string enteredBy = recoDbGetServiceProviderDetailsResult.FirstOrDefault()?.Name;

                    this._RecoDbContext.Diaries.Add(new Models.RecoDb.Diary()
                    {
                        ClaimID = reportDetail.ClaimID,
                        Subject = await _MacroService.Replace(reportDetail.ClaimID, template.Subject),
                        Details = await _MacroService.Replace(reportDetail.ClaimID, template.TemplateText),
                        AbeyanceDate = DateTime.Now.AddDays(days),
                        EntryDate = DateTime.Now,
                        EnteredBy = enteredBy,
                        DiaryStatusID = 145, // Open Status
                        Recipients = reportDetail.DefenseCounselEmailAddress
                    });
                    await this._RecoDbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Log.Error("Error occured while trying to send Submit report email. details: {0}", ex);
            }
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

        protected async Task ShowFormErrors(FormInvalidSubmitEventArgs args)
        {
            foreach (var error in args.Errors)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"{error}");
            }
            //ValidateReport();
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

        protected async void ReloadTradeList()
        {
            var recoDbGetTradeDetailsResult = await RecoDb.GetTradeDetails(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getTradesList =  recoDbGetTradeDetailsResult.ToList();
        }

        protected async void ReloadOtherPartyList()
        {
            getOtherPartyList = await RecoDb.GetClaimOtherParties(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
        }

        protected async Task ReloadExpertList()
        {
            var recoDbGetClaimExpertsResult = await RecoDb.GetClaimExperts(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"DisplayOrder asc" });
            getExpertList =  recoDbGetClaimExpertsResult.ToList();
        }

        protected async void ReloadClaimantList()
        {
            var recoDbGetClaimClaimantsResult = await RecoDb.GetClaimClaimants(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"ClaimantOrder asc" });
            getClaimants = recoDbGetClaimClaimantsResult;

            //if (!isEOProgram)
            //    getClaimantList = Mapper.Map<IQueryable<ClaimClaimant>, IList<CppClaimantViewModel>>(recoDbGetClaimClaimantsResult);
            //else
            //    getEOClaimantList = Mapper.Map<IQueryable<ClaimClaimant>, IList<EOClaimantViewModel>>(recoDbGetClaimClaimantsResult);

        }

        protected async void ReloadInsuredList()
        {
            try
            {
                var recoDbGetClaimInsuredsResult = await RecoDb.GetClaimInsureds(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"DisplayOrder asc" });
                getInsureds = recoDbGetClaimInsuredsResult;

                //if (Globals.generalsettings.ApplicationName == "RECO CMS")
                //{
                //    getInsuredList = Mapper.Map<IQueryable<ClaimInsured>, IList<CppInsuredViewModel>>(recoDbGetClaimInsuredsResult);
                //    getBrokerageList = Mapper.Map<IQueryable<ClaimInsured>, IList<CppBrokerageViewModel>>(recoDbGetClaimInsuredsResult);

                //}

            }
            catch { }

            try
            {
                var recoDbGetClaimSummariesResult = await RecoDb.GetClaimSummaries(claim.ClaimID);
                claimsummary = (MarkupString)recoDbGetClaimSummariesResult.FirstOrDefault().ClaimSummary1;
            }
            catch { }
        }

        private void DialogOpen()
        {
            this.RteObj.DialogOpen();
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

        public async void LoadFileSummary()
        {
            try
            {
                var summary = await RecoDb.GetClaimFileSummaries(claim.ClaimID, Security.User.Id);
                FileSummary = summary.Single().Details;
            }
            catch
            {
                return;
            }
        }

        protected void RowRender(RowRenderEventArgs<ClaimActivityLog> args)
        {
            if (args.Data.Confidential == true) 
                args.Attributes.Add("style", $"background-color: #ffe6e6"); //Pink
            else if (args.Data.LargeLoss == true)
                args.Attributes.Add("style", $"background-color: #ffffe6"); //Yellow
            else if (args.Data.NoteType == "Diary")
                if (args.Data.AbeyanceDate > DateTime.Today)
                    args.Attributes.Add("style", $"foreground-color: #e6fff2");

            args.Expandable = true;
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

        protected void FileCellRender(DataGridCellRenderEventArgs<ClaimActivityLog> args)
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

        protected async void SendSurveyEmail()
        {
            //Only Send DemandLetter, SmallClaim, SuperiorCourt Files
            var getDemandLetterId = recoDbGetParameterDetailsResult.First(p => p.ParamTypeDesc == "Claim Initiation" && p.ParamDesc == "Demand Letter").ParameterID;
            var getSmallClaimID = recoDbGetParameterDetailsResult.First(p => p.ParamTypeDesc == "Claim Initiation" && p.ParamDesc == "Small Claim").ParameterID;
            var getSuperiorCourtID = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Claim Initiation" && p.ParamDesc == "Superior Court").First().ParameterID;

            if (!(eoclaimdetails.ClaimInitiationID == getDemandLetterId || eoclaimdetails.ClaimInitiationID == getSmallClaimID || eoclaimdetails.ClaimInitiationID == getSuperiorCourtID))
                return;

            if (!claim.SurveyOnClose)
                return;

            return;

            // string message = "Your claim has now been closed, and we'd like to hear from you regarding you claim experience through a short survey.<br/><br/>";
            // message += "Address of Trade: <br/>";
            // message += trade.Address1 + "<br/>" + trade.City + "<br/>" + trade.PostalCode + "<br/><br/>";
            // message += "The information will be used to: <br/>";
            // message += "<ul><li>Improve the claim experience</li>";
            // message += "<ul><li>Develop loss prevention materials</li>";
            // message += "<ul><li>Provide feedback on the insurance program to RECO</li></ul><br/>";
            // message += "This information may be shared on a no-name basis with the insurer, service providers and RECO. <br/><br/>";
            // message += "We thank you in advance for taking the time to share your thoughts<br/>";
            // message += "<a href='https://www.surveymonkey.com/s/GB7QDF9?c=" + claim.ClaimID + "_[partylink]'>Click Survey Link Here</a><br/><br/><br/><hr>";
            // message += "This email was sent to you on behalf of the RECO Insurance Program <br/><br/>";
            // message += "Underwritten by certain Lloyd's Underwriters<br />";
            // message += "Endorsed by the Real Estate Council of Ontario<br />";
            // message += "Managed and distributed by 3303128 Canada Inc. trading as Alternative Risk Services <br />";
            // message += "Berkeley Castle <br/>";
            // message += "250 The Esplanade Suite 302<br/>";
            // message += "Toronto, ON M5A 1J2 <br/><br/>";
            // message += "1-866-426-1666 <br/>";
            // message += "info@ar-services.ca";

            // if (claim.BrokerageOnly != getBrokerageOnlyID)
            //     foreach (ClaimInsured aninsured in getInsureds)
            //     {
            //         var email = new MimeKit.MimeMessage
            //         {
            //             Subject = Globals.generalsettings.ApplicationName + " Claim Survey" + claim.ClaimNo
            //         };

            //         var builder = new BodyBuilder();

            //         // Set the plain-text version of the message text
            //         builder.HtmlBody = message.Replace("[partylink]", "R" + aninsured.InsuredID);

            //         // Now we just need to set the message body and we're done
            //         email.Body = builder.ToMessageBody();
            //         email.From.Add(new MailboxAddress(Globals.generalsettings.SystemEmail));
            //         email.To.Add(new MailboxAddress(aninsured.EmailAddress));

            //         await mailService.SendMail(email);
            //     }

            // ClaimInsured firstinsured = getInsureds.FirstOrDefault();
            // if (claim.BrokerageOnly != getRegistrantOnlyID && firstinsured.BrokerageEmail != null)  //Send to Brokerage
            // {

            //     var email = new MimeKit.MimeMessage
            //     {
            //         Subject = Globals.generalsettings.ApplicationName + " Claim Survey" + claim.ClaimNo
            //     };

            //     var builder = new BodyBuilder();

            //     // Set the plain-text version of the message text
            //     builder.HtmlBody = message.Replace("[partylink]", "B0");

            //     // Now we just need to set the message body and we're done
            //     email.Body = builder.ToMessageBody();
            //     email.From.Add(new MailboxAddress(Globals.generalsettings.SystemEmail));
            //     email.To.Add(new MailboxAddress(firstinsured.BrokerageEmail));

            //     try
            //     {
            //         await mailService.SendMail(email);
            //     }
            //     catch (Exception ex)
            //     {
            //         await SaveErrorAsync(ex);
            //         NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Claim Saved, Unable to Send Survey Email" });
            //     }

            // }

        }
        protected async void UpdateClaimStatusHistory()
        {
            var recoDbGetClaimStatusHistoriesResult = await RecoDb.GetClaimStatusHistories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"StatusChangeDate desc", Top = 1 });
            if (recoDbGetClaimStatusHistoriesResult.FirstOrDefault() != null) {
                previousclaimstatus = recoDbGetClaimStatusHistoriesResult.FirstOrDefault().ClaimStatusID;
            }

            if (recoDbGetClaimStatusHistoriesResult.FirstOrDefault() == null) {
                previousclaimstatus = -1;
            }

            if (previousclaimstatus != claim.ClaimStatusID)
            {
                claimstatushistory = new RecoCms6.Models.RecoDb.ClaimStatusHistory();
                claimstatushistory.ClaimID = claim.ClaimID;
                claimstatushistory.NewStatusID = claim.ClaimStatusID;
                claimstatushistory.ChangedBy = printFirstInitialLastName(serviceprovider?.Name);
                var recoDbCreateClaimStatusHistoryResult = await RecoDb.CreateClaimStatusHistory(claimstatushistory);

            }
        }

        static string printFirstInitialLastName(String name)
        {
            if (name.Length == 0)
                return String.Empty;

            string shortname = String.Empty;

            // Since touuper() returns int,
            // we do typecasting
            shortname = Char.ToUpper(name[0]).ToString();
            // Traverse rest of the string and
            // print the characters after spaces.
            for (int i = 1; i < name.Length - 1; i++)
                if (name[i] != ' ')
                    shortname += Char.ToUpper(name[i + 1]).ToString();

            return shortname.Replace("'", "");
        }

        protected async void loadFileReports()
        {
            List<int> fileReportIds = new List<int>();

            var recoDbGetClaimFileReportsResult = await RecoDb.GetClaimFileReportings(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });

            foreach (ClaimFileReporting fileReport in recoDbGetClaimFileReportsResult)
                fileReportIds.Add(fileReport.ServiceProviderID);

            selectedFileReportIds = fileReportIds;
        }

        protected async Task saveFileReports()
        {
            List<int> newFileReportIds = new List<int>();

            foreach (int i in selectedFileReportIds)
                newFileReportIds.Add(i);

            foreach (ClaimFileReporting cfr in claim.ClaimFileReportings)
                if (!selectedFileReportIds.Contains(cfr.ServiceProviderID))
                    await RecoDb.DeleteClaimFileReporting(cfr.FileReportID);
                else
                    newFileReportIds.Remove(cfr.ServiceProviderID);

            foreach (int i in newFileReportIds)
            {
                
                ClaimFileReporting cfr = new ClaimFileReporting();
                cfr.ClaimID = claim.ClaimID;
                cfr.ServiceProviderID = i;
                await RecoDb.CreateClaimFileReporting(cfr);
            }

            //claim.ClaimFileReportings = selectedFileReportIds.Select(r => new ClaimFileReporting() { ClaimID = claim.ClaimID, ServiceProviderID = r }).ToList();
        }

        protected bool Validate()
        {
            isValid = true;

            if (claim.ClaimNo == string.Empty)
            {
                claimNumRequired = true;
                isValid = false;
            }
            else
                claimNumRequired = false;

            if (claim.ContractYearID == 0)
            {
                contractYearRequired = true;
                isValid = false;
            }
            else
                contractYearRequired = false;

            if (claim.ClaimStatusID == 0)
            {
                statusRequired = true;
                isValid = false;
            }
            else
                statusRequired = false;

            if (claim.AdjusterClaimNo != null)
            {
                Regex regex = new Regex(@"(^33410-)?\d\d\d\d\d\d");
                Match match = regex.Match(claim.AdjusterClaimNo);
                if (claim.AdjusterClaimNo != string.Empty && !match.Success)
                {
                    invalidAdjusterNum = true;
                    isValid = false;
                }
                else
                    invalidAdjusterNum = false;
            }
            else
                invalidAdjusterNum = false;


            return isValid;
        }
        protected async System.Threading.Tasks.Task CloseClaim()
        {
            
            var recoDbGetClaimTotalIncurredByCategoriesResult = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { OrderBy = $"ParamDesc asc" });
            var indemnityreserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().IndemnityReserve;

            var legalreserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().LegalReserve;

            var adjustingreserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().AdjustingReserve;

            var expensereserve = recoDbGetClaimTotalIncurredByCategoriesResult.FirstOrDefault().ExpenseReserve;

            var zerotransaction = new RecoCms6.Models.RecoDb.Transaction() { };

            zerotransaction.ClaimID = claim.ClaimID;

            zerotransaction.TransactionDate = DateTime.Now;

            zerotransaction.IncurredCategoryID = (await recoDbGetParameterDetailsResult
                .FirstOrDefaultAsync(p => p.ParamTypeDesc == "Incurred Category" && p.ParamDesc == "Reserve"))?.ParameterID ?? 0;

            zerotransaction.Comments = "Claim Closed, Auto Zeroed Reserve";

            if (indemnityreserve > 0)
            {
                zerotransaction.Amount = -1 * indemnityreserve;
                

                zerotransaction.IncurredTypeID =
                    (await recoDbGetParameterDetailsResult.FirstOrDefaultAsync(p =>
                        p.ParamTypeDesc == "Incurred Type" && p.ParamDesc == "Indemnity"))?.ParameterID ?? 0;

                zerotransaction.ID = Guid.NewGuid();
                var recoDbCreateTransactionResult = await RecoDb.CreateTransaction(zerotransaction);
            }

            if (adjustingreserve > 0)
            {
                zerotransaction.Amount = -1 * adjustingreserve;
                zerotransaction.IncurredTypeID = (await recoDbGetParameterDetailsResult
                    .FirstOrDefaultAsync(p => p.ParamTypeDesc == "Incurred Type" && p.ParamDesc == "Adjusting"))?.ParameterID ?? 0;
                zerotransaction.ID = Guid.NewGuid();
                zerotransaction.TransactionID = 0;
                var recoDbCreateTransactionResult0 = await RecoDb.CreateTransaction(zerotransaction);

            }

            if (legalreserve > 0)
            {
                zerotransaction.Amount = -1 * legalreserve;
                zerotransaction.IncurredTypeID =
                    (await recoDbGetParameterDetailsResult.FirstOrDefaultAsync(p =>
                        p.ParamTypeDesc == "Incurred Type" && p.ParamDesc == "Legal"))?.ParameterID??0;

                zerotransaction.ID = Guid.NewGuid();
                zerotransaction.TransactionID = 0;
                var recoDbCreateTransactionResult01 = await RecoDb.CreateTransaction(zerotransaction);
            }

            if (expensereserve > 0)
            {
                zerotransaction.Amount = -1 * expensereserve;
                zerotransaction.IncurredTypeID = (await recoDbGetParameterDetailsResult
                    .FirstOrDefaultAsync(p => p.ParamTypeDesc == "Incurred Type" && p.ParamDesc == "Expense"))?.ParameterID ?? 0;
                
                zerotransaction.ID = Guid.NewGuid();
                zerotransaction.TransactionID = 0;
                var recoDbCreateTransactionResult012 = await RecoDb.CreateTransaction(zerotransaction);
            }

            if (adjustingreserve > 0 || expensereserve > 0 || indemnityreserve > 0 || legalreserve > 0)
            {
                var recoDbGetClaimTotalIncurredByCategoriesResult0 = await RecoDb.GetClaimTotalIncurredByCategories(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                getTotalIncurred =  recoDbGetClaimTotalIncurredByCategoriesResult0.ToList();
                var recoDbGetClaimIndividualTransactionsResult = await RecoDb.GetClaimIndividualTransactions(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"TransactionDate desc" });
                transactions =  recoDbGetClaimIndividualTransactionsResult.ToList();
            }

            var recoDbRemoveFutureDiariesResult = await RecoDb.RemoveFutureDiaries(claim.ClaimID);
            
            if (claim.CloseDate == null)
                claim.CloseDate = DateTime.Today;

            bCloseClaim = true;

            var recoDbGetClaimDiaryDetailsResult = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
            diaries =  recoDbGetClaimDiaryDetailsResult.ToList();
            //if (Globals.generalsettings.ApplicationName == "RECO CMS")
            //    SendSurveyEmail();
        }

        public async Task OnInputFileChange(IFileListEntry[] files)
        {
            newRecoMail.Files = files.ToList();
        }

        async Task ShowBusyEmailDialog()
        {
            BusyDialog("Sending ...");
            
            await InvokeAsync(async () =>
            {
                await Task.Delay(50);
                await SendEmail();
            });
        }

        public async Task SendEmail()
        {
            try
            {
                //showprogressbar = true;
                newRecoMail.Claimlist = claimList;


                await mailService.SendMail(newRecoMail, Security.User, bAttachToClaim);

                if (bAttachToClaim)
                    await AttachEmail();

                ClearEmailForm();
                DialogService.Close();

                NotificationService.Notify(NotificationSeverity.Success, "Email Has Been Sent", "");
                

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
                newRecoMail.From = Security.User.Email;
                //var emailHtml = await TemplateBuilder.Build(Templates.AttachMailToClaim, newRecoMail);
                var emailHtml = TemplateBuilder.BuildAttachMailToClaim(newRecoMail);
                var reportPdf = Utility.PdfConverter.ToPDFByteArray(emailHtml);


                var file = this._RecoDbContext.Files.Add(new Models.RecoDb.File()
                {
                    ID = Guid.NewGuid(),
                    ClaimID = claim.ClaimID,
                    Extension = ".pdf",
                    Subject = $"{newRecoMail.Subject}",
                    Filename = $"Mail_As_Pdf_{claim.ClaimNo}_{Guid.NewGuid()}.pdf",
                    EntryDate = DateTime.Now,
                    FileTypeID = recoDbGetParameterDetailsResult.FirstOrDefault(p => p.ParamTypeDesc == "File Type" && p.ParamDesc == "Email")?.ParameterID,
                    StoredDocument = reportPdf,
                    UploadedById = Security.User.Id,
                    ContentType = "application/pdf"
                });
                this._RecoDbContext.SaveChanges();
                await ReloadFiles();
            }
            catch (Exception ex) {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
            }

        }

        private async Task ReloadFiles()
        {
            var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", intClaimID);
            claimfiles =  recoDbGetClaimFilesByUsersResult.OrderBy(cf => cf.Sticky).ThenByDescending(cf => cf.EntryDate).ToList();

            var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            activityLog =  recoDbGetClaimActivityLogsResult.ToList();
        }

        public void ConnectEmailAccount()
        {
            var returnUrl = HttpUtility.UrlEncode(UriHelper.ToBaseRelativePath(UriHelper.Uri));
            UriHelper.NavigateTo($"/MS?returnUrl={returnUrl}", true);
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

        public void ToAddressessChanged()
            => this.newRecoMail.To = ToAddresses;

        public void CCAddressessChanged()
            => this.newRecoMail.CC = CCAddresses;

        public void BCCAddressesChanged()
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

        protected async void LaunchActivityLogItem(RecoCms6.Models.RecoDb.ClaimActivityLog args)
        {
            if (args.LogType == "Note")
            {
                //var dialogResult = await DialogService.OpenAsync<AddNote>($"Edit Note", new Dictionary<string, object>() { { "NoteID", args.ID } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true, Draggable = true });
                //if (dialogResult != null)
                //{
                //    bFirstRender = true;
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
                    bFirstRender = true;
                    var recoDbGetClaimActivityLogsResult0 = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                    activityLog =  recoDbGetClaimActivityLogsResult0.ToList();
                }
            }

            if (args.LogType == "File")
            {
                var dialogResult01 = await DialogService.OpenAsync<EditFile>($"Edit File", new Dictionary<string, object>() { { "ID", args.ID } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true });
                if (dialogResult01 != null)
                {
                    bFirstRender = true;
                    var recoDbGetClaimActivityLogsResult01 = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                    activityLog =  recoDbGetClaimActivityLogsResult01.ToList();
                }
            }
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
                note.EnteredByID = recoDbGetServiceProviderDetailsResult.FirstOrDefault()?.Name;
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

                //SaveNoteAuditTrail(note);

                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Note has been saved" });

                note = new Note();
                note.NoteTypeID = getDefaultNoteTypeID;
                TemplateID = 0;
                bNewNote = true;

                var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
                bFirstRender = true;

                activityLog =  recoDbGetClaimActivityLogsResult.ToList();
            }
            catch (System.Exception recoDbCreateNoteException)
            {
                await SaveErrorAsync(recoDbCreateNoteException);
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new Note!" });
            }
        }

        protected void SaveNoteAuditTrail(RecoCms6.Models.RecoDb.Note note)
        {
            var auditTrail = new RecoCms6.Models.RecoDb.AuditTrail();
            auditTrail.ClaimID = claim.ClaimID;
            auditTrail.TableAffected = "[Notes]";
            auditTrail.RowDetails = JsonConvert.SerializeObject(note);
            auditTrail.UserID = Security.User.Name.Substring(0,1) + Security.User.Name.Substring(Security.User.Name.IndexOf(' ',StringComparison.OrdinalIgnoreCase),254);
            _ = RecoDb.CreateAuditTrail(auditTrail);

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

        public void ClearEmailForm()
        {
            newRecoMail = new RecoMail();

            fromMail = "";

            ClaimTitle = "";

            ToAddresses = new List<string> { };

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

        protected async void ReloadClaim()
        {
            //Reload Claim
            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, Expand = "ClaimFileReportings" });
            claim = recoDbGetClaimsResult.First();

            //Reload EOClaimDetails
            var recoDbGetEoClaimDetailByClaimIdResult = await RecoDb.GetEoClaimDetailByClaimId(intClaimID);
            if (recoDbGetEoClaimDetailByClaimIdResult != null)
                eoclaimdetails = recoDbGetEoClaimDetailByClaimIdResult;
            else
                eoclaimdetails = new RecoCms6.Models.RecoDb.EoClaimDetail();

            //Reload Trade
            ReloadTradeList();
            //Reload Claimant
            ReloadClaimantList();
            //Reload Insured
            ReloadInsuredList();
        }

        protected async System.Threading.Tasks.Task DownloadFileAsync(int fileID)
        {
            //string[] docExtensions = { ".pdf", ".xls", ".xlsx", ".doc", ".docx" };
            //string[] imageExtensions = { ".png", ".jpeg", ".jpg", ".gif" };
            //string[] avExtensions = { ".avi", ".mov", ".mp4", ".mp3", ".m4a", ".wav" };

            try
            {
                UriHelper.NavigateTo($"/downloadfullfile/FileID={fileID}", true);
            }
            catch (Exception ex) {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
            }



        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (bFirstRender && activityLog != null && datagridActivityLog != null)
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
                    if (!claimOpened) //Do not expand Diary on open
                    {
                        ExpandedNotes.Add(log.ID.ToString());
                    }
                    if (ExpandedNotes.Contains(log.ID.ToString()))
                    {
                        try
                        {
                            await datagridActivityLog.ExpandRow(log);
                        }
                        catch { }
                    }
                }

                bFirstRender = false;
                if (!claimOpened)
                {
                    SetPreference(false);
                }
                StateHasChanged();
            }
            base.OnAfterRender(firstRender);
        }
        protected async System.Threading.Tasks.Task DownloadFile(Models.RecoDb.File file)
        { }
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

        protected async void OpenNewTab(MouseEventArgs args)
        {
            try
            {
                ContextMenuService.Open(args, new List<ContextMenuItem>() { new ContextMenuItem() { Text = "Open Claim in New Browser Tab", Value = 1 } }, async (MenuItemEventArgs item) => {
                    await JSRuntime.InvokeVoidAsync("open", $"edit-claim/{claim.ClaimID.ToBase64()}", "_blank");
                });
            }
            catch
            { }
        }

        protected void GenerateRndParameter()
        {
            randomParam = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        }

        protected void NoteDetailsChanged(string args)
        {
            note.Details = args;
        }
        protected void ExecutiveSummaryChanged(string args)
        {
            report.ExecutiveSummary = args;
        }

        protected void FactsChanged(string args)
        {
            report.Facts = args;
        }

        protected void CoverageChanged(string args)
        {
            report.Coverage = args;
        }

        protected void LiabilityChanged(string args)
        {
            report.Liability = args;
        }
        protected void DamagesChanged(string args)
        {
            report.Damages = args;
        }

        protected void ActionPlanChanged(string args)
        {
            report.ActionPlan = args;
        }

        protected void RecommendationsChanged(string args)
        {
            report.Recommendations = args;
        }

        protected async Task<ServiceProviderClaimPreference> GetPreferenceAsync()
        {
            try
            {
                var recoDbGetServiceProviderClaimPreferencesResult = await RecoDb.GetServiceProviderClaimPreferences(new Query() { Filter = $@"i => i.ServiceProviderID == @0 && i.ClaimID == @1", FilterParameters = new object[] { serviceprovider?.ServiceProviderID, claim.ClaimID } });
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


        protected async void SetPreference(bool isPageLoad)
        {
            //if (bFirstRender)
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
                    claimpreference.ServiceProviderID = serviceprovider.ServiceProviderID ;
                    claimpreference.DateLastAccessed = DateTime.Now;
                    if (!isPageLoad)
                    {
                        claimpreference.JsonPreference = GetJsonPreference();
                        if (claimpreference.JsonPreference== "{\"ExpandedNotes\":\"\"}")
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
                    if(serviceprovider is not null)
                        await RecoDb.UpdateServiceProviderClaimPreference(serviceprovider.ServiceProviderID, claim.ClaimID, claimpreference);
                }

                recoDbGetServiceProviderClaimPreferencesResult = await RecoDb.GetServiceProviderClaimPreferences(new Query() { Filter = $@"i => i.ServiceProviderID == @0", FilterParameters = new object[] { serviceprovider.ServiceProviderID }, OrderBy = $"DateLastAccessed desc", Top = 10 });
                Globals.ServiceProviderClaims = recoDbGetServiceProviderClaimPreferencesResult;
            }
            catch { }

        }

        protected async Task<ServiceProvider> GetCurrentServiceProvider()
        {
            var recoDbGetUsersResult = await RecoDb.GetUserDetails(new Query { Filter = $@"i=> i.UserName == @0", FilterParameters = new object[] { Security.Principal.Identity.Name } });
            var userdetail = recoDbGetUsersResult.FirstOrDefault();

            var recoDbGetServiceProvidersResult = await RecoDb.GetServiceProviders(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { userdetail.Id } });
            serviceprovider = recoDbGetServiceProvidersResult.FirstOrDefault();

            return serviceprovider;
        }

        protected string GetJsonPreference()
        {
            dynamic preferences = new ExpandoObject();
            if (ExpandedNotes == null)
                ExpandedNotes = new List<string>();

            preferences.ExpandedNotes = string.Join(',', ExpandedNotes);
            return JsonConvert.SerializeObject(preferences);
        }

        private async Task UpdateXRefClaims()
        {
            foreach (var xrefToAdd in XRefClaimsListToAdd)
            {
                var crossRefToAdd = new CrossReferencedClaim
                {
                    ClaimID = xrefToAdd.BaseClaimID,
                    XRefClaimID = xrefToAdd.XRefClaimID,
                };
                var recoDbCreateCrossReferencedClaimResult = await RecoDb.CreateCrossReferencedClaim(crossRefToAdd);
            }

            XRefClaimsListToAdd.Clear();

            foreach (var xrefToDelete in XRefClaimsListToDelete)
            {
                var recoDbRemoveCrossReferencesResult =
                    await RecoDb.RemoveCrossReferences(xrefToDelete.BaseClaimID, xrefToDelete.XRefClaimID);
            }

            XRefClaimsListToDelete.Clear();

            var recoDbGetXRefClaimsResult = await RecoDb.GetXRefClaims(new Query()
            {
                Filter = $@"i => i.BaseClaimID == @0", FilterParameters = new object[] { claim.ClaimID },
                OrderBy = $"XRefClaimNo asc"
            });
            getXRefClaimsList = recoDbGetXRefClaimsResult.ToList();
        }

        
        private IQueryable<ParameterDetail> recoDbGetParameterDetailsResult;

        private bool _claimDetailsTabLoaded;
        private async Task LoadClaimDetailsTabData()
        {
            if (_claimDetailsTabLoaded)
            {
                return;
            }
            _claimDetailsTabLoaded = true;
            
            var recoDbGetGetAvailableServiceProvidersResult = await RecoDb.GetGetAvailableServiceProviders(claim.ClaimID, new Query() { OrderBy = $"NameandFirm asc" });
            getAdjustersList = recoDbGetGetAvailableServiceProvidersResult.Where(sp => sp.SystemRole == "Adjuster").ToList();

            getCoverageCounselList = recoDbGetGetAvailableServiceProvidersResult.Where(sp => sp.FirmType == "Coverage Counsel").ToList();

            getFileHandlerList = recoDbGetGetAvailableServiceProvidersResult.Where(sp => sp.FileHandler == true).ToList();

            getDefenseCounselList = recoDbGetGetAvailableServiceProvidersResult.Where(sp => sp.FirmType == "Defense Counsel").ToList();

            getReportsToList = recoDbGetGetAvailableServiceProvidersResult.Where(sp => sp.ServiceProviderRole == "Program Manager" || sp.ServiceProviderRole == "Adjuster" || sp.ServiceProviderRole == "Claims Manager").ToList();

            getEOProgramID = recoDbGetParameterDetailsResult.FirstOrDefault(p => p.ParamTypeDesc == "ProgramID" && p.ParamDesc == "Errors and Omissions").ParameterID;

            isEOProgram = claim.ProgramID == getEOProgramID;

            getClaimStatusList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Claim Status").ToList();

            getClaimInitiationList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Claim Initiation").ToList();

            getLossCauseResult = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Loss Cause").ToList();

            getDenialCodeList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Denial Code").ToList();

            getBrokerageOnlyList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "BrokerageOnly").ToList();

            getTradeTypeList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Trade Type").ToList();

            getStageSettledList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Stage Settled").ToList();

            getFileOutcomeList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "File Outcome").ToList();
            
            getDeductibleList = recoDbGetParameterDetailsResult.Any(p => p.ParamTypeDesc == "Deductible" && p.ParamValue == -1 && p.ParameterID == claim.Deductible) 
                ? recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Deductible").OrderBy(p => p.ParamValue).ToList() 
                : recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Deductible" && p.ParamValue != -1).OrderBy(p => p.ParamValue).ToList();
            
            claim.Deductible ??= getDeductibleList.FirstOrDefault(dl => dl.ParamValue == 1)?.ParameterID ?? 0;

            getRORList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Reservation of Rights").ToList();

            getLitigationTypeList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Litigation Type").ToList();

            getDeductibleHandlingList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Deductible Handled").ToList();

            getRecoveryList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Recovery").ToList();

            getRECOOutcomeList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "RECO Complaint Outcome").ToList();

            getYesNoPendingList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "YesNoNA").ToList();

            getEndOfDealList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc.Equals("End of Deal")).ToList();

            getUrbanOrRuralList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "UrbanOrRural").ToList();

            getTransactionValueList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Transaction Value").OrderBy(p => p.ParamValue).ToList();

            var recoDbGetTradesResult = await RecoDb.GetTrades(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID }, OrderBy = $"DisplayOrder asc" });
            trade ??= recoDbGetTradesResult.FirstOrDefault();

            claimdetails = await RecoDb.GetCdpClaimDetailByClaimId(intClaimID);
            eoclaimdetails = await RecoDb.GetEoClaimDetailByClaimId(intClaimID);

            var recoDbGetNoticeOfClaimsResult = await RecoDb.GetNoticeOfClaims(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
            NoticeOfClaimRefNum = recoDbGetNoticeOfClaimsResult.FirstOrDefault()?.RefNum ?? string.Empty;

            var recoDbGetClaimLitigationDatesResult = await RecoDb.GetClaimLitigationDates(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"LitigationDate asc" });
            getClaimLitigationDatesList =  recoDbGetClaimLitigationDatesResult.ToList();
            
            var recoDbGetGetSevenYearsClaimIndemnitiesResult = await RecoDb.GetGetSevenYearsClaimIndemnities(intClaimID, new Query() { OrderBy = $"ClaimNo asc" });
            getSevenYearIndemnitiesResult = recoDbGetGetSevenYearsClaimIndemnitiesResult.ToList();
            
            var recoDbGetCostAwardsResult = await RecoDb.GetCostAwards(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"CostAwardDate desc" });
            getCostAwardsList =  recoDbGetCostAwardsResult.ToList();

            
        }

        private bool _contactInfoTabLoaded;
        private async Task LoadContactInfoTabData()
        {
            if (_contactInfoTabLoaded)
            {
                return;
            }
            _contactInfoTabLoaded = true;
            
            ReloadClaimantList();

            ReloadOtherPartyList();
            
            await ReloadExpertList();
            
            ReloadTradeList();
            
        }

        private bool _reservesPaymentsTabLoaded;
        private async Task LoadReservesPaymentsTabData()
        {
            if (_reservesPaymentsTabLoaded)
            {
                return;
            }
            _reservesPaymentsTabLoaded = true;
            
            if (Globals.generalsettings.ApplicationName == "REIX CMS")
            {
                var recoDbGetClaimIndividualTransactionsResult = await RecoDb.GetClaimIndividualTransactions(new Query() { Filter = $@"i => i.ClaimID == @0 && i.RelatedTransactionID == @1", FilterParameters = new object[] { intClaimID, null }, OrderBy = $"TransactionDate desc,TransactionID desc" });
                transactions = recoDbGetClaimIndividualTransactionsResult.ToList();
            }
            if (Globals.generalsettings.ApplicationName == "RECO CMS")
            {
                var recoDbGetClaimIndividualTransactionsResult0 = await RecoDb.GetClaimIndividualTransactions(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID }, OrderBy = $"TransactionDate desc,TransactionID desc" });
                transactions =  recoDbGetClaimIndividualTransactionsResult0.ToList();
            }
        }

        private bool _notesTabLoaded;
        private async Task LoadNotesTabData()
        {
            if (_notesTabLoaded)
            {
                return;
            }
            _notesTabLoaded = true;
            
            getNoteTypeList = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Note Type").ToList();

            getDefaultNoteTypeID = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Note Type" && p.ParamDesc == "Note").First().ParameterID;
            note.NoteTypeID = getDefaultNoteTypeID;

            var recoDbGetTemplateDetailsResult = await RecoDb.GetTemplateDetails(new Query() { OrderBy = $"Title asc" });
            getNoteTemplateResults = recoDbGetTemplateDetailsResult.Where(dt => dt.TemplateType == "<All>" || dt.TemplateType == "Note").ToList();

            var recoDbGetClaimActivityLogsResult = await RecoDb.GetClaimActivityLogs(claim.ClaimID, $"{Security.User.Id}", new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            activityLog =  recoDbGetClaimActivityLogsResult.ToList();
        }

        private bool _attachmentsTabLoaded;
        private async Task LoadAttachmentsTabData()
        {
            if (_attachmentsTabLoaded)
            {
                return;
            }
            _attachmentsTabLoaded = true;
            
            var recoDbGetClaimFilesByUsersResult = await RecoDb.GetClaimFilesByUsers($"{Security.User.Id}", intClaimID, new Query() { OrderBy = $"Sticky desc,EntryDate desc" });
            claimfiles =  recoDbGetClaimFilesByUsersResult.ToList();
            
        }

        private bool _diariesTabLoaded;
        private async Task LoadDiariesTabData()
        {
            if (_diariesTabLoaded)
            {
                return;
            }

            _diariesTabLoaded = true;
            
            var recoDbGetClaimDiaryDetailsResult = await RecoDb.GetClaimDiaryDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.DiaryStatus == @1", FilterParameters = new object[] { claim.ClaimID, "Open" }, OrderBy = $"EntryDate desc" });
            diaries = recoDbGetClaimDiaryDetailsResult.ToList();

            
        }
        
        private bool _claimReportsTabLoaded;
        private async Task LoadClaimReportsTabData()
        {
            if (_claimReportsTabLoaded)
            {
                return;
            }
            _claimReportsTabLoaded = true;
            
            parameterFlags = recoDbGetParameterDetailsResult.Where(p => p.ParamTypeDesc == "Claim Report Flag").ToList();
            report = await getClaimReport(claim.ClaimID);
        }
        
        private bool _emailTabLoaded;
        private async Task LoadEmailTabData()
        {
            if (_emailTabLoaded)
            {
                return;
            }
            _emailTabLoaded = true;
            
            var recoDbGetTemplateDetailsResult = await RecoDb.GetTemplateDetails(new Query() { OrderBy = $"Title asc" });
            getEmailTemplateResults = recoDbGetTemplateDetailsResult.Where(dt => dt.TemplateType == "<All>" || dt.TemplateType == "Email" || dt.TemplateType == "Diary/Email").ToList();
            
            var recoDbGetStandardEmailAddressesResult = await RecoDb.GetStandardEmailAddresses(new Query() { OrderBy = $"EmailAddress asc" });
            standardEmails =  recoDbGetStandardEmailAddressesResult.ToList();
        }
    }
}
