using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("SalesClassificationBreakdownByTradeType", Schema = "dbo")]
  public partial class SalesClassificationBreakdownByTradeType
  {
    public string TradeType
    {
      get;
      set;
    }
    public int? Open
    {
      get;
      set;
    }
    public int? Closed
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? TotalClaims
    {
      get;
      set;
    }
  }
}
