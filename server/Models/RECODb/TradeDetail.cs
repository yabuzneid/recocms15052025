using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TradeDetails", Schema = "dbo")]
  public partial class TradeDetail
  {
    public int TradeID
    {
      get;
      set;
    }
    public string Address1
    {
      get;
      set;
    }
    public string Address2
    {
      get;
      set;
    }
    public string UnitNumber
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
    public Int16? DisplayOrder
    {
      get;
      set;
    }
    public string Province
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
    public string TradeType
    {
      get;
      set;
    }
  }
}
