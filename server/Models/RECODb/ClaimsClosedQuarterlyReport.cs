using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimsClosedQuarterlyReport", Schema = "dbo")]
  public partial class ClaimsClosedQuarterlyReport
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

    [Column("Loss Cause")]
    public string LossCause
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? IndemnityPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? AdjustingPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? LegalPaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? ExpensePaid
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? RecoveredCosts
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? TotalIncurred
    {
      get;
      set;
    }

    [Column("Date Closed")]
    public DateTime? DateClosed
    {
      get;
      set;
    }
  }
}
