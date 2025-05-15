using Microsoft.AspNetCore.Mvc;

namespace RecoCms6
{
    public partial class ExportRecoDbController(RecoDbService service) : ExportController
    {
        [HttpGet("/export/RecoDb/accountingaudits/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAccountingAuditsToCSV(int? ProgramID, string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAccountingAudits(ProgramID, StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/accountingaudits/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAccountingAuditsToExcel(int? ProgramID, string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAccountingAudits(ProgramID, StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/accountingrecoveryaudits/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAccountingRecoveryAuditsToCSV(int? ProgramID, string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAccountingRecoveryAudits(ProgramID, StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/accountingrecoveryaudits/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAccountingRecoveryAuditsToExcel(int? ProgramID, string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAccountingRecoveryAudits(ProgramID, StartDate, EndDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/activefilehandlerdiaries/csv")]
        [HttpGet("/export/RecoDb/activefilehandlerdiaries/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActiveFileHandlerDiariesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetActiveFileHandlerDiaries(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/activefilehandlerdiaries/excel")]
        [HttpGet("/export/RecoDb/activefilehandlerdiaries/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActiveFileHandlerDiariesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetActiveFileHandlerDiaries(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/activeuserdiaryreports/csv(ReminderDateFrom='{ReminderDateFrom}', ReminderDateTo='{ReminderDateTo}', UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActiveUserDiaryReportsToCSV(string ReminderDateFrom, string ReminderDateTo, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetActiveUserDiaryReports(ReminderDateFrom, ReminderDateTo, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/activeuserdiaryreports/excel(ReminderDateFrom='{ReminderDateFrom}', ReminderDateTo='{ReminderDateTo}', UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActiveUserDiaryReportsToExcel(string ReminderDateFrom, string ReminderDateTo, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetActiveUserDiaryReports(ReminderDateFrom, ReminderDateTo, UserID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/actualdaysopens/csv")]
        [HttpGet("/export/RecoDb/actualdaysopens/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActualDaysOpensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetActualDaysOpens(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/actualdaysopens/excel")]
        [HttpGet("/export/RecoDb/actualdaysopens/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActualDaysOpensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetActualDaysOpens(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/actuarybordereaus/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActuaryBordereausToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetActuaryBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/actuarybordereaus/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportActuaryBordereausToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetActuaryBordereaus(ReportDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/administrators/csv")]
        [HttpGet("/export/RecoDb/administrators/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAdministratorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAdministrators(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/administrators/excel")]
        [HttpGet("/export/RecoDb/administrators/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAdministratorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAdministrators(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/appointments/csv")]
        [HttpGet("/export/RecoDb/appointments/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAppointmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAppointments(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/appointments/excel")]
        [HttpGet("/export/RecoDb/appointments/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAppointmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAppointments(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/audittrails/csv")]
        [HttpGet("/export/RecoDb/audittrails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAuditTrailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditTrails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/audittrails/excel")]
        [HttpGet("/export/RecoDb/audittrails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAuditTrailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditTrails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/audittraildetails/csv")]
        [HttpGet("/export/RecoDb/audittraildetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAuditTrailDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditTrailDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/audittraildetails/excel")]
        [HttpGet("/export/RecoDb/audittraildetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAuditTrailDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditTrailDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/autoreservings/csv")]
        [HttpGet("/export/RecoDb/autoreservings/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAutoReservingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoReservings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/autoreservings/excel")]
        [HttpGet("/export/RecoDb/autoreservings/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAutoReservingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoReservings(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/availableincurredcategories/csv")]
        [HttpGet("/export/RecoDb/availableincurredcategories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAvailableIncurredCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAvailableIncurredCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/availableincurredcategories/excel")]
        [HttpGet("/export/RecoDb/availableincurredcategories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAvailableIncurredCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAvailableIncurredCategories(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/availableincurredtypes/csv")]
        [HttpGet("/export/RecoDb/availableincurredtypes/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAvailableIncurredTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAvailableIncurredTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/availableincurredtypes/excel")]
        [HttpGet("/export/RecoDb/availableincurredtypes/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAvailableIncurredTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAvailableIncurredTypes(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/binaryrolevalues/csv")]
        [HttpGet("/export/RecoDb/binaryrolevalues/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBinaryRoleValuesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBinaryRoleValues(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/binaryrolevalues/excel")]
        [HttpGet("/export/RecoDb/binaryrolevalues/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBinaryRoleValuesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBinaryRoleValues(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/brokerages/csv")]
        [HttpGet("/export/RecoDb/brokerages/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBrokeragesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBrokerages(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/brokerages/excel")]
        [HttpGet("/export/RecoDb/brokerages/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBrokeragesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBrokerages(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/brokeragecontacts/csv")]
        [HttpGet("/export/RecoDb/brokeragecontacts/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBrokerageContactsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBrokerageContacts(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/brokeragecontacts/excel")]
        [HttpGet("/export/RecoDb/brokeragecontacts/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBrokerageContactsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBrokerageContacts(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/builders/csv")]
        [HttpGet("/export/RecoDb/builders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBuildersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBuilders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/builders/excel")]
        [HttpGet("/export/RecoDb/builders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBuildersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBuilders(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/builderdetails/csv")]
        [HttpGet("/export/RecoDb/builderdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBuilderDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBuilderDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/builderdetails/excel")]
        [HttpGet("/export/RecoDb/builderdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportBuilderDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBuilderDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/cdinoticeofclaimdetails/csv")]
        [HttpGet("/export/RecoDb/cdinoticeofclaimdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCdiNoticeOfClaimDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCdiNoticeOfClaimDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/cdinoticeofclaimdetails/excel")]
        [HttpGet("/export/RecoDb/cdinoticeofclaimdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCdiNoticeOfClaimDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCdiNoticeOfClaimDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/cdpclaimdetails/csv")]
        [HttpGet("/export/RecoDb/cdpclaimdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCdpClaimDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCdpClaimDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/cdpclaimdetails/excel")]
        [HttpGet("/export/RecoDb/cdpclaimdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCdpClaimDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCdpClaimDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/checksystemnotices/csv(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCheckSystemNoticesToCSV(string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCheckSystemNotices(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/checksystemnotices/excel(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCheckSystemNoticesToExcel(string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCheckSystemNotices(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/checktransactionlimits/csv(UserID='{UserID}', IncurredCategoryID={IncurredCategoryID}, IncurredTypeID={IncurredTypeID}, ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCheckTransactionLimitsToCSV(string UserID, int? IncurredCategoryID, int? IncurredTypeID, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCheckTransactionLimits(UserID, IncurredCategoryID, IncurredTypeID, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/checktransactionlimits/excel(UserID='{UserID}', IncurredCategoryID={IncurredCategoryID}, IncurredTypeID={IncurredTypeID}, ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCheckTransactionLimitsToExcel(string UserID, int? IncurredCategoryID, int? IncurredTypeID, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCheckTransactionLimits(UserID, IncurredCategoryID, IncurredTypeID, ProgramID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claims/csv")]
        [HttpGet("/export/RecoDb/claims/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claims/excel")]
        [HttpGet("/export/RecoDb/claims/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimactivitylogs/csv(ClaimID={ClaimID}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimActivityLogsToCSV(int? ClaimID, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimActivityLogs(ClaimID, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimactivitylogs/excel(ClaimID={ClaimID}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimActivityLogsToExcel(int? ClaimID, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimActivityLogs(ClaimID, UserID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimbaseprincipals/csv")]
        [HttpGet("/export/RecoDb/claimbaseprincipals/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimBasePrincipalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimBasePrincipals(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimbaseprincipals/excel")]
        [HttpGet("/export/RecoDb/claimbaseprincipals/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimBasePrincipalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimBasePrincipals(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimclaimants/csv")]
        [HttpGet("/export/RecoDb/claimclaimants/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimClaimantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimClaimants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimclaimants/excel")]
        [HttpGet("/export/RecoDb/claimclaimants/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimClaimantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimClaimants(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimcurrentpayments/csv")]
        [HttpGet("/export/RecoDb/claimcurrentpayments/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimCurrentPaymentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimCurrentPayments(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimcurrentpayments/excel")]
        [HttpGet("/export/RecoDb/claimcurrentpayments/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimCurrentPaymentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimCurrentPayments(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimcurrentreserves/csv")]
        [HttpGet("/export/RecoDb/claimcurrentreserves/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimCurrentReservesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimCurrentReserves(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimcurrentreserves/excel")]
        [HttpGet("/export/RecoDb/claimcurrentreserves/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimCurrentReservesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimCurrentReserves(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimdetailsbordereaus/csv")]
        [HttpGet("/export/RecoDb/claimdetailsbordereaus/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimDetailsBordereausToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimDetailsBordereaus(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimdetailsbordereaus/excel")]
        [HttpGet("/export/RecoDb/claimdetailsbordereaus/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimDetailsBordereausToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimDetailsBordereaus(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimdetailsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', ClaimStatusID={ClaimStatusID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimDetailsReportsToCSV(string StartDate, string EndDate, int? ClaimStatusID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimDetailsReports(StartDate, EndDate, ClaimStatusID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimdetailsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', ClaimStatusID={ClaimStatusID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimDetailsReportsToExcel(string StartDate, string EndDate, int? ClaimStatusID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimDetailsReports(StartDate, EndDate, ClaimStatusID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimdiarydetails/csv")]
        [HttpGet("/export/RecoDb/claimdiarydetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimDiaryDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimDiaryDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimdiarydetails/excel")]
        [HttpGet("/export/RecoDb/claimdiarydetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimDiaryDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimDiaryDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimemailaddresses/csv(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimEmailAddressesToCSV(int? ClaimID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimEmailAddresses(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimemailaddresses/excel(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimEmailAddressesToExcel(int? ClaimID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimEmailAddresses(ClaimID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimexperts/csv")]
        [HttpGet("/export/RecoDb/claimexperts/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimExpertsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimExperts(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimexperts/excel")]
        [HttpGet("/export/RecoDb/claimexperts/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimExpertsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimExperts(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimfilehandlerandreports/csv")]
        [HttpGet("/export/RecoDb/claimfilehandlerandreports/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFileHandlerAndReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimFileHandlerAndReports(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimfilehandlerandreports/excel")]
        [HttpGet("/export/RecoDb/claimfilehandlerandreports/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFileHandlerAndReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimFileHandlerAndReports(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimfilereportings/csv")]
        [HttpGet("/export/RecoDb/claimfilereportings/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFileReportingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimFileReportings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimfilereportings/excel")]
        [HttpGet("/export/RecoDb/claimfilereportings/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFileReportingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimFileReportings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimfilesummaries/csv(ClaimID={ClaimID}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFileSummariesToCSV(int? ClaimID, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimFileSummaries(ClaimID, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimfilesummaries/excel(ClaimID={ClaimID}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFileSummariesToExcel(int? ClaimID, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimFileSummaries(ClaimID, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimfilesbyusers/csv(UserID='{UserID}', ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFilesByUsersToCSV(string UserID, int? ClaimID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimFilesByUsers(UserID, ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimfilesbyusers/excel(UserID='{UserID}', ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimFilesByUsersToExcel(string UserID, int? ClaimID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimFilesByUsers(UserID, ClaimID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimindividualtransactions/csv")]
        [HttpGet("/export/RecoDb/claimindividualtransactions/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimIndividualTransactionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimIndividualTransactions(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimindividualtransactions/excel")]
        [HttpGet("/export/RecoDb/claimindividualtransactions/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimIndividualTransactionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimIndividualTransactions(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claiminsureds/csv")]
        [HttpGet("/export/RecoDb/claiminsureds/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimInsuredsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimInsureds(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claiminsureds/excel")]
        [HttpGet("/export/RecoDb/claiminsureds/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimInsuredsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimInsureds(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimlagtimereports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimLagTimeReportsToCSV(string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimLagTimeReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimlagtimereports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimLagTimeReportsToExcel(string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimLagTimeReports(StartDate, EndDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimlists/csv")]
        [HttpGet("/export/RecoDb/claimlists/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimLists(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimlists/excel")]
        [HttpGet("/export/RecoDb/claimlists/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimLists(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimlitigationdates/csv")]
        [HttpGet("/export/RecoDb/claimlitigationdates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimLitigationDatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimLitigationDates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimlitigationdates/excel")]
        [HttpGet("/export/RecoDb/claimlitigationdates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimLitigationDatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimLitigationDates(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimotherparties/csv")]
        [HttpGet("/export/RecoDb/claimotherparties/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimOtherPartiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimOtherParties(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimotherparties/excel")]
        [HttpGet("/export/RecoDb/claimotherparties/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimOtherPartiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimOtherParties(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimpreferencesdetails/csv")]
        [HttpGet("/export/RecoDb/claimpreferencesdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimPreferencesDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimPreferencesDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimpreferencesdetails/excel")]
        [HttpGet("/export/RecoDb/claimpreferencesdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimPreferencesDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimPreferencesDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimprincipals/csv")]
        [HttpGet("/export/RecoDb/claimprincipals/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimPrincipalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimPrincipals(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimprincipals/excel")]
        [HttpGet("/export/RecoDb/claimprincipals/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimPrincipalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimPrincipals(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimrapidsearchlists/csv")]
        [HttpGet("/export/RecoDb/claimrapidsearchlists/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimRapidSearchListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimRapidSearchLists(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimrapidsearchlists/excel")]
        [HttpGet("/export/RecoDb/claimrapidsearchlists/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimRapidSearchListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimRapidSearchLists(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimreports/csv")]
        [HttpGet("/export/RecoDb/claimreports/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimReports(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimreports/excel")]
        [HttpGet("/export/RecoDb/claimreports/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimReports(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimreportdetails/csv")]
        [HttpGet("/export/RecoDb/claimreportdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimReportDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimReportDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimreportdetails/excel")]
        [HttpGet("/export/RecoDb/claimreportdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimReportDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimReportDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimsearchlists/csv")]
        [HttpGet("/export/RecoDb/claimsearchlists/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimSearchListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimSearchLists(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimsearchlists/excel")]
        [HttpGet("/export/RecoDb/claimsearchlists/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimSearchListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimSearchLists(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimstatushistories/csv")]
        [HttpGet("/export/RecoDb/claimstatushistories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimStatusHistoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimStatusHistories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimstatushistories/excel")]
        [HttpGet("/export/RecoDb/claimstatushistories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimStatusHistoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimStatusHistories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimsummaries/csv(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimSummariesToCSV(int? ClaimID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimSummaries(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimsummaries/excel(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimSummariesToExcel(int? ClaimID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimSummaries(ClaimID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimtotalincurredbycategories/csv")]
        [HttpGet("/export/RecoDb/claimtotalincurredbycategories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimTotalIncurredByCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimTotalIncurredByCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimtotalincurredbycategories/excel")]
        [HttpGet("/export/RecoDb/claimtotalincurredbycategories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimTotalIncurredByCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimTotalIncurredByCategories(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimtotalincurredbytransactiondates/csv")]
        [HttpGet("/export/RecoDb/claimtotalincurredbytransactiondates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimTotalIncurredByTransactionDatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimTotalIncurredByTransactionDates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimtotalincurredbytransactiondates/excel")]
        [HttpGet("/export/RecoDb/claimtotalincurredbytransactiondates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimTotalIncurredByTransactionDatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimTotalIncurredByTransactionDates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimtransactionsummarybydates/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimTransactionSummaryByDatesToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimTransactionSummaryByDates(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimtransactionsummarybydates/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimTransactionSummaryByDatesToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimTransactionSummaryByDates(ReportDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimants/csv")]
        [HttpGet("/export/RecoDb/claimants/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimants/excel")]
        [HttpGet("/export/RecoDb/claimants/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimants(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimantlitigationroles/csv")]
        [HttpGet("/export/RecoDb/claimantlitigationroles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantLitigationRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimantLitigationRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimantlitigationroles/excel")]
        [HttpGet("/export/RecoDb/claimantlitigationroles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantLitigationRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimantLitigationRoles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimantpaymentsreceiveds/csv")]
        [HttpGet("/export/RecoDb/claimantpaymentsreceiveds/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantPaymentsReceivedsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimantPaymentsReceiveds(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimantpaymentsreceiveds/excel")]
        [HttpGet("/export/RecoDb/claimantpaymentsreceiveds/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantPaymentsReceivedsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimantPaymentsReceiveds(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimantsolicitors/csv")]
        [HttpGet("/export/RecoDb/claimantsolicitors/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantSolicitorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimantSolicitors(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimantsolicitors/excel")]
        [HttpGet("/export/RecoDb/claimantsolicitors/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantSolicitorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimantSolicitors(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimanttotalincurredbycategories/csv")]
        [HttpGet("/export/RecoDb/claimanttotalincurredbycategories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantTotalIncurredByCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimantTotalIncurredByCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimanttotalincurredbycategories/excel")]
        [HttpGet("/export/RecoDb/claimanttotalincurredbycategories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimantTotalIncurredByCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimantTotalIncurredByCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimsclosedquarterlyreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsClosedQuarterlyReportsToCSV(string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsClosedQuarterlyReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimsclosedquarterlyreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsClosedQuarterlyReportsToExcel(string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsClosedQuarterlyReports(StartDate, EndDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/claimswithindemnities/csv")]
        [HttpGet("/export/RecoDb/claimswithindemnities/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsWithIndemnities(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnities/excel")]
        [HttpGet("/export/RecoDb/claimswithindemnities/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsWithIndemnities(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnitypaids/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityPaidsToCSV(int? ProgramID, string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsWithIndemnityPaids(ProgramID, ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnitypaids/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityPaidsToExcel(int? ProgramID, string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsWithIndemnityPaids(ProgramID, ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnitypaiddetaileds/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityPaidDetailedsToCSV(int? ProgramID, string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsWithIndemnityPaidDetaileds(ProgramID, ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnitypaiddetaileds/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityPaidDetailedsToExcel(int? ProgramID, string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsWithIndemnityPaidDetaileds(ProgramID, ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnityreserves/csv(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityReservesToCSV(int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsWithIndemnityReserves(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnityreserves/excel(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityReservesToExcel(int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsWithIndemnityReserves(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnityreservewithdetails/csv(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityReserveWithDetailsToCSV(int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsWithIndemnityReserveWithDetails(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithindemnityreservewithdetails/excel(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithIndemnityReserveWithDetailsToExcel(int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsWithIndemnityReserveWithDetails(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithreservedetailsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithReserveDetailsReportsToCSV(string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetClaimsWithReserveDetailsReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/claimswithreservedetailsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportClaimsWithReserveDetailsReportsToExcel(string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetClaimsWithReserveDetailsReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/cloneclaimprincipals/csv(ClaimID={ClaimID}, ClonedClaimNo='{ClonedClaimNo}', UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCloneClaimPrincipalsToCSV(int? ClaimID, string ClonedClaimNo, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCloneClaimPrincipals(ClaimID, ClonedClaimNo, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/cloneclaimprincipals/excel(ClaimID={ClaimID}, ClonedClaimNo='{ClonedClaimNo}', UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCloneClaimPrincipalsToExcel(int? ClaimID, string ClonedClaimNo, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCloneClaimPrincipals(ClaimID, ClonedClaimNo, UserID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/commissioninstallments/csv")]
        [HttpGet("/export/RecoDb/commissioninstallments/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCommissionInstallmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCommissionInstallments(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/commissioninstallments/excel")]
        [HttpGet("/export/RecoDb/commissioninstallments/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCommissionInstallmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCommissionInstallments(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/costawards/csv")]
        [HttpGet("/export/RecoDb/costawards/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCostAwardsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCostAwards(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/costawards/excel")]
        [HttpGet("/export/RecoDb/costawards/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCostAwardsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCostAwards(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/costofclaimsbytypereports/csv")]
        [HttpGet("/export/RecoDb/costofclaimsbytypereports/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCostOfClaimsByTypeReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCostOfClaimsByTypeReports(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/costofclaimsbytypereports/excel")]
        [HttpGet("/export/RecoDb/costofclaimsbytypereports/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCostOfClaimsByTypeReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCostOfClaimsByTypeReports(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/courtdates/csv")]
        [HttpGet("/export/RecoDb/courtdates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCourtDatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCourtDates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/courtdates/excel")]
        [HttpGet("/export/RecoDb/courtdates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCourtDatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCourtDates(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/cppnoticeofclaimsdetails/csv")]
        [HttpGet("/export/RecoDb/cppnoticeofclaimsdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCppNoticeOfClaimsDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCppNoticeOfClaimsDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/cppnoticeofclaimsdetails/excel")]
        [HttpGet("/export/RecoDb/cppnoticeofclaimsdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCppNoticeOfClaimsDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCppNoticeOfClaimsDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/crossreferencedclaims/csv")]
        [HttpGet("/export/RecoDb/crossreferencedclaims/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCrossReferencedClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCrossReferencedClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/crossreferencedclaims/excel")]
        [HttpGet("/export/RecoDb/crossreferencedclaims/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCrossReferencedClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCrossReferencedClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/currentdiaryreports/csv")]
        [HttpGet("/export/RecoDb/currentdiaryreports/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCurrentDiaryReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrentDiaryReports(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/currentdiaryreports/excel")]
        [HttpGet("/export/RecoDb/currentdiaryreports/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportCurrentDiaryReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrentDiaryReports(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/defensecounselwithopenfiles/csv(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDefenseCounselWithOpenFilesToCSV(int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDefenseCounselWithOpenFiles(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/defensecounselwithopenfiles/excel(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDefenseCounselWithOpenFilesToExcel(int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDefenseCounselWithOpenFiles(ProgramID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/diaries/csv")]
        [HttpGet("/export/RecoDb/diaries/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDiariesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDiaries(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/diaries/excel")]
        [HttpGet("/export/RecoDb/diaries/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDiariesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDiaries(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/diarytemplates/csv")]
        [HttpGet("/export/RecoDb/diarytemplates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDiaryTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDiaryTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/diarytemplates/excel")]
        [HttpGet("/export/RecoDb/diarytemplates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportDiaryTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDiaryTemplates(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/emailfolders/csv")]
        [HttpGet("/export/RecoDb/emailfolders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmailFoldersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmailFolders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/emailfolders/excel")]
        [HttpGet("/export/RecoDb/emailfolders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmailFoldersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmailFolders(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/emaillinkfiles/csv")]
        [HttpGet("/export/RecoDb/emaillinkfiles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmailLinkFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmailLinkFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/emaillinkfiles/excel")]
        [HttpGet("/export/RecoDb/emaillinkfiles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmailLinkFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmailLinkFiles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/emailmessages/csv")]
        [HttpGet("/export/RecoDb/emailmessages/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmailMessagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmailMessages(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/emailmessages/excel")]
        [HttpGet("/export/RecoDb/emailmessages/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmailMessagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmailMessages(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/emptyreservebordereaus/csv")]
        [HttpGet("/export/RecoDb/emptyreservebordereaus/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmptyReserveBordereausToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEmptyReserveBordereaus(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/emptyreservebordereaus/excel")]
        [HttpGet("/export/RecoDb/emptyreservebordereaus/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEmptyReserveBordereausToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEmptyReserveBordereaus(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/eoclaimdetails/csv")]
        [HttpGet("/export/RecoDb/eoclaimdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEoClaimDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEoClaimDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/eoclaimdetails/excel")]
        [HttpGet("/export/RecoDb/eoclaimdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEoClaimDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEoClaimDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/eonoticeofclaimsdetails/csv")]
        [HttpGet("/export/RecoDb/eonoticeofclaimsdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEoNoticeOfClaimsDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetEoNoticeOfClaimsDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/eonoticeofclaimsdetails/excel")]
        [HttpGet("/export/RecoDb/eonoticeofclaimsdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportEoNoticeOfClaimsDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetEoNoticeOfClaimsDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/errordetails/csv")]
        [HttpGet("/export/RecoDb/errordetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportErrorDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetErrorDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/errordetails/excel")]
        [HttpGet("/export/RecoDb/errordetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportErrorDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetErrorDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/errorlogs/csv")]
        [HttpGet("/export/RecoDb/errorlogs/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportErrorLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetErrorLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/errorlogs/excel")]
        [HttpGet("/export/RecoDb/errorlogs/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportErrorLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetErrorLogs(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/experts/csv")]
        [HttpGet("/export/RecoDb/experts/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportExpertsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetExperts(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/experts/excel")]
        [HttpGet("/export/RecoDb/experts/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportExpertsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetExperts(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/files/csv")]
        [HttpGet("/export/RecoDb/files/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/files/excel")]
        [HttpGet("/export/RecoDb/files/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFiles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/filedetails/csv")]
        [HttpGet("/export/RecoDb/filedetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFileDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFileDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/filedetails/excel")]
        [HttpGet("/export/RecoDb/filedetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFileDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFileDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/fileroledetails/csv")]
        [HttpGet("/export/RecoDb/fileroledetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFileRoleDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFileRoleDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/fileroledetails/excel")]
        [HttpGet("/export/RecoDb/fileroledetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFileRoleDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFileRoleDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/filesroles/csv")]
        [HttpGet("/export/RecoDb/filesroles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFilesRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFilesRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/filesroles/excel")]
        [HttpGet("/export/RecoDb/filesroles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFilesRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFilesRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/findopenfilesforregistrants/csv(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFindOpenFilesForRegistrantsToCSV(int? ClaimID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFindOpenFilesForRegistrants(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/findopenfilesforregistrants/excel(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFindOpenFilesForRegistrantsToExcel(int? ClaimID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFindOpenFilesForRegistrants(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/findserviceproviderbyidentityusers/csv(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFindServiceProviderByIdentityUsersToCSV(string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFindServiceProviderByIdentityUsers(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/findserviceproviderbyidentityusers/excel(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFindServiceProviderByIdentityUsersToExcel(string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFindServiceProviderByIdentityUsers(UserID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/firms/csv")]
        [HttpGet("/export/RecoDb/firms/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFirmsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFirms(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/firms/excel")]
        [HttpGet("/export/RecoDb/firms/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFirmsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFirms(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/firmdetails/csv")]
        [HttpGet("/export/RecoDb/firmdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFirmDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFirmDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/firmdetails/excel")]
        [HttpGet("/export/RecoDb/firmdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFirmDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFirmDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/fullbordereaus/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFullBordereausToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFullBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/fullbordereaus/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFullBordereausToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFullBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/fullbordereaurecos/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFullBordereauRecosToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFullBordereauRecos(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/fullbordereaurecos/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFullBordereauRecosToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFullBordereauRecos(ReportDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/fullclaimstatushistories/csv")]
        [HttpGet("/export/RecoDb/fullclaimstatushistories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFullClaimStatusHistoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFullClaimStatusHistories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/fullclaimstatushistories/excel")]
        [HttpGet("/export/RecoDb/fullclaimstatushistories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportFullClaimStatusHistoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFullClaimStatusHistories(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/generalsettings/csv")]
        [HttpGet("/export/RecoDb/generalsettings/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGeneralSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(service.GetGeneralSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generalsettings/excel")]
        [HttpGet("/export/RecoDb/generalsettings/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGeneralSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(service.GetGeneralSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generateclaimnumbers/csv(ProgramID={ProgramID}, ContractYear={ContractYear}, SelectedOccurrence={SelectedOccurrence}, IsIncident={IsIncident}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateClaimNumbersToCSV(int? ProgramID, int? ContractYear, int? SelectedOccurrence, bool? IsIncident, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGenerateClaimNumbers(ProgramID, ContractYear, SelectedOccurrence, IsIncident), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generateclaimnumbers/excel(ProgramID={ProgramID}, ContractYear={ContractYear}, SelectedOccurrence={SelectedOccurrence}, IsIncident={IsIncident}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateClaimNumbersToExcel(int? ProgramID, int? ContractYear, int? SelectedOccurrence, bool? IsIncident, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGenerateClaimNumbers(ProgramID, ContractYear, SelectedOccurrence, IsIncident), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generatenewclaimantclaims/csv(MasterFileID={MasterFileID}, ClaimantID={ClaimantID}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateNewClaimantClaimsToCSV(int? MasterFileID, int? ClaimantID, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGenerateNewClaimantClaims(MasterFileID, ClaimantID, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generatenewclaimantclaims/excel(MasterFileID={MasterFileID}, ClaimantID={ClaimantID}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateNewClaimantClaimsToExcel(int? MasterFileID, int? ClaimantID, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGenerateNewClaimantClaims(MasterFileID, ClaimantID, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generatenewclaimanttradeclaims/csv(MasterClaimID={MasterClaimID}, ClaimantID={ClaimantID}, ReportDate='{ReportDate}', UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateNewClaimantTradeClaimsToCSV(int? MasterClaimID, int? ClaimantID, string ReportDate, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGenerateNewClaimantTradeClaims(MasterClaimID, ClaimantID, ReportDate, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generatenewclaimanttradeclaims/excel(MasterClaimID={MasterClaimID}, ClaimantID={ClaimantID}, ReportDate='{ReportDate}', UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateNewClaimantTradeClaimsToExcel(int? MasterClaimID, int? ClaimantID, string ReportDate, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGenerateNewClaimantTradeClaims(MasterClaimID, ClaimantID, ReportDate, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generatenewoccurrences/csv(ProgramID={ProgramID}, ContractYear={ContractYear}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateNewOccurrencesToCSV(int? ProgramID, int? ContractYear, string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGenerateNewOccurrences(ProgramID, ContractYear, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/generatenewoccurrences/excel(ProgramID={ProgramID}, ContractYear={ContractYear}, UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGenerateNewOccurrencesToExcel(int? ProgramID, int? ContractYear, string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGenerateNewOccurrences(ProgramID, ContractYear, UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getavailableserviceproviders/csv(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetAvailableServiceProvidersToCSV(int? ClaimID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetAvailableServiceProviders(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getavailableserviceproviders/excel(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetAvailableServiceProvidersToExcel(int? ClaimID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetAvailableServiceProviders(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getfilebyids/csv(Id='{Id}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetFileByIdsToCSV(string Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetFileByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getfilebyids/excel(Id='{Id}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetFileByIdsToExcel(string Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetFileByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/gethigherrankedroles/csv(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetHigherRankedRolesToCSV(string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetHigherRankedRoles(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/gethigherrankedroles/excel(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetHigherRankedRolesToExcel(string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetHigherRankedRoles(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getlowerrankedroles/csv(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetLowerRankedRolesToCSV(string UserID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetLowerRankedRoles(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getlowerrankedroles/excel(UserID='{UserID}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetLowerRankedRolesToExcel(string UserID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetLowerRankedRoles(UserID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getmaxdiarytemplatedisplayorders/csv")]
        [HttpGet("/export/RecoDb/getmaxdiarytemplatedisplayorders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetMaxDiaryTemplateDisplayOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetMaxDiaryTemplateDisplayOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getmaxdiarytemplatedisplayorders/excel")]
        [HttpGet("/export/RecoDb/getmaxdiarytemplatedisplayorders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetMaxDiaryTemplateDisplayOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetMaxDiaryTemplateDisplayOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getnextclaimantordernums/csv(claimid={claimid}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetNextClaimantOrderNumsToCSV(int? claimid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetNextClaimantOrderNums(claimid), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getnextclaimantordernums/excel(claimid={claimid}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetNextClaimantOrderNumsToExcel(int? claimid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetNextClaimantOrderNums(claimid), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getnextinsuredordernums/csv(claimid={claimid}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetNextInsuredOrderNumsToCSV(int? claimid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetNextInsuredOrderNums(claimid), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getnextinsuredordernums/excel(claimid={claimid}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetNextInsuredOrderNumsToExcel(int? claimid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetNextInsuredOrderNums(claimid), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getreportdates/csv(ServiceProviderID={ServiceProviderID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetReportDatesToCSV(int? ServiceProviderID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetReportDates(ServiceProviderID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getreportdates/excel(ServiceProviderID={ServiceProviderID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetReportDatesToExcel(int? ServiceProviderID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetReportDates(ServiceProviderID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getsevenyearsclaimindemnities/csv(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetSevenYearsClaimIndemnitiesToCSV(int? ClaimID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetSevenYearsClaimIndemnities(ClaimID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/getsevenyearsclaimindemnities/excel(ClaimID={ClaimID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportGetSevenYearsClaimIndemnitiesToExcel(int? ClaimID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetSevenYearsClaimIndemnities(ClaimID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/insureds/csv")]
        [HttpGet("/export/RecoDb/insureds/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInsuredsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInsureds(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/insureds/excel")]
        [HttpGet("/export/RecoDb/insureds/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInsuredsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInsureds(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/insuredlitigationroles/csv")]
        [HttpGet("/export/RecoDb/insuredlitigationroles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInsuredLitigationRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInsuredLitigationRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/insuredlitigationroles/excel")]
        [HttpGet("/export/RecoDb/insuredlitigationroles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInsuredLitigationRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInsuredLitigationRoles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/invoiceuploads/csv")]
        [HttpGet("/export/RecoDb/invoiceuploads/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvoiceUploadsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvoiceUploads(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/invoiceuploads/excel")]
        [HttpGet("/export/RecoDb/invoiceuploads/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvoiceUploadsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvoiceUploads(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/invoiceuploadfiles/csv")]
        [HttpGet("/export/RecoDb/invoiceuploadfiles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvoiceUploadFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvoiceUploadFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/invoiceuploadfiles/excel")]
        [HttpGet("/export/RecoDb/invoiceuploadfiles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvoiceUploadFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvoiceUploadFiles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/invoiceuploadrowerrors/csv")]
        [HttpGet("/export/RecoDb/invoiceuploadrowerrors/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvoiceUploadRowErrorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvoiceUploadRowErrors(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/invoiceuploadrowerrors/excel")]
        [HttpGet("/export/RecoDb/invoiceuploadrowerrors/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvoiceUploadRowErrorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvoiceUploadRowErrors(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/issuereportings/csv")]
        [HttpGet("/export/RecoDb/issuereportings/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportIssueReportingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetIssueReportings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/issuereportings/excel")]
        [HttpGet("/export/RecoDb/issuereportings/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportIssueReportingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetIssueReportings(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/largelossbordereaus/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLargeLossBordereausToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLargeLossBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/largelossbordereaus/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLargeLossBordereausToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLargeLossBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/lastdefenceclaimreports/csv")]
        [HttpGet("/export/RecoDb/lastdefenceclaimreports/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLastDefenceClaimReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLastDefenceClaimReports(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/lastdefenceclaimreports/excel")]
        [HttpGet("/export/RecoDb/lastdefenceclaimreports/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLastDefenceClaimReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLastDefenceClaimReports(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/losscausetags/csv")]
        [HttpGet("/export/RecoDb/losscausetags/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLossCauseTagsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLossCauseTags(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/losscausetags/excel")]
        [HttpGet("/export/RecoDb/losscausetags/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLossCauseTagsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLossCauseTags(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/losscausetagcounts/csv")]
        [HttpGet("/export/RecoDb/losscausetagcounts/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLossCauseTagCountsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLossCauseTagCounts(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/losscausetagcounts/excel")]
        [HttpGet("/export/RecoDb/losscausetagcounts/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportLossCauseTagCountsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLossCauseTagCounts(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/mostrecentstatuschangedates/csv")]
        [HttpGet("/export/RecoDb/mostrecentstatuschangedates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportMostRecentStatusChangeDatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMostRecentStatusChangeDates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/mostrecentstatuschangedates/excel")]
        [HttpGet("/export/RecoDb/mostrecentstatuschangedates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportMostRecentStatusChangeDatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMostRecentStatusChangeDates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/movementbordereaus/csv(ReportDate='{ReportDate}', PreviousDate='{PreviousDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportMovementBordereausToCSV(string ReportDate, string PreviousDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMovementBordereaus(ReportDate, PreviousDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/movementbordereaus/excel(ReportDate='{ReportDate}', PreviousDate='{PreviousDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportMovementBordereausToExcel(string ReportDate, string PreviousDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMovementBordereaus(ReportDate, PreviousDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/nextclaimdisplayorders/csv")]
        [HttpGet("/export/RecoDb/nextclaimdisplayorders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNextClaimDisplayOrdersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNextClaimDisplayOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/nextclaimdisplayorders/excel")]
        [HttpGet("/export/RecoDb/nextclaimdisplayorders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNextClaimDisplayOrdersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNextClaimDisplayOrders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noactivediarybordereaus/csv")]
        [HttpGet("/export/RecoDb/noactivediarybordereaus/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoActiveDiaryBordereausToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoActiveDiaryBordereaus(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noactivediarybordereaus/excel")]
        [HttpGet("/export/RecoDb/noactivediarybordereaus/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoActiveDiaryBordereausToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoActiveDiaryBordereaus(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/notes/csv")]
        [HttpGet("/export/RecoDb/notes/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNotesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNotes(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/notes/excel")]
        [HttpGet("/export/RecoDb/notes/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNotesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNotes(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noteroles/csv")]
        [HttpGet("/export/RecoDb/noteroles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoteRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoteRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noteroles/excel")]
        [HttpGet("/export/RecoDb/noteroles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoteRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoteRoles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaims/csv")]
        [HttpGet("/export/RecoDb/noticeofclaims/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaims/excel")]
        [HttpGet("/export/RecoDb/noticeofclaims/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaims(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimbrokerages/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimbrokerages/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimBrokeragesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimBrokerages(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimbrokerages/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimbrokerages/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimBrokeragesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimBrokerages(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimclaimants/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimclaimants/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimClaimantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimClaimants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimclaimants/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimclaimants/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimClaimantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimClaimants(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimfiles/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimfiles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimfiles/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimfiles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimFiles(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimlists/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimlists/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimLists(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimlists/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimlists/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimLists(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimpurchasers/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimpurchasers/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimPurchasersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimPurchasers(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimpurchasers/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimpurchasers/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimPurchasersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimPurchasers(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimregistrants/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimregistrants/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimRegistrantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimRegistrants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimregistrants/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimregistrants/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimRegistrantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimRegistrants(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimtrades/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimtrades/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimTradesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimTrades(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimtrades/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimtrades/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimTradesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimTrades(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/noticeofclaimvendors/csv")]
        [HttpGet("/export/RecoDb/noticeofclaimvendors/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimVendorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetNoticeOfClaimVendors(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/noticeofclaimvendors/excel")]
        [HttpGet("/export/RecoDb/noticeofclaimvendors/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportNoticeOfClaimVendorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetNoticeOfClaimVendors(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/occurrences/csv")]
        [HttpGet("/export/RecoDb/occurrences/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrencesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOccurrences(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/occurrences/excel")]
        [HttpGet("/export/RecoDb/occurrences/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrencesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOccurrences(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/occurrenceclaimtrades/csv")]
        [HttpGet("/export/RecoDb/occurrenceclaimtrades/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceClaimTradesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOccurrenceClaimTrades(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/occurrenceclaimtrades/excel")]
        [HttpGet("/export/RecoDb/occurrenceclaimtrades/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceClaimTradesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOccurrenceClaimTrades(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/occurrenceclaimants/csv")]
        [HttpGet("/export/RecoDb/occurrenceclaimants/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceClaimantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOccurrenceClaimants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/occurrenceclaimants/excel")]
        [HttpGet("/export/RecoDb/occurrenceclaimants/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceClaimantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOccurrenceClaimants(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/occurrencedetails/csv")]
        [HttpGet("/export/RecoDb/occurrencedetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOccurrenceDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/occurrencedetails/excel")]
        [HttpGet("/export/RecoDb/occurrencedetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOccurrenceDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/occurrencetotalincurredbycategories/csv")]
        [HttpGet("/export/RecoDb/occurrencetotalincurredbycategories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceTotalIncurredByCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOccurrenceTotalIncurredByCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/occurrencetotalincurredbycategories/excel")]
        [HttpGet("/export/RecoDb/occurrencetotalincurredbycategories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOccurrenceTotalIncurredByCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOccurrenceTotalIncurredByCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/openclaimsbylawfirmreports/csv(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenClaimsByLawFirmReportsToCSV(int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOpenClaimsByLawFirmReports(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/openclaimsbylawfirmreports/excel(ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenClaimsByLawFirmReportsToExcel(int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOpenClaimsByLawFirmReports(ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/openclaimsreports/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenClaimsReportsToCSV(int? ProgramID, string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOpenClaimsReports(ProgramID, ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/openclaimsreports/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenClaimsReportsToExcel(int? ProgramID, string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOpenClaimsReports(ProgramID, ReportDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/openfilesbylawyers/csv")]
        [HttpGet("/export/RecoDb/openfilesbylawyers/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenFilesByLawyersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOpenFilesByLawyers(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/openfilesbylawyers/excel")]
        [HttpGet("/export/RecoDb/openfilesbylawyers/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenFilesByLawyersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOpenFilesByLawyers(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/openstatushistories/csv")]
        [HttpGet("/export/RecoDb/openstatushistories/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenStatusHistoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOpenStatusHistories(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/openstatushistories/excel")]
        [HttpGet("/export/RecoDb/openstatushistories/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOpenStatusHistoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOpenStatusHistories(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/otherparties/csv")]
        [HttpGet("/export/RecoDb/otherparties/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOtherPartiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOtherParties(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/otherparties/excel")]
        [HttpGet("/export/RecoDb/otherparties/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportOtherPartiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOtherParties(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/paramtypes/csv")]
        [HttpGet("/export/RecoDb/paramtypes/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportParamTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetParamTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/paramtypes/excel")]
        [HttpGet("/export/RecoDb/paramtypes/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportParamTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetParamTypes(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/parameters/csv")]
        [HttpGet("/export/RecoDb/parameters/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportParametersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetParameters(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/parameters/excel")]
        [HttpGet("/export/RecoDb/parameters/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportParametersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetParameters(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/parameterdetails/csv")]
        [HttpGet("/export/RecoDb/parameterdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportParameterDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetParameterDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/parameterdetails/excel")]
        [HttpGet("/export/RecoDb/parameterdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportParameterDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetParameterDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/periodpaymentbreakdowns/csv")]
        [HttpGet("/export/RecoDb/periodpaymentbreakdowns/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPeriodPaymentBreakdownsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPeriodPaymentBreakdowns(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/periodpaymentbreakdowns/excel")]
        [HttpGet("/export/RecoDb/periodpaymentbreakdowns/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPeriodPaymentBreakdownsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPeriodPaymentBreakdowns(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/policysummaries/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPolicySummariesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPolicySummaries(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/policysummaries/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPolicySummariesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPolicySummaries(ReportDate, ProgramID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/postalcodes/csv")]
        [HttpGet("/export/RecoDb/postalcodes/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPostalCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPostalCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/postalcodes/excel")]
        [HttpGet("/export/RecoDb/postalcodes/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPostalCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPostalCodes(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/postalcodedetails/csv")]
        [HttpGet("/export/RecoDb/postalcodedetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPostalCodeDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPostalCodeDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/postalcodedetails/excel")]
        [HttpGet("/export/RecoDb/postalcodedetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPostalCodeDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPostalCodeDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/provincialcourtactionsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProvincialCourtActionsReportsToCSV(string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProvincialCourtActionsReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/provincialcourtactionsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProvincialCourtActionsReportsToExcel(string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProvincialCourtActionsReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/queensbenchactionsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportQueensBenchActionsReportsToCSV(string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetQueensBenchActionsReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/queensbenchactionsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportQueensBenchActionsReportsToExcel(string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetQueensBenchActionsReports(StartDate, EndDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/receivers/csv")]
        [HttpGet("/export/RecoDb/receivers/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportReceiversToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReceivers(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/receivers/excel")]
        [HttpGet("/export/RecoDb/receivers/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportReceiversToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReceivers(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/recolloydsbordereaus/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRecoLloydsBordereausToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRecoLloydsBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/recolloydsbordereaus/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRecoLloydsBordereausToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRecoLloydsBordereaus(ReportDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/refactorlogs/csv")]
        [HttpGet("/export/RecoDb/refactorlogs/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRefactorLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRefactorLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/refactorlogs/excel")]
        [HttpGet("/export/RecoDb/refactorlogs/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRefactorLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRefactorLogs(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/registrants/csv")]
        [HttpGet("/export/RecoDb/registrants/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRegistrantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRegistrants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/registrants/excel")]
        [HttpGet("/export/RecoDb/registrants/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRegistrantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRegistrants(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/reservechangehistories/csv(StartDate='{StartDate}', EndDate='{EndDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportReserveChangeHistoriesToCSV(string StartDate, string EndDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReserveChangeHistories(StartDate, EndDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/reservechangehistories/excel(StartDate='{StartDate}', EndDate='{EndDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportReserveChangeHistoriesToExcel(string StartDate, string EndDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReserveChangeHistories(StartDate, EndDate, ProgramID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/roles/csv")]
        [HttpGet("/export/RecoDb/roles/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/roles/excel")]
        [HttpGet("/export/RecoDb/roles/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoles(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/salesclassificationbreakdownbypolicyyearandtradetypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSalesClassificationBreakdownByPolicyYearAndTradeTypesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSalesClassificationBreakdownByPolicyYearAndTradeTypes(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/salesclassificationbreakdownbypolicyyearandtradetypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSalesClassificationBreakdownByPolicyYearAndTradeTypesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSalesClassificationBreakdownByPolicyYearAndTradeTypes(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/salesclassificationbreakdownbytradetypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSalesClassificationBreakdownByTradeTypesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSalesClassificationBreakdownByTradeTypes(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/salesclassificationbreakdownbytradetypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSalesClassificationBreakdownByTradeTypesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSalesClassificationBreakdownByTradeTypes(ReportDate, ProgramID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/sentletters/csv")]
        [HttpGet("/export/RecoDb/sentletters/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSentLettersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSentLetters(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/sentletters/excel")]
        [HttpGet("/export/RecoDb/sentletters/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSentLettersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSentLetters(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/serviceproviders/csv")]
        [HttpGet("/export/RecoDb/serviceproviders/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetServiceProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/serviceproviders/excel")]
        [HttpGet("/export/RecoDb/serviceproviders/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetServiceProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/serviceproviderbordereaus/csv(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderBordereausToCSV(string ReportDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetServiceProviderBordereaus(ReportDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/serviceproviderbordereaus/excel(ReportDate='{ReportDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderBordereausToExcel(string ReportDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetServiceProviderBordereaus(ReportDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/serviceproviderclaimpreferences/csv")]
        [HttpGet("/export/RecoDb/serviceproviderclaimpreferences/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderClaimPreferencesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetServiceProviderClaimPreferences(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/serviceproviderclaimpreferences/excel")]
        [HttpGet("/export/RecoDb/serviceproviderclaimpreferences/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderClaimPreferencesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetServiceProviderClaimPreferences(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/serviceproviderdetails/csv")]
        [HttpGet("/export/RecoDb/serviceproviderdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetServiceProviderDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/serviceproviderdetails/excel")]
        [HttpGet("/export/RecoDb/serviceproviderdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportServiceProviderDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetServiceProviderDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/standardemailaddresses/csv")]
        [HttpGet("/export/RecoDb/standardemailaddresses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportStandardEmailAddressesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetStandardEmailAddresses(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/standardemailaddresses/excel")]
        [HttpGet("/export/RecoDb/standardemailaddresses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportStandardEmailAddressesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetStandardEmailAddresses(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/systemnotices/csv")]
        [HttpGet("/export/RecoDb/systemnotices/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSystemNoticesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSystemNotices(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/systemnotices/excel")]
        [HttpGet("/export/RecoDb/systemnotices/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSystemNoticesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSystemNotices(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/systemnoticereads/csv")]
        [HttpGet("/export/RecoDb/systemnoticereads/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSystemNoticeReadsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSystemNoticeReads(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/systemnoticereads/excel")]
        [HttpGet("/export/RecoDb/systemnoticereads/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSystemNoticeReadsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSystemNoticeReads(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/systemtemplates/csv")]
        [HttpGet("/export/RecoDb/systemtemplates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSystemTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSystemTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/systemtemplates/excel")]
        [HttpGet("/export/RecoDb/systemtemplates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSystemTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSystemTemplates(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/templatedetails/csv")]
        [HttpGet("/export/RecoDb/templatedetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTemplateDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTemplateDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/templatedetails/excel")]
        [HttpGet("/export/RecoDb/templatedetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTemplateDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTemplateDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/tokencaches/csv")]
        [HttpGet("/export/RecoDb/tokencaches/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTokenCachesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTokenCaches(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/tokencaches/excel")]
        [HttpGet("/export/RecoDb/tokencaches/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTokenCachesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTokenCaches(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyallegationandlosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByAllegationAndLossCausesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalClaimsByAllegationAndLossCauses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyallegationandlosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByAllegationAndLossCausesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalClaimsByAllegationAndLossCauses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyboardjuridictions/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByBoardJuridictionsToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalClaimsByBoardJuridictions(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyboardjuridictions/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByBoardJuridictionsToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalClaimsByBoardJuridictions(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyclaimtypeandlosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByClaimTypeAndLossCausesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalClaimsByClaimTypeAndLossCauses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyclaimtypeandlosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByClaimTypeAndLossCausesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalClaimsByClaimTypeAndLossCauses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbylitigationtypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByLitigationTypesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalClaimsByLitigationTypes(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbylitigationtypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsByLitigationTypesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalClaimsByLitigationTypes(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyallegations/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsbyAllegationsToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalClaimsbyAllegations(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclaimsbyallegations/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClaimsbyAllegationsToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalClaimsbyAllegations(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclosedclaimswithindemnitypaids/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClosedClaimsWithIndemnityPaidsToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalClosedClaimsWithIndemnityPaids(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalclosedclaimswithindemnitypaids/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalClosedClaimsWithIndemnityPaidsToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalClosedClaimsWithIndemnityPaids(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totaldollarspaidbylosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalDollarsPaidByLossCausesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalDollarsPaidByLossCauses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totaldollarspaidbylosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalDollarsPaidByLossCausesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalDollarsPaidByLossCauses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalincurredlossesbypolicyyears/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalIncurredLossesByPolicyYearsToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalIncurredLossesByPolicyYears(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalincurredlossesbypolicyyears/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalIncurredLossesByPolicyYearsToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalIncurredLossesByPolicyYears(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalpaidbyclaimstatuses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalPaidByClaimStatusesToCSV(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTotalPaidByClaimStatuses(ReportDate, ProgramID), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/totalpaidbyclaimstatuses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTotalPaidByClaimStatusesToExcel(string ReportDate, int? ProgramID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTotalPaidByClaimStatuses(ReportDate, ProgramID), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/trades/csv")]
        [HttpGet("/export/RecoDb/trades/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTradesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTrades(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/trades/excel")]
        [HttpGet("/export/RecoDb/trades/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTradesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTrades(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/tradedetails/csv")]
        [HttpGet("/export/RecoDb/tradedetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTradeDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTradeDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/tradedetails/excel")]
        [HttpGet("/export/RecoDb/tradedetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTradeDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTradeDetails(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/transactions/csv")]
        [HttpGet("/export/RecoDb/transactions/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTransactionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactions(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/transactions/excel")]
        [HttpGet("/export/RecoDb/transactions/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTransactionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactions(), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/transactionapprovallimits/csv")]
        [HttpGet("/export/RecoDb/transactionapprovallimits/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTransactionApprovalLimitsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactionApprovalLimits(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/transactionapprovallimits/excel")]
        [HttpGet("/export/RecoDb/transactionapprovallimits/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTransactionApprovalLimitsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactionApprovalLimits(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/transactionlistreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTransactionListReportsToCSV(string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTransactionListReports(StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/transactionlistreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTransactionListReportsToExcel(string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTransactionListReports(StartDate, EndDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/userdetails/csv")]
        [HttpGet("/export/RecoDb/userdetails/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUserDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUserDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/userdetails/excel")]
        [HttpGet("/export/RecoDb/userdetails/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUserDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUserDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/voidpayments/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportVoidPaymentsToCSV(int? ProgramID, string StartDate, string EndDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetVoidPayments(ProgramID, StartDate, EndDate), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/voidpayments/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportVoidPaymentsToExcel(int? ProgramID, string StartDate, string EndDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetVoidPayments(ProgramID, StartDate, EndDate), Request.Query), fileName);
        }
        [HttpGet("/export/RecoDb/xrefclaims/csv")]
        [HttpGet("/export/RecoDb/xrefclaims/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportXRefClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetXRefClaims(), Request.Query), fileName);
        }

        [HttpGet("/export/RecoDb/xrefclaims/excel")]
        [HttpGet("/export/RecoDb/xrefclaims/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportXRefClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetXRefClaims(), Request.Query), fileName);
        }
    }
}
