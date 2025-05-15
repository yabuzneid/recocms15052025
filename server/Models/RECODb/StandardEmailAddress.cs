using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("StandardEmailAddresses", Schema = "dbo")]
  public partial class StandardEmailAddress
  {
    public string EmailAddress
    {
      get;
      set;
    }
  }
}
