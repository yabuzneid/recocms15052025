using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Experts", Schema = "dbo")]
  public partial class Expert
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    public Claim Claim { get; set; }
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
    public Parameter Parameter { get; set; }
    public int ServiceProviderID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
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
    public Parameter Parameter1 { get; set; }
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
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public int? FirmID
    {
      get;
      set;
    }
    public Firm Firm { get; set; }
  }
}
