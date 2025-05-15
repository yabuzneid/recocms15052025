using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalClaimsByBoardJuridiction", Schema = "dbo")]
  public partial class TotalClaimsByBoardJuridiction
  {
    public string BoardJurisdiction
    {
      get;
      set;
    }
    public int? TotalClaims
    {
      get;
      set;
    }
  }
}
