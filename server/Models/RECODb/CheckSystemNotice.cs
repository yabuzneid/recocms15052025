using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CheckSystemNotice", Schema = "dbo")]
  public partial class CheckSystemNotice
  {
    public string SystemNotice
    {
      get;
      set;
    }
  }
}
