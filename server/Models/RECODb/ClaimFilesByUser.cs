using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimFilesByUser", Schema = "dbo")]
  public partial class ClaimFilesByUser
  {
    public int FileID
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public string Subject
    {
      get;
      set;
    }
    public int VisibleTo
    {
      get;
      set;
    }
    public string UploadedById
    {
      get;
      set;
    }
    public int? FileTypeID
    {
      get;
      set;
    }
    public bool LargeLoss
    {
      get;
      set;
    }
    public bool Sticky
    {
      get;
      set;
    }
    public string Filename
    {
      get;
      set;
    }
    public string Extension
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Filesize
    {
      get;
      set;
    }
    public string ContentType
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string UploadedBy
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
    public string FileType
    {
      get;
      set;
    }
    public string Comments
    {
      get;
      set;
    }
    public string FileDescription
    {
      get;
      set;
    }
    public bool Confidential
    {
      get;
      set;
    }
  }
}
