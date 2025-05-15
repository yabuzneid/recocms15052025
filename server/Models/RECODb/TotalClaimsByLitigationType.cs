using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalClaimsByLitigationType", Schema = "dbo")]
  public partial class TotalClaimsByLitigationType
  {

    [Column("Policy Year")]
    public string PolicyYear
    {
      get;
      set;
    }
    public int? SmallClaims
    {
      get;
      set;
    }
    public int? QueensBench
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? TotalLitigation
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
