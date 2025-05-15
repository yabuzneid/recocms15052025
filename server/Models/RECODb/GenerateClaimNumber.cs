using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GenerateClaimNumber", Schema = "dbo")]
  public partial class GenerateClaimNumber
  {
    public string NewNumber
    {
      get;
      set;
    }
  }
}
