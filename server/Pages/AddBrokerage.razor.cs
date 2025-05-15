using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;

namespace RecoCms6.Pages
{
    public partial class AddBrokerageComponent
    {
        BrokerageContact contactToInsert;
        protected async Task InsertContactRow()
        {
            contactToInsert = new BrokerageContact();
            await contactsGrid.InsertRow(contactToInsert);
        }
    }
}
