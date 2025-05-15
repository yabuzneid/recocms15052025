using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("__RefactorLog", Schema = "dbo")]
  public partial class RefactorLog
  {
    [Key]
    public Guid OperationKey
    {
      get;
      set;
    }
  }
}
