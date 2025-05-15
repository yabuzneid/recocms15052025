using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CommissionInstallments", Schema = "dbo")]
  public partial class CommissionInstallment
  {
    public int TradeID
    {
      get;
      set;
    }
    public Trade Trade { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CommissionInstallmentID
    {
      get;
      set;
    }
    public decimal? Amount
    {
      get;
      set;
    }
    public DateTime? DatePaid
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
  }
}
