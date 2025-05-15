using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GenerateNewOccurrence", Schema = "dbo")]
  public partial class GenerateNewOccurrence
  {
    public int? NewOccurrenceID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? NewClaimID
    {
      get;
      set;
    }
  }
}
