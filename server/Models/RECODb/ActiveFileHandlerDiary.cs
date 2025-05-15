using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ActiveFileHandlerDiaries", Schema = "dbo")]
  public partial class ActiveFileHandlerDiary
  {
    public int ClaimID
    {
      get;
      set;
    }
  }
}
