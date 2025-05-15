using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.EntityFrameworkCore;
using RecoCms6.Services.TemplateEngine;
using Microsoft.AspNetCore.Components;
using RecoCms6.Data;
using RecoCms6.Services;
using RecoCms6.Utility;
using RecoCms6.Models.RecoDb;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace RecoCms6.Pages
{
    public partial class ClaimReportComponent
    {
        [Inject]
        protected RecoDbContext _RecoDbContext { get; set; }

        [Inject]
        protected MailService _MailService { get; set; }

        [Inject]
        protected MacroService _MacroService { get; set; }

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
            var reports = await RecoDb.GetClaimReports(new Radzen.Query() { Filter = $@"i => i.ClaimID == {ClaimID} && i.HandlingFirmID == {serviceprovider.FirmID}" });

            //no report created so far, just create the initial report
            if (reports.Count() == 0)
            {
                return new RecoCms6.Models.RecoDb.ClaimReport()
                {
                    InitialReport = true,
                    ClaimID = ClaimID,
                    Incremental = false,
                    HandlingFirmID = serviceprovider.FirmID

                };
            }

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
                lastSubmitedReportCopy.Liability =  String.Empty;
                lastSubmitedReportCopy.Recommendations = String.Empty;
                lastSubmitedReportCopy.ClaimReportFlagID = null;

                return lastSubmitedReportCopy;
            }

            //if non of the above fresh start.
            return new RecoCms6.Models.RecoDb.ClaimReport()
            {
                InitialReport = true,
                ClaimID = ClaimID,
                Incremental = false,
                HandlingFirmID = serviceprovider.FirmID
            };

        }

        protected async System.Threading.Tasks.Task DownloadFileAsync(int fileID)
        {
            string[] docExtensions = { ".pdf", ".xls", ".xlsx", ".doc", ".docx" };
            string[] imageExtensions = { ".png", ".jpeg", ".jpg", ".gif" };
            string[] avExtensions = { ".avi", ".mov", ".mp4", ".mp3", ".m4a", ".wav" };

            try
            {
                    UriHelper.NavigateTo($"/downloadfullfile/FileID={fileID}", true);
            }
            catch { }
        }

        protected async Task LoadPreviousReports()
        {
            var recoDbGetClaimReportDetailsResult = await RecoDb.GetClaimReportDetails(new Query() { Filter = $@"i => i.ClaimID == @0 && i.HandlingFirmID == @1", FilterParameters = new object[] { claim.ClaimID, serviceprovider.FirmID }, OrderBy = $"DateCreated desc" });
            claimReports = recoDbGetClaimReportDetailsResult;

            previousClaimReports = recoDbGetClaimReportDetailsResult.Where(cr => cr.DateSubmitted != null);

            previousActionPlans = previousClaimReports.Where(cr => cr.ActionPlan != null);

            previousFacts = previousClaimReports.Where(cr => cr.Facts != null);

            previousCoverage = previousClaimReports.Where(cr => cr.Coverage != null);

            previousLiability = previousClaimReports.Where(cr => cr.Liability != null);

            previousDamages = previousClaimReports.Where(cr => cr.Damages != null);

            previousRecommendations = previousClaimReports.Where(cr => cr.Recommendations != null);

        }
        protected async Task<bool> SaveReport()
        {
            int claimreportid;
            if (IsSubmitEvent)
            {
                //if (!ValidateReport())
                //    return false;
                report.DateSubmitted = DateTime.Now;
                var recoDbGetServiceProviderDetailsResult = await RecoDb.GetServiceProviderDetails(new Query() { Filter = $@"i => i.UserID == @0", FilterParameters = new object[] { Security.User.Id } });
                report.SubmittedBy = recoDbGetServiceProviderDetailsResult.First().Name;
            }
            else
                report.FileId = null;

            report.DateLastModified = DateTime.Now;
            //fresh report
            if (report.ClaimReportID == 0)
            {
                report.DateCreated = DateTime.Now;
                await this.RecoDb.CreateClaimReport(report);
                if (!IsSubmitEvent)
                    return true;
            }
            else
                await this.RecoDb.UpdateClaimReport(report.ClaimReportID, report);

            claimreportid = report.ClaimReportID;

            //Update Claim to save the Counsel File #
            if (claim.CounselFileNo != String.Empty)
                await RecoDb.UpdateCounselClaimNums(claim.ClaimID, $"{claim.CounselFileNo}");

            if (IsSubmitEvent)
                await handleReport(claimreportid);

            return true;
        }

        private async Task handleReport(int claimreportid)
        {
            
            var reportDetail = this._RecoDbContext.ClaimReportDetails.Where(rpd => rpd.ClaimReportID == claimreportid).FirstOrDefault();

            //var reportHtml = await TemplateBuilder.Build(Templates.ClaimReport, reportDetail);
            var reportHtml = TemplateBuilder.BuildClaimReport(reportDetail);
            var reportPdf = reportHtml.ToPDFByteArray();

            try
            {
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
                    VisibleToCounsel = Security.IsInRole("Defense Counsel"),
                    FileTypeID = getClaimReportFileTypeID
                });

                this._RecoDbContext.SaveChanges();

                //Save the file id with the claim report
                report.FileId = file.Entity.FileID;
                await this.RecoDb.UpdateClaimReport(report.ClaimReportID, report);
            }
            catch(Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
                NotificationService.Notify(NotificationSeverity.Error, $"Unable to save pdf", $"{ex.Message}");
            }

            try
            {

                if (Security.IsInRole("Defense Counsel"))
                {
                    var recoDbRemoveFutureDiariesResult = await RecoDb.RemoveFutureCounselDiaries(claim.ClaimID);

                    if (Globals.gblCurrentClaim.Status == "Open")
                    {
                        var template = this._RecoDbContext.DiaryTemplates.Where(x => x.Title == "Update Request").FirstOrDefault();
                        var days = reportDetail.ReportingDays ?? 90; //Default to 90 Days if Reporting Days is null

                        var recoDbGetServiceProviderDetailsResult = await RecoDb.GetClaimLists(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                        string enteredBy = recoDbGetServiceProviderDetailsResult.First().FileHandler;

                        this._RecoDbContext.Diaries.Add(new Models.RecoDb.Diary()
                        {
                            ID = Guid.NewGuid(),
                            ClaimID = reportDetail.ClaimID,
                            Subject = await _MacroService.Replace(reportDetail.ClaimID, template.Subject),
                            Details = await _MacroService.Replace(reportDetail.ClaimID, template.TemplateText),
                            AbeyanceDate = DateTime.Now.AddDays(days),
                            EntryDate = DateTime.Now,
                            EnteredBy = enteredBy,
                            DiaryStatusID = 145, // Open Status
                            Recipients = reportDetail.DefenseCounselEmailAddress
                        });
                        this._RecoDbContext.SaveChanges();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
                NotificationService.Notify(NotificationSeverity.Error, $"Unable to create diary", $"{ex.InnerException.Message}");
            }

            reportDetail.UploadedByEmail = Security.User.Email;
            try
            {
                await _MailService.SendReportMail(reportDetail, Security.User, reportHtml);
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", claim.ClaimID);
                NotificationService.Notify(NotificationSeverity.Error, $"Unable to send email", $"{ex.Message}");
            }
            
            var reports = await RecoDb.GetClaimReports(new Radzen.Query() { Filter = $@"i => i.ClaimID == {reportDetail.ClaimID} && i.HandlingFirmID == {serviceprovider.FirmID}" });
            await LoadPreviousReports();
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
                () => string.IsNullOrWhiteSpace(report.Recommendations) ? "Recommendations required!" : string.Empty,
                () => string.IsNullOrWhiteSpace(report.DamagesClaimed) ? "Damages Claimed required!": string.Empty
            };

            rfvExecSummary = report.ExecutiveSummary == string.Empty;
            rfvFacts = report.Facts == string.Empty;
            rfvActionPlan = false;
            rfvCoverage = report.Coverage == string.Empty;
            rfvDamages = report.Damages == string.Empty;
            rfvDamagesClaimed = report.DamagesClaimed == string.Empty;
            rfvEstimatedExpenses = report.EstimatedExpenses == string.Empty;
            rfvEstimatedIndmenity = report.EstimatedIndemnity == string.Empty;
            rfvLiability = report.Liability == string.Empty;
            rfvRecommendations = report.Recommendations == string.Empty;
            rfvSubrogation = report.PossibleSubrogation == string.Empty;


            if (!report.InitialReport)
            {
                fieldValidation.Add(() => string.IsNullOrWhiteSpace(report.ActionPlan) ? "Update required!" : string.Empty);
                rfvActionPlan = report.ActionPlan == string.Empty;
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

        protected async Task FilterFiles(IEnumerable<File> files)
        {

        }

        async Task ShowBusyDialog()
        {

            await InvokeAsync(async () =>
              {
                  await Task.Delay(50);
                  saveResult = await SaveReport();

                  // Close the dialog
                  DialogService.Close();  
                
              });

            BusyDialog(IsSubmitEvent ? "Submitting ..." : "Saving ...");

            if (saveResult && !IsSubmitEvent)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Report is saved" });
            }

            if (saveResult && IsSubmitEvent)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Report Has been Submitted" });
                report = await getClaimReport(claim.ClaimID);
            }
            DialogService.Close();
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
            }, new DialogOptions() { ShowTitle = false, Style = "min-height:auto;min-width:auto;width:auto", CloseDialogOnOverlayClick=false });
        }

        protected async void SetPreference()
        {
            try
            {
                var recoDbGetServiceProviderClaimPreferencesResult = await RecoDb.GetServiceProviderClaimPreferences(new Query() { Filter = $@"i => i.ServiceProviderID == @0 && i.ClaimID == @1", FilterParameters = new object[] { serviceprovider.ServiceProviderID, claim.ClaimID } });
                claimpreference = recoDbGetServiceProviderClaimPreferencesResult.FirstOrDefault();
                if (claimpreference == null)
                {
                    claimpreference = new RecoCms6.Models.RecoDb.ServiceProviderClaimPreference();
                    claimpreference.ClaimID = claim.ClaimID;
                    claimpreference.ServiceProviderID = serviceprovider.ServiceProviderID;
                    claimpreference.DateLastAccessed = DateTime.Now;
                    await RecoDb.CreateServiceProviderClaimPreference(claimpreference);
                }
                else
                {
                    claimpreference.DateLastAccessed = DateTime.Now;
                    await RecoDb.UpdateServiceProviderClaimPreference(serviceprovider.ServiceProviderID, claim.ClaimID, claimpreference);
                }
            }
            catch { }

        }
    }
}
