using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetSevenYearsClaimIndemnity", Schema = "dbo")]
  public partial class GetSevenYearsClaimIndemnity
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public decimal? ContractYear
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal IndemnityReserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal IndemnityPayment
    {
      get;
      set;
    }
  }
}
