using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ActualDaysOpen", Schema = "dbo")]
  public partial class ActualDaysOpen
  {
    public int ClaimID
    {
      get;
      set;
    }
    public int? DaysActuallyOpen
    {
      get;
      set;
    }
  }
}
