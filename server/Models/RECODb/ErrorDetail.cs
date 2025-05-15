using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ErrorDetails", Schema = "dbo")]
  public partial class ErrorDetail
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public string ErrorMessage
    {
      get;
      set;
    }
    public DateTime? TimeOfError
    {
      get;
      set;
    }
  }
}
