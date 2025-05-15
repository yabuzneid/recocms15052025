using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimPurchasers", Schema = "dbo")]
  public partial class NoticeOfClaimPurchaser
  {
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PurchaserID
    {
      get;
      set;
    }
    public string PurchaserName
    {
      get;
      set;
    }
    public string PurchaserAddress
    {
      get;
      set;
    }
    public string PurchaserPostalCode
    {
      get;
      set;
    }
    public string PurchaserSolicitorName
    {
      get;
      set;
    }
  }
}
