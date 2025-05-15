using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaims", Schema = "dbo")]
  public partial class NoticeOfClaim
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NoticeOfClaimID
    {
      get;
      set;
    }

    public ICollection<EoNoticeOfClaimsDetail> EoNoticeOfClaimsDetails { get; set; }
    public ICollection<NoticeOfClaimTrade> NoticeOfClaimTrades { get; set; }
    public ICollection<NoticeOfClaimBrokerage> NoticeOfClaimBrokerages { get; set; }
    public ICollection<NoticeOfClaimClaimant> NoticeOfClaimClaimants { get; set; }
    public ICollection<NoticeOfClaimRegistrant> NoticeOfClaimRegistrants { get; set; }
    public ICollection<NoticeOfClaimFile> NoticeOfClaimFiles { get; set; }
    public ICollection<NoticeOfClaimPurchaser> NoticeOfClaimPurchasers { get; set; }
    public ICollection<NoticeOfClaimVendor> NoticeOfClaimVendors { get; set; }
    public int ProgramID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
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
    public Parameter Parameter1 { get; set; }
    public string UserID
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public DateTime? DateSubmitted
    {
      get;
      set;
    }
  }
}
