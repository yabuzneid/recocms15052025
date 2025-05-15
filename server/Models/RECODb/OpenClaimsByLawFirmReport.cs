using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OpenClaimsByLawFirmReport", Schema = "dbo")]
  public partial class OpenClaimsByLawFirmReport
  {

    [Column("Law Firm")]
    public string LawFirm
    {
      get;
      set;
    }

    [Column("Lawyer Name")]
    public string LawyerName
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

    [Column("Claim Status")]
    public string ClaimStatus
    {
      get;
      set;
    }
    public decimal? AmountClaimed
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
  }
}
