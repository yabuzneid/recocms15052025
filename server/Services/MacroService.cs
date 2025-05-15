using Microsoft.EntityFrameworkCore;
using Radzen;
using RecoCms6.Models.RecoDb;
using RecoCms6.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RecoCms6.Services
{
    public class MacroService
    {
        private Dictionary<string, Func<ClaimList, string>> macroValues = new Dictionary<string, Func<ClaimList, string>>()
        {
            { "[Enter Date]", claim =>  DateTime.Now.ToShortDateString() },
            { "[ClaimNo]", claim => claim.ClaimNo ?? "[ClaimNo ]" },
            { "[Insured]", claim => claim?.Insured1 ?? "[Insured ]" },
            { "[Claimant]", claim => claim?.Claimant1 ?? "[Claimant ]" },
            { "[TradeAddress]", claim => claim?.FullAddress ?? "[TradeAddress ]" },
            { "[FileHandler]", claim => claim?.FileHandler ?? "[FileHandler ]" },
            { "[FileHandlerFirm]", claim => claim?.FileHandlerFirm?? "[FileHandlerFirm ]" },
            { "[DefenseCounsel]", claim => claim?.DefenceCounsel ?? "[DefenseCounsel ]" },
            { "[Brokerage]" , claim=>claim?.Brokerage1 ?? claim?.Brokerage ?? "[Brokerage ]" },
            { "[Registrants]", claim => claim?.Insureds ?? "[Registrants ]" },
            { "[DateSubmitted]", claim => "[DateSubmitted ]" },
            { "[CounselFileNo]", claim=>claim?.CounselFileNo??"[CounselFileNo ]" },
            { "[FileHandlerEmail]", claim=>claim?.FileHandlerEmailAddress??"[FileHandlerEmail ]" },
            { "[LastReportDate]", claim=>claim?.LastSubmittedReport.ToString()??"[LastReportDate ]" },
            { "[ProgramManager]", claim=>claim?.ProgramManager??"[ProgramManager ]" },
            { "[FileHandlerPhoneNum]", claim=>claim?.FileHandlerPhoneNum??"[FileHandlerPhoneNum ]" },
            { "[BrokerOfRecord]", claim=>claim?.BrokerOfRecord??"[BrokerOfRecord ]" },
            { "[AdjusterFileNum]", claim=>claim?.AdjusterClaimNo??"[AdjusterFileNum ]" }
        };

        private RecoDbService recoDbService;

        public MacroService(RecoDbService recoDbService)
        {
            this.recoDbService = recoDbService;
        }

        public async Task<string> Replace(int claimID, string toReplace) 
        {
            //var query = await this.recoDbService.GetClaims(new Query() { Filter = $@"i => i.ClaimID == {claimID}" });
            
            var query = await this.recoDbService.GetClaimLists(new Query { Filter = $@"i => i.ClaimID == {claimID}" });
            var claim = query.FirstOrDefault();
            /*var claim = query.Include(x => x.Trades)
                .Include(x => x.Claimants)
                .Include(x => x.Insureds)
                    .ThenInclude(x => x.Registrant)
                .Include(x => x.ServiceProvider1)
                    .ThenInclude(x => x.Firm)
                    .FirstOrDefault(); */


            var result = toReplace;
            foreach ((string macroKey, Func<ClaimList,string> getData) in macroValues)
            {
                result = result.Replace(macroKey, getData(claim));
            }

            return result;
        }
    }
}
