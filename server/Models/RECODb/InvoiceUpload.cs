using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("InvoiceUpload", Schema = "dbo")]
  public partial class InvoiceUpload
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InvoiceUploadID
    {
      get;
      set;
    }
    public string InsuredLastName
    {
      get;
      set;
    }
    public string ClaimNo
    {
      get;
      set;
    }
    public string FileNo
    {
      get;
      set;
    }
    public decimal? Fees
    {
      get;
      set;
    }
    public decimal? Disbursements
    {
      get;
      set;
    }
    public decimal? Taxes
    {
      get;
      set;
    }
    public decimal? Total
    {
      get;
      set;
    }
    public string PayAndClose
    {
      get;
      set;
    }
    public int? RowNumber
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
  }
}
