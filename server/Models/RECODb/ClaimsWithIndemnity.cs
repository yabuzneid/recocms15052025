using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimsWithIndemnity", Schema = "dbo")]
  public partial class ClaimsWithIndemnity
  {
    public string RegistrantNo
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public decimal IndemnityReserve
    {
      get;
      set;
    }
    public decimal IndemnityPayment
    {
      get;
      set;
    }
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
    public int ProgramID
    {
      get;
      set;
    }
  }
}
