using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("MovementBordereau", Schema = "dbo")]
  public partial class MovementBordereau
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
    public string Program
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
    public string Claimant
    {
      get;
      set;
    }
    public string Status
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
    public decimal? AmountOfClaim
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Legal Paid")]
    public decimal LegalPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Adjusting Paid")]
    public decimal AdjustingPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Indemnity Paid")]
    public decimal IndemnityPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Legal Reserve")]
    public decimal LegalReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Adjusting Reserve")]
    public decimal AdjustingReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Indemnity Reserve")]
    public decimal IndemnityReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Deductible
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Subrogation
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Total Paid")]
    public decimal TotalPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Total Reserve")]
    public decimal TotalReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Total Incurred")]
    public decimal TotalIncurred
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
    public string ClaimDescription
    {
      get;
      set;
    }
  }
}
