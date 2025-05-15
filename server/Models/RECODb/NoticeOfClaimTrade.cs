using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimTrade", Schema = "dbo")]
  public partial class NoticeOfClaimTrade
  {
    [Key]
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    public string TradeAddress
    {
      get;
      set;
    }
    public string TradeCity
    {
      get;
      set;
    }
    public int? TradeProvince
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string TradePostalCode
    {
      get;
      set;
    }
  }
}
