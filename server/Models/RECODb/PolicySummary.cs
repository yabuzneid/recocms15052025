using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("PolicySummary", Schema = "dbo")]
  public partial class PolicySummary
  {

    [Column("Policy Num")]
    public string PolicyNum
    {
      get;
      set;
    }
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
    public DateTime? ReportDate
    {
      get;
      set;
    }
    public decimal? AmountClaimed
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
