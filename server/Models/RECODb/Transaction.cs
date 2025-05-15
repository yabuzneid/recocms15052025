using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Transactions", Schema = "dbo")]
  public partial class Transaction
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TransactionID
    {
      get;
      set;
    }

    public ICollection<Transaction> Transactions1 { get; set; }
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public int IncurredTypeID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int IncurredCategoryID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public DateTime TransactionDate
    {
      get;
      set;
    }
    public decimal Amount
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
    public Transaction Transaction1 { get; set; }
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
    public Firm Firm { get; set; }
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
    public string SendingInstructions
    {
      get;
      set;
    }
    public int? ServiceProviderID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
    public int? ReserveTypeID
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public DateTime? InvoicePeriodStartDate
    {
      get;
      set;
    }
    public DateTime? InvoicePeriodEndDate
    {
      get;
      set;
    }
    public DateTime? InvoiceDate
    {
      get;
      set;
    }
  }
}
