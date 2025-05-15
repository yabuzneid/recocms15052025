using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimLitigationDates", Schema = "dbo")]
  public partial class ClaimLitigationDate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LitigationDateID
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
    public DateTime LitigationDate
    {
      get;
      set;
    }
    public int? LitigationDateTypeID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int? LitigationStatusID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
  }
}
