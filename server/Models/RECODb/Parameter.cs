using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Parameters", Schema = "dbo")]
  public partial class Parameter
  {
    public int ParamTypeID
    {
      get;
      set;
    }
    public ParamType ParamType { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ParameterID
    {
      get;
      set;
    }

    public ICollection<Diary> Diaries { get; set; }
    public ICollection<Claimant> Claimants { get; set; }
    public ICollection<Claimant> Claimants1 { get; set; }
    public ICollection<Claimant> Claimants2 { get; set; }
    public ICollection<EoNoticeOfClaimsDetail> EoNoticeOfClaimsDetails { get; set; }
    public ICollection<Expert> Experts { get; set; }
    public ICollection<Expert> Experts1 { get; set; }
    public ICollection<Expert> Experts2 { get; set; }
    public ICollection<ServiceProvider> ServiceProviders { get; set; }
    public ICollection<ServiceProvider> ServiceProviders1 { get; set; }
    public ICollection<ServiceProvider> ServiceProviders2 { get; set; }
    public ICollection<ClaimantLitigationRole> ClaimantLitigationRoles { get; set; }
    public ICollection<Trade> Trades { get; set; }
    public ICollection<Trade> Trades1 { get; set; }
    public ICollection<Trade> Trades2 { get; set; }
    public ICollection<Trade> Trades3 { get; set; }
    public ICollection<Trade> Trades4 { get; set; }
    public ICollection<Trade> Trades5 { get; set; }
    public ICollection<Trade> Trades6 { get; set; }
    public ICollection<Trade> Trades7 { get; set; }
    public ICollection<Brokerage> Brokerages { get; set; }
    public ICollection<Note> Notes { get; set; }
    public ICollection<BrokerageContact> BrokerageContacts { get; set; }
    public ICollection<ClaimStatusHistory> ClaimStatusHistories { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Transaction> Transactions1 { get; set; }
    public ICollection<Transaction> Transactions2 { get; set; }
    public ICollection<ClaimReport> ClaimReports { get; set; }
    public ICollection<Occurrence> Occurrences { get; set; }
    public ICollection<Occurrence> Occurrences1 { get; set; }
    public ICollection<Occurrence> Occurrences2 { get; set; }
    public ICollection<Occurrence> Occurrences3 { get; set; }
    public ICollection<NoticeOfClaim> NoticeOfClaims { get; set; }
    public ICollection<NoticeOfClaim> NoticeOfClaims1 { get; set; }
    public ICollection<TransactionApprovalLimit> TransactionApprovalLimits { get; set; }
    public ICollection<DiaryTemplate> DiaryTemplates { get; set; }
    public ICollection<DiaryTemplate> DiaryTemplates1 { get; set; }
    public ICollection<Insured> Insureds { get; set; }
    public ICollection<Insured> Insureds1 { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public ICollection<Claim> Claims1 { get; set; }
    public ICollection<Claim> Claims2 { get; set; }
    public ICollection<Claim> Claims3 { get; set; }
    public ICollection<Claim> Claims4 { get; set; }
    public ICollection<Claim> Claims5 { get; set; }
    public ICollection<Claim> Claims6 { get; set; }
    public ICollection<Claim> Claims7 { get; set; }
    public ICollection<Claim> Claims8 { get; set; }
    public ICollection<Claim> Claims9 { get; set; }
    public ICollection<Claim> Claims10 { get; set; }
    public ICollection<CdpClaimDetail> CdpClaimDetails { get; set; }
    public ICollection<CdpClaimDetail> CdpClaimDetails1 { get; set; }
    public ICollection<ClaimLitigationDate> ClaimLitigationDates { get; set; }
    public ICollection<ClaimLitigationDate> ClaimLitigationDates1 { get; set; }
    public ICollection<AutoReserving> AutoReservings { get; set; }
    public ICollection<AutoReserving> AutoReservings1 { get; set; }
    public ICollection<Builder> Builders { get; set; }
    public ICollection<Builder> Builders1 { get; set; }
    public ICollection<PostalCode> PostalCodes { get; set; }
    public ICollection<Registrant> Registrants { get; set; }
    public ICollection<Registrant> Registrants1 { get; set; }
    public ICollection<Firm> Firms { get; set; }
    public ICollection<ClaimantSolicitor> ClaimantSolicitors { get; set; }
    public ICollection<ClaimantSolicitor> ClaimantSolicitors1 { get; set; }
    public ICollection<SentLetter> SentLetters { get; set; }
    public ICollection<NoticeOfClaimTrade> NoticeOfClaimTrades { get; set; }
    public ICollection<NoticeOfClaimBrokerage> NoticeOfClaimBrokerages { get; set; }
    public ICollection<NoticeOfClaimBrokerage> NoticeOfClaimBrokerages1 { get; set; }
    public ICollection<InsuredLitigationRole> InsuredLitigationRoles { get; set; }
    public ICollection<Administrator> Administrators { get; set; }
    public ICollection<Administrator> Administrators1 { get; set; }
    public ICollection<NoticeOfClaimRegistrant> NoticeOfClaimRegistrants { get; set; }
    public ICollection<NoticeOfClaimRegistrant> NoticeOfClaimRegistrants1 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails1 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails2 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails3 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails4 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails5 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails6 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails7 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails8 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails9 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails10 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails11 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails12 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails13 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails14 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails15 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails16 { get; set; }
    public ICollection<CourtDate> CourtDates { get; set; }
    public ICollection<OtherParty> OtherParties { get; set; }
    public ICollection<OtherParty> OtherParties1 { get; set; }
    public ICollection<OtherParty> OtherParties2 { get; set; }
    public ICollection<OtherParty> OtherParties3 { get; set; }
    public ICollection<NoticeOfClaimFile> NoticeOfClaimFiles { get; set; }
    public ICollection<IssueReporting> IssueReportings { get; set; }
    public ICollection<Receiver> Receivers { get; set; }
    public ICollection<Receiver> Receivers1 { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Appointment> Appointments1 { get; set; }
    public string ParamAbbrev
    {
      get;
      set;
    }
    public string ParamDesc
    {
      get;
      set;
    }
    public decimal? ParamValue
    {
      get;
      set;
    }
    public bool Locked
    {
      get;
      set;
    }
    public int? ParentParamTypeID
    {
      get;
      set;
    }
    public ParamType ParamType1 { get; set; }
  }
}
