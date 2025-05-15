using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("PeriodPaymentBreakdown", Schema = "dbo")]
  public partial class PeriodPaymentBreakdown
  {
    public string ParamDesc
    {
      get;
      set;
    }
    public decimal? TotalAmount
    {
      get;
      set;
    }
    public decimal? TotalDisbursements
    {
      get;
      set;
    }
    public string ParamAbbrev
    {
      get;
      set;
    }
  }
}
