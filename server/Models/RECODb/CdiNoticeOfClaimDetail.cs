using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CDINoticeOfClaimDetails", Schema = "dbo")]
  public partial class CdiNoticeOfClaimDetail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID
    {
      get;
      set;
    }
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public decimal? AmountClaimed
    {
      get;
      set;
    }
    public string Details
    {
      get;
      set;
    }
    public decimal? PurchasePrice
    {
      get;
      set;
    }
    public string AddressOfProperty
    {
      get;
      set;
    }
    public string NameOfSeller
    {
      get;
      set;
    }
    public string SellerSolicitorName
    {
      get;
      set;
    }
    public string BuyerName
    {
      get;
      set;
    }
    public string BuyerSolicitorName
    {
      get;
      set;
    }
    public int? PurchaseAndSaleAgreeementFileId
    {
      get;
      set;
    }
    public DateTime? InitialDepositDate
    {
      get;
      set;
    }
    public DateTime? SecondDepositDate
    {
      get;
      set;
    }
    public DateTime? ThirdDepositDate
    {
      get;
      set;
    }
    public DateTime? OtherDepositDate
    {
      get;
      set;
    }
    public decimal? InitialDepositAmount
    {
      get;
      set;
    }
    public decimal? SecondDepositAmount
    {
      get;
      set;
    }
    public decimal? ThirdDepositAmount
    {
      get;
      set;
    }
    public decimal? OtherDepositAmount
    {
      get;
      set;
    }
    public string BrokerageAccountBank
    {
      get;
      set;
    }
    public string BrokerageAccountNumber
    {
      get;
      set;
    }
    public string BrokerageAccountAddress
    {
      get;
      set;
    }
    public string BrokerageFailure
    {
      get;
      set;
    }
    public DateTime? DateOfDiscoveryOfLoss
    {
      get;
      set;
    }
    public string DiscoveryOfLossDetails
    {
      get;
      set;
    }
    public bool PoliceReported
    {
      get;
      set;
    }
    public DateTime? PoliceReportedDate
    {
      get;
      set;
    }
    public string PoliceOfficerName
    {
      get;
      set;
    }
    public string PoliceOfficerPhoneNumber
    {
      get;
      set;
    }
    public string ClaimentEffortToRecoverDeposit
    {
      get;
      set;
    }
    public bool CounterClaimExists
    {
      get;
      set;
    }
    public bool Agree
    {
      get;
      set;
    }
  }
}
