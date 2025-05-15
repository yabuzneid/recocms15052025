using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimInsureds", Schema = "dbo")]
  public partial class ClaimInsured
  {
    public int ClaimID
    {
      get;
      set;
    }
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
    public Int16? YearsOfExperience
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
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public int? BrokerageID
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
    public Int16 DisplayOrder
    {
      get;
      set;
    }
    public string TransactionRole
    {
      get;
      set;
    }
    public string Province
    {
      get;
      set;
    }

    [Column("Preferred Communication Method")]
    public string PreferredCommunicationMethod
    {
      get;
      set;
    }
    public int InsuredID
    {
      get;
      set;
    }
    public string BrokerOfRecord
    {
      get;
      set;
    }
    public string Brokerage
    {
      get;
      set;
    }
    public int? RegistrantID
    {
      get;
      set;
    }
    public string BrokerageAddress
    {
      get;
      set;
    }
    public string BrokerageEmail
    {
      get;
      set;
    }
    public string BrokerageContactPerson
    {
      get;
      set;
    }
    public string BrokerageContactEmail
    {
      get;
      set;
    }
    public string BrokerageContactPhoneNum
    {
      get;
      set;
    }
    public string PrimaryInsured
    {
      get;
      set;
    }
  }
}
