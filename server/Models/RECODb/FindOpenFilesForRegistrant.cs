using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FindOpenFilesForRegistrant", Schema = "dbo")]
  public partial class FindOpenFilesForRegistrant
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public string FilehandlerEmail
    {
      get;
      set;
    }
    public string FileHandler
    {
      get;
      set;
    }
    public decimal? ParamValue
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string PaidClaimNo
    {
      get;
      set;
    }
    public string RegistrantNo
    {
      get;
      set;
    }
    public string ParamAbbrev
    {
      get;
      set;
    }
  }
}
