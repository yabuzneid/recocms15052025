using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetFileById", Schema = "dbo")]
  public partial class GetFileById
  {
    public Guid? ID
    {
      get;
      set;
    }
    public int FileID
    {
      get;
      set;
    }
    public int? ClaimID
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
    public Byte[] StoredDocument
    {
      get;
      set;
    }
    public string Filename
    {
      get;
      set;
    }
    public string ContentType
    {
      get;
      set;
    }
    public string Subject
    {
      get;
      set;
    }
  }
}
