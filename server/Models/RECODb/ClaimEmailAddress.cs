using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimEmailAddresses", Schema = "dbo")]
  public partial class ClaimEmailAddress
  {
    public int ClaimID
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }
  }
}
