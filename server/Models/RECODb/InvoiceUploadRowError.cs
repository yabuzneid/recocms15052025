using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("InvoiceUploadRowErrors", Schema = "dbo")]
  public partial class InvoiceUploadRowError
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ErrorID
    {
      get;
      set;
    }
    public int RowNumber
    {
      get;
      set;
    }
    public string Problem
    {
      get;
      set;
    }
  }
}
