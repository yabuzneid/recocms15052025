using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OccurrenceClaimTrades", Schema = "dbo")]
  public partial class OccurrenceClaimTrade
  {
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

    [Column("Claim Status")]
    public string ClaimStatus
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }

    [Column("Transaction Role")]
    public string TransactionRole
    {
      get;
      set;
    }
    public string TradeDisplay
    {
      get;
      set;
    }
    public int? OccurrenceID
    {
      get;
      set;
    }
    public int ClaimantID
    {
      get;
      set;
    }
    public int? TradeID
    {
      get;
      set;
    }
    public string Address1
    {
      get;
      set;
    }
    public int MasterFileID
    {
      get;
      set;
    }
  }
}
