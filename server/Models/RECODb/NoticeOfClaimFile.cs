using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimFiles", Schema = "dbo")]
  public partial class NoticeOfClaimFile
  {
    public int? NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FileID
    {
      get;
      set;
    }
    public string Filename
    {
      get;
      set;
    }
    public Byte[] StoredFile
    {
      get;
      set;
    }
    public int TypeOfFileID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string UploadedById
    {
      get;
      set;
    }
    public Guid? ID
    {
      get;
      set;
    }
    public string ContentType
    {
      get;
      set;
    }
  }
}
