using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("AuditTrail", Schema = "dbo")]
  public partial class AuditTrail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuditTrailID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public DateTime AuditTrailDate
    {
      get;
      set;
    }
    public string TableAffected
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
    public string RowDetails
    {
      get;
      set;
    }
  }
}
