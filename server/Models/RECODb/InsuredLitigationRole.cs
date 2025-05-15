using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("InsuredLitigationRoles", Schema = "dbo")]
  public partial class InsuredLitigationRole
  {
    [Key]
    public int InsuredID
    {
      get;
      set;
    }
    public Insured Insured { get; set; }
    [Key]
    public int LitigationRoleID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
  }
}
