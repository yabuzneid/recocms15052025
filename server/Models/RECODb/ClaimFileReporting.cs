using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimFileReporting", Schema = "dbo")]
  public partial class ClaimFileReporting
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FileReportID
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
    public int ServiceProviderID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
  }
}
