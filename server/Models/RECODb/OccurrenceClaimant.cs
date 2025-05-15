using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("OccurrenceClaimants", Schema = "dbo")]
  public partial class OccurrenceClaimant
  {
    public string MasterFileNo
    {
      get;
      set;
    }
    public int MasterFileID
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
    public string ClaimantDisplay
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
    public decimal? IndemnityReserve
    {
      get;
      set;
    }
    public decimal? IndemnityPayment
    {
      get;
      set;
    }
    public decimal? AdjustingReserve
    {
      get;
      set;
    }
    public decimal? AdjustingPayment
    {
      get;
      set;
    }
    public decimal? LegalReserve
    {
      get;
      set;
    }
    public decimal? LegalPayment
    {
      get;
      set;
    }
    public decimal? ExpenseReserve
    {
      get;
      set;
    }
    public decimal? ExpensePayment
    {
      get;
      set;
    }
    public decimal? Subrogation
    {
      get;
      set;
    }
    public decimal? Deductible
    {
      get;
      set;
    }
    public decimal? TotalReserve
    {
      get;
      set;
    }
    public decimal? TotalPayment
    {
      get;
      set;
    }
    public decimal? TotalRecovery
    {
      get;
      set;
    }
    public decimal? TotalIncurred
    {
      get;
      set;
    }
  }
}
