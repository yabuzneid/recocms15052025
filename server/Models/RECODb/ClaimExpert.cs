using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimExperts", Schema = "dbo")]
  public partial class ClaimExpert
  {
    public int ExpertID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public Int16 DisplayOrder
    {
      get;
      set;
    }
    public int ServiceProviderRoleID
    {
      get;
      set;
    }
    public string ServiceProviderRole
    {
      get;
      set;
    }
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
    public string Address
    {
      get;
      set;
    }
    public int? ProvinceID
    {
      get;
      set;
    }
    public string City
    {
      get;
      set;
    }
    public string PostalCode
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }
    public string BusinessPhoneNum
    {
      get;
      set;
    }
    public string CellPhoneNum
    {
      get;
      set;
    }
    public string FaxNum
    {
      get;
      set;
    }
    public string Province
    {
      get;
      set;
    }
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public string PreferredCommunicationMethod
    {
      get;
      set;
    }
    public string FirmName
    {
      get;
      set;
    }
  }
}
