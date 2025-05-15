using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimClaimants", Schema = "dbo")]
  public partial class ClaimClaimant
  {
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
    public int ClaimantID
    {
      get;
      set;
    }
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
    public int? PreferredCommunicationMethod
    {
      get;
      set;
    }
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
    public int? RegistrantID
    {
      get;
      set;
    }
    public string RegistrantNo
    {
      get;
      set;
    }
    public DateTime? RegistrationExpiryDate
    {
      get;
      set;
    }
    public Int16? YearsOfExperience
    {
      get;
      set;
    }
    public int? BrokerageID
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
    public int? StatementOfAdjustmentsID
    {
      get;
      set;
    }
    public int? BuilderAgreementsID
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
    public int? NoticeOfClaimID
    {
      get;
      set;
    }
    public string ClaimantSolicitor
    {
      get;
      set;
    }
    public string SolicitorFirm
    {
      get;
      set;
    }
    public string SolicitorEmail
    {
      get;
      set;
    }
    public string TransactionRole
    {
      get;
      set;
    }
  }
}
