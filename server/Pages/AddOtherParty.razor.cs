using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Microsoft.AspNetCore.Components;
using RecoCms6.Data;
using DocumentFormat.OpenXml.Office.CustomXsn;

namespace RecoCms6.Pages
{
    public partial class AddOtherPartyComponent
    {
        [Inject]
        public RecoDbContext DbContext { get; set; }

        public OtherParty Get(int intOtherProperty) 
        {
            return DbContext.OtherParties.FirstOrDefault(x => x.OtherPartyID == intOtherProperty);
        }

        public bool Upsert()
        {
            if (otherparty.OtherPartyID == 0)
            {
                DbContext.OtherParties.Add(otherparty);
                if (otherparty.SolicitorID != null)
                    DbContext.ServiceProviders.Add(solicitor);
            }
            
            DbContext.SaveChanges();

            return true;
        }
    }
}
