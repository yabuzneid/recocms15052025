using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("XRefClaims", Schema = "dbo")]
  public partial class XRefClaim
  {
    public int BaseClaimID
    {
      get;
      set;
    }
    public int XRefClaimID
    {
      get;
      set;
    }
    public string XRefClaimNo
    {
      get;
      set;
    }
    public string XRefInsureds
    {
      get;
      set;
    }
    public string XRefClaimants
    {
      get;
      set;
    }
    public string XRefAddress
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
    public string DefenceCounsel
    {
      get;
      set;
    }
    public string FileHandler
    {
      get;
      set;
    }
  }
}
