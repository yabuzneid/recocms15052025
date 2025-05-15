using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("VoidPayments", Schema = "dbo")]
  public partial class VoidPayment
  {
    public string ClaimNo
    {
      get;
      set;
    }
    public string ControlNumber
    {
      get;
      set;
    }
    public DateTime TransactionDate
    {
      get;
      set;
    }
    public DateTime? VoidDate
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
