using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CostOfClaimsByTypeReport", Schema = "dbo")]
  public partial class CostOfClaimsByTypeReport
  {

    [Column("Claim Status")]
    public string ClaimStatus
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }

    [Column("Claim Type")]
    public string ClaimType
    {
      get;
      set;
    }

    [Column("Cause of Claim")]
    public string CauseofClaim
    {
      get;
      set;
    }
    public string Details
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal IndemnityReserve
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
    public decimal AdjustingReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal AdjustingPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal LegalReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal LegalPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal ExpenseReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal ExpensePaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal RecoveredCosts
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal TotalIncurred
    {
      get;
      set;
    }
  }
}
