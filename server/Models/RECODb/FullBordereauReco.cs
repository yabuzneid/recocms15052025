using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FullBordereau_RECO", Schema = "dbo")]
  public partial class FullBordereauReco
  {

    [Column("Contract Year")]
    public string ContractYear
    {
      get;
      set;
    }
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
    public string Registrants
    {
      get;
      set;
    }
    public string RegistrantNumbers
    {
      get;
      set;
    }
    public string RegistrantEmail
    {
      get;
      set;
    }
    public string Broker
    {
      get;
      set;
    }
    public string Claimant
    {
      get;
      set;
    }

    [Column("Claimant Email Address")]
    public string ClaimantEmailAddress
    {
      get;
      set;
    }
    public string Program
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }

    [Column("Coverage Issue")]
    public string CoverageIssue
    {
      get;
      set;
    }

    [Column("Defense Counsel")]
    public string DefenseCounsel
    {
      get;
      set;
    }

    [Column("Defense Firm")]
    public int? DefenseFirm
    {
      get;
      set;
    }
    public string Adjuster
    {
      get;
      set;
    }

    [Column("Adjusting Firm")]
    public string AdjustingFirm
    {
      get;
      set;
    }

    [Column("File Handler")]
    public string FileHandler
    {
      get;
      set;
    }

    [Column("Coverage Counsel")]
    public string CoverageCounsel
    {
      get;
      set;
    }

    [Column("Coverage Firm")]
    public string CoverageFirm
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
    public DateTime? CloseDate
    {
      get;
      set;
    }
    public decimal? AmountOfClaim
    {
      get;
      set;
    }

    [Column("Status of Funds")]
    public string StatusofFunds
    {
      get;
      set;
    }

    [Column("Indemnity Reserve")]
    public decimal? IndemnityReserve
    {
      get;
      set;
    }

    [Column("Legal Reserve")]
    public decimal? LegalReserve
    {
      get;
      set;
    }

    [Column("Adjusting Reserve")]
    public decimal? AdjustingReserve
    {
      get;
      set;
    }

    [Column("Total Reserve")]
    public decimal? TotalReserve
    {
      get;
      set;
    }

    [Column("Indemnity Paid")]
    public decimal? IndemnityPaid
    {
      get;
      set;
    }

    [Column("Legal Paid")]
    public decimal? LegalPaid
    {
      get;
      set;
    }

    [Column("Legal Fees")]
    public decimal? LegalFees
    {
      get;
      set;
    }

    [Column("Legal Disbursements")]
    public decimal? LegalDisbursements
    {
      get;
      set;
    }

    [Column("Legal Taxes")]
    public decimal? LegalTaxes
    {
      get;
      set;
    }

    [Column("Adjusing Paid")]
    public decimal? AdjusingPaid
    {
      get;
      set;
    }

    [Column("Adjuster Fees")]
    public decimal? AdjusterFees
    {
      get;
      set;
    }

    [Column("Adjuster Disbursements")]
    public decimal? AdjusterDisbursements
    {
      get;
      set;
    }

    [Column("Adjuster Taxes")]
    public decimal? AdjusterTaxes
    {
      get;
      set;
    }

    [Column("Total Paid")]
    public decimal? TotalPaid
    {
      get;
      set;
    }
    public decimal? Deductible
    {
      get;
      set;
    }
    public decimal? Subrogation
    {
      get;
      set;
    }

    [Column("Total Incurred")]
    public decimal? TotalIncurred
    {
      get;
      set;
    }
    public string TransactionType
    {
      get;
      set;
    }
    public decimal? TransactionValue
    {
      get;
      set;
    }
    public string UrbanOrRural
    {
      get;
      set;
    }

    [Column("Current Claim Status")]
    public string CurrentClaimStatus
    {
      get;
      set;
    }

    [Column("Claim or Incident")]
    public string ClaimorIncident
    {
      get;
      set;
    }

    [Column("Converted To Litigation")]
    public DateTime? ConvertedToLitigation
    {
      get;
      set;
    }

    [Column("Claim Initiation")]
    public string ClaimInitiation
    {
      get;
      set;
    }
    public DateTime? LapseDate
    {
      get;
      set;
    }

    [Column("End of Deal Reason")]
    public string EndofDealReason
    {
      get;
      set;
    }

    [Column("Denied Reason")]
    public string DeniedReason
    {
      get;
      set;
    }
    public string TradeAddress
    {
      get;
      set;
    }
    public string TradeCity
    {
      get;
      set;
    }
    public string TradeProvince
    {
      get;
      set;
    }
    public string TradePostalCode
    {
      get;
      set;
    }

    [Column("Loss Cause Desc")]
    public string LossCauseDesc
    {
      get;
      set;
    }
    public string LossCauseTags
    {
      get;
      set;
    }
    public string ClaimDescription
    {
      get;
      set;
    }

    [Column("Last Examiner Diary")]
    public DateTime? LastExaminerDiary
    {
      get;
      set;
    }

    [Column("Avg Years of Experience")]
    public int? AvgYearsofExperience
    {
      get;
      set;
    }
    public string ApplicableParty
    {
      get;
      set;
    }
  }
}
