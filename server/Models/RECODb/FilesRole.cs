using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FilesRoles", Schema = "dbo")]
  public partial class FilesRole
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public int FileID
    {
      get;
      set;
    }
    public int RoleID
    {
      get;
      set;
    }
    public Role Role { get; set; }
  }
}
