using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace RecoCms6.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public IPAddress TwofaIpAddress { get; set; }

        public DateTime UseIpFor2faSince { get; set; }

        [NotMapped]
        public IEnumerable<string> RoleNames { get; set; }

        [IgnoreDataMember]
        public override string PasswordHash { get; set; }

        [IgnoreDataMember, NotMapped]
        public string Password { get; set; }

        [IgnoreDataMember, NotMapped]
        public string ConfirmPassword { get; set; }

        [IgnoreDataMember, NotMapped]
        public string Name
        {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }
        }
        public bool? LoggedInTwoFactor { get; set; }
    }
}
