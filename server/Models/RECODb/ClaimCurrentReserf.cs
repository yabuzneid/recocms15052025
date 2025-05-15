using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimCurrentReserves", Schema = "dbo")]
  public partial class ClaimCurrentReserf
  {
    public int ClaimID
    {
      get;
      set;
    }
    public int IncurredTypeID
    {
      get;
      set;
    }
    public decimal? TotalReserve
    {
      get;
      set;
    }
    public string IncurredType
    {
      get;
      set;
    }
  }
}
