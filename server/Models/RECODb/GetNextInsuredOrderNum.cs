using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetNextInsuredOrderNum", Schema = "dbo")]
  public partial class GetNextInsuredOrderNum
  {
    public int? newInsuredOrderNum
    {
      get;
      set;
    }
  }
}
