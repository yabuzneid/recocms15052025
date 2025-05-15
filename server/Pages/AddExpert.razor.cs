using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace RecoCms6.Pages
{
    public partial class AddExpertComponent
    {
        protected void Validate()
        {
            rfvExpert = expert.ServiceProviderID == 0;

            rfvName = String.IsNullOrWhiteSpace(expert.Name);
            if (String.IsNullOrWhiteSpace(expert.EmailAddress))
                rfvEmail = false;
            else
                rfvEmail =!IsEmailValid(expert.EmailAddress);

            Regex regex = new Regex(@"([ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy][0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy])\ ?([0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy][0-9])");
            if (!String.IsNullOrWhiteSpace(expert.PostalCode))
            {
                Match match = regex.Match(expert.PostalCode);
                rfvPostalCode = !match.Success;
            }
            else
                rfvPostalCode = false;
            
            rfvRole = expert.ServiceProviderRoleID == 0;

            bPageIsValid =  !(rfvEmail || rfvName || rfvExpert || rfvPostalCode || rfvRole);
        }

        protected bool IsEmailValid(string emailaddress)
        {
            //No Validation for RECO CMS for now.  
            if (Globals.generalsettings.ApplicationName == "RECO CMS")
                return true;

            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
