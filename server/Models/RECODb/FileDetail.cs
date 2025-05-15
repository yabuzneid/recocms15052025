using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("FileDetails", Schema = "dbo")]
  public partial class FileDetail
  {
    public string Subject
    {
      get;
      set;
    }
    public bool VisibleToCounsel
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
    public bool Confidential
    {
      get;
      set;
    }
    public string Comments
    {
      get;
      set;
    }
    public int FileID
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
    public string Extension
    {
      get;
      set;
    }
    public string Filename
    {
      get;
      set;
    }
    public string FileDescription
    {
      get;
      set;
    }
    public Byte[] HashedFilename
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
  }
}
