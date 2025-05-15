using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalClaimsbyAllegations", Schema = "dbo")]
  public partial class TotalClaimsbyAllegation
  {
    public string Allegation
    {
      get;
      set;
    }
    public int? Open
    {
      get;
      set;
    }
    public int? Closed
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? TotalClaims
    {
      get;
      set;
    }
  }
}
