using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimVendors", Schema = "dbo")]
  public partial class NoticeOfClaimVendor
  {
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VendorID
    {
      get;
      set;
    }
    public string VendorName
    {
      get;
      set;
    }
    public string VendorAddress
    {
      get;
      set;
    }
    public string VendorPostalCode
    {
      get;
      set;
    }
    public string VendorSolicitorName
    {
      get;
      set;
    }
  }
}
