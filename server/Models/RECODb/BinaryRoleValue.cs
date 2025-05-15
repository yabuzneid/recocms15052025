using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("BinaryRoleValues", Schema = "dbo")]
  public partial class BinaryRoleValue
  {
    [Key]
    public string RoleID
    {
      get;
      set;
    }
    public int BinaryValue
    {
      get;
      set;
    }
  }
}
