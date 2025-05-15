using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimFileHandlerAndReports", Schema = "dbo")]
  public partial class ClaimFileHandlerAndReport
  {
    public string Initials
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
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
    public int ServiceProviderID
    {
      get;
      set;
    }
  }
}
