using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("PostalCodes", Schema = "dbo")]
  public partial class PostalCode
  {
    [Key]

    [Column("PostalCode")]
    public string PostalCode1
    {
      get;
      set;
    }
    public int? CityID
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
    public string Province
    {
      get;
      set;
    }
  }
}
