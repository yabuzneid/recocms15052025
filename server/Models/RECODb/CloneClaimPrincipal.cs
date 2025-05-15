using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CloneClaimPrincipals", Schema = "dbo")]
  public partial class CloneClaimPrincipal
  {
    public int? ClonedClaimID
    {
      get;
      set;
    }
  }
}
