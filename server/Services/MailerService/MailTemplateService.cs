using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Services.MailerService
{
    public static class MailTemplateService
    {
        public static string GetEmailTemplate(string name) =>
            $@"Dear {name} 

            Test email...

            Best regards,
            Reco";
    }
}
