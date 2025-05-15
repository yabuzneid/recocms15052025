using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OccurrenceDetails", Schema = "dbo")]
  public partial class OccurrenceDetail
  {
    public Guid ID
    {
      get;
      set;
    }
    public int OccurrenceID
    {
      get;
      set;
    }
    public string OccurrenceNo
    {
      get;
      set;
    }
    public string OccurrenceDescription
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
    public DateTime? OccurrenceDate
    {
      get;
      set;
    }
    public decimal? ValueOfTransaction
    {
      get;
      set;
    }
    public decimal? AdjustedGrossClaim
    {
      get;
      set;
    }
    public decimal? ExpectedPayout
    {
      get;
      set;
    }
    public string BrokerageName
    {
      get;
      set;
    }
    public int? OccurenceStatusID
    {
      get;
      set;
    }
    public decimal? TotalClaimedAmount
    {
      get;
      set;
    }
    public string FullOccurrenceName
    {
      get;
      set;
    }
  }
}
