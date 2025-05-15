using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("EONoticeOfClaimsDetails", Schema = "dbo")]
  public partial class EoNoticeOfClaimsDetail
  {
    [Key]
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    public string ClaimantName
    {
      get;
      set;
    }
    public int? LitigationDocumentsDeliveredID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string OtherMethodOfDelivery
    {
      get;
      set;
    }
    public string GeneralNotes
    {
      get;
      set;
    }
    public DateTime? DateServed
    {
      get;
      set;
    }
    public DateTime? DateAccepted
    {
      get;
      set;
    }
    public DateTime? DateAware
    {
      get;
      set;
    }
    public bool? ClaimantCorrespondenceAttached
    {
      get;
      set;
    }
    public bool? LawyerCorrespondenceAttached
    {
      get;
      set;
    }
  }
}
