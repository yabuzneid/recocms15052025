using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OtherParties", Schema = "dbo")]
  public partial class OtherParty
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
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
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OtherPartyID
    {
      get;
      set;
    }
    public int? RegistrantID
    {
      get;
      set;
    }
    public Registrant Registrant { get; set; }
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
    public Parameter Parameter { get; set; }
    public int? CountryID
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
    public Int16? DisplayOrder
    {
      get;
      set;
    }
    public int? SolicitorID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
    public int? OtherPartyTransactionRoleID
    {
      get;
      set;
    }
    public Parameter Parameter3 { get; set; }
    public int? BrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
    public string TransactionRoleOther
    {
      get;
      set;
    }
  }
}
