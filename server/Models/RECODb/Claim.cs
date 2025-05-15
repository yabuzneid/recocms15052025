using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Claims", Schema = "dbo")]
  public partial class Claim
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaimID
    {
      get;
      set;
    }

    public ICollection<Diary> Diaries { get; set; }
    public ICollection<Claimant> Claimants { get; set; }
    public ICollection<Expert> Experts { get; set; }
    public ICollection<ErrorLog> ErrorLogs { get; set; }
    public ICollection<Trade> Trades { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<ClaimStatusHistory> ClaimStatusHistories { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<ClaimReport> ClaimReports { get; set; }
    public ICollection<NoticeOfClaim> NoticeOfClaims { get; set; }
    public ICollection<Insured> Insureds { get; set; }
    public ICollection<Claim> Claims1 { get; set; }
    public ICollection<CdpClaimDetail> CdpClaimDetails { get; set; }
    public ICollection<CdpClaimDetail> CdpClaimDetails1 { get; set; }
    public ICollection<CdpClaimDetail> CdpClaimDetails2 { get; set; }
    public ICollection<ClaimLitigationDate> ClaimLitigationDates { get; set; }
    public ICollection<CrossReferencedClaim> CrossReferencedClaims { get; set; }
    public ICollection<CrossReferencedClaim> CrossReferencedClaims1 { get; set; }
    public ICollection<ClaimFileReporting> ClaimFileReportings { get; set; }
    public ICollection<CostAward> CostAwards { get; set; }
    public ICollection<SentLetter> SentLetters { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails { get; set; }
    public ICollection<AuditTrail> AuditTrails { get; set; }
    public ICollection<CourtDate> CourtDates { get; set; }
    public ICollection<OtherParty> OtherParties { get; set; }
    public ICollection<LossCauseTag> LossCauseTags { get; set; }
    public ICollection<ServiceProviderClaimPreference> ServiceProviderClaimPreferences { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public string ClaimNo
    {
      get;
      set;
    }
    public string AdjusterClaimNo
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int ContractYearID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public int ClaimStatusID
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public int? AdjusterID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
    public int? DefenseCounselID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider1 { get; set; }
    public int? CoverageCounselID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider2 { get; set; }
    public int? FileHandlerID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider3 { get; set; }
    public int? BrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
    public int? BrokerageTransactionRoleID
    {
      get;
      set;
    }
    public Parameter Parameter3 { get; set; }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public DateTime? ClaimDate
    {
      get;
      set;
    }
    public DateTime? AgreementDate
    {
      get;
      set;
    }
    public DateTime? ReportDate
    {
      get;
      set;
    }
    public DateTime? ClaimPaidDate
    {
      get;
      set;
    }
    public DateTime? LapseDate
    {
      get;
      set;
    }
    public DateTime? ServedDate
    {
      get;
      set;
    }
    public bool CoverageIssue
    {
      get;
      set;
    }
    public bool ClassAction
    {
      get;
      set;
    }
    public bool NotYetReported
    {
      get;
      set;
    }
    public int? BrokerageOnly
    {
      get;
      set;
    }
    public Parameter Parameter4 { get; set; }
    public string ClaimDescription
    {
      get;
      set;
    }
    public int? LossCauseID
    {
      get;
      set;
    }
    public Parameter Parameter5 { get; set; }
    public bool SurveyOnClose
    {
      get;
      set;
    } = true;
    public int? OccurrenceID
    {
      get;
      set;
    }
    public Occurrence Occurrence { get; set; }
    public DateTime? CloseDate
    {
      get;
      set;
    }
    public int? OriginalFileHandlerID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider4 { get; set; }
    public string CounselFileNo
    {
      get;
      set;
    }
    public int? ReservationOfRightsID
    {
      get;
      set;
    }
    public Parameter Parameter6 { get; set; }
    public int? Deductible
    {
      get;
      set;
    }
    public Parameter Parameter7 { get; set; }
    public string ReservationOfRightsOther
    {
      get;
      set;
    }
    public int? PolicyID
    {
      get;
      set;
    }
    public Parameter Parameter8 { get; set; }
    public int? ReportingDays
    {
      get;
      set;
    }
    public int? MediatorID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider5 { get; set; }
    public string Liability
    {
      get;
      set;
    }
    public string Apportionment
    {
      get;
      set;
    }
    public string RealDamages
    {
      get;
      set;
    }
    public string LossPotential
    {
      get;
      set;
    }
    public string CoverageIssues
    {
      get;
      set;
    }
    public string CurrentPlan
    {
      get;
      set;
    }
    public decimal? AmountClaimed
    {
      get;
      set;
    }
    public DateTime? ReservationOfRightsDate
    {
      get;
      set;
    }
    public bool MasterFile
    {
      get;
      set;
    }
    public int? ClaimTypeID
    {
      get;
      set;
    }
    public Parameter Parameter9 { get; set; }
    public bool SurveySent
    {
      get;
      set;
    }
    public int? ClaimantID
    {
      get;
      set;
    }
    public Claimant Claimant { get; set; }
    public int? MasterFileID
    {
      get;
      set;
    }
    public Claim Claim1 { get; set; }
    public int? NotYetReportedByID
    {
      get;
      set;
    }
    public Parameter Parameter10 { get; set; }
    public string ClaimDetails
    {
      get;
      set;
    }
  }
}
