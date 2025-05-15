using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoActiveDiaryBordereau", Schema = "dbo")]
  public partial class NoActiveDiaryBordereau
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

    [Column("RECO Claim #")]
    public string RECOClaim
    {
      get;
      set;
    }

    [Column("Adjuster Claim #")]
    public string AdjusterClaim
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Registrants
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Claim Initiation")]
    public string ClaimInitiation
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Defense Firm")]
    public string DefenseFirm
    {
      get;
      set;
    }

    [Column("Defense Counsel")]
    public string DefenseCounsel
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
