using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ServiceProviderDetails", Schema = "dbo")]
  public partial class ServiceProviderDetail
  {
    public int ServiceProviderID
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }

    [Column("Firm Name")]
    public string FirmName
    {
      get;
      set;
    }

    [Column("Firm Type")]
    public string FirmType
    {
      get;
      set;
    }
    public string BusinessPhoneNum
    {
      get;
      set;
    }

    [Column("Service Provider Role")]
    public string ServiceProviderRole
    {
      get;
      set;
    }

    [Column("Name and Firm")]
    public string NameandFirm
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
    public int? FirmID
    {
      get;
      set;
    }
    public string SystemRole
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
    public bool? Active
    {
      get;
      set;
    }
    public bool? SubmitPayments
    {
      get;
      set;
    }
    public bool? ViewReports
    {
      get;
      set;
    }
    public bool? FileHandler
    {
      get;
      set;
    }
    public bool? PrimeUser
    {
      get;
      set;
    }
    public bool? AllowedToViewConfidential
    {
      get;
      set;
    }
    public string IPAddress
    {
      get;
      set;
    }
  }
}
