using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GenerateNewClaimantClaim", Schema = "dbo")]
  public partial class GenerateNewClaimantClaim
  {
    public int? NewClaimID
    {
      get;
      set;
    }
  }
}
