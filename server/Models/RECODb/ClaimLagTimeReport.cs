using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimLagTimeReport", Schema = "dbo")]
  public partial class ClaimLagTimeReport
  {
    public string ClaimNo
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Insureds
    {
      get;
      set;
    }

    [Column("Claim Type")]
    public string ClaimType
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public DateTime? ClaimDate
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Claim Lag")]
    public int? ClaimLag
    {
      get;
      set;
    }
  }
}
