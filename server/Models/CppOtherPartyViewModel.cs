using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class CppOtherPartyViewModel
    {
        public Guid ID { get; set; }
        public int ClaimID { get; set; }

        public int OtherPartyID { get; set; }

        [DisplayName("Transaction Role")]
        public string TransactionRole { get; set; }

        public string Name { get; set; }

        [DisplayName("Business Phone #")]
        public string BusinessPhoneNum { get; set; }

        [DisplayName("Cell Phone #")]
        public string CellPhoneNum { get; set; }

        [DisplayName("Communication Method")]
        public string CommunicationMethod { get; set; }
    }
}