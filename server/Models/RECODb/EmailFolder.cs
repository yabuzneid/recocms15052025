using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("EmailFolders", Schema = "dbo")]
  public partial class EmailFolder
  {
    [Key]
    public string ID
    {
      get;
      set;
    }
    public int FolderID
    {
      get;
      set;
    }

    public ICollection<EmailFolder> EmailFolders1 { get; set; }
    public ICollection<EmailMessage> EmailMessages { get; set; }
    public string DisplayName
    {
      get;
      set;
    }
    public int? ParentFolderID
    {
      get;
      set;
    }
    public EmailFolder EmailFolder1 { get; set; }
    public int TotalCount
    {
      get;
      set;
    }
    public int UnreadCount
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
  }
}
