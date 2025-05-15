using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FullClaimStatusHistory", Schema = "dbo")]
  public partial class FullClaimStatusHistory
  {
    public int ClaimID
    {
      get;
      set;
    }

    [Column("Claim Status")]
    public string ClaimStatus
    {
      get;
      set;
    }
    public DateTime? StatusChangeDate
    {
      get;
      set;
    }
    public int? NewStatusID
    {
      get;
      set;
    }
  }
}
