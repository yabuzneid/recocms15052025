using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("EmailMessages", Schema = "dbo")]
  public partial class EmailMessage
  {
    [Key]
    public string ID
    {
      get;
      set;
    }
    public int MessageID
    {
      get;
      set;
    }
    public int ParentFolderID
    {
      get;
      set;
    }
    public EmailFolder EmailFolder { get; set; }
    public string Subject
    {
      get;
      set;
    }
    public string Sender
    {
      get;
      set;
    }
    public string CCRecipients
    {
      get;
      set;
    }
    public bool HasAttachments
    {
      get;
      set;
    }
  }
}
