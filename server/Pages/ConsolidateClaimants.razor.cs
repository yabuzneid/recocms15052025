using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;

namespace RecoCms6.Pages
{
    public partial class ConsolidateClaimantsComponent
    {
        public async void ConsolidateClaimants()
        {
            foreach (OccurrenceClaimant selectedclaimant in selectedclaimants)
            {
                if (selectedclaimant.ClaimantID != chosenclaimant)
                    await RecoDb.ConsolidateClaimants(chosenclaimant, selectedclaimant.ClaimantID);
            }
        }
    }
}
