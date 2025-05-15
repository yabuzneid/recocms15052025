using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Pages
{
    public partial class AddClaimComponent
    {

        RecoCms6.Models.RecoDb.PostalCodeDetail _getPostalCodeDetail;
        protected RecoCms6.Models.RecoDb.PostalCodeDetail getPostalCodeDetail
        {
            get
            {
                return _getPostalCodeDetail;
            }
            set
            {
                if (!object.Equals(_getPostalCodeDetail, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "getPostalCodeDetail", NewValue = value, OldValue = _getPostalCodeDetail };
                    _getPostalCodeDetail = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected async void GetPostalCodeDetails()
        {
            if (claimtrade.PostalCode.Length != 7)
                return;

            var recoDbGetPostalCodeResult = await RecoDb.GetPostalCodeDetails(new Query() { Filter = $@"i => i.PostalCode == @0", FilterParameters = new object[] { claimtrade.PostalCode } });
            getPostalCodeDetail = recoDbGetPostalCodeResult.FirstOrDefault();

            if (getPostalCodeDetail != null)
            {
                claimtrade.Province = getPostalCodeDetail.ProvinceID;
                claimtrade.City = getPostalCodeDetail.City;
            }

        }

        protected async Task<bool> SaveTrade()
        {
            if (claimtrade.Address1 == null)
                return false;

            claimtrade.ClaimID = claim.ClaimID;
            try
            {
                var recoDbGetNextClaimDisplayOrdersResult = await RecoDb.GetNextClaimDisplayOrders(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { claim.ClaimID } });
                claimtrade.DisplayOrder = (short)recoDbGetNextClaimDisplayOrdersResult.FirstOrDefault().NextTradeDisplayOrder;

                claimtrade.DisplayOrder = 1;

                if (claimtrade.TradeID > 0)
                    await RecoDb.UpdateTrade(claimtrade.TradeID, claimtrade);
                else
                    await RecoDb.CreateTrade(claimtrade);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
