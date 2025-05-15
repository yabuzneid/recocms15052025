using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ServiceProviderClaimPreferences", Schema = "dbo")]
  public partial class ServiceProviderClaimPreference
  {
    [Key]
    public int ServiceProviderID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
    [Key]
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public DateTime DateLastAccessed
    {
      get;
      set;
    }
    public string JsonPreference
    {
      get;
      set;
    }
  }
}
