using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("BuilderDetails", Schema = "dbo")]
  public partial class BuilderDetail
  {
    public int BuilderID
    {
      get;
      set;
    }
    public string BuilderDetails
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
    public string ContactName
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
  }
}
