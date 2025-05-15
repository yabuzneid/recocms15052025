using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Files", Schema = "dbo")]
  public partial class File
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FileID
    {
      get;
      set;
    }

    public ICollection<ClaimReport> ClaimReports { get; set; }
    public int ClaimID
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
    public string Extension
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public Int64? Filesize
    {
      get;
      set;
    }
    public string ContentType
    {
      get;
      set;
    }
    public bool Confidential
    {
      get;
      set;
    }
    public bool VisibleToCounsel
    {
      get;
      set;
    }
    public string Comments
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public Byte[] HashedFilename
    {
      get;
      set;
    }
    public string FileDescription
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Filesize2
    {
      get;
      set;
    }
  }
}
