using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimsWithIndemnityReserveWithDetails", Schema = "dbo")]
  public partial class ClaimsWithIndemnityReserveWithDetail
  {
    public string ClaimNo
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Insureds
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Agency At Time Of Loss")]
    public string AgencyAtTimeOfLoss
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

    [Column("Cause Of Claim")]
    public string CauseOfClaim
    {
      get;
      set;
    }
    public string Details
    {
      get;
      set;
    }
  }
}
