using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalPaidByClaimStatus", Schema = "dbo")]
  public partial class TotalPaidByClaimStatus
  {
    public string ClaimStatus
    {
      get;
      set;
    }
    public int? ClaimsReported
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
    public decimal? TotalPayment
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
