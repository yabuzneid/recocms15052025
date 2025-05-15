using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CDPClaimDetails", Schema = "dbo")]
  public partial class CdpClaimDetail
  {
    [Key]
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public int? StatusOfFundsID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public DateTime? TransactionClosingDate
    {
      get;
      set;
    }
    public bool Verified
    {
      get;
      set;
    }
    public decimal? ClaimedAmount
    {
      get;
      set;
    }
    public decimal? AdjustedGrossClaim
    {
      get;
      set;
    }
    public decimal? ExpectedPayout
    {
      get;
      set;
    }
    public decimal? ValueOfTransaction
    {
      get;
      set;
    }
    public bool PreconstructionDeal
    {
      get;
      set;
    }
    public string Comments
    {
      get;
      set;
    }
    public string ClaimCalculation
    {
      get;
      set;
    }
    public int? CDFileID
    {
      get;
      set;
    }
    public Claim Claim1 { get; set; }
    public string ClaimVerification
    {
      get;
      set;
    }
    public string TrustAccountBank
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
    public string RecoveryEfforts
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
    public DateTime? OtherDepositDate
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
    public bool SharedCommission
    {
      get;
      set;
    }
    public decimal? ClaimedAmount1
    {
      get;
      set;
    }
    public bool PaymentsOwing
    {
      get;
      set;
    }
    public bool ByInsurerOrReceiver
    {
      get;
      set;
    }
    public bool ClaimantStatus
    {
      get;
      set;
    }
    public bool PaymentMade
    {
      get;
      set;
    }
    public string ReasonNoPayment
    {
      get;
      set;
    }
    public bool CoverageCap
    {
      get;
      set;
    }
    public int? ByInsurerOrReceiverID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public int? RelatedClaimID
    {
      get;
      set;
    }
    public Claim Claim2 { get; set; }
    public string AmountClaimedDetails
    {
      get;
      set;
    }
    public string CommissionCalculations
    {
      get;
      set;
    }
    public string InitialStatus
    {
      get;
      set;
    }
    public string CurrentDevelopments
    {
      get;
      set;
    }
    public string Resolution
    {
      get;
      set;
    }
    public string OtherParties
    {
      get;
      set;
    }
    public string Miscellaneous
    {
      get;
      set;
    }
  }
}
