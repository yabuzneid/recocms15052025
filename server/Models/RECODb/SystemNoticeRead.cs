using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("SystemNoticeRead", Schema = "dbo")]
  public partial class SystemNoticeRead
  {
    [Key]
    public string UserID
    {
      get;
      set;
    }
    public DateTime MessageRead
    {
      get;
      set;
    }
  }
}
