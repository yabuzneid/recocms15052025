using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class ExpertViewModel
    {
        public int ExpertID { get; set; }
        public int ClaimID { get; set; }
        [DisplayName("Role")]
        public string ServiceProviderRole { get; set; }
        public string Name { get; set; }
        [DisplayName("Firm")]
        public string FirmName { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Business Phone #")]
        public string BusinessPhoneNum { get; set; }
        [DisplayName("Cell Phone #")]
        public string CellPhoneNum { get; set; }
        
    }
}
