using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TransactionApprovalLimits", Schema = "dbo")]
  public partial class TransactionApprovalLimit
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApprovalLimitID
    {
      get;
      set;
    }

    public ICollection<TransactionApprovalLimit> TransactionApprovalLimits1 { get; set; }
    public TransactionApprovalLimit TransactionApprovalLimit1 { get; set; }
    public string RoleID
    {
      get;
      set;
    }
    public int IncurredTypeID
    {
      get;
      set;
    }
    public int IncurredCategoryID
    {
      get;
      set;
    }
    public int ApprovalLimit
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
    public int? ProgramID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
  }
}
