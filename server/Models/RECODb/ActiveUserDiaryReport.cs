using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ActiveUserDiaryReport", Schema = "dbo")]
  public class ActiveUserDiaryReportModel
  {
    public int ClaimTypeID
    {
      get;
      set;
    }
    public DateTime? ReminderDate
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string UserID
    {
      get;
      set;
    }
    public string Subject
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
    public string Program
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

    [Column("File Handler")]
    public string FileHandler
    {
      get;
      set;
    }
    public string Recipients
    {
      get;
      set;
    }
  }
}
