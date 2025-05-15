using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FullBordereau", Schema = "dbo")]
  public partial class FullBordereau
  {
    public int ProgramID
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

    [Column("Claim Status")]
    public string ClaimStatus
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Insureds
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
    public string Address
    {
      get;
      set;
    }
    public decimal? AmountClaimed
    {
      get;
      set;
    }
    public string Adjuster
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
    public string CounselFileNo
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

    [Column("File Handler")]
    public string FileHandler
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string ClaimantSolicitors
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string ClaimantSolicitorFirms
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Brokerage
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Broker1
    {
      get;
      set;
    }
    public string ClaimType
    {
      get;
      set;
    }

    [Column("Brokerage Transaction Role")]
    public string BrokerageTransactionRole
    {
      get;
      set;
    }
    public DateTime? CloseDate
    {
      get;
      set;
    }
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

    [Column("Applicable Party")]
    public string ApplicableParty
    {
      get;
      set;
    }

    [Column("Loss Cause")]
    public string LossCause
    {
      get;
      set;
    }
    public string OccurrenceNo
    {
      get;
      set;
    }
    public decimal? ValueOfTransaction
    {
      get;
      set;
    }
    public decimal? ExpectedPayout
    {
      get;
      set;
    }
    public decimal? AdjustedGrossClaim
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Not Yet Reported")]
    public string NotYetReported
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Class Action")]
    public string ClassAction
    {
      get;
      set;
    }
    public string LitigationType
    {
      get;
      set;
    }
    public string ClaimDescription
    {
      get;
      set;
    }
    public decimal? IndemnityReserve
    {
      get;
      set;
    }
    public decimal? IndemnityPayment
    {
      get;
      set;
    }
    public decimal? LegalReserve
    {
      get;
      set;
    }
    public decimal? LegalPayment
    {
      get;
      set;
    }
    public decimal? AdjustingReserve
    {
      get;
      set;
    }
    public decimal? AdjustingPayment
    {
      get;
      set;
    }
    public decimal? ExpenseReserve
    {
      get;
      set;
    }
    public decimal? ExpensePayment
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
  }
}
