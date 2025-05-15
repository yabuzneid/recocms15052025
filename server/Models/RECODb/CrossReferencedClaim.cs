using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CrossReferencedClaims", Schema = "dbo")]
  public partial class CrossReferencedClaim
  {
    [Key]
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    [Key]
    public int XRefClaimID
    {
      get;
      set;
    }
    public Claim Claim1 { get; set; }
  }
}
