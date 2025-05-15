using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimCurrentPayments", Schema = "dbo")]
  public partial class ClaimCurrentPayment
  {
    public int ClaimID
    {
      get;
      set;
    }
    public int IncurredTypeID
    {
      get;
      set;
    }
    public decimal? TotalPayment
    {
      get;
      set;
    }
    public string IncurredType
    {
      get;
      set;
    }
  }
}
