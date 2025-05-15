using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Newtonsoft.Json;

namespace RecoCms6.Pages
{
    public partial class AddClaimLitigationDateComponent
    {
        protected async Task SaveErrorAsync(System.Exception exception)
        {
            try
            {
                var errorLog = new ErrorLog();
                errorLog.ClaimID = claimlitigationdate.ClaimID;
                errorLog.ErrorMessage = JsonConvert.SerializeObject(exception);
                errorLog.UserID = Security.User.Id;
                await RecoDb.CreateErrorLog(errorLog);
            }
            catch { }
        }
    }
}
