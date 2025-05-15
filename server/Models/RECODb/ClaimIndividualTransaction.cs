using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimIndividualTransactions", Schema = "dbo")]
  public partial class ClaimIndividualTransaction
  {
    public Guid ID
    {
      get;
      set;
    }
    public int TransactionID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public string IncurredType
    {
      get;
      set;
    }
    public string IncurredCategory
    {
      get;
      set;
    }
    public DateTime TransactionDate
    {
      get;
      set;
    }
    public decimal? Amount
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public string PayableTo
    {
      get;
      set;
    }
    public string ChequeNum
    {
      get;
      set;
    }
    public string InvoiceNum
    {
      get;
      set;
    }
    public string Comments
    {
      get;
      set;
    }
    public string EnteredByID
    {
      get;
      set;
    }
    public int? RelatedTransactionID
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
    public decimal? ApplicableDeductible
    {
      get;
      set;
    }
    public int? FirmID
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
    public string JournalNumber
    {
      get;
      set;
    }
    public DateTime? VoidDate
    {
      get;
      set;
    }
    public int? ReserveTypeID
    {
      get;
      set;
    }

    [Column("Reserve Reason")]
    public string ReserveReason
    {
      get;
      set;
    }

    [Column("Entered By")]
    public string EnteredBy
    {
      get;
      set;
    }
  }
}
