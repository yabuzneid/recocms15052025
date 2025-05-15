using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Pages
{
    public partial class AddTradeComponent
    {
        protected async System.Threading.Tasks.Task SaveTrade()
        {
            try
            {
                var recoDbGetNextClaimDisplayOrdersResult = await RecoDb.GetNextClaimDisplayOrders(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { intClaimID } });
                trade.DisplayOrder = (short)recoDbGetNextClaimDisplayOrdersResult.FirstOrDefault().NextTradeDisplayOrder;

                if (trade.TradeID > 0)
                {
                    var recoDbUpdateTradeResult = await RecoDb.UpdateTrade(trade.TradeID, trade);
                    var recoDbStoreClaimAuditTrailsResult = await RecoDb.StoreClaimAuditTrails(claim.ClaimID, $"{Security.User.Id}");
                }
                else
                {
                    var recoDbCreateTradeResult = await RecoDb.CreateTrade(trade);
                    var recoDbStoreClaimAuditTrailsResult0 = await RecoDb.StoreClaimAuditTrails(claim.ClaimID, $"{Security.User.Id}");                    
                }
                DialogService.Close(trade);
            }
            catch (System.Exception recoDbUpdateTradeException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable to Save" });
            }
        }
    }
}
