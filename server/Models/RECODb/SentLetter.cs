using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("SentLetters", Schema = "dbo")]
  public partial class SentLetter
  {
    [Key]
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    [Key]
    public DateTime DateLetterSent
    {
      get;
      set;
    }
    [Key]
    public int LetterTypeID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int FileID
    {
      get;
      set;
    }
  }
}
