using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimsWithIndemnityPaid", Schema = "dbo")]
  public partial class ClaimsWithIndemnityPaid
  {
    public string ContractYear
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

    [Column("Claim Status")]
    public string ClaimStatus
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

    [Column("Claims Reported")]
    public int? ClaimsReported
    {
      get;
      set;
    }
  }
}
