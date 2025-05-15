using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("AccountingAudit", Schema = "dbo")]
  public partial class AccountingAudit
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public string RequestID
    {
      get;
      set;
    }
    public DateTime TransactionDate
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string PayTypeDescription
    {
      get;
      set;
    }
    public string Payee
    {
      get;
      set;
    }
    public decimal Amount
    {
      get;
      set;
    }
  }
}
