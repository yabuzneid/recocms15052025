using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimRapidSearchList", Schema = "dbo")]
  public partial class ClaimRapidSearchList
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
    public int? FileHandlerID
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
    public int ContractYearID
    {
      get;
      set;
    }
  }
}
