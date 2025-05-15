using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ServiceProviderBordereau", Schema = "dbo")]
  public partial class ServiceProviderBordereau
  {

    [Column("Program Name")]
    public string ProgramName
    {
      get;
      set;
    }

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
    public string DefenseFirm
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
    public string StatusOfFunds
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

    [Column("Adjusting Paid")]
    public decimal? AdjustingPaid
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
    public int? TransactionValue
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
    public int? TradeProvince
    {
      get;
      set;
    }
    public string TradePostalCode
    {
      get;
      set;
    }
    public string ClaimDescription
    {
      get;
      set;
    }
    public decimal? TotalOccuranceIndemnity
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
  }
}
