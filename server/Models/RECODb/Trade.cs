using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Trades", Schema = "dbo")]
  public partial class Trade
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TradeID
    {
      get;
      set;
    }

    public ICollection<CommissionInstallment> CommissionInstallments { get; set; }
    public int? ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    public string Address1
    {
      get;
      set;
    }
    public string Address2
    {
      get;
      set;
    }
    public string UnitNumber
    {
      get;
      set;
    }
    public int? Province
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string City
    {
      get;
      set;
    }
    public string PostalCode
    {
      get;
      set;
    }
    public int? HomeInspection
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public int? SPIS
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public int? PersonalInterest
    {
      get;
      set;
    }
    public Parameter Parameter3 { get; set; }
    public int? Country
    {
      get;
      set;
    }
    public Parameter Parameter4 { get; set; }
    public DateTime? LeaseDate
    {
      get;
      set;
    }
    public decimal? Price
    {
      get;
      set;
    }
    public DateTime? DateClosed
    {
      get;
      set;
    }
    public decimal? DepositAmount
    {
      get;
      set;
    }
    public int? TradeTypeID
    {
      get;
      set;
    }
    public Parameter Parameter5 { get; set; }
    public bool DealClosed
    {
      get;
      set;
    }
    public string BuyerName
    {
      get;
      set;
    }
    public int? BuyerCDFileID
    {
      get;
      set;
    }
    public string SellerName
    {
      get;
      set;
    }
    public int? SellerCDFileID
    {
      get;
      set;
    }
    public bool BuilderDeal
    {
      get;
      set;
    }
    public int? BuilderID
    {
      get;
      set;
    }
    public Builder Builder { get; set; }
    public string BuilderReferenceNum
    {
      get;
      set;
    }
    public double? CommissionPercentage
    {
      get;
      set;
    }
    public decimal? CommissionGross
    {
      get;
      set;
    }
    public bool CommissionPaidInInstallments
    {
      get;
      set;
    }
    public bool PreconstructionDeal
    {
      get;
      set;
    }
    public bool SharedCommission
    {
      get;
      set;
    }
    public int? SharedAgentID
    {
      get;
      set;
    }
    public Registrant Registrant { get; set; }
    public bool SharedAgentSubmitClaim
    {
      get;
      set;
    }
    public int? SharedAgentClaimID
    {
      get;
      set;
    }
    public decimal? AmountCollected
    {
      get;
      set;
    }
    public DateTime? AmountCollectedDate
    {
      get;
      set;
    }
    public bool OutstandingMoney
    {
      get;
      set;
    }
    public bool OutstandingMoneyInTransit
    {
      get;
      set;
    }
    public decimal? OutstandingMoneyAmount
    {
      get;
      set;
    }
    public string OutstandingMoneyAction
    {
      get;
      set;
    }
    public int? UrbanOrRuralID
    {
      get;
      set;
    }
    public Parameter Parameter6 { get; set; }
    public Int16? DisplayOrder
    {
      get;
      set;
    }
    public double? CommissionOtherParties
    {
      get;
      set;
    }
    public decimal? AmountPreviouslyPaid
    {
      get;
      set;
    }
    public int? DidDealClose
    {
      get;
      set;
    }
    public Parameter Parameter7 { get; set; }
  }
}
