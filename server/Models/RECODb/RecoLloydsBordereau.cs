using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("RECOLloydsBordereau", Schema = "dbo")]
  public partial class RecoLloydsBordereau
  {
    public int ClaimTypeID
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Registrants
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string RegistrantNumbers
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Broker
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Claimants
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Status
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Adjusting Firm")]
    public string AdjustingFirm
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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

    [Column("Previously Paid - Indemnity")]
    public decimal? PreviouslyPaidIndemnity
    {
      get;
      set;
    }

    [Column("Previously Paid - Legal")]
    public decimal? PreviouslyPaidLegal
    {
      get;
      set;
    }

    [Column("Previously Paid - Adjusting")]
    public decimal? PreviouslyPaidAdjusting
    {
      get;
      set;
    }

    [Column("Previously Paid - Total")]
    public decimal? PreviouslyPaidTotal
    {
      get;
      set;
    }

    [Column("Paid This Month - Indemnity")]
    public decimal? PaidThisMonthIndemnity
    {
      get;
      set;
    }

    [Column("Paid This Month - Legal")]
    public decimal? PaidThisMonthLegal
    {
      get;
      set;
    }

    [Column("Paid This Month - Adjusting")]
    public decimal? PaidThisMonthAdjusting
    {
      get;
      set;
    }

    [Column("Paid This Month - Total")]
    public decimal? PaidThisMonthTotal
    {
      get;
      set;
    }

    [Column("Deductible This Month")]
    public decimal? DeductibleThisMonth
    {
      get;
      set;
    }

    [Column("Subrogation This Month")]
    public decimal? SubrogationThisMonth
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string TransactionType
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string TransactionValue
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Urban Or Rural")]
    public string UrbanOrRural
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Claim Initiation")]
    public string ClaimInitiation
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Claim Or Incident")]
    public string ClaimOrIncident
    {
      get;
      set;
    }
    public DateTime? LapseDate
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("End of Deal Reason")]
    public string EndofDealReason
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Denied Reason")]
    public string DeniedReason
    {
      get;
      set;
    }
    public string Program
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Date As Of")]
    public DateTime? DateAsOf
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
  }
}
