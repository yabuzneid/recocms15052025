using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetLowerRankedRoles", Schema = "dbo")]
  public partial class GetLowerRankedRole
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
