using System;
using System.ComponentModel;

namespace RecoCms6.Models
{
    public class EOClaimantViewModel
    {
        public Guid ID { get; set; }
        public int ClaimID { get; set; }
        public int ClaimantID { get; set; }
        [DisplayName("Transaction Role")]
        public string TransactionRole { get; set; }
        public string Name { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Solicitor")]
        public string ClaimantSolicitor { get; set; }
        
        [DisplayName("Business Phone #")]
        public string BusinessPhoneNum { get; set; }
        [DisplayName("Cell Phone #")]
        public string CellPhoneNum { get; set; }
    }
}
