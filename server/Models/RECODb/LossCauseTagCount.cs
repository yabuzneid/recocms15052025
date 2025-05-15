using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("LossCauseTagCount", Schema = "dbo")]
  public partial class LossCauseTagCount
  {

    [Column("Loss Cause")]
    public string LossCause
    {
      get;
      set;
    }
    public int? LossCauseID
    {
      get;
      set;
    }
    public string LossCauseTag
    {
      get;
      set;
    }
    public int? NumberOfTags
    {
      get;
      set;
    }
  }
}
