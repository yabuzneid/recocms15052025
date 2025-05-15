using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("PostalCodeDetails", Schema = "dbo")]
  public partial class PostalCodeDetail
  {
    public string City
    {
      get;
      set;
    }
    public string Province
    {
      get;
      set;
    }
    public int CityID
    {
      get;
      set;
    }
    public int ProvinceID
    {
      get;
      set;
    }
    public string PostalCode
    {
      get;
      set;
    }
  }
}
