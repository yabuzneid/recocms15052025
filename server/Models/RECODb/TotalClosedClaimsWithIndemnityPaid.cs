using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalClosedClaimsWithIndemnityPaid", Schema = "dbo")]
  public partial class TotalClosedClaimsWithIndemnityPaid
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
    public string LossCause
    {
      get;
      set;
    }
    public decimal? IndemnityPaid
    {
      get;
      set;
    }
    public decimal? AdjustingPaid
    {
      get;
      set;
    }
    public decimal? LegalPaid
    {
      get;
      set;
    }
    public decimal? ExpensePaid
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
