using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimSearchList", Schema = "dbo")]
  public partial class ClaimSearchList
  {
    public string Program
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public string Address
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
    public string Broker
    {
      get;
      set;
    }
    public string BrokerOfRecord
    {
      get;
      set;
    }
    public string DefenceCounsel
    {
      get;
      set;
    }
    public string Occurences
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public string AdjusterClaimNo
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
    public int? AdjusterID
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
    public string Status
    {
      get;
      set;
    }
    public int? FileHandlerID
    {
      get;
      set;
    }
    public bool CoverageIssue
    {
      get;
      set;
    }
    public int? BrokerageOnly
    {
      get;
      set;
    }
    public int? DefenseCounselFirmID
    {
      get;
      set;
    }
    public string Adjuster
    {
      get;
      set;
    }
    public int ClaimStatusID
    {
      get;
      set;
    }
    public string CounselFileNo
    {
      get;
      set;
    }
    public bool ClaimOrIncident
    {
      get;
      set;
    }
    public string FileHandler
    {
      get;
      set;
    }
    public string NoticeOfClaimRefNum
    {
      get;
      set;
    }
    public string CoverageIssues
    {
      get;
      set;
    }
    public bool MasterFile
    {
      get;
      set;
    }
    public string Brokerage
    {
      get;
      set;
    }
    public string Brokerage1
    {
      get;
      set;
    }
    public string Broker1
    {
      get;
      set;
    }
    public string Builder1
    {
      get;
      set;
    }
    public int ContractYearID
    {
      get;
      set;
    }
  }
}
