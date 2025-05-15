using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FileRoleDetails", Schema = "dbo")]
  public partial class FileRoleDetail
  {
    public Guid ID
    {
      get;
      set;
    }
    public int FileID
    {
      get;
      set;
    }
    public string AspNetRoleId
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public int RoleID
    {
      get;
      set;
    }
  }
}
