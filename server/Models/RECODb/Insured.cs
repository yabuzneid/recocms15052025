using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Insureds", Schema = "dbo")]
  public partial class Insured
  {
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public int? RegistrantID
    {
      get;
      set;
    }
    public Registrant Registrant { get; set; }
    public Int16 DisplayOrder
    {
      get;
      set;
    }
    public int? TransactionRoleID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InsuredID
    {
      get;
      set;
    }

    public ICollection<InsuredLitigationRole> InsuredLitigationRoles { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
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
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int? BrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
    public string BrokerageName
    {
      get;
      set;
    }
    public string BrokerageAddress
    {
      get;
      set;
    }
    public int? BrokerageProvinceID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public string BrokerageCity
    {
      get;
      set;
    }
    public string BrokeragePostalCode
    {
      get;
      set;
    }
    public string BrokerageEmailAddress
    {
      get;
      set;
    }
    public string BrokerageBusinessPhoneNum
    {
      get;
      set;
    }
    public string BrokerOfRecord
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
    public bool? PrimaryInsured
    {
      get;
      set;
    }
  }
}
