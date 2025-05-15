using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GenerateNewClaimantTradeClaim", Schema = "dbo")]
  public partial class GenerateNewClaimantTradeClaim
  {
    public int? NewClaimID
    {
      get;
      set;
    }
  }
}
