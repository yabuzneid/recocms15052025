using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Brokerages", Schema = "dbo")]
  public partial class Brokerage
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BrokerageID
    {
      get;
      set;
    }

    public ICollection<Claimant> Claimants { get; set; }
    public ICollection<BrokerageContact> BrokerageContacts { get; set; }
    public ICollection<Occurrence> Occurrences { get; set; }
    public ICollection<Insured> Insureds { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public ICollection<Registrant> Registrants { get; set; }
    public ICollection<OtherParty> OtherParties { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string RegistrantNo
    {
      get;
      set;
    }
    public DateTime? RegistrationExpiryDate
    {
      get;
      set;
    }
    public int? BrokerOfRecordID
    {
      get;
      set;
    }
    public Registrant Registrant { get; set; }
    public string ContactPerson
    {
      get;
      set;
    }
    public string Street1
    {
      get;
      set;
    }
    public string Street2
    {
      get;
      set;
    }
    public string UnitNumber
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
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int? AdministratorID
    {
      get;
      set;
    }
    public Administrator Administrator { get; set; }
    public string BrokerOfRecordName
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public string ContactPersonEmail
    {
      get;
      set;
    }
    public string ContactPersonPhoneNum
    {
      get;
      set;
    }
  }
}
