using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("DefenseCounselWithOpenFiles", Schema = "dbo")]
  public partial class DefenseCounselWithOpenFile
  {

    [Column("Defense Counsel")]
    public string DefenseCounsel
    {
      get;
      set;
    }

    [Column("Total Claims")]
    public int? TotalClaims
    {
      get;
      set;
    }
  }
}
