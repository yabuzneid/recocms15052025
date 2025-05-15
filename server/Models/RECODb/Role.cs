using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Roles", Schema = "dbo")]
  public partial class Role
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }

    public ICollection<FilesRole> FilesRoles { get; set; }
    public ICollection<NoteRole> NoteRoles { get; set; }
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
    public Int16? Ranking
    {
      get;
      set;
    }
  }
}
