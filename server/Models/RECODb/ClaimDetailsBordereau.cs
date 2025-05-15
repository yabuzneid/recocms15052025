using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimDetailsBordereau", Schema = "dbo")]
  public partial class ClaimDetailsBordereau
  {
    public int ClaimID
    {
      get;
      set;
    }
    public string ClaimNo
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

    [Column("Program Name")]
    public string ProgramName
    {
      get;
      set;
    }
    public int ContractYearID
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
    public int ClaimStatusID
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

    [Column("Status Abbrev")]
    public string StatusAbbrev
    {
      get;
      set;
    }
    public string Adjuster
    {
      get;
      set;
    }
    public int? AdjustingFirmID
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
    public string CounselFileNo
    {
      get;
      set;
    }

    [Column("Coverage Counsel")]
    public string CoverageCounsel
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

    [Column("Original File Handler")]
    public string OriginalFileHandler
    {
      get;
      set;
    }
    public string Brokerage
    {
      get;
      set;
    }

    [Column("Brokerage Transaction Role")]
    public string BrokerageTransactionRole
    {
      get;
      set;
    }
    public DateTime? CloseDate
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public DateTime? ClaimDate
    {
      get;
      set;
    }
    public DateTime? AgreementDate
    {
      get;
      set;
    }
    public DateTime? ReportDate
    {
      get;
      set;
    }
    public DateTime? ClaimPaidDate
    {
      get;
      set;
    }
    public DateTime? LapseDate
    {
      get;
      set;
    }
    public DateTime? ServedDate
    {
      get;
      set;
    }

    [Column("Brokerage Only ?")]
    public string BrokerageOnly
    {
      get;
      set;
    }

    [Column("Loss Cause")]
    public string LossCause
    {
      get;
      set;
    }
    public int? OccurrenceID
    {
      get;
      set;
    }
    public string OccurrenceNo
    {
      get;
      set;
    }
    public decimal? ValueOfTransaction
    {
      get;
      set;
    }
    public decimal? ExpectedPayout
    {
      get;
      set;
    }
    public decimal? AdjustedGrossClaim
    {
      get;
      set;
    }
    public string Insureds
    {
      get;
      set;
    }
    public string InsuredRegNo
    {
      get;
      set;
    }
    public string Claimants
    {
      get;
      set;
    }
    public string ClaimantSolicitors
    {
      get;
      set;
    }
    public string ClaimantSolicitorFirms
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }

    [Column("Coverage Issue")]
    public string CoverageIssue
    {
      get;
      set;
    }

    [Column("Not Yet Reported")]
    public string NotYetReported
    {
      get;
      set;
    }

    [Column("Class Action")]
    public string ClassAction
    {
      get;
      set;
    }
    public decimal? OpenOrClosed
    {
      get;
      set;
    }
    public decimal? AmountClaimed
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
    public string ClaimType
    {
      get;
      set;
    }
    public int? DefenseCounselFirmID
    {
      get;
      set;
    }
    public int? CoverageCounselFirmID
    {
      get;
      set;
    }
    public string LitigationType
    {
      get;
      set;
    }
    public string ClaimDescription
    {
      get;
      set;
    }

    [Column("Claim or Incident")]
    public string ClaimorIncident
    {
      get;
      set;
    }
    public string ApplicableParty
    {
      get;
      set;
    }
    public int? AvgYearsOfExperience
    {
      get;
      set;
    }
    public string RegistrantEmailAddresses
    {
      get;
      set;
    }
    public string ClaimantEmails
    {
      get;
      set;
    }
    public bool? UrbanOrRural
    {
      get;
      set;
    }
    public DateTime? ConvertedToLitigation
    {
      get;
      set;
    }
    public string ClaimInitiation
    {
      get;
      set;
    }
    public string EndOfDeal
    {
      get;
      set;
    }
    public string DenialCode
    {
      get;
      set;
    }
    public string LossCauseTags
    {
      get;
      set;
    }
    public string ClaimConvertedTo
    {
      get;
      set;
    }
    public string UrbanOrRuralDesc
    {
      get;
      set;
    }
    public string StatusOfFunds
    {
      get;
      set;
    }
    public string MasterFile
    {
      get;
      set;
    }
    public string MasterBrokerage
    {
      get;
      set;
    }
    public string OccurrenceBrokerage
    {
      get;
      set;
    }
  }
}
