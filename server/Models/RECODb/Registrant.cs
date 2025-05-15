using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Registrants", Schema = "dbo")]
  public partial class Registrant
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RegistrantID
    {
      get;
      set;
    }

    public ICollection<Claimant> Claimants { get; set; }
    public ICollection<Trade> Trades { get; set; }
    public ICollection<Brokerage> Brokerages { get; set; }
    public ICollection<Insured> Insureds { get; set; }
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
    public Parameter Parameter { get; set; }
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
    public Parameter Parameter1 { get; set; }
    public int? BrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
  }
}
