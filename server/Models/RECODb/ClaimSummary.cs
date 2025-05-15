using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimSummary", Schema = "dbo")]
  public partial class ClaimSummary
  {

    [Column("ClaimSummary")]
    public string ClaimSummary1
    {
      get;
      set;
    }
  }
}
