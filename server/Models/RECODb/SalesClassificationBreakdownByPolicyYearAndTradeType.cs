using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("SalesClassificationBreakdownByPolicyYearAndTradeType", Schema = "dbo")]
  public partial class SalesClassificationBreakdownByPolicyYearAndTradeType
  {

    [Column("Policy Year")]
    public string PolicyYear
    {
      get;
      set;
    }
    public string Policy
    {
      get;
      set;
    }
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
    public int? TotalClaims
    {
      get;
      set;
    }
  }
}
