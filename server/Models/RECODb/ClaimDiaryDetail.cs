using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimDiaryDetails", Schema = "dbo")]
  public partial class ClaimDiaryDetail
  {

    [Column("Diary Status")]
    public string DiaryStatus
    {
      get;
      set;
    }
    public int DiaryID
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public string Subject
    {
      get;
      set;
    }
    public DateTime AbeyanceDate
    {
      get;
      set;
    }
    public string Recipients
    {
      get;
      set;
    }
    public string EnteredBy
    {
      get;
      set;
    }
  }
}
