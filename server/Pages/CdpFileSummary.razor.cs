using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Pages
{
    public partial class CdpFileSummaryComponent
    {
        protected async System.Threading.Tasks.Task SaveSummary()
        {
            var recoDbUpdateClaimResult = await RecoDb.UpdateClaim(claim.ID, claim);
            var recoDbUpdateEoClaimDetailResult = await RecoDb.UpdateCdpClaimDetail(claim.ClaimID, claimdetails);

            if (!newclaimant)
            {
                var recoDbUpdateClaimantResult = await RecoDb.UpdateClaimant(claimant.ID, claimant);

            }
            else if (newclaimant && claimant.Name != null)
            {
                claimant.ClaimID = claim.ClaimID;
                claimant.ClaimantOrder = 1;
                var recoDbCreateClaimantResult = await RecoDb.CreateClaimant(claimant);
            }

            if (!newtrade)
            {
                var recoDbUpdateTradeResult = await RecoDb.UpdateTrade(trade.TradeID, trade);

            }
            else if (newtrade && trade.Address1 != null)
            {
                trade.ClaimID = claim.ClaimID;
                trade.DisplayOrder = 1;
                var recoDbCreateTradeResult = await RecoDb.CreateTrade(trade);
            }

            DialogService.Close(claim);
        }
    
    }
}
