using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Hangfire;
using RecoCms6.Services.Background.MailServices;
using System.IO;

namespace RecoCms6.Pages
{
    public partial class ClaimsComponent
    {
        protected RadzenTextBox txtSearch;
        //protected RadzenSelectBar<int> selectBarStatus;
        //protected RadzenSelectBar<dynamic> selectBarBrokerageOnly;
        protected RadzenCheckBox<bool> chkCoverageIssue;
        protected RadzenDropDown<int> dropdownStatusFilter;
        protected RadzenDropDown<int> dropdownBrokerageOnly;
        protected RadzenDropDown<dynamic> dropdownClaimOrIncident;
        //protected RadzenSelectBar<dynamic> selectbarClaimOrIncident;

        protected async System.Threading.Tasks.Task SelectBarStatusChanged(int args)
        {
            await _GetFilterdListBy<int>("ClaimStatusID", args);
        }

        protected async Task SelectBarBrokerageOnlyChanged(int args)
        {
            await _GetFilterdListBy<int>("BrokerageOnly", args);
        }

        protected async System.Threading.Tasks.Task ChkCoverageIssueChangeAlt(bool args)
        {
            await _GetFilterdListBy<bool>("CoverageIssue", args);
        }

        protected async System.Threading.Tasks.Task SelectBarClaimOrIncidentChanged (int args)
        {
            //if (args == 2)
                await TxtSearchChanged(false);
            //else if (args == 1)
            //    await _GetFilterdListBy<bool>("ClaimOrIncident", true);
            //else
            //    await _GetFilterdListBy<bool>("ClaimOrIncident", false);
        }
        protected async Task TxtSearchChanged(bool args)
        {
            
            await _GetFilterdListBy<bool>("", args);
            
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                //_LoadSelectBar(selectBarStatus, 1);
                //_LoadSelectBar(selectBarBrokerageOnly, 26);
            }
        }

        private void _LoadSelectBar(RadzenSelectBar<int> selectBarStatus, int paramTypeID)
        {
            IEnumerable<RadzenSelectBarItem> statuses = Parameters
               .Where(p => p.ParamTypeID == paramTypeID)
               .Select(p => new RadzenSelectBarItem() { Text = p.ParamDesc, Value = p.ParameterID });

            foreach (var status in statuses)
            {
                selectBarStatus.AddItem(status);
            }
        }

        private async Task _GetFilterdListBy<Targs>(string param, Targs args)
        {
            isLoading = true;
            await Task.Delay(1);
            var search = txtSearch?.Value?.Trim() ?? string.Empty;

            Query query;
            
            //if (param != "")
            //    query = _BuildQuery(args, search, $@"&& (i.{param} == {args})");
            //else
            query = _BuildQuery(args, search, "");

            var recoDbGetClaimListsResult = await RecoDb.GetClaimSearchLists(query);

            if (excludedIDs.Count > 0)
                getClaimListsResult = recoDbGetClaimListsResult.Where(c => !excludedIDs.Contains(c.ClaimID));
            else
                getClaimListsResult = recoDbGetClaimListsResult;

            if (getClaimListsResult.Count() == 1 && SelectClaim == null && bAuto) //Go directly to 
            {
                var claim = getClaimListsResult.First();

                if (Security.IsInRole("Defense Counsel", "Legal Assistants"))
                    UriHelper.NavigateTo($"claim-report/{claim.ClaimID.ToBase64()}", true);
                else if (claim.Program == "Errors And Omissions")
                    UriHelper.NavigateTo($"edit-claim/{claim.ClaimID.ToBase64()}", true);
                else
                    UriHelper.NavigateTo($"edit-commission-claim/{claim.ClaimID.ToBase64()}", true);
            }

            //await datagrid0.FirstPage();
            isLoading = false;
            await Task.Delay(1);

            //if (Security.IsInRole("Defense Counsel"))
            //    if (selectedProgramID == 0)
            //        getClaimListsResult = recoDbGetClaimListsResult.Where(c => c.DefenseCounselFirmID == serviceprovider.FirmID);
            //    else
            //        getClaimListsResult = recoDbGetClaimListsResult.Where(c => c.ProgramID == selectedProgramID && c.DefenseCounselFirmID == serviceprovider.FirmID);
            //else if (selectedProgramID == 0)
            //    getClaimListsResult = recoDbGetClaimListsResult.Where(c => !excludedIDs.Contains(c.ClaimID));
            //else
            //    getClaimListsResult = recoDbGetClaimListsResult.Where(c => c.ProgramID == selectedProgramID && !excludedIDs.Contains(c.ClaimID));
        }

        private Query _BuildQuery<T>(T args, string search, string queryString = "")
        {
            Query query;

            var searchQuery = String.Empty;

            if (search != String.Empty)
                searchQuery = $@"i => (i.ClaimNo.Contains(""{search}"")
                    || i.Claimants.Contains(""{search}"")
                    || i.Insureds.Contains(""{search}"")
                    || i.Address.Contains(""{search}"")
                    || i.FileHandler.Contains(""{search}"")
                    || i.Broker.Contains(""{search}"")
                    || i.Broker1.Contains(""{search}"")
                    || i.Brokerage.Contains(""{search}"")
                    || i.Brokerage1.Contains(""{search}"")
                    || i.BrokerOfRecord.Contains(""{search}"")
                    || i.Builder1.Contains(""{search}"")
                    || i.DefenceCounsel.Contains(""{search}"")) ";
            
            var filterQuery = String.Empty;

            if (filterBrokerageOnly > 0)
                filterQuery = $@"&& i.BrokerageOnly == {filterBrokerageOnly} ";

            //if (dropdownStatusFilter.Value != null && dropdownStatusFilter.Value.ToString() != "0")
            //    filterQuery = filterQuery + $@"&& i.ClaimStatusID == {dropdownStatusFilter.Value} ";

            if (excludedClaimID != 0)
                filterQuery = filterQuery + $@"&& i.ClaimID != {excludedClaimID} ";

            //if (excludedIDs.Count > 0)
            //{
            //    foreach (int excludedId in excludedIDs)
            //        filterQuery = filterQuery + $@"&& i.ClaimID != " + excludedId.ToString();
            //}
                
            if (filterStatus > 0)
                filterQuery = filterQuery + $@"&& i.ClaimStatusID == {filterStatus} ";

            if (chkCoverageIssue.HasValue)
                filterQuery = filterQuery + $@"&& i.CoverageIssue == true ";

            if (dropdownClaimOrIncident.Value != null && dropdownClaimOrIncident.Value?.ToString() == "1")
                filterQuery = filterQuery + $@"&& i.ClaimOrIncident == true ";
            else if (dropdownClaimOrIncident.Value != null && dropdownClaimOrIncident.Value?.ToString() == "0")
                filterQuery = filterQuery + $@"&& i.ClaimOrIncident == false ";


            if (Globals.selectedProgramID > 0)
                filterQuery = filterQuery + $@"&& i.ProgramID == {Globals.selectedProgramID} ";

            if (Security.IsInRole("Defense Counsel", "Legal Assistants"))
            {
                if (serviceprovider.PrimeUser == true) //Let Prime users see all files in the firm
                    filterQuery = filterQuery + $@"&& i.DefenseCounselFirmID == {serviceprovider.FirmID} ";
                else
                    filterQuery = filterQuery + $@"&& i.DefenseCounselID == {serviceprovider.ServiceProviderID} ";
            }
                

            if (searchQuery == String.Empty && filterQuery != String.Empty) //Remove the first 2 ampersands if there's no search criteria
            {
                filterQuery = filterQuery.Substring(3);
                filterQuery = $@"i => " + filterQuery;
            }
            else
                filterQuery = searchQuery + filterQuery;

            query = new Query() { Filter = filterQuery, OrderBy = $"ClaimNo desc" };

            return query;
        }

        protected void GenerateRndParameter()
        {
            //randomParam = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        }
    }
}