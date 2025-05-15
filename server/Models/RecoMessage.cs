using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class RecoMessage
    {
        public Message Message { get; set; }
        public Models.RecoDb.Claim Claim { get; set; }

        public bool HasClaim 
        {
            get => Claim != null;
            
        }

        public string ClaimNo
        {
            get => Claim?.ClaimNo ?? "";
            set 
            {

            }
        }
    }
}
