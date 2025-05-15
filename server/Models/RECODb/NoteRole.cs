using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoteRole", Schema = "dbo")]
  public partial class NoteRole
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public int? NoteId
    {
      get;
      set;
    }
    public Note Note { get; set; }
    public int? RoleId
    {
      get;
      set;
    }
    public Role Role { get; set; }
  }
}
