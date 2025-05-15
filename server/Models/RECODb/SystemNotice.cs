using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("SystemNotices", Schema = "dbo")]
  public partial class SystemNotice
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SystemNoticeID
    {
      get;
      set;
    }

    [Column("SystemNotice")]
    public string SystemNotice1
    {
      get;
      set;
    }
  }
}
