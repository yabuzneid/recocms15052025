using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimPreferencesDetails", Schema = "dbo")]
  public partial class ClaimPreferencesDetail
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public DateTime DateLastAccessed
    {
      get;
      set;
    }
    public string JsonPreference
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
  }
}
