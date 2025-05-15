using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimsWithIndemnityPaidDetailed", Schema = "dbo")]
  public partial class ClaimsWithIndemnityPaidDetailed
  {

    [Column("Claim Status")]
    public string ClaimStatus
    {
      get;
      set;
    }

    [Column("Claim Number")]
    public string ClaimNumber
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
    public string Allegation
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
    public string ContractYear
    {
      get;
      set;
    }
  }
}
