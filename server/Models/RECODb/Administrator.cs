using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Administrators", Schema = "dbo")]
  public partial class Administrator
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AdministratorID
    {
      get;
      set;
    }

    public ICollection<Brokerage> Brokerages { get; set; }
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
  }
}
