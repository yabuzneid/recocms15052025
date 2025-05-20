using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using RecoCms6.Models;
using System.Reflection.Emit;

namespace RecoCms6.Data
{
    public partial class RecoDbContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public RecoDbContext(DbContextOptions<RecoDbContext> options):base(options)
    {
    }

    public RecoDbContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<RecoCms6.Models.RecoDb.AccountingAudit>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.AccountingRecoveryAudit>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ActiveFileHandlerDiary>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ActiveUserDiaryReportModel>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ActualDaysOpen>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.AuditTrailDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredCategory>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredType>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.BuilderDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.CheckSystemNotice>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.CheckTransactionLimit>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimBasePrincipal>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentPayment>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentReserf>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimDiaryDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimEmailAddress>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileHandlerAndReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimLagTimeReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimOtherParty>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimPreferencesDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimSummary>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnity>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserveWithDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.CloneClaimPrincipal>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.CurrentDiaryReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.DefenseCounselWithOpenFile>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ErrorDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FileDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FileRoleDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FindOpenFilesForRegistrant>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FindServiceProviderByIdentityUser>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FirmDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.FullClaimStatusHistory>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GenerateClaimNumber>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewClaimantClaim>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewClaimantTradeClaim>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewOccurrence>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetAvailableServiceProvider>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetFileById>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetHigherRankedRole>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetLowerRankedRole>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetMaxDiaryTemplateDisplayOrder>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetNextClaimantOrderNum>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetNextInsuredOrderNum>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetReportDate>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.LastDefenceClaimReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.LossCauseTagCount>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.MostRecentStatusChangeDate>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.NoActiveDiaryBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimList>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimTrade>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsByLawFirmReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OpenFilesByLawyer>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.OpenStatusHistory>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.PeriodPaymentBreakdown>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.PostalCodeDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ProvincialCourtActionsReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.QueensBenchActionsReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByTradeType>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.StandardEmailAddress>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TemplateDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByAllegationAndLossCause>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByBoardJuridiction>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByClaimTypeAndLossCause>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByLitigationType>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsbyAllegation>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalDollarsPaidByLossCause>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TradeDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.TransactionListReport>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.UserDetail>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.VoidPayment>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.XRefClaim>().HasNoKey();
        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>().HasKey(table => new {
          table.ProgramID, table.ClaimInitiationID, table.ClaimOrIncident
        });
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantLitigationRole>().HasKey(table => new {
          table.ClaimantID, table.LitigationRole
        });
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantPaymentsReceived>().HasKey(table => new {
          table.ClaimantID, table.PaymentReceivedDate
        });
        builder.Entity<RecoCms6.Models.RecoDb.CrossReferencedClaim>().HasKey(table => new {
          table.ClaimID, table.XRefClaimID
        });
        builder.Entity<RecoCms6.Models.RecoDb.InsuredLitigationRole>().HasKey(table => new {
          table.InsuredID, table.LitigationRoleID
        });
        builder.Entity<RecoCms6.Models.RecoDb.LossCauseTag>().HasKey(table => new {
          table.ClaimID, table.LossCauseTag1
        });
        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>().HasKey(table => new {
          table.ClaimID, table.DateLetterSent, table.LetterTypeID
        });
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference>().HasKey(table => new {
          table.ServiceProviderID, table.ClaimID
        });
        builder.Entity<RecoCms6.Models.RecoDb.LegalAssistants>()
              .HasOne(la => la.DefenseCounsel)
              .WithMany(sp => sp.AsDefenseCounsel)
              .HasForeignKey(la => la.DefenseCounselID)
              .HasPrincipalKey(sp => sp.ServiceProviderID)
              .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<RecoCms6.Models.RecoDb.LegalAssistants>()
                .HasOne(la => la.LegalAssistant)
                .WithMany(sp => sp.AsLegalAssistant)
                .HasForeignKey(la => la.LegalAssistantID)
                .HasPrincipalKey(sp => sp.ServiceProviderID)
                .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<RecoCms6.Models.RecoDb.LegalAssistants>()
                .HasKey(la => new { la.DefenseCounselID, la.LegalAssistantID });
        builder.Entity<RecoCms6.Models.RecoDb.Administrator>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Administrators)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Administrator>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Administrators1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Appointments)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Appointments)
              .HasForeignKey(i => i.AppointmentType)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Appointments1)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.AuditTrail>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.AuditTrails)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.AutoReservings)
              .HasForeignKey(i => i.ProgramID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.AutoReservings1)
              .HasForeignKey(i => i.ClaimInitiationID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .HasOne(i => i.Registrant)
              .WithMany(i => i.Brokerages)
              .HasForeignKey(i => i.BrokerOfRecordID)
              .HasPrincipalKey(i => i.RegistrantID);
        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Brokerages)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .HasOne(i => i.Administrator)
              .WithMany(i => i.Brokerages)
              .HasForeignKey(i => i.AdministratorID)
              .HasPrincipalKey(i => i.AdministratorID);
        builder.Entity<RecoCms6.Models.RecoDb.BrokerageContact>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.BrokerageContacts)
              .HasForeignKey(i => i.BrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.BrokerageContact>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.BrokerageContacts)
              .HasForeignKey(i => i.BrokerageRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Builder>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Builders)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Builder>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Builders1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.CdpClaimDetails)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.CdpClaimDetails)
              .HasForeignKey(i => i.StatusOfFundsID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .HasOne(i => i.Claim1)
              .WithMany(i => i.CdpClaimDetails1)
              .HasForeignKey(i => i.CDFileID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.CdpClaimDetails1)
              .HasForeignKey(i => i.ByInsurerOrReceiverID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .HasOne(i => i.Claim2)
              .WithMany(i => i.CdpClaimDetails2)
              .HasForeignKey(i => i.RelatedClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Claims)
              .HasForeignKey(i => i.ProgramID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Claims1)
              .HasForeignKey(i => i.ContractYearID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.Claims2)
              .HasForeignKey(i => i.ClaimStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.Claims)
              .HasForeignKey(i => i.AdjusterID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.ServiceProvider1)
              .WithMany(i => i.Claims1)
              .HasForeignKey(i => i.DefenseCounselID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.ServiceProvider2)
              .WithMany(i => i.Claims2)
              .HasForeignKey(i => i.CoverageCounselID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.ServiceProvider3)
              .WithMany(i => i.Claims3)
              .HasForeignKey(i => i.FileHandlerID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.Claims)
              .HasForeignKey(i => i.BrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter3)
              .WithMany(i => i.Claims3)
              .HasForeignKey(i => i.BrokerageTransactionRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter4)
              .WithMany(i => i.Claims4)
              .HasForeignKey(i => i.BrokerageOnly)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter5)
              .WithMany(i => i.Claims5)
              .HasForeignKey(i => i.LossCauseID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Occurrence)
              .WithMany(i => i.Claims)
              .HasForeignKey(i => i.OccurrenceID)
              .HasPrincipalKey(i => i.OccurrenceID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.ServiceProvider4)
              .WithMany(i => i.Claims4)
              .HasForeignKey(i => i.OriginalFileHandlerID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter6)
              .WithMany(i => i.Claims6)
              .HasForeignKey(i => i.ReservationOfRightsID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter7)
              .WithMany(i => i.Claims7)
              .HasForeignKey(i => i.Deductible)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter8)
              .WithMany(i => i.Claims8)
              .HasForeignKey(i => i.PolicyID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.ServiceProvider5)
              .WithMany(i => i.Claims5)
              .HasForeignKey(i => i.MediatorID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter9)
              .WithMany(i => i.Claims9)
              .HasForeignKey(i => i.ClaimTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Claimant)
              .WithMany(i => i.Claims)
              .HasForeignKey(i => i.ClaimantID)
              .HasPrincipalKey(i => i.ClaimantID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Claim1)
              .WithMany(i => i.Claims1)
              .HasForeignKey(i => i.MasterFileID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .HasOne(i => i.Parameter10)
              .WithMany(i => i.Claims10)
              .HasForeignKey(i => i.NotYetReportedByID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileReporting>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.ClaimFileReportings)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileReporting>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.ClaimFileReportings)
              .HasForeignKey(i => i.ServiceProviderID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.ClaimLitigationDates)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.ClaimLitigationDates)
              .HasForeignKey(i => i.LitigationDateTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.ClaimLitigationDates1)
              .HasForeignKey(i => i.LitigationStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.ClaimReports)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.ClaimReports)
              .HasForeignKey(i => i.ClaimReportFlagID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .HasOne(i => i.Firm)
              .WithMany(i => i.ClaimReports)
              .HasForeignKey(i => i.HandlingFirmID)
              .HasPrincipalKey(i => i.FirmID);
            builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .HasOne(i => i.File)
              .WithMany(i => i.ClaimReports)
              .HasForeignKey(i => i.FileId)
              .HasPrincipalKey(i => i.FileID);
            builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.ClaimStatusHistories)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.ClaimStatusHistories)
              .HasForeignKey(i => i.NewStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Claimants)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.Registrant)
              .WithMany(i => i.Claimants)
              .HasForeignKey(i => i.RegistrantID)
              .HasPrincipalKey(i => i.RegistrantID);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Claimants)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Claimants1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.ClaimantSolicitor)
              .WithMany(i => i.Claimants)
              .HasForeignKey(i => i.ClaimantSolicitorID)
              .HasPrincipalKey(i => i.SolicitorID)
              .OnDelete(DeleteBehavior.SetNull);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.Claimants2)
              .HasForeignKey(i => i.TransactionRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.Claimants)
              .HasForeignKey(i => i.CooperatingBrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantLitigationRole>()
              .HasOne(i => i.Claimant)
              .WithMany(i => i.ClaimantLitigationRoles)
              .HasForeignKey(i => i.ClaimantID)
              .HasPrincipalKey(i => i.ClaimantID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantLitigationRole>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.ClaimantLitigationRoles)
              .HasForeignKey(i => i.LitigationRole)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantPaymentsReceived>()
              .HasOne(i => i.Claimant)
              .WithMany(i => i.ClaimantPaymentsReceiveds)
              .HasForeignKey(i => i.ClaimantID)
              .HasPrincipalKey(i => i.ClaimantID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantSolicitor>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.ClaimantSolicitors)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ClaimantSolicitor>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.ClaimantSolicitors1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.CommissionInstallment>()
              .HasOne(i => i.Trade)
              .WithMany(i => i.CommissionInstallments)
              .HasForeignKey(i => i.TradeID)
              .HasPrincipalKey(i => i.TradeID);
        builder.Entity<RecoCms6.Models.RecoDb.CostAward>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.CostAwards)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.CourtDates)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.CourtDates)
              .HasForeignKey(i => i.CourtDateTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.CourtDates)
              .HasForeignKey(i => i.AssignedServiceProviderID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.CrossReferencedClaim>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.CrossReferencedClaims)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.CrossReferencedClaim>()
              .HasOne(i => i.Claim1)
              .WithMany(i => i.CrossReferencedClaims1)
              .HasForeignKey(i => i.XRefClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Diaries)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Diaries)
              .HasForeignKey(i => i.DiaryStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.DiaryTemplate>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.DiaryTemplates)
              .HasForeignKey(i => i.DefaultSendToID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.DiaryTemplate>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.DiaryTemplates1)
              .HasForeignKey(i => i.TemplateTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .HasOne(i => i.EmailFolder1)
              .WithMany(i => i.EmailFolders1)
              .HasForeignKey(i => i.ParentFolderID)
              .HasPrincipalKey(i => i.FolderID);
        builder.Entity<RecoCms6.Models.RecoDb.EmailMessage>()
              .HasOne(i => i.EmailFolder)
              .WithMany(i => i.EmailMessages)
              .HasForeignKey(i => i.ParentFolderID)
              .HasPrincipalKey(i => i.FolderID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.EoClaimDetails)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.EoClaimDetails)
              .HasForeignKey(i => i.ClaimInitiationID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.EoClaimDetails1)
              .HasForeignKey(i => i.ClaimConvertedToID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.EoClaimDetails2)
              .HasForeignKey(i => i.DenialCodeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.EoClaimDetails)
              .HasForeignKey(i => i.AppraiserID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.ServiceProvider1)
              .WithMany(i => i.EoClaimDetails1)
              .HasForeignKey(i => i.DutyOfCareExpertID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.ServiceProvider2)
              .WithMany(i => i.EoClaimDetails2)
              .HasForeignKey(i => i.MediatorID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.ServiceProvider3)
              .WithMany(i => i.EoClaimDetails3)
              .HasForeignKey(i => i.OpposingAppraiserID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.ServiceProvider4)
              .WithMany(i => i.EoClaimDetails4)
              .HasForeignKey(i => i.OpposingDutyOfCareExpertID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter3)
              .WithMany(i => i.EoClaimDetails3)
              .HasForeignKey(i => i.TypeOfOtherInsuranceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter4)
              .WithMany(i => i.EoClaimDetails4)
              .HasForeignKey(i => i.TypeOfActionID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter5)
              .WithMany(i => i.EoClaimDetails5)
              .HasForeignKey(i => i.FirstDemandFormID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter6)
              .WithMany(i => i.EoClaimDetails6)
              .HasForeignKey(i => i.BoardJurisdictionID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter7)
              .WithMany(i => i.EoClaimDetails7)
              .HasForeignKey(i => i.LitigationTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter8)
              .WithMany(i => i.EoClaimDetails8)
              .HasForeignKey(i => i.LitigationDocumentsDeliveredID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter9)
              .WithMany(i => i.EoClaimDetails9)
              .HasForeignKey(i => i.AllegationID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter10)
              .WithMany(i => i.EoClaimDetails10)
              .HasForeignKey(i => i.DeductibleHandledID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter11)
              .WithMany(i => i.EoClaimDetails11)
              .HasForeignKey(i => i.EndOfDealID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter12)
              .WithMany(i => i.EoClaimDetails12)
              .HasForeignKey(i => i.TransactionValueID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter13)
              .WithMany(i => i.EoClaimDetails13)
              .HasForeignKey(i => i.RecoveryID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter14)
              .WithMany(i => i.EoClaimDetails14)
              .HasForeignKey(i => i.RECOComplaintOutcomeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter15)
              .WithMany(i => i.EoClaimDetails15)
              .HasForeignKey(i => i.LitigationRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .HasOne(i => i.Parameter16)
              .WithMany(i => i.EoClaimDetails16)
              .HasForeignKey(i => i.DidDealClose)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.EoNoticeOfClaimsDetails)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.EoNoticeOfClaimsDetails)
              .HasForeignKey(i => i.LitigationDocumentsDeliveredID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ErrorLog>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.ErrorLogs)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Experts)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Experts)
              .HasForeignKey(i => i.ServiceProviderRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.Experts)
              .HasForeignKey(i => i.ServiceProviderID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Experts1)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.Experts2)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .HasOne(i => i.Firm)
              .WithMany(i => i.Experts)
              .HasForeignKey(i => i.FirmID)
              .HasPrincipalKey(i => i.FirmID);
        builder.Entity<RecoCms6.Models.RecoDb.FilesRole>()
              .HasOne(i => i.Role)
              .WithMany(i => i.FilesRoles)
              .HasForeignKey(i => i.RoleID)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<RecoCms6.Models.RecoDb.Firm>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Firms)
              .HasForeignKey(i => i.FirmTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Insureds)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .HasOne(i => i.Registrant)
              .WithMany(i => i.Insureds)
              .HasForeignKey(i => i.RegistrantID)
              .HasPrincipalKey(i => i.RegistrantID);
        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Insureds)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.Insureds)
              .HasForeignKey(i => i.BrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Insureds1)
              .HasForeignKey(i => i.BrokerageProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.InsuredLitigationRole>()
              .HasOne(i => i.Insured)
              .WithMany(i => i.InsuredLitigationRoles)
              .HasForeignKey(i => i.InsuredID)
              .HasPrincipalKey(i => i.InsuredID);
        builder.Entity<RecoCms6.Models.RecoDb.InsuredLitigationRole>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.InsuredLitigationRoles)
              .HasForeignKey(i => i.LitigationRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadFile>()
              .HasOne(i => i.Firm)
              .WithMany(i => i.InvoiceUploadFiles)
              .HasForeignKey(i => i.FirmID)
              .HasPrincipalKey(i => i.FirmID);
        builder.Entity<RecoCms6.Models.RecoDb.IssueReporting>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.IssueReportings)
              .HasForeignKey(i => i.IssueStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.LossCauseTag>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.LossCauseTags)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Notes)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Notes)
              .HasForeignKey(i => i.NoteTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoteRole>()
              .HasOne(i => i.Note)
              .WithMany(i => i.NoteRoles)
              .HasForeignKey(i => i.NoteId)
              .HasPrincipalKey(i => i.NoteID);
        builder.Entity<RecoCms6.Models.RecoDb.NoteRole>()
              .HasOne(i => i.Role)
              .WithMany(i => i.NoteRoles)
              .HasForeignKey(i => i.RoleId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.NoticeOfClaims)
              .HasForeignKey(i => i.ProgramID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.NoticeOfClaims1)
              .HasForeignKey(i => i.NoticeOfClaimStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.NoticeOfClaims)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimBrokerages)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.NoticeOfClaimBrokerages)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.NoticeOfClaimBrokerages1)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimClaimant>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimClaimants)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimFile>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimFiles)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimFile>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.NoticeOfClaimFiles)
              .HasForeignKey(i => i.TypeOfFileID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimPurchaser>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimPurchasers)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimRegistrants)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .HasOne(i => i.NoticeOfClaimBrokerage)
              .WithMany(i => i.NoticeOfClaimRegistrants)
              .HasForeignKey(i => i.NoticeOfClaimBrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.NoticeOfClaimRegistrants)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.NoticeOfClaimRegistrants1)
              .HasForeignKey(i => i.BrokerageTransactionRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimTrade>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimTrades)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimTrade>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.NoticeOfClaimTrades)
              .HasForeignKey(i => i.TradeProvince)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimVendor>()
              .HasOne(i => i.NoticeOfClaim)
              .WithMany(i => i.NoticeOfClaimVendors)
              .HasForeignKey(i => i.NoticeOfClaimID)
              .HasPrincipalKey(i => i.NoticeOfClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Occurrences)
              .HasForeignKey(i => i.ProgramID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.Occurrences)
              .HasForeignKey(i => i.BrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Occurrences1)
              .HasForeignKey(i => i.ContractYearID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.Occurrences2)
              .HasForeignKey(i => i.OccurrenceReason)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.Receiver)
              .WithMany(i => i.Occurrences)
              .HasForeignKey(i => i.ReceiverID)
              .HasPrincipalKey(i => i.ReceiverID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.Occurrences)
              .HasForeignKey(i => i.CounselID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .HasOne(i => i.Parameter3)
              .WithMany(i => i.Occurrences3)
              .HasForeignKey(i => i.OccurenceStatusID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.OtherParties)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Registrant)
              .WithMany(i => i.OtherParties)
              .HasForeignKey(i => i.RegistrantID)
              .HasPrincipalKey(i => i.RegistrantID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.OtherParties)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.OtherParties1)
              .HasForeignKey(i => i.CountryID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.OtherParties2)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.OtherParties)
              .HasForeignKey(i => i.SolicitorID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Parameter3)
              .WithMany(i => i.OtherParties3)
              .HasForeignKey(i => i.OtherPartyTransactionRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.OtherParties)
              .HasForeignKey(i => i.BrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.ParamType>()
              .HasOne(i => i.ParamType1)
              .WithMany(i => i.ParamTypes1)
              .HasForeignKey(i => i.ParentParamTypeID)
              .HasPrincipalKey(i => i.ParamTypeID);
        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .HasOne(i => i.ParamType)
              .WithMany(i => i.Parameters)
              .HasForeignKey(i => i.ParamTypeID)
              .HasPrincipalKey(i => i.ParamTypeID);
        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .HasOne(i => i.ParamType1)
              .WithMany(i => i.Parameters1)
              .HasForeignKey(i => i.ParentParamTypeID)
              .HasPrincipalKey(i => i.ParamTypeID);
        builder.Entity<RecoCms6.Models.RecoDb.PostalCode>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.PostalCodes)
              .HasForeignKey(i => i.CityID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Receiver>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Receivers)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Receiver>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Receivers1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Registrants)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Registrants1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .HasOne(i => i.Brokerage)
              .WithMany(i => i.Registrants)
              .HasForeignKey(i => i.BrokerageID)
              .HasPrincipalKey(i => i.BrokerageID);
        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.SentLetters)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.SentLetters)
              .HasForeignKey(i => i.LetterTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.ServiceProviders)
              .HasForeignKey(i => i.ProvinceID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.ServiceProviders1)
              .HasForeignKey(i => i.PreferredCommunicationMethodID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .HasOne(i => i.Firm)
              .WithMany(i => i.ServiceProviders)
              .HasForeignKey(i => i.FirmID)
              .HasPrincipalKey(i => i.FirmID);
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.ServiceProviders2)
              .HasForeignKey(i => i.ServiceProviderRoleID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.ServiceProviderClaimPreferences)
              .HasForeignKey(i => i.ServiceProviderID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.ServiceProviderClaimPreferences)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Trades)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Trades)
              .HasForeignKey(i => i.Province)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Trades1)
              .HasForeignKey(i => i.HomeInspection)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.Trades2)
              .HasForeignKey(i => i.SPIS)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter3)
              .WithMany(i => i.Trades3)
              .HasForeignKey(i => i.PersonalInterest)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter4)
              .WithMany(i => i.Trades4)
              .HasForeignKey(i => i.Country)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter5)
              .WithMany(i => i.Trades5)
              .HasForeignKey(i => i.TradeTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Builder)
              .WithMany(i => i.Trades)
              .HasForeignKey(i => i.BuilderID)
              .HasPrincipalKey(i => i.BuilderID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Registrant)
              .WithMany(i => i.Trades)
              .HasForeignKey(i => i.SharedAgentID)
              .HasPrincipalKey(i => i.RegistrantID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter6)
              .WithMany(i => i.Trades6)
              .HasForeignKey(i => i.UrbanOrRuralID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .HasOne(i => i.Parameter7)
              .WithMany(i => i.Trades7)
              .HasForeignKey(i => i.DidDealClose)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.Claim)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.ClaimID)
              .HasPrincipalKey(i => i.ClaimID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.IncurredTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.Parameter1)
              .WithMany(i => i.Transactions1)
              .HasForeignKey(i => i.IncurredCategoryID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.Transaction1)
              .WithMany(i => i.Transactions1)
              .HasForeignKey(i => i.RelatedTransactionID)
              .HasPrincipalKey(i => i.TransactionID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.Firm)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.FirmID)
              .HasPrincipalKey(i => i.FirmID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.ServiceProvider)
              .WithMany(i => i.Transactions)
              .HasForeignKey(i => i.ServiceProviderID)
              .HasPrincipalKey(i => i.ServiceProviderID);
        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .HasOne(i => i.Parameter2)
              .WithMany(i => i.Transactions2)
              .HasForeignKey(i => i.ReserveTypeID)
              .HasPrincipalKey(i => i.ParameterID);
        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .HasOne(i => i.TransactionApprovalLimit1)
              .WithMany(i => i.TransactionApprovalLimits1)
              .HasForeignKey(i => i.ApprovalLimitID)
              .HasPrincipalKey(i => i.ApprovalLimitID);
        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .HasOne(i => i.Parameter)
              .WithMany(i => i.TransactionApprovalLimits)
              .HasForeignKey(i => i.ProgramID)
              .HasPrincipalKey(i => i.ParameterID);

        builder.Entity<RecoCms6.Models.RecoDb.Administrator>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())")
              .ValueGeneratedOnAdd();

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.EntryDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.AllDay)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.VisibleTo)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrail>()
              .Property(p => p.AuditTrailDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Builder>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.Verified)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PreconstructionDeal)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PartialIncluded)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PoliceReported)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.CounterClaimExists)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.Agree)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.SharedCommission)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PaymentsOwing)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ByInsurerOrReceiver)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ClaimantStatus)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PaymentMade)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.CoverageCap)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.EntryDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.CoverageIssue)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClassAction)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.NotYetReported)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.SurveyOnClose)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ReportingDays)
              .HasDefaultValueSql("((90))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.MasterFile)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.SurveySent)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.InitialReport)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.Incremental)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .Property(p => p.StatusChangeDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.SharedCommission)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.PaymentsOwing)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ByInsurerOrReceiver)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ClaimantStatus)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.PaymentMade)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.CoverageCap)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.SelfRepresented)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantSolicitor>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.CostAward>()
              .Property(p => p.Paid)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.EntryDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.VisibleTo)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .Property(p => p.TotalCount)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .Property(p => p.UnreadCount)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EmailMessage>()
              .Property(p => p.HasAttachments)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.ClaimOrIncident)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.UrbanOrRural)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.OtherInsurance)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.Litigation)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.MatterSetForTrial)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.CostAwardsGranted)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.IncreasedDeductible)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.RECOComplaint)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.Denied)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .Property(p => p.ClaimantCorrespondenceAttached)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.ErrorLog>()
              .Property(p => p.ErrorLogDateTime)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.VisibleTo)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.LargeLoss)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.Sticky)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.Confidential)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.VisibleToCounsel)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Firm>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.OccurrenceMade)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.SeparateIncidents)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.Active)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.UseSSL)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.PrimaryInsured)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.EntryDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.VisibleTo)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.LargeLoss)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.Sticky)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.Confidential)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.VisibleToCounsel)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.OccurrenceDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.FreezeOrder)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .Property(p => p.Locked)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Receiver>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.Active)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.DealClosed)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.BuilderDeal)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.CommissionPaidInInstallments)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.PreconstructionDeal)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.SharedCommission)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.SharedAgentSubmitClaim)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.OutstandingMoney)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.OutstandingMoneyInTransit)
              .HasDefaultValueSql("((0))");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.DisplayOrder)
              .HasDefaultValueSql("((1))").ValueGeneratedNever();

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.ID)
              .HasDefaultValueSql("(newid())");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.EntryDate)
              .HasDefaultValueSql("(getdate())");

        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .Property(p => p.ApprovalLimit)
              .HasDefaultValueSql("((0))");


        builder.Entity<RecoCms6.Models.RecoDb.AccountingAudit>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.AccountingRecoveryAudit>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ActiveUserDiaryReportModel>()
              .Property(p => p.ReminderDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LastExaminerDiary)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.StartDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.EndDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrail>()
              .Property(p => p.AuditTrailDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrailDetail>()
              .Property(p => p.AuditTrailDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredCategory>()
              .Property(p => p.FiscalYear)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredType>()
              .Property(p => p.FiscalYear)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .Property(p => p.RegistrationExpiryDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.InitialDepositDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.SecondDepositDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.ThirdDepositDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.OtherDepositDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.DateOfDiscoveryOfLoss)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.PoliceReportedDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.TransactionClosingDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.InitialDepositDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.SecondDepositDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ThirdDepositDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.OtherDepositDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.DateOfDiscoveryOfLoss)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PoliceReportedDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClaimPaidDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ServedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ReservationOfRightsDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.AbeyanceDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.RegistrationExpiryDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ServedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsReport>()
              .Property(p => p.DateReported)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDiaryDetail>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDiaryDetail>()
              .Property(p => p.AbeyanceDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.VoidDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.RegistrationExpiryDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLagTimeReport>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLagTimeReport>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.DateLitigationServed)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ServedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ReservationOfRightsDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.LastSubmittedReport)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .Property(p => p.LitigationDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPreferencesDetail>()
              .Property(p => p.DateLastAccessed)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.DateCreated)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.DateLastModified)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.DateSubmitted)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.DateCreated)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.DateLastModified)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.DateSubmitted)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .Property(p => p.StatusChangeDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantPaymentsReceived>()
              .Property(p => p.PaymentReceivedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.DateClosed)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CommissionInstallment>()
              .Property(p => p.DatePaid)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CostAward>()
              .Property(p => p.CostAwardDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .Property(p => p.CourtDate1)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.CloseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.InitialDepositDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.SecondDepositDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.ThirdDepositDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.CurrentDiaryReport>()
              .Property(p => p.DiaryDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.AbeyanceDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ServedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.LitigationDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.ConvertedToLitigation)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DateLitigationServed)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DateOrderMade)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DateCollected)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.PretrialDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.TrialDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.ConvertedToClaimDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DenialLetterDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .Property(p => p.DateServed)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .Property(p => p.DateAccepted)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .Property(p => p.DateAware)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ErrorDetail>()
              .Property(p => p.TimeOfError)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ErrorLog>()
              .Property(p => p.ErrorLogDateTime)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.FileDetail>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ServedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.ConvertedToLitigation)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LastExaminerDiary)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.FullClaimStatusHistory>()
              .Property(p => p.StatusChangeDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.FiscalYear)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.GetReportDate>()
              .Property(p => p.StartDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.GetReportDate>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadFile>()
              .Property(p => p.UploadDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.IssueReporting>()
              .Property(p => p.DateEntered)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ServedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.LastDefenceClaimReport>()
              .Property(p => p.DateSubmitted)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.MostRecentStatusChangeDate>()
              .Property(p => p.MostRecentStatusChangeDate1)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .Property(p => p.DateSubmitted)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimList>()
              .Property(p => p.DateSubmitted)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.OccurrenceDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.FreezeOrderDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.OccurrenceDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.DateOpened)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.DateClosed)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.OpenStatusHistory>()
              .Property(p => p.StatusChangeDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ProvincialCourtActionsReport>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.QueensBenchActionsReport>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.LapseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.DateAsOf)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.RegistrationExpiryDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>()
              .Property(p => p.DateLetterSent)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.StartDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.ClaimDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AgreementDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.ReportDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.CloseDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LastExaminerDiary)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference>()
              .Property(p => p.DateLastAccessed)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.SystemNoticeRead>()
              .Property(p => p.MessageRead)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.TokenCache>()
              .Property(p => p.ExpiresAt)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.LeaseDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.DateClosed)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.AmountCollectedDate)
              .HasColumnType("date");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.EntryDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.VoidDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.InvoicePeriodStartDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.InvoicePeriodEndDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.InvoiceDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.TransactionListReport>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.VoidPayment>()
              .Property(p => p.TransactionDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.VoidPayment>()
              .Property(p => p.VoidDate)
              .HasColumnType("datetime");

        builder.Entity<RecoCms6.Models.RecoDb.AccountingAudit>()
              .Property(p => p.TransactionDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.AccountingAudit>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.AccountingRecoveryAudit>()
              .Property(p => p.TransactionDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.AccountingRecoveryAudit>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActiveFileHandlerDiary>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActiveUserDiaryReportModel>()
              .Property(p => p.ClaimTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActiveUserDiaryReportModel>()
              .Property(p => p.ReminderDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActualDaysOpen>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActualDaysOpen>()
              .Property(p => p.DaysActuallyOpen)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AmountOfClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LegalFees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LegalDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LegalTaxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AdjusterFees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AdjusterDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AdjusterTaxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.TotalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LapseDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.LastExaminerDiary)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ActuaryBordereau>()
              .Property(p => p.AvgYearsofExperience)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Administrator>()
              .Property(p => p.AdministratorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Administrator>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Administrator>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.AppointmentID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.AppointmentType)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.VisibleTo)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Appointment>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrail>()
              .Property(p => p.AuditTrailID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrailDetail>()
              .Property(p => p.AuditTrailID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AuditTrailDetail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>()
              .Property(p => p.ClaimInitiationID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>()
              .Property(p => p.AdjusterReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.AutoReserving>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredCategory>()
              .Property(p => p.ParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredCategory>()
              .Property(p => p.ParamValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredCategory>()
              .Property(p => p.ParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredCategory>()
              .Property(p => p.ParentParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredType>()
              .Property(p => p.ParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredType>()
              .Property(p => p.ParamValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredType>()
              .Property(p => p.ParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.AvailableIncurredType>()
              .Property(p => p.ParentParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BinaryRoleValue>()
              .Property(p => p.BinaryValue)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .Property(p => p.BrokerOfRecordID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Brokerage>()
              .Property(p => p.AdministratorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BrokerageContact>()
              .Property(p => p.BrokerageContactID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BrokerageContact>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BrokerageContact>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BrokerageContact>()
              .Property(p => p.BrokerageRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Builder>()
              .Property(p => p.BuilderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Builder>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Builder>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BuilderDetail>()
              .Property(p => p.BuilderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BuilderDetail>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.BuilderDetail>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.PurchasePrice)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.PurchaseAndSaleAgreeementFileId)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.InitialDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.SecondDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.ThirdDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail>()
              .Property(p => p.OtherDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.StatusOfFundsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ClaimedAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.CDFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.InitialDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.SecondDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ThirdDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PurchasePrice)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.PurchaseAndSaleAgreeementFileId)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.OtherDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ClaimedAmount1)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.ByInsurerOrReceiverID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CdpClaimDetail>()
              .Property(p => p.RelatedClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CheckTransactionLimit>()
              .Property(p => p.ApprovalLimit)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.AdjusterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.DefenseCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.CoverageCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.FileHandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.BrokerageTransactionRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.BrokerageOnly)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.LossCauseID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.OriginalFileHandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ReservationOfRightsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.Deductible)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.PolicyID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ReportingDays)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.MediatorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClaimTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.MasterFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claim>()
              .Property(p => p.NotYetReportedByID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.NoteID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.Sticky)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.LargeLoss)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.Confidential)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimActivityLog>()
              .Property(p => p.AbeyanceDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimBasePrincipal>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.PreferredCommunicationMethod)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.ClaimantOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.ClaimantSolicitorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.RegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.YearsOfExperience)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.TradeRecordSheetID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.AgreementofSaleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.CommissionInvoiceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.StatementOfAdjustmentsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.BuilderAgreementsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.SplitCommissionChequeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.NSFCommissionChequeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimClaimant>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentPayment>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentPayment>()
              .Property(p => p.IncurredTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentPayment>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentReserf>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentReserf>()
              .Property(p => p.IncurredTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimCurrentReserf>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.AdjustingFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.OpenOrClosed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.DefenseCounselFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.CoverageCounselFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsBordereau>()
              .Property(p => p.AvgYearsOfExperience)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsReport>()
              .Property(p => p.DateReported)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDetailsReport>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDiaryDetail>()
              .Property(p => p.DiaryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimDiaryDetail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimEmailAddress>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.ExpertID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.ServiceProviderRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimExpert>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileHandlerAndReport>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileHandlerAndReport>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileReporting>()
              .Property(p => p.FileReportID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileReporting>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileReporting>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.NoteID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.Sticky)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.LargeLoss)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFileSummary>()
              .Property(p => p.VisibleTo)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.VisibleTo)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.FileTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.LargeLoss)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.Sticky)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimFilesByUser>()
              .Property(p => p.Confidential)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.TransactionID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.RelatedTransactionID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.Fees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.Disbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.Taxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.ApplicableDeductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.IncurredTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.IncurredCategoryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimIndividualTransaction>()
              .Property(p => p.ReserveTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.YearsOfExperience)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.InsuredID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimInsured>()
              .Property(p => p.RegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLagTimeReport>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLagTimeReport>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLagTimeReport>()
              .Property(p => p.ClaimLag)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.AdjusterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.DefenseCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.CoverageCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.FilehandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.BrokerageOnly)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.LossCauseID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.AdjusterFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.DefenseCounselFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalIndemnity)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalAdjusting)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalLegal)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TotalExpense)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.XRef)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.PastIndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.ReportingDays)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.TradePrice)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.DepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimList>()
              .Property(p => p.MasterFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .Property(p => p.LitigationDateID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .Property(p => p.LitigationDateTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimLitigationDate>()
              .Property(p => p.LitigationStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimOtherParty>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimOtherParty>()
              .Property(p => p.OtherPartyID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimOtherParty>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.InsuredID1)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.InsuredID2)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.InsuredID3)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.TradePrice)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.DepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.FilehandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimPrincipal>()
              .Property(p => p.AvgYearsOfExperience)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.AdjusterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.DefenseCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.CoverageCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.FileHandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.BrokerageOnly)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.DefenseCounselFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimRapidSearchList>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.ClaimReportID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.ClaimReportFlagID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReport>()
              .Property(p => p.HandlingFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.ClaimReportID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.ClaimReportFlagID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.DefenseCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.CoverageCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.AdjusterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.FilehandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.ReportingDays)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.HandlingFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimReportDetail>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.AdjusterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.DefenseCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.CoverageCounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.FileHandlerID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.BrokerageOnly)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.DefenseCounselFirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimSearchList>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimStatusHistory>()
              .Property(p => p.NewStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.RegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ClaimantOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ClaimantSolicitorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.TransactionRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.CooperatingBrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.ClaimedAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.TradeRecordSheetID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.AgreementofSaleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.CommissionInvoiceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.BuilderAgreementsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.StatementOfAdjustmentsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.SplitCommissionChequeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Claimant>()
              .Property(p => p.NSFCommissionChequeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantLitigationRole>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantLitigationRole>()
              .Property(p => p.LitigationRole)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantPaymentsReceived>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantPaymentsReceived>()
              .Property(p => p.PaymentAmountReceived)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantSolicitor>()
              .Property(p => p.SolicitorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantSolicitor>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantSolicitor>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.RecoveredCosts)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport>()
              .Property(p => p.DateClosed)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnity>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnity>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnity>()
              .Property(p => p.ContractYear)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnity>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnity>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid>()
              .Property(p => p.ClaimsReported)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf>()
              .Property(p => p.ExpenseBalance)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.ClaimAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.ExpenseBalance)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.RecoveredCosts)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CloneClaimPrincipal>()
              .Property(p => p.ClonedClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CommissionInstallment>()
              .Property(p => p.TradeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CommissionInstallment>()
              .Property(p => p.CommissionInstallmentID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CommissionInstallment>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostAward>()
              .Property(p => p.CostAwardID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CostAward>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CostAward>()
              .Property(p => p.CostAward1)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.RecoveredCosts)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .Property(p => p.CourtDateID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .Property(p => p.CourtDateTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CourtDate>()
              .Property(p => p.AssignedServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.NoticeOfClaimDetailsID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.PartialAmountReceived)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.InitialDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.SecondDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.ThirdDepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.BrokerageAgreementFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.PurchaseAgreementFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.TradeRecordSheetFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail>()
              .Property(p => p.CommissionInvoiceFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CrossReferencedClaim>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CrossReferencedClaim>()
              .Property(p => p.XRefClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CurrentDiaryReport>()
              .Property(p => p.ClaimTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.CurrentDiaryReport>()
              .Property(p => p.DiaryDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.DefenseCounselWithOpenFile>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.DiaryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.VisibleTo)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Diary>()
              .Property(p => p.DiaryStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.DiaryTemplate>()
              .Property(p => p.DiaryTemplateID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.DiaryTemplate>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.DiaryTemplate>()
              .Property(p => p.DefaultSendToID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.DiaryTemplate>()
              .Property(p => p.TemplateTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .Property(p => p.FolderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .Property(p => p.ParentFolderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .Property(p => p.TotalCount)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailFolder>()
              .Property(p => p.UnreadCount)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailLinkFile>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailLinkFile>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailMessage>()
              .Property(p => p.MessageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmailMessage>()
              .Property(p => p.ParentFolderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.LapseDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ServedDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EmptyReserveBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.ClaimInitiationID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.ClaimConvertedToID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DenialCodeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.AppraiserID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DutyOfCareExpertID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.MediatorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.OpposingAppraiserID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.OpposingDutyOfCareExpertID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.CoverageReservationsValue)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.TypeOfOtherInsuranceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.TypeOfActionID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.FileOutcomeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.StageSettled)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.FirstDemandFormID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.BoardJurisdictionID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.LitigationTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.LitigationDocumentsDeliveredID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.AllegationID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DeductibleHandledID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.EndOfDealID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.TransactionValueID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.RecoveryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.Misrepresentation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.Negligence)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.NegligentMisrep)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.PunitiveAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.Fraud)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.OtherAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DeductibleAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.RECOComplaintOutcomeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.LitigationRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoClaimDetail>()
              .Property(p => p.DidDealClose)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail>()
              .Property(p => p.LitigationDocumentsDeliveredID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ErrorLog>()
              .Property(p => p.ErrorLogID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ErrorLog>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.ExpertID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.ServiceProviderRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Expert>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.VisibleTo)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.FileTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.File>()
              .Property(p => p.Filesize)
              .HasPrecision(19, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FileDetail>()
              .Property(p => p.FileTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FileDetail>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FileRoleDetail>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FileRoleDetail>()
              .Property(p => p.RoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FilesRole>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FilesRole>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FilesRole>()
              .Property(p => p.RoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FindOpenFilesForRegistrant>()
              .Property(p => p.ParamValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FindServiceProviderByIdentityUser>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Firm>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Firm>()
              .Property(p => p.FirmTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FirmDetail>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FirmDetail>()
              .Property(p => p.FirmTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.LapseDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ServedDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.DefenseFirm)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AmountOfClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LegalFees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LegalDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LegalTaxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AdjusingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AdjusterFees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AdjusterDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AdjusterTaxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.TotalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.TransactionValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.ConvertedToLitigation)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LapseDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.LastExaminerDiary)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullBordereauReco>()
              .Property(p => p.AvgYearsofExperience)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullClaimStatusHistory>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.FullClaimStatusHistory>()
              .Property(p => p.NewStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.Port)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GeneralSetting>()
              .Property(p => p.ImapPort)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewClaimantClaim>()
              .Property(p => p.NewClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewClaimantTradeClaim>()
              .Property(p => p.NewClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewOccurrence>()
              .Property(p => p.NewOccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GenerateNewOccurrence>()
              .Property(p => p.NewClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetAvailableServiceProvider>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetAvailableServiceProvider>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetAvailableServiceProvider>()
              .Property(p => p.Active)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetAvailableServiceProvider>()
              .Property(p => p.FileHandler)
              .HasPrecision(1, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetFileById>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetFileById>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetFileById>()
              .Property(p => p.FileTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetHigherRankedRole>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetLowerRankedRole>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetMaxDiaryTemplateDisplayOrder>()
              .Property(p => p.MaxDisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetNextClaimantOrderNum>()
              .Property(p => p.newOrderNum)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetNextInsuredOrderNum>()
              .Property(p => p.newInsuredOrderNum)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetReportDate>()
              .Property(p => p.StartDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetReportDate>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity>()
              .Property(p => p.ContractYear)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.RegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.TransactionRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.InsuredID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Insured>()
              .Property(p => p.BrokerageProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InsuredLitigationRole>()
              .Property(p => p.InsuredID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InsuredLitigationRole>()
              .Property(p => p.LitigationRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.InvoiceUploadID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.Fees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.Disbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.Taxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.Total)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.RowNumber)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUpload>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadFile>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadFile>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadFile>()
              .Property(p => p.Filesize)
              .HasPrecision(19, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadFile>()
              .Property(p => p.GeneratedInvoiceFilesize)
              .HasPrecision(19, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadRowError>()
              .Property(p => p.ErrorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.InvoiceUploadRowError>()
              .Property(p => p.RowNumber)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.IssueReporting>()
              .Property(p => p.IssueReportingID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.IssueReporting>()
              .Property(p => p.IssueStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.EntryDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ClaimPaidDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.LapseDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ServedDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LargeLossBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.LastDefenceClaimReport>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LastDefenceClaimReport>()
              .Property(p => p.DateSubmitted)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.LossCauseTag>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LossCauseTagCount>()
              .Property(p => p.LossCauseID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.LossCauseTagCount>()
              .Property(p => p.NumberOfTags)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.MostRecentStatusChangeDate>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.ClaimTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.AmountOfClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.TotalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.MovementBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>()
              .Property(p => p.NextClaimantDisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>()
              .Property(p => p.NextInsuredDisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>()
              .Property(p => p.NextOtherDisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>()
              .Property(p => p.NextExpertDisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NextClaimDisplayOrder>()
              .Property(p => p.NextTradeDisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoActiveDiaryBordereau>()
              .Property(p => p.ClaimTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.NoteID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.VisibleTo)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Note>()
              .Property(p => p.NoteTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoteRole>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoteRole>()
              .Property(p => p.NoteId)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoteRole>()
              .Property(p => p.RoleId)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .Property(p => p.NoticeOfClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaim>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimClaimant>()
              .Property(p => p.ID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimClaimant>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimClaimant>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimClaimant>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimFile>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimFile>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimFile>()
              .Property(p => p.TypeOfFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimList>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimList>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimList>()
              .Property(p => p.NoticeOfClaimStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimList>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimPurchaser>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimPurchaser>()
              .Property(p => p.PurchaserID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .Property(p => p.NOCRegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .Property(p => p.NoticeOfClaimBrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .Property(p => p.YearsOfExperience)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant>()
              .Property(p => p.BrokerageTransactionRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimTrade>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimTrade>()
              .Property(p => p.TradeProvince)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimVendor>()
              .Property(p => p.NoticeOfClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.NoticeOfClaimVendor>()
              .Property(p => p.VendorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.TotalClaimedAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.ContractYearID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.OccurrenceReason)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.ReceiverID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.CounselID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.OccurenceStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Occurrence>()
              .Property(p => p.BrokerageProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimTrade>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimTrade>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimTrade>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimTrade>()
              .Property(p => p.TradeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimTrade>()
              .Property(p => p.MasterFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.MasterFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.ClaimantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceClaimant>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.ValueOfTransaction)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.AdjustedGrossClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.ExpectedPayout)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.OccurenceStatusID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceDetail>()
              .Property(p => p.TotalClaimedAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory>()
              .Property(p => p.OccurrenceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsByLawFirmReport>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.ClaimAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.DateOpened)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.DateClosed)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.DaysSinceCreation)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.DaysSinceLastOpened)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OpenClaimsReport>()
              .Property(p => p.TotalDaysOpen)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OpenFilesByLawyer>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenFilesByLawyer>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OpenStatusHistory>()
              .Property(p => p.ParamValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.OpenStatusHistory>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OpenStatusHistory>()
              .Property(p => p.ParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.OtherPartyID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.RegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.CountryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.SolicitorID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.OtherPartyTransactionRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.OtherParty>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParamType>()
              .Property(p => p.ParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParamType>()
              .Property(p => p.ParentParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .Property(p => p.ParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .Property(p => p.ParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .Property(p => p.ParamValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Parameter>()
              .Property(p => p.ParentParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>()
              .Property(p => p.ParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>()
              .Property(p => p.ParamValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>()
              .Property(p => p.ParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>()
              .Property(p => p.ParentParameterID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>()
              .Property(p => p.ParentParamTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ParameterDetail>()
              .Property(p => p.ParamIDAsValue)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PeriodPaymentBreakdown>()
              .Property(p => p.TotalAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PeriodPaymentBreakdown>()
              .Property(p => p.TotalDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.IndemnityPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.AdjustingPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.LegalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.ExpensePayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.TotalRecovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PolicySummary>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.PostalCode>()
              .Property(p => p.CityID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.PostalCodeDetail>()
              .Property(p => p.CityID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.PostalCodeDetail>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ProvincialCourtActionsReport>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.QueensBenchActionsReport>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Receiver>()
              .Property(p => p.ReceiverID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Receiver>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Receiver>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ClaimTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PreviouslyPaidIndemnity)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PreviouslyPaidLegal)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PreviouslyPaidAdjusting)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PreviouslyPaidTotal)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PaidThisMonthIndemnity)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PaidThisMonthLegal)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PaidThisMonthAdjusting)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.PaidThisMonthTotal)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.DeductibleThisMonth)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.SubrogationThisMonth)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.LapseDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.RecoLloydsBordereau>()
              .Property(p => p.DateAsOf)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.RegistrantID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.YearsOfExperience)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Registrant>()
              .Property(p => p.BrokerageID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.AmountClaimed)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.TransactionDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.IndemnityIncreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.IndemnityDecreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.AdjustingIncreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.AdjustingDecreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.LegalIncreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.LegalDecreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.ExpenseIncreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel>()
              .Property(p => p.ExpenseDecreased)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Role>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Role>()
              .Property(p => p.Ranking)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType>()
              .Property(p => p.Open)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType>()
              .Property(p => p.Closed)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByTradeType>()
              .Property(p => p.Open)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByTradeType>()
              .Property(p => p.Closed)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByTradeType>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>()
              .Property(p => p.LetterTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SentLetter>()
              .Property(p => p.FileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.ProvinceID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.PreferredCommunicationMethodID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProvider>()
              .Property(p => p.ServiceProviderRoleID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.ClaimDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AgreementDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.ReportDate)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.CloseDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AmountOfClaim)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.TotalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LegalFees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LegalDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LegalTaxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AdjusterFees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AdjusterDisbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.AdjusterTaxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.TotalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.Deductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.Subrogation)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.TransactionValue)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.ConvertedToLitigation)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.TradeProvince)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.TotalOccuranceIndemnity)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderBordereau>()
              .Property(p => p.LastExaminerDiary)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderDetail>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.ServiceProviderDetail>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SystemNotice>()
              .Property(p => p.SystemNoticeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.SystemTemplate>()
              .Property(p => p.TemplateID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TemplateDetail>()
              .Property(p => p.DiaryTemplateID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TemplateDetail>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TokenCache>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByAllegationAndLossCause>()
              .Property(p => p.ClaimsReported)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByBoardJuridiction>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByClaimTypeAndLossCause>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByLitigationType>()
              .Property(p => p.SmallClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByLitigationType>()
              .Property(p => p.QueensBench)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByLitigationType>()
              .Property(p => p.TotalLitigation)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsByLitigationType>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsbyAllegation>()
              .Property(p => p.Open)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsbyAllegation>()
              .Property(p => p.Closed)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClaimsbyAllegation>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>()
              .Property(p => p.ClaimsReported)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalDollarsPaidByLossCause>()
              .Property(p => p.ClaimsReported)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalDollarsPaidByLossCause>()
              .Property(p => p.TotalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.Open)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.Closed)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.TotalClaims)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.Recovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.ClaimsReported)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.IndemnityReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.IndemnityPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.ExpenseReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.ExpensePaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.AdjustingReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.AdjustingPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.LegalReserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.LegalPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.Recovery)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.TotalPayment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus>()
              .Property(p => p.TotalIncurred)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.TradeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.Province)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.HomeInspection)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.SPIS)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.PersonalInterest)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.Country)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.Price)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.DepositAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.TradeTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.BuyerCDFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.SellerCDFileID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.BuilderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.CommissionPercentage)
              .HasPrecision(53, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.CommissionGross)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.SharedAgentID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.SharedAgentClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.AmountCollected)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.OutstandingMoneyAmount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.UrbanOrRuralID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.CommissionOtherParties)
              .HasPrecision(53, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.AmountPreviouslyPaid)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Trade>()
              .Property(p => p.DidDealClose)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TradeDetail>()
              .Property(p => p.TradeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TradeDetail>()
              .Property(p => p.DisplayOrder)
              .HasPrecision(5, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TradeDetail>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.TransactionID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.ClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.IncurredTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.IncurredCategoryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.RelatedTransactionID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.Fees)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.Disbursements)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.Taxes)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.ApplicableDeductible)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.Transaction>()
              .Property(p => p.ReserveTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .Property(p => p.ApprovalLimitID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .Property(p => p.IncurredTypeID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .Property(p => p.IncurredCategoryID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .Property(p => p.ApprovalLimit)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionApprovalLimit>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionListReport>()
              .Property(p => p.TransactionDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionListReport>()
              .Property(p => p.Reserve)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.TransactionListReport>()
              .Property(p => p.Payment)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.UserDetail>()
              .Property(p => p.FirmID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.UserDetail>()
              .Property(p => p.ServiceProviderID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.VoidPayment>()
              .Property(p => p.TransactionDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.VoidPayment>()
              .Property(p => p.VoidDate)
              .HasPrecision(23, 3);

        builder.Entity<RecoCms6.Models.RecoDb.VoidPayment>()
              .Property(p => p.Amount)
              .HasPrecision(19, 4);

        builder.Entity<RecoCms6.Models.RecoDb.XRefClaim>()
              .Property(p => p.BaseClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.XRefClaim>()
              .Property(p => p.XRefClaimID)
              .HasPrecision(10, 0);

        builder.Entity<RecoCms6.Models.RecoDb.XRefClaim>()
              .Property(p => p.ProgramID)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<RecoCms6.Models.RecoDb.AccountingAudit> AccountingAudits
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.AccountingRecoveryAudit> AccountingRecoveryAudits
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ActiveFileHandlerDiary> ActiveFileHandlerDiaries
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ActiveUserDiaryReportModel> ActiveUserDiaryReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ActualDaysOpen> ActualDaysOpens
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ActuaryBordereau> ActuaryBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Administrator> Administrators
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Appointment> Appointments
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.AuditTrail> AuditTrails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.AuditTrailDetail> AuditTrailDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.AutoReserving> AutoReservings
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.AvailableIncurredCategory> AvailableIncurredCategories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.AvailableIncurredType> AvailableIncurredTypes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.BinaryRoleValue> BinaryRoleValues
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Brokerage> Brokerages
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.BrokerageContact> BrokerageContacts
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Builder> Builders
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.BuilderDetail> BuilderDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CdiNoticeOfClaimDetail> CdiNoticeOfClaimDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CdpClaimDetail> CdpClaimDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CheckSystemNotice> CheckSystemNotices
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CheckTransactionLimit> CheckTransactionLimits
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Claim> Claims
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimActivityLog> ClaimActivityLogs
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimBasePrincipal> ClaimBasePrincipals
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimClaimant> ClaimClaimants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimCurrentPayment> ClaimCurrentPayments
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimCurrentReserf> ClaimCurrentReserves
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimDetailsBordereau> ClaimDetailsBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimDetailsReport> ClaimDetailsReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimDiaryDetail> ClaimDiaryDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimEmailAddress> ClaimEmailAddresses
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimExpert> ClaimExperts
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimFileHandlerAndReport> ClaimFileHandlerAndReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimFileReporting> ClaimFileReportings
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimFileSummary> ClaimFileSummaries
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimFilesByUser> ClaimFilesByUsers
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimIndividualTransaction> ClaimIndividualTransactions
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimInsured> ClaimInsureds
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimLagTimeReport> ClaimLagTimeReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimList> ClaimLists
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimLitigationDate> ClaimLitigationDates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimOtherParty> ClaimOtherParties
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimPreferencesDetail> ClaimPreferencesDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimPrincipal> ClaimPrincipals
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimRapidSearchList> ClaimRapidSearchLists
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimReport> ClaimReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimReportDetail> ClaimReportDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimSearchList> ClaimSearchLists
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimStatusHistory> ClaimStatusHistories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimSummary> ClaimSummaries
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimTotalIncurredByCategory> ClaimTotalIncurredByCategories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimTotalIncurredByTransactionDate> ClaimTotalIncurredByTransactionDates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimTransactionSummaryByDate> ClaimTransactionSummaryByDates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Claimant> Claimants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimantLitigationRole> ClaimantLitigationRoles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimantPaymentsReceived> ClaimantPaymentsReceiveds
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimantSolicitor> ClaimantSolicitors
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimantTotalIncurredByCategory> ClaimantTotalIncurredByCategories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsClosedQuarterlyReport> ClaimsClosedQuarterlyReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsWithIndemnity> ClaimsWithIndemnities
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaid> ClaimsWithIndemnityPaids
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsWithIndemnityPaidDetailed> ClaimsWithIndemnityPaidDetaileds
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserf> ClaimsWithIndemnityReserves
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsWithIndemnityReserveWithDetail> ClaimsWithIndemnityReserveWithDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ClaimsWithReserveDetailsReport> ClaimsWithReserveDetailsReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CloneClaimPrincipal> CloneClaimPrincipals
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CommissionInstallment> CommissionInstallments
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CostAward> CostAwards
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CostOfClaimsByTypeReport> CostOfClaimsByTypeReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CourtDate> CourtDates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CppNoticeOfClaimsDetail> CppNoticeOfClaimsDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CrossReferencedClaim> CrossReferencedClaims
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.CurrentDiaryReport> CurrentDiaryReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.DefenseCounselWithOpenFile> DefenseCounselWithOpenFiles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Diary> Diaries
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.DiaryTemplate> DiaryTemplates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.EmailFolder> EmailFolders
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.EmailLinkFile> EmailLinkFiles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.EmailMessage> EmailMessages
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.EmptyReserveBordereau> EmptyReserveBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.EoClaimDetail> EoClaimDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.EoNoticeOfClaimsDetail> EoNoticeOfClaimsDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ErrorDetail> ErrorDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ErrorLog> ErrorLogs
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Expert> Experts
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.File> Files
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FileDetail> FileDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FileRoleDetail> FileRoleDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FilesRole> FilesRoles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FindOpenFilesForRegistrant> FindOpenFilesForRegistrants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FindServiceProviderByIdentityUser> FindServiceProviderByIdentityUsers
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Firm> Firms
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FirmDetail> FirmDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FullBordereau> FullBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FullBordereauReco> FullBordereauRecos
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.FullClaimStatusHistory> FullClaimStatusHistories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GeneralSetting> GeneralSettings
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GenerateClaimNumber> GenerateClaimNumbers
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GenerateNewClaimantClaim> GenerateNewClaimantClaims
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GenerateNewClaimantTradeClaim> GenerateNewClaimantTradeClaims
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GenerateNewOccurrence> GenerateNewOccurrences
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetAvailableServiceProvider> GetAvailableServiceProviders
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetFileById> GetFileByIds
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetHigherRankedRole> GetHigherRankedRoles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetLowerRankedRole> GetLowerRankedRoles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetMaxDiaryTemplateDisplayOrder> GetMaxDiaryTemplateDisplayOrders
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetNextClaimantOrderNum> GetNextClaimantOrderNums
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetNextInsuredOrderNum> GetNextInsuredOrderNums
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetReportDate> GetReportDates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.GetSevenYearsClaimIndemnity> GetSevenYearsClaimIndemnities
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Insured> Insureds
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.InsuredLitigationRole> InsuredLitigationRoles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.InvoiceUpload> InvoiceUploads
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.InvoiceUploadFile> InvoiceUploadFiles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.InvoiceUploadRowError> InvoiceUploadRowErrors
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.IssueReporting> IssueReportings
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.LargeLossBordereau> LargeLossBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.LastDefenceClaimReport> LastDefenceClaimReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.LossCauseTag> LossCauseTags
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.LossCauseTagCount> LossCauseTagCounts
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.MostRecentStatusChangeDate> MostRecentStatusChangeDates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.MovementBordereau> MovementBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NextClaimDisplayOrder> NextClaimDisplayOrders
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoActiveDiaryBordereau> NoActiveDiaryBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Note> Notes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoteRole> NoteRoles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaim> NoticeOfClaims
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimBrokerage> NoticeOfClaimBrokerages
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimClaimant> NoticeOfClaimClaimants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimFile> NoticeOfClaimFiles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimList> NoticeOfClaimLists
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimPurchaser> NoticeOfClaimPurchasers
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimRegistrant> NoticeOfClaimRegistrants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimTrade> NoticeOfClaimTrades
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.NoticeOfClaimVendor> NoticeOfClaimVendors
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Occurrence> Occurrences
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OccurrenceClaimTrade> OccurrenceClaimTrades
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OccurrenceClaimant> OccurrenceClaimants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OccurrenceDetail> OccurrenceDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OccurrenceTotalIncurredByCategory> OccurrenceTotalIncurredByCategories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OpenClaimsByLawFirmReport> OpenClaimsByLawFirmReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OpenClaimsReport> OpenClaimsReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OpenFilesByLawyer> OpenFilesByLawyers
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OpenStatusHistory> OpenStatusHistories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.OtherParty> OtherParties
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ParamType> ParamTypes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Parameter> Parameters
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ParameterDetail> ParameterDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.PeriodPaymentBreakdown> PeriodPaymentBreakdowns
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.PolicySummary> PolicySummaries
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.PostalCode> PostalCodes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.PostalCodeDetail> PostalCodeDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ProvincialCourtActionsReport> ProvincialCourtActionsReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.QueensBenchActionsReport> QueensBenchActionsReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Receiver> Receivers
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.RecoLloydsBordereau> RecoLloydsBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.RefactorLog> RefactorLogs
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Registrant> Registrants
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ReserveChangeHistoryModel> ReserveChangeHistories
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Role> Roles
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType> SalesClassificationBreakdownByPolicyYearAndTradeTypes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.SalesClassificationBreakdownByTradeType> SalesClassificationBreakdownByTradeTypes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.SentLetter> SentLetters
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ServiceProvider> ServiceProviders
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.LegalAssistants> LegalAssistants
    {
        get;
        set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ServiceProviderBordereau> ServiceProviderBordereaus
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ServiceProviderClaimPreference> ServiceProviderClaimPreferences
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.ServiceProviderDetail> ServiceProviderDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.StandardEmailAddress> StandardEmailAddresses
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.SystemNotice> SystemNotices
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.SystemNoticeRead> SystemNoticeReads
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.SystemTemplate> SystemTemplates
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TemplateDetail> TemplateDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TokenCache> TokenCaches
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalClaimsByAllegationAndLossCause> TotalClaimsByAllegationAndLossCauses
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalClaimsByBoardJuridiction> TotalClaimsByBoardJuridictions
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalClaimsByClaimTypeAndLossCause> TotalClaimsByClaimTypeAndLossCauses
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalClaimsByLitigationType> TotalClaimsByLitigationTypes
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalClaimsbyAllegation> TotalClaimsbyAllegations
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalClosedClaimsWithIndemnityPaid> TotalClosedClaimsWithIndemnityPaids
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalDollarsPaidByLossCause> TotalDollarsPaidByLossCauses
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalIncurredLossesByPolicyYear> TotalIncurredLossesByPolicyYears
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TotalPaidByClaimStatus> TotalPaidByClaimStatuses
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Trade> Trades
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TradeDetail> TradeDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.Transaction> Transactions
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TransactionApprovalLimit> TransactionApprovalLimits
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.TransactionListReport> TransactionListReports
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.UserDetail> UserDetails
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.VoidPayment> VoidPayments
    {
      get;
      set;
    }

    public DbSet<RecoCms6.Models.RecoDb.XRefClaim> XRefClaims
    {
      get;
      set;
    }
  }
}
