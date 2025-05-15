using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Firms", Schema = "dbo")]
  public partial class Firm
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FirmID
    {
      get;
      set;
    }

    public ICollection<Expert> Experts { get; set; }
    public ICollection<InvoiceUploadFile> InvoiceUploadFiles { get; set; }
    public ICollection<ServiceProvider> ServiceProviders { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<ClaimReport> ClaimReports { get; set; }
    public string Name
    {
      get;
      set;
    }
    public int FirmTypeID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
  }
}
