using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("MostRecentStatusChangeDate", Schema = "dbo")]
  public partial class MostRecentStatusChangeDate
  {
    public int ClaimID
    {
      get;
      set;
    }

    [Column("MostRecentStatusChangeDate")]
    public DateTime? MostRecentStatusChangeDate1
    {
      get;
      set;
    }
  }
}
