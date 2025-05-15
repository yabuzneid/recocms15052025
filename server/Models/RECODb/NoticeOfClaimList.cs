using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimList", Schema = "dbo")]
  public partial class NoticeOfClaimList
  {
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
    public string ProgramName
    {
      get;
      set;
    }
    public string RefNum
    {
      get;
      set;
    }
    public int NoticeOfClaimStatusID
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
    public DateTime? DateSubmitted
    {
      get;
      set;
    }
    public string TradeAddress
    {
      get;
      set;
    }
    public string BrokerageName
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
  }
}
