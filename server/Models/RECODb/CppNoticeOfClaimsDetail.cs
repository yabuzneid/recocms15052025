using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CPPNoticeOfClaimsDetails", Schema = "dbo")]
  public partial class CppNoticeOfClaimsDetail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NoticeOfClaimDetailsID
    {
      get;
      set;
    }
    public int? NoticeOfClaimID
    {
      get;
      set;
    }
    public decimal? AmountClaimed
    {
      get;
      set;
    }
    public decimal? PartialAmountReceived
    {
      get;
      set;
    }
    public bool PartialIncluded
    {
      get;
      set;
    }
    public DateTime? AgreementDate
    {
      get;
      set;
    }
    public DateTime? CloseDate
    {
      get;
      set;
    }
    public decimal? InitialDepositAmount
    {
      get;
      set;
    }
    public DateTime? InitialDepositDate
    {
      get;
      set;
    }
    public decimal? SecondDepositAmount
    {
      get;
      set;
    }
    public DateTime? SecondDepositDate
    {
      get;
      set;
    }
    public decimal? ThirdDepositAmount
    {
      get;
      set;
    }
    public DateTime? ThirdDepositDate
    {
      get;
      set;
    }
    public string BrokerFailureReason
    {
      get;
      set;
    }
    public string BrokerCommunications
    {
      get;
      set;
    }
    public string RecoveryEfforts
    {
      get;
      set;
    }
    public int? BrokerageAgreementFileID
    {
      get;
      set;
    }
    public int? PurchaseAgreementFileID
    {
      get;
      set;
    }
    public int? TradeRecordSheetFileID
    {
      get;
      set;
    }
    public int? CommissionInvoiceFileID
    {
      get;
      set;
    }
    public string TrustAccountBank
    {
      get;
      set;
    }
    public string TrustAccountNum
    {
      get;
      set;
    }
    public string TrustAccountAddress
    {
      get;
      set;
    }
  }
}
