using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalIncurredLossesByPolicyYear", Schema = "dbo")]
  public partial class TotalIncurredLossesByPolicyYear
  {

    [Column("Policy Year")]
    public string PolicyYear
    {
      get;
      set;
    }
    public int? Open
    {
      get;
      set;
    }
    public int? Closed
    {
      get;
      set;
    }
    public int? TotalClaims
    {
      get;
      set;
    }
    public decimal? IndemnityReserve
    {
      get;
      set;
    }
    public decimal? IndemnityPaid
    {
      get;
      set;
    }
    public decimal? ExpenseReserve
    {
      get;
      set;
    }
    public decimal? ExpensePaid
    {
      get;
      set;
    }
    public decimal? AdjustingReserve
    {
      get;
      set;
    }
    public decimal? AdjustingPaid
    {
      get;
      set;
    }
    public decimal? LegalReserve
    {
      get;
      set;
    }
    public decimal? LegalPaid
    {
      get;
      set;
    }
    public decimal? Recovery
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
