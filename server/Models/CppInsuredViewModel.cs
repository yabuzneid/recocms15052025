using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class CppInsuredViewModel
    {
        public Guid ID { get; set; }
        public int ClaimID { get; set; }
        public int InsuredID { get; set; }

        [DisplayName("Transaction Role")]
        public string TransactionRole { get; set; }

        public string Name { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Business Phone #")]
        public string BusinessPhoneNum { get; set; }

        [DisplayName("Cell Phone #")]
        public string CellPhoneNum { get; set; }

        [DisplayName("Broker Of Record")]
        public string BrokerOfRecord { get; set; }

        [DisplayName("Brokerage")]
        public string Brokerage { get; set; }

        [DisplayName("Registrant #")]
        public string RegistrantNo { get; set; }
        [DisplayName("Primary Insured")]
        public string PrimaryInsured { get; set; }


    }
}
