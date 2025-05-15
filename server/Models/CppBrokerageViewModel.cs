using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class CppBrokerageViewModel
    {
        public Guid ID { get; set; }
        public int InsuredID { get; set; }

        [DisplayName("Brokerage")]
        public string Brokerage { get; set; }

        [DisplayName("Main Contact")]
        public string BrokerageContactPerson { get; set; }

        [DisplayName("Email Address")]
        public string BrokerageContactEmail { get; set; }

        [DisplayName("Phone #")]
        public string BrokerageContactPhoneNum { get; set; }

        [DisplayName("Broker Of Record")]
        public string BrokerOfRecord { get; set; }
    }
}