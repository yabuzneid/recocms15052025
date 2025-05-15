using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OpenFilesByLawyer", Schema = "dbo")]
  public partial class OpenFilesByLawyer
  {

    [Column("Law Firm")]
    public string LawFirm
    {
      get;
      set;
    }
    public string DefenceCounsel
    {
      get;
      set;
    }
    public string CounselFileNo
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public decimal? AmountClaimed
    {
      get;
      set;
    }
    public string Insureds
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
  }
}
