using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalClaimsByAllegationAndLossCause", Schema = "dbo")]
  public partial class TotalClaimsByAllegationAndLossCause
  {
    public string Allegation
    {
      get;
      set;
    }
    public string LossCause
    {
      get;
      set;
    }
    public int? ClaimsReported
    {
      get;
      set;
    }
  }
}
