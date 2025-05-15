using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalClaimsByClaimTypeAndLossCause", Schema = "dbo")]
  public partial class TotalClaimsByClaimTypeAndLossCause
  {
    public string TradeType
    {
      get;
      set;
    }
    public string LossCause
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
