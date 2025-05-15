using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CurrentDiaryReport", Schema = "dbo")]
  public partial class CurrentDiaryReport
  {
    public int ClaimTypeID
    {
      get;
      set;
    }

    [Column("Contract Year")]
    public string ContractYear
    {
      get;
      set;
    }

    [Column("Claim Num")]
    public string ClaimNum
    {
      get;
      set;
    }
    public string Program
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

    [Column("Diary Date")]
    public DateTime? DiaryDate
    {
      get;
      set;
    }

    [Column("Diary Subject")]
    public string DiarySubject
    {
      get;
      set;
    }

    [Column("File Handler")]
    public string FileHandler
    {
      get;
      set;
    }
  }
}
