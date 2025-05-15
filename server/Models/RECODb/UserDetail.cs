using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("UserDetails", Schema = "dbo")]
  public partial class UserDetail
  {
    public string Id
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public string Firm
    {
      get;
      set;
    }
    public string Role
    {
      get;
      set;
    }
    public string UserName
    {
      get;
      set;
    }
    public string AbbreviatedName
    {
      get;
      set;
    }
    public bool? SubmitPayments
    {
      get;
      set;
    }
    public bool? Active
    {
      get;
      set;
    }
    public bool? ViewReports
    {
      get;
      set;
    }
    public bool? FileHandler
    {
      get;
      set;
    }
    public bool? AllowedToViewConfidential
    {
      get;
      set;
    }
    public int? FirmID
    {
      get;
      set;
    }
    public int? ServiceProviderID
    {
      get;
      set;
    }
    public bool? PrimeUser
    {
      get;
      set;
    }
  }
}
