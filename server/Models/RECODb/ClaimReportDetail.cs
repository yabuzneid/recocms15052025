using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimReportDetails", Schema = "dbo")]
  public partial class ClaimReportDetail
  {
    public int ClaimReportID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public DateTime DateCreated
    {
      get;
      set;
    }
    public bool InitialReport
    {
      get;
      set;
    }
    public string SubmittedBy
    {
      get;
      set;
    }
    public string Facts
    {
      get;
      set;
    }
    public string Coverage
    {
      get;
      set;
    }
    public string Liability
    {
      get;
      set;
    }
    public string Damages
    {
      get;
      set;
    }
    public string EstimatedExpenses
    {
      get;
      set;
    }
    public string EstimatedIndemnity
    {
      get;
      set;
    }
    public string PossibleSubrogation
    {
      get;
      set;
    }
    public string ActionPlan
    {
      get;
      set;
    }
    public DateTime? DateLastModified
    {
      get;
      set;
    }
    public DateTime? DateSubmitted
    {
      get;
      set;
    }
    public bool Incremental
    {
      get;
      set;
    }
    public string ExecutiveSummary
    {
      get;
      set;
    }
    public string Recommendations
    {
      get;
      set;
    }
    public string DamagesClaimed
    {
      get;
      set;
    }
    public int? ClaimReportFlagID
    {
      get;
      set;
    }
    public string Filename
    {
      get;
      set;
    }
    public Guid? ID
    {
      get;
      set;
    }
    public string SubmittedByName
    {
      get;
      set;
    }
    public string ClaimReportFlag
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public string Insured1
    {
      get;
      set;
    }
    public string Claimant1
    {
      get;
      set;
    }
    public string Insured2
    {
      get;
      set;
    }
    public string Insured3
    {
      get;
      set;
    }
    public string Claimant2
    {
      get;
      set;
    }
    public string Claimant3
    {
      get;
      set;
    }
    public string Broker
    {
      get;
      set;
    }
    public string Insureds
    {
      get;
      set;
    }
    public string Claimants
    {
      get;
      set;
    }
    public string Status
    {
      get;
      set;
    }
    public int? DefenseCounselID
    {
      get;
      set;
    }
    public int? CoverageCounselID
    {
      get;
      set;
    }
    public int? AdjusterID
    {
      get;
      set;
    }
    public int? FilehandlerID
    {
      get;
      set;
    }
    public int? ReportingDays
    {
      get;
      set;
    }
    public string FileHandlerEmailAddress
    {
      get;
      set;
    }
    public string AdjusterEmailAddress
    {
      get;
      set;
    }
    public string DefenseCounselEmailAddress
    {
      get;
      set;
    }
    public int? HandlingFirmID
    {
      get;
      set;
    }
    public string HandlingFirmName
    {
      get;
      set;
    }
    public string ReportsTo
    {
      get;
      set;
    }
    public string ApplicationName
    {
      get;
      set;
    }
    public string ReportsToEmail
    {
      get;
      set;
    }
    public string UploadedById
    {
      get;
      set;
    }
    public string UploadedByEmail
    {
      get;
      set;
    }
    public int? FileID
    {
      get;
      set;
    }
    public string FirmType
    {
      get;
      set;
    }
  }
}
