using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimDetailsReport", Schema = "dbo")]
  public partial class ClaimDetailsReport
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public DateTime? DateReported
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
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Claimants
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Brokerage At Time Of Loss")]
    public string BrokerageAtTimeOfLoss
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

    [Column("Agency Type")]
    public string AgencyType
    {
      get;
      set;
    }

    [Column("Claim Type")]
    public string ClaimType
    {
      get;
      set;
    }
    public string Allegation
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
    public string ClaimDescription
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Closed
    {
      get;
      set;
    }
    public int ClaimStatusID
    {
      get;
      set;
    }
  }
}
