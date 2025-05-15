using System;
using System.ComponentModel;

namespace RecoCms6.Models
{
    public class CppClaimantViewModel
    {
        public Guid ID { get; set; }
        public int ClaimID { get; set; }
        public int ClaimantID { get; set; }
        [DisplayName("Transaction Role")]
        public string TransactionRole { get; set; }
        public string Name { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Business Phone #")]
        public string BusinessPhoneNum { get; set; }
        [DisplayName("Cell Phone #")]
        public string CellPhoneNum { get; set; }
        [DisplayName("Trade Record Sheet")]
        public int? TradeRecordSheetID { get; set; }
        [DisplayName("Agreement of Sale")]
        public int? AgreementofSaleID { get; set; }
        [DisplayName("Commission Invoice")]
        public int? CommissionInvoiceID { get; set; }
        [DisplayName("Statement of Adjustments")]
        public int? StatementOfAdjustmentsID { get; set; }
        [DisplayName("Builder Agreements")]
        public int? BuilderAgreementsID { get; set; }
        [DisplayName("Split Commission Cheque")]
        public int? SplitCommissionChequeID { get; set; }
        [DisplayName("NSF Commission Cheque")]
        public int? NSFCommissionChequeID { get; set; }
        [DisplayName("Notice of Claim")]
        public int? NoticeOfClaimID { get; set; }
        
    }
}
