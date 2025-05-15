using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Diaries", Schema = "dbo")]
  public partial class Diary
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DiaryID
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
    public DateTime EntryDate
    {
      get;
      set;
    }
        public string Recipients
        {
            get;
            set;
        } = string.Empty;
    public string Subject
    {
      get;
      set;
    }
    public string Details
    {
      get;
      set;
    }
    public DateTime? AbeyanceDate
    {
      get;
      set;
    }
    public int VisibleTo
    {
      get;
      set;
    }
    public int DiaryStatusID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string EnteredBy
    {
      get;
      set;
    }
  }
}
