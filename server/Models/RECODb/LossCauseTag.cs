using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("LossCauseTags", Schema = "dbo")]
  public partial class LossCauseTag
  {
    [Key]
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    [Key]

    [Column("LossCauseTag")]
    public string LossCauseTag1
    {
      get;
      set;
    }
  }
}
