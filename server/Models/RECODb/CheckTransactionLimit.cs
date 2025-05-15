using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CheckTransactionLimit", Schema = "dbo")]
  public partial class CheckTransactionLimit
  {
    public int? ApprovalLimit
    {
      get;
      set;
    }
  }
}
