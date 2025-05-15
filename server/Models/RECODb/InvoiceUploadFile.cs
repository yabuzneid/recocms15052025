using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("InvoiceUploadFiles", Schema = "dbo")]
  public partial class InvoiceUploadFile
  {
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
    public int FirmID
    {
      get;
      set;
    }
    public Firm Firm { get; set; }
    public DateTime UploadDate
    {
      get;
      set;
    }
    public string UploadedByID
    {
      get;
      set;
    }
    public Byte[] StoredInvoice
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
    public Int64? Filesize
    {
      get;
      set;
    }
    public Byte[] GeneratedInvoice
    {
      get;
      set;
    }
    public string GeneratedInvoiceContentType
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public Int64? GeneratedInvoiceFilesize
    {
      get;
      set;
    }
    public string GeneratedInvoiceFilename
    {
      get;
      set;
    }
  }
}
