using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Claimants", Schema = "dbo")]
  public partial class Claimant
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    public int? ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaimantID
    {
      get;
      set;
    }

    public ICollection<ClaimantLitigationRole> ClaimantLitigationRoles { get; set; }
    public ICollection<ClaimantPaymentsReceived> ClaimantPaymentsReceiveds { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public int? RegistrantID
    {
      get;
      set;
    }
    public Registrant Registrant { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public int? ProvinceID
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
    public string EmailAddress
    {
      get;
      set;
    }
    public string BusinessPhoneNum
    {
      get;
      set;
    }
    public string CellPhoneNum
    {
      get;
      set;
    }
    public string FaxNum
    {
      get;
      set;
    }
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public Int16 ClaimantOrder
    {
      get;
      set;
    }
    public int? ClaimantSolicitorID
    {
      get;
      set;
    }
    public ClaimantSolicitor ClaimantSolicitor { get; set; }
    public int? TransactionRoleID
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public int? CooperatingBrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
    public bool SharedCommission
    {
      get;
      set;
    }
    public decimal? ClaimedAmount
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
    public int? NoticeOfClaimID
    {
      get;
      set;
    }
    public int? TradeRecordSheetID
    {
      get;
      set;
    }
    public int? AgreementofSaleID
    {
      get;
      set;
    }
    public int? CommissionInvoiceID
    {
      get;
      set;
    }
    public int? BuilderAgreementsID
    {
      get;
      set;
    }
    public int? StatementOfAdjustmentsID
    {
      get;
      set;
    }
    public int? SplitCommissionChequeID
    {
      get;
      set;
    }
    public int? NSFCommissionChequeID
    {
      get;
      set;
    }
    public bool SelfRepresented
    {
      get;
      set;
    }
    public string ContactName
    {
      get;
      set;
    }
    public string RegistrantNum
    {
      get;
      set;
    }
    public string OtherTransactionRole
    {
      get;
      set;
    }
  }
}
