using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TransactionListReport", Schema = "dbo")]
  public partial class TransactionListReport
  {
    public string ClaimNo
    {
      get;
      set;
    }

    [Column("Policy #")]
    public string Policy
    {
      get;
      set;
    }

    [Column("Contract Year")]
    public string ContractYear
    {
      get;
      set;
    }
    public DateTime TransactionDate
    {
      get;
      set;
    }

    [Column("Loss Type")]
    public string LossType
    {
      get;
      set;
    }
    public string Type
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Reserve
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Payment
    {
      get;
      set;
    }
    public string Comments
    {
      get;
      set;
    }

    [Column("Added By")]
    public string AddedBy
    {
      get;
      set;
    }
  }
}
