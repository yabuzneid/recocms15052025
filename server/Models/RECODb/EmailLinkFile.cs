using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("EmailLinkFile", Schema = "dbo")]
  public partial class EmailLinkFile
  {
    public string MailID
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
    public string FileGuid
    {
      get;
      set;
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID
    {
      get;
      set;
    }
  }
}
