using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OpenStatusHistory", Schema = "dbo")]
  public partial class OpenStatusHistory
  {
    public decimal? ParamValue
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public DateTime StatusChangeDate
    {
      get;
      set;
    }
    public string StatusName
    {
      get;
      set;
    }
    public int ParameterID
    {
      get;
      set;
    }
  }
}
