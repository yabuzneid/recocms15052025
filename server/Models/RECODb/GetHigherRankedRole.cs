using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetHigherRankedRoles", Schema = "dbo")]
  public partial class GetHigherRankedRole
  {
    public int Id
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
  }
}
