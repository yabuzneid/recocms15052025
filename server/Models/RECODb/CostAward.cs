using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CostAwards", Schema = "dbo")]
  public partial class CostAward
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CostAwardID
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

    [Column("CostAward")]
    public decimal CostAward1
    {
      get;
      set;
    }
    public DateTime CostAwardDate
    {
      get;
      set;
    }
    public bool? Paid
    {
      get;
      set;
    }
  }
}
