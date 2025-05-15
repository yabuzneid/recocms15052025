using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NextClaimDisplayOrders", Schema = "dbo")]
  public partial class NextClaimDisplayOrder
  {
    public int ClaimID
    {
      get;
      set;
    }
    public Int16? NextClaimantDisplayOrder
    {
      get;
      set;
    }
    public Int16? NextInsuredDisplayOrder
    {
      get;
      set;
    }
    public Int16? NextOtherDisplayOrder
    {
      get;
      set;
    }
    public Int16? NextExpertDisplayOrder
    {
      get;
      set;
    }
    public Int16? NextTradeDisplayOrder
    {
      get;
      set;
    }
  }
}
