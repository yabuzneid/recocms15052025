using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ErrorLogs", Schema = "dbo")]
  public partial class ErrorLog
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ErrorLogID
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public string UserID
    {
      get;
      set;
    }
    public string ErrorMessage
    {
      get;
      set;
    }
    public DateTime ErrorLogDateTime
    {
      get;
      set;
    }
  }
}
