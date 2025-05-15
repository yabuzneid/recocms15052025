using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FindServiceProviderByIdentityUser", Schema = "dbo")]
  public partial class FindServiceProviderByIdentityUser
  {
    public int? ServiceProviderID
    {
      get;
      set;
    }
  }
}
