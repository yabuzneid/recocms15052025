using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TotalDollarsPaidByLossCause", Schema = "dbo")]
  public partial class TotalDollarsPaidByLossCause
  {
    public string LossCause
    {
      get;
      set;
    }
    public int? ClaimsReported
    {
      get;
      set;
    }
    public decimal? TotalPaid
    {
      get;
      set;
    }
  }
}
