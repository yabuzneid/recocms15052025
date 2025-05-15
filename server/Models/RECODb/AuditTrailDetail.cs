using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("AuditTrailDetails", Schema = "dbo")]
  public partial class AuditTrailDetail
  {
    public DateTime AuditTrailDate
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public string TableAffected
    {
      get;
      set;
    }
    public string RowDetails
    {
      get;
      set;
    }
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
    public string Name
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
  }
}
