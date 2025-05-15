using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetNextClaimantOrderNum", Schema = "dbo")]
  public partial class GetNextClaimantOrderNum
  {
    public int? newOrderNum
    {
      get;
      set;
    }
  }
}
