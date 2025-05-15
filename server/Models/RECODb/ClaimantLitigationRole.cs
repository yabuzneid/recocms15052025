using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimantLitigationRoles", Schema = "dbo")]
  public partial class ClaimantLitigationRole
  {
    [Key]
    public int ClaimantID
    {
      get;
      set;
    }
    public Claimant Claimant { get; set; }
    [Key]
    public int LitigationRole
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
  }
}
