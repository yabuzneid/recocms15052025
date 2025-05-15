using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimList", Schema = "dbo")]
  public partial class ClaimList
  {
    public string Program
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public string Insureds
    {
      get;
      set;
    }
    public string Claimants
    {
      get;
      set;
    }
    public string Broker
    {
      get;
      set;
    }
    public string BrokerOfRecord
    {
      get;
      set;
    }
    public string DefenceCounsel
    {
      get;
      set;
    }
    public string Occurences
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
    public string AdjusterClaimNo
    {
      get;
      set;
    }
    public int? ProgramID
    {
      get;
      set;
    }
    public int? AdjusterID
    {
      get;
      set;
    }
    public int? DefenseCounselID
    {
      get;
      set;
    }
    public int? CoverageCounselID
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public int? FilehandlerID
    {
      get;
      set;
    }
    public bool CoverageIssue
    {
      get;
      set;
    }
    public int? BrokerageOnly
    {
      get;
      set;
    }
    public int? LossCauseID
    {
      get;
      set;
    }
    public int? BrokerageID
    {
      get;
      set;
    }
    public int? AdjusterFirmID
    {
      get;
      set;
    }
    public int? DefenseCounselFirmID
    {
      get;
      set;
    }
    public string Adjuster
    {
      get;
      set;
    }
    public int? ClaimStatusID
    {
      get;
      set;
    }
    public string CounselFileNo
    {
      get;
      set;
    }
    public string Insured1
    {
      get;
      set;
    }
    public string Insured2
    {
      get;
      set;
    }
    public string Insured3
    {
      get;
      set;
    }
    public string Claimant1
    {
      get;
      set;
    }
    public string Claimant2
    {
      get;
      set;
    }
    public string Claimant3
    {
      get;
      set;
    }
    public decimal? TotalReserve
    {
      get;
      set;
    }
    public decimal? TotalPayment
    {
      get;
      set;
    }
    public decimal? TotalRecovery
    {
      get;
      set;
    }
    public decimal? TotalIncurred
    {
      get;
      set;
    }
    public decimal? TotalIndemnity
    {
      get;
      set;
    }
    public decimal? TotalAdjusting
    {
      get;
      set;
    }
    public decimal? TotalLegal
    {
      get;
      set;
    }
    public decimal? TotalExpense
    {
      get;
      set;
    }
    public bool ClaimOrIncident
    {
      get;
      set;
    }
    public string FullAddress
    {
      get;
      set;
    }
    public string ClaimNoDisplay
    {
      get;
      set;
    }
    public string FullAddressDisplay
    {
      get;
      set;
    }
    public string TotalIncurredDisplay
    {
      get;
      set;
    }
    public string TotalReserveDisplay
    {
      get;
      set;
    }
    public string TotalPaymentDisplay
    {
      get;
      set;
    }
    public string TotalRecoveryDisplay
    {
      get;
      set;
    }
    public string Insured1Display
    {
      get;
      set;
    }
    public string Insured2Display
    {
      get;
      set;
    }
    public string Insured3Display
    {
      get;
      set;
    }
    public string Claimant1Display
    {
      get;
      set;
    }
    public string Claimant2Display
    {
      get;
      set;
    }
    public string Claimant3Display
    {
      get;
      set;
    }
    public string FileHandler
    {
      get;
      set;
    }
    public string ReportsTo
    {
      get;
      set;
    }
    public bool NotYetReported
    {
      get;
      set;
    }
    public int? XRef
    {
      get;
      set;
    }
    public decimal? PastIndemnityPaid
    {
      get;
      set;
    }
    public string DefenceCounselInitials
    {
      get;
      set;
    }
    public string CoverageIssueWarning
    {
      get;
      set;
    }
    public string XRefTag
    {
      get;
      set;
    }
    public string LargeLossWarning
    {
      get;
      set;
    }
    public string BrokerageWarning
    {
      get;
      set;
    }
    public string DeductibleWarning
    {
      get;
      set;
    }
    public string NotYetReportedWarning
    {
      get;
      set;
    }
    public string FileHandlerFirm
    {
      get;
      set;
    }
    public int? ReportingDays
    {
      get;
      set;
    }
    public string FileHandlerEmailAddress
    {
      get;
      set;
    }
    public string AdjusterEmailAddress
    {
      get;
      set;
    }
    public string DefenseCounselEmailAddress
    {
      get;
      set;
    }
    public string NoticeOfClaimRefNum
    {
      get;
      set;
    }
    public string Claimant
    {
      get;
      set;
    }
    public DateTime? ReportDate
    {
      get;
      set;
    }
    public DateTime? AgreementDate
    {
      get;
      set;
    }
    public DateTime? CloseDate
    {
      get;
      set;
    }
    public string ClaimantsWithRoles
    {
      get;
      set;
    }
    public string ClaimantSolicitors
    {
      get;
      set;
    }
    public string InsuredsWithRoles
    {
      get;
      set;
    }
    public string OtherPartyDetails
    {
      get;
      set;
    }
    public decimal? TradePrice
    {
      get;
      set;
    }
    public decimal? DepositAmount
    {
      get;
      set;
    }
    public string ClaimDescription
    {
      get;
      set;
    }
    public string Deductible
    {
      get;
      set;
    }
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
    public string TypeOfAction
    {
      get;
      set;
    }
    public string Jurisdiction
    {
      get;
      set;
    }
    public string CourtFileNumber
    {
      get;
      set;
    }
    public DateTime? DateLitigationServed
    {
      get;
      set;
    }
    public string Outcome
    {
      get;
      set;
    }
    public string OffersMade
    {
      get;
      set;
    }
    public string Discoveries
    {
      get;
      set;
    }
    public string Mediations
    {
      get;
      set;
    }
    public string Trials
    {
      get;
      set;
    }
    public DateTime? ServedDate
    {
      get;
      set;
    }
    public DateTime? ReservationOfRightsDate
    {
      get;
      set;
    }
    public bool? MasterFile
    {
      get;
      set;
    }
    public string Brokerage
    {
      get;
      set;
    }
    public string FileHandlerInitials
    {
      get;
      set;
    }
    public string Brokerage1
    {
      get;
      set;
    }
    public string Broker1
    {
      get;
      set;
    }
    public string Builder1
    {
      get;
      set;
    }
    public string ProgramManager
    {
      get;
      set;
    }
    public Guid? ProgramManagerID
    {
      get;
      set;
    }
    public DateTime? LastSubmittedReport
    {
      get;
      set;
    }
    public string FileHandlerPhoneNum
    {
      get;
      set;
    }
    public string BrokerageContactName
    {
      get;
      set;
    }
    public string BrokerageContactPhone
    {
      get;
      set;
    }
    public string BrokerageContactEmail
    {
      get;
      set;
    }
    public string CostAward
    {
      get;
      set;
    }
    public string ReportsToEmail
    {
      get;
      set;
    }
    public int? MasterFileID
    {
      get;
      set;
    }
    public string MasterAdjusterFileNo
    {
      get;
      set;
    }
    public string NoActiveDiaries
    {
      get;
      set;
    }
  }
}
