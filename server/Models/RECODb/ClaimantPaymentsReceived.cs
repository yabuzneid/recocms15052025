using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimantPaymentsReceived", Schema = "dbo")]
  public partial class ClaimantPaymentsReceived
  {
    [Key]
    public int ClaimantID
    {
      get;
      set;
    }
    public Claimant Claimant { get; set; }
    [Key]
    public DateTime PaymentReceivedDate
    {
      get;
      set;
    }
    public decimal PaymentAmountReceived
    {
      get;
      set;
    }
  }
}
