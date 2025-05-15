using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class TradeViewModel
    {
        public int TradeID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [DisplayName("Unit #")]
        public string UnitNumber { get; set; }
        public string City { get; set; }
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string Province { get; set; }
        [DisplayName("Type")]
        public string TradeType { get; set; }
        public int ClaimID { get; set; }
        public int OccurrenceID { get; set; }
        
    }
}
