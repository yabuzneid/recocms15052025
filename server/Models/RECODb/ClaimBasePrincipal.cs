using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimBasePrincipals", Schema = "dbo")]
  public partial class ClaimBasePrincipal
  {
    public int ClaimID
    {
      get;
      set;
    }
    public string Claimants
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
    public string Address
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
    public string Builder1
    {
      get;
      set;
    }
  }
}
