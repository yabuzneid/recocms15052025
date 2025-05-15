using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FirmDetails", Schema = "dbo")]
  public partial class FirmDetail
  {
    public int FirmID
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public int FirmTypeID
    {
      get;
      set;
    }
    public string FirmType
    {
      get;
      set;
    }
    public string IndemnityType
    {
      get;
      set;
    }
  }
}
