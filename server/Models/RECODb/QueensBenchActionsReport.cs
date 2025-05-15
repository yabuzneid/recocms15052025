using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("QueensBenchActionsReport", Schema = "dbo")]
  public partial class QueensBenchActionsReport
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public DateTime? ClaimDate
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

    [Column("Type Of Sale")]
    public string TypeOfSale
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
    public string Brokerage
    {
      get;
      set;
    }
    public string Allegation
    {
      get;
      set;
    }

    [Column("Cause Of Claim")]
    public string CauseOfClaim
    {
      get;
      set;
    }
  }
}
