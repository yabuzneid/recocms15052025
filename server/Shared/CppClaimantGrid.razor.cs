using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using RecoCms6.Models;
using RecoCms6.Models.RecoDb;
using RecoCms6.Pages;
using Syncfusion.Blazor.Grids;

namespace RecoCms6.Shared
{
    public partial class CppClaimantGrid<TItem, TEntity, TOpenDialog> : ComponentBase where TEntity : class, new() where TOpenDialog : ComponentBase
    {
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment TableHeader { get; set; }

        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter]
        public Func<IEnumerable<TItem>, List<TEntity>> EntityQuery { get; set; }

        [Parameter]
        public Action<List<TEntity>> UpdateOrder { get; set; }

        [Parameter]
        public System.Action ReloadGrid { get; set; }

        [Parameter]
        public List<string> ExcludeList { get; set; }

        [Parameter]
        public int PageSize { get; set; } = 5;

        [Parameter]
        public IEnumerable<ParameterDetail> PageSizeList { get; set; }

        [Parameter]
        public Func<TItem, Dictionary<string, object>> DialogParameters { get; set; }

        [Parameter]
        public List<string> HiddenColumns { get; set; } = new List<string>();

        [Inject]
        protected RecoDbService RecoDb { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }

        /// <summary>
        /// Row drag drop handler
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public void RowDropHandler(RowDragEventArgs<TItem> args)
        {
            List<TEntity> entities = RecoDb.GetEntitiesByIds<TEntity>(EntityQuery(Items));

            int fromIndex = Convert.ToInt32(args.FromIndex);
            int dropIndex = Convert.ToInt32(args.DropIndex);

            var item = entities[fromIndex];
            entities.RemoveAt(fromIndex);
            entities.Insert(dropIndex, item);

            UpdateOrder(entities);

            RecoDb.UpdateEntities<TEntity>(entities, ExcludeList);
        }

        protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
        { 
            this.PageSize = Convert.ToInt32(args);
        }

        public async void RowSelectHandler(RowSelectEventArgs<TItem> args)
        {
            string strTitle = String.Empty;

            if (args.Data.GetType().ToString().Contains("CppInsuredViewModel") || args.Data.GetType().ToString().Contains("CppBrokerageViewModel")) {
                strTitle = "Edit Insured";
                await DialogService.OpenAsync<AddInsuredComponent>(strTitle, DialogParameters(args.Data), new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });
            }
            else if (args.Data.GetType().ToString().Contains("CppClaimantViewModel")) {
                strTitle = "Edit " + Globals.generalsettings.ClaimantName;
                
            }
            else if (args.Data.GetType().ToString().Contains("CppOtherPartyViewModel"))
                strTitle = "Edit Other Party";
            else if (args.Data.GetType().ToString().Contains("EOClaimantViewModel"))
                strTitle = "Edit " + Globals.generalsettings.ClaimantName;
            else if (args.Data.GetType().ToString().Contains("ExpertViewModel"))
                strTitle = "Edit Expert";
            else
                strTitle = "Edit";

           var changeditem = await DialogService.OpenAsync<TOpenDialog>(strTitle, DialogParameters(args.Data), new DialogOptions() { Width = $"{900}px", Height = $"{800}px" });
            //if (changeditem != null)
            {
                ReloadGrid();
                this.StateHasChanged();
            }
                

            
        }


        private string GetHeaderText(System.Reflection.PropertyInfo prop)
        {
            string text;

            if (prop.Name == "StatusDesc" || prop.Name == "StatusAbbrev")
                return "Status";

            if (prop.Name == "Claimants" || prop.Name == "Claimant")
                return Globals.generalsettings.ClaimantName;

            if (prop.Name.Contains("Claimant"))
                return prop.Name.Replace("Claimant", Globals.generalsettings.ClaimantName);

            if (prop.Name == "Location" || prop.Name == "Trade")
                return Globals.generalsettings.LocationName;

            if (prop.Name == "Trade Type" || prop.Name == "TradeType")
                return Globals.generalsettings.TradeTypeName;

            if (prop.Name == "ContractYear" || prop.Name == "Contract Year")
                return Globals.generalsettings.ContractYear;

            if (prop.Name == "Subrogation")
                return Globals.generalsettings.SubrogationName;

            if (prop.Name == "Broker1")
                return "Broker";

            if (prop.Name == "Loss Cause" || prop.Name == "LossCause")
                return Globals.generalsettings.LossCauseName;

            var attributes = prop.GetCustomAttributes(true);
            if (attributes == null)
            {
                return System.Text.RegularExpressions.Regex.Replace(prop.Name, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
            }

            var attr = attributes.FirstOrDefault(a => a is System.ComponentModel.DisplayNameAttribute);
            if (attr != null)
            {
                return ((System.ComponentModel.DisplayNameAttribute)attr).DisplayName;
            }

            return System.Text.RegularExpressions.Regex.Replace(prop.Name, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }

        protected async System.Threading.Tasks.Task ButtonDeleteRowClick(MouseEventArgs args, object item)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this row?") == true)
                {
                    var claimInfo = item.GetType().GetProperty("ClaimID");
                    int claimID = Convert.ToInt32(claimInfo.GetValue(item, null));

                    if (item.GetType().ToString().Contains("TradeViewModel"))
                    {
                        var propertyInfo = item.GetType().GetProperty("TradeID");
                        var value = propertyInfo.GetValue(item, null);
                        await RecoDb.DeleteTrade(Convert.ToInt32(value));
                        await RecoDb.ReorderTradesOrders(claimID);
                    }
                    else if (item.GetType().ToString().Contains("CppInsuredViewModel"))
                    {
                        var propertyInfo = item.GetType().GetProperty("ID");
                        var value = propertyInfo.GetValue(item, null);
                        await RecoDb.DeleteInsured(Guid.Parse(value.ToString()));
                        await RecoDb.ReorderInsuredOrders(claimID);
                    }
                    else if (item.GetType().ToString().Contains("CppOtherPartyViewModel"))
                    {
                        var propertyInfo = item.GetType().GetProperty("ID");
                        var value = propertyInfo.GetValue(item, null);
                        await RecoDb.DeleteOtherParty(Guid.Parse(value.ToString()));
                        await RecoDb.ReorderOtherPartiesOrders(claimID);
                    }
                    else if (item.GetType().ToString().Contains("ExpertViewModel"))
                    {
                        var propertyInfo = item.GetType().GetProperty("ExpertID");
                        var value = propertyInfo.GetValue(item, null);
                        await RecoDb.DeleteExpert(Convert.ToInt32(value));
                        await RecoDb.ReorderExpertOrders(claimID);
                    }
                    else if (item.GetType().ToString().Contains("CppClaimantViewModel") || item.GetType().ToString().Contains("EOClaimantViewModel"))
                    {
                        var propertyInfo = item.GetType().GetProperty("ID");
                        var value = propertyInfo.GetValue(item, null);
                        await RecoDb.DeleteClaimant(Guid.Parse(value.ToString()));
                        await RecoDb.ReorderClaimantOrders(claimID);
                    }

                    ReloadGrid();
                }
            }
            catch (System.Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete trades/claimants/insureds/other parties/experts" });
            }
            
        }
    }
}