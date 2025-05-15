using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimStatusHistory", Schema = "dbo")]
  public partial class ClaimStatusHistory
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaimStatusID
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
    public DateTime StatusChangeDate
    {
      get;
      set;
    }
    public int NewStatusID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string ChangedBy
    {
      get;
      set;
    }
  }
}
