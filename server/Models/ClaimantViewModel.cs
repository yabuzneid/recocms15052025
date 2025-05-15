using System;
using System.ComponentModel;

namespace RecoCms6.Models
{
    public class ClaimantViewModel
    {
        public Guid ID { get; set; }
        public int ClaimID { get; set; }

        public string Name { get; set; }

        [DisplayName("EMAIL ADDRESS")]
        public string EmailAddress { get; set; }

        [DisplayName("BUSINESS PHONE #")]
        public string BusinessPhoneNum { get; set; }

        [DisplayName("CELL PHONE #")]
        public string CellPhoneNum { get; set; }
    }
}
