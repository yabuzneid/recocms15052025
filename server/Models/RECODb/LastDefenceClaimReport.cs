using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("LastDefenceClaimReport", Schema = "dbo")]
  public partial class LastDefenceClaimReport
  {
    public int ProgramID
    {
      get;
      set;
    }
    public string ClaimType
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
    public string ClaimNo
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string LawFirm
    {
      get;
      set;
    }
    public string DisplayName
    {
      get;
      set;
    }
    public DateTime? DateSubmitted
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string InsuredName
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string ClaimantName
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Current Claim Status")]
    public string CurrentClaimStatus
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
  }
}
