using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RecoCms6.Models;

namespace RecoCms6.Pages
{
    public partial class AddTradeComponent : ComponentBase, IDisposable
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }

        public void Dispose()
        {
            Globals.PropertyChanged -= OnPropertyChanged;
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected RecoDbService RecoDb { get; set; }

        [Parameter]
        public dynamic TradeID { get; set; }

        [Parameter]
        public dynamic ClaimID { get; set; }
        protected RadzenGrid<RecoCms6.Models.RecoDb.CommissionInstallment> gridCommissionInstallments;

        int _intTradeID;
        protected int intTradeID
        {
            get
            {
                return _intTradeID;
            }
            set
            {
                if (!object.Equals(_intTradeID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intTradeID", NewValue = value, OldValue = _intTradeID };
                    _intTradeID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _intClaimID;
        protected int intClaimID
        {
            get
            {
                return _intClaimID;
            }
            set
            {
                if (!object.Equals(_intClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "intClaimID", NewValue = value, OldValue = _intClaimID };
                    _intClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Trade _trade;
        protected RecoCms6.Models.RecoDb.Trade trade
        {
            get
            {
                return _trade;
            }
            set
            {
                if (!object.Equals(_trade, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "trade", NewValue = value, OldValue = _trade };
                    _trade = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _buyerCDFileID;
        protected int buyerCDFileID
        {
            get
            {
                return _buyerCDFileID;
            }
            set
            {
                if (!object.Equals(_buyerCDFileID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "buyerCDFileID", NewValue = value, OldValue = _buyerCDFileID };
                    _buyerCDFileID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _sharedAgentClaimID;
        protected int sharedAgentClaimID
        {
            get
            {
                return _sharedAgentClaimID;
            }
            set
            {
                if (!object.Equals(_sharedAgentClaimID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sharedAgentClaimID", NewValue = value, OldValue = _sharedAgentClaimID };
                    _sharedAgentClaimID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _sellerCDFileID;
        protected int sellerCDFileID
        {
            get
            {
                return _sellerCDFileID;
            }
            set
            {
                if (!object.Equals(_sellerCDFileID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sellerCDFileID", NewValue = value, OldValue = _sellerCDFileID };
                    _sellerCDFileID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Claim> _getAssocCDClaimsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.Claim> getAssocCDClaimsResult
        {
            get
            {
                return _getAssocCDClaimsResult;
            }
            set
            {
                if (!object.Equals(_getAssocCDClaimsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getAssocCDClaimsResult", NewValue = value, OldValue = _getAssocCDClaimsResult };
                    _getAssocCDClaimsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Claim _claim;
        protected RecoCms6.Models.RecoDb.Claim claim
        {
            get
            {
                return _claim;
            }
            set
            {
                if (!object.Equals(_claim, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "claim", NewValue = value, OldValue = _claim };
                    _claim = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getParametersResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getParametersResult
        {
            get
            {
                return _getParametersResult;
            }
            set
            {
                if (!object.Equals(_getParametersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getParametersResult", NewValue = value, OldValue = _getParametersResult };
                    _getParametersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProvinceList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProvinceList
        {
            get
            {
                return _getProvinceList;
            }
            set
            {
                if (!object.Equals(_getProvinceList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProvinceList", NewValue = value, OldValue = _getProvinceList };
                    _getProvinceList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getYesNoNAList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getYesNoNAList
        {
            get
            {
                return _getYesNoNAList;
            }
            set
            {
                if (!object.Equals(_getYesNoNAList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getYesNoNAList", NewValue = value, OldValue = _getYesNoNAList };
                    _getYesNoNAList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getTradeTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getTradeTypeList
        {
            get
            {
                return _getTradeTypeList;
            }
            set
            {
                if (!object.Equals(_getTradeTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTradeTypeList", NewValue = value, OldValue = _getTradeTypeList };
                    _getTradeTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCountryList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCountryList
        {
            get
            {
                return _getCountryList;
            }
            set
            {
                if (!object.Equals(_getCountryList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCountryList", NewValue = value, OldValue = _getCountryList };
                    _getCountryList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getEOProgramID;
        protected int getEOProgramID
        {
            get
            {
                return _getEOProgramID;
            }
            set
            {
                if (!object.Equals(_getEOProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEOProgramID", NewValue = value, OldValue = _getEOProgramID };
                    _getEOProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getCPProgramID;
        protected int getCPProgramID
        {
            get
            {
                return _getCPProgramID;
            }
            set
            {
                if (!object.Equals(_getCPProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCPProgramID", NewValue = value, OldValue = _getCPProgramID };
                    _getCPProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getCDProgramID;
        protected int getCDProgramID
        {
            get
            {
                return _getCDProgramID;
            }
            set
            {
                if (!object.Equals(_getCDProgramID, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCDProgramID", NewValue = value, OldValue = _getCDProgramID };
                    _getCDProgramID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isEOProgram;
        protected bool isEOProgram
        {
            get
            {
                return _isEOProgram;
            }
            set
            {
                if (!object.Equals(_isEOProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isEOProgram", NewValue = value, OldValue = _isEOProgram };
                    _isEOProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isCPProgram;
        protected bool isCPProgram
        {
            get
            {
                return _isCPProgram;
            }
            set
            {
                if (!object.Equals(_isCPProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isCPProgram", NewValue = value, OldValue = _isCPProgram };
                    _isCPProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isCDProgram;
        protected bool isCDProgram
        {
            get
            {
                return _isCDProgram;
            }
            set
            {
                if (!object.Equals(_isCDProgram, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isCDProgram", NewValue = value, OldValue = _isCDProgram };
                    _isCDProgram = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getUrbanOrRuralList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getUrbanOrRuralList
        {
            get
            {
                return _getUrbanOrRuralList;
            }
            set
            {
                if (!object.Equals(_getUrbanOrRuralList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getUrbanOrRuralList", NewValue = value, OldValue = _getUrbanOrRuralList };
                    _getUrbanOrRuralList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCityList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCityList
        {
            get
            {
                return _getCityList;
            }
            set
            {
                if (!object.Equals(_getCityList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCityList", NewValue = value, OldValue = _getCityList };
                    _getCityList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getYesNoPendingList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getYesNoPendingList
        {
            get
            {
                return _getYesNoPendingList;
            }
            set
            {
                if (!object.Equals(_getYesNoPendingList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getYesNoPendingList", NewValue = value, OldValue = _getYesNoPendingList };
                    _getYesNoPendingList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.BuilderDetail> _getBuildersList;
        protected IEnumerable<RecoCms6.Models.RecoDb.BuilderDetail> getBuildersList
        {
            get
            {
                return _getBuildersList;
            }
            set
            {
                if (!object.Equals(_getBuildersList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBuildersList", NewValue = value, OldValue = _getBuildersList };
                    _getBuildersList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.Registrant> _getSharedAgent;
        protected IEnumerable<RecoCms6.Models.RecoDb.Registrant> getSharedAgent
        {
            get
            {
                return _getSharedAgent;
            }
            set
            {
                if (!object.Equals(_getSharedAgent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSharedAgent", NewValue = value, OldValue = _getSharedAgent };
                    _getSharedAgent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.CommissionInstallment> _getCommissionInstallmentsList;
        protected IEnumerable<RecoCms6.Models.RecoDb.CommissionInstallment> getCommissionInstallmentsList
        {
            get
            {
                return _getCommissionInstallmentsList;
            }
            set
            {
                if (!object.Equals(_getCommissionInstallmentsList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCommissionInstallmentsList", NewValue = value, OldValue = _getCommissionInstallmentsList };
                    _getCommissionInstallmentsList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        dynamic _builder;
        protected dynamic builder
        {
            get
            {
                return _builder;
            }
            set
            {
                if (!object.Equals(_builder, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "builder", NewValue = value, OldValue = _builder };
                    _builder = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.Registrant _sharedAgent;
        protected RecoCms6.Models.RecoDb.Registrant sharedAgent
        {
            get
            {
                return _sharedAgent;
            }
            set
            {
                if (!object.Equals(_sharedAgent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sharedAgent", NewValue = value, OldValue = _sharedAgent };
                    _sharedAgent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            intTradeID = (int)TradeID;

            intClaimID = (int)ClaimID;

            if (intTradeID == 0) {
                trade = new RecoCms6.Models.RecoDb.Trade(){};
            }

            buyerCDFileID = 0;

            sharedAgentClaimID = 0;

            sellerCDFileID = 0;

            if (intTradeID > 0)
            {
                var recoDbGetTradeByTradeIdResult = await RecoDb.GetTradeByTradeId(intTradeID);
                trade = recoDbGetTradeByTradeIdResult;

                if (trade.BuyerCDFileID != null) {
                    buyerCDFileID = (int)trade.BuyerCDFileID;
                }

                if (trade.SharedAgentClaimID != null) {
                    sharedAgentClaimID = (int)trade.SharedAgentClaimID;
                }

                if (trade.SellerCDFileID != null) {
                    sellerCDFileID = (int)trade.SellerCDFileID;
                }
            }

            trade.ClaimID = intClaimID;

            var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2 || i.ClaimID == @3", FilterParameters = new object[] { sharedAgentClaimID, buyerCDFileID, sellerCDFileID, intClaimID } });
            getAssocCDClaimsResult = recoDbGetClaimsResult;

            claim = recoDbGetClaimsResult.Where(c=>c.ClaimID == intClaimID).First();

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2 || i.ParamTypeDesc == @3 || i.ParamTypeDesc == @4 || i.ParamTypeDesc == @5 || i.ParamTypeDesc == @6 || i.ParamTypeDesc == @7", FilterParameters = new object[] { "Province", "YesNoNA", "Trade Type", "Country", "ProgramID", "UrbanOrRural", "City", "YesNoPending" }, OrderBy = $"ParamDesc asc" });
            getParametersResult = recoDbGetParameterDetailsResult;

            getProvinceList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Province");

            getYesNoNAList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="YesNoNA");

            getTradeTypeList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Trade Type");

            getCountryList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Country").OrderByDescending(pd=>pd.ParamValue).ThenBy(pd=>pd.ParamDesc);

            getEOProgramID = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="ProgramID" && pd.ParamAbbrev=="EO").First().ParameterID;

            getCPProgramID = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="ProgramID" && pd.ParamAbbrev=="CPP").First().ParameterID;

            getCDProgramID = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="ProgramID" && pd.ParamAbbrev=="CDP").First().ParameterID;

            isEOProgram = claim.ProgramID == getEOProgramID;

            isCPProgram = claim.ProgramID == getCPProgramID;

            isCDProgram = claim.ProgramID == getCDProgramID;

            getUrbanOrRuralList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="UrbanOrRural");

            getCityList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="City" && pd.ParentParameterID==trade.Province);

            getYesNoPendingList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="YesNoPending");

            var recoDbGetBuilderDetailsResult = await RecoDb.GetBuilderDetails(new Query() { OrderBy = $"Name asc" });
            getBuildersList = recoDbGetBuilderDetailsResult;

            var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { trade.SharedAgentID } });
            getSharedAgent = recoDbGetRegistrantsResult;

            var recoDbGetCommissionInstallmentsResult = await RecoDb.GetCommissionInstallments(new Query() { Filter = $@"i => i.TradeID == @0", FilterParameters = new object[] { trade.TradeID }, OrderBy = $"DatePaid desc" });
            if (!isEOProgram) {
                getCommissionInstallmentsList = recoDbGetCommissionInstallmentsResult;
            }

            if (intTradeID == 0) {
                trade.Province = Globals.defaultProvinceID;
            }

            if (intTradeID == 0) {
                trade.Country = Globals.defaultCountryID;
            }
        }

        protected async System.Threading.Tasks.Task TemplateForm0Submit(RecoCms6.Models.RecoDb.Trade args)
        {
            await SaveTrade();
        }

        protected async System.Threading.Tasks.Task ProvinceChange(dynamic args)
        {
            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParentParameterID == @0", FilterParameters = new object[] { trade.Province }, OrderBy = $"ParamDesc asc" });
            getCityList = recoDbGetParameterDetailsResult;
        }

        protected async System.Threading.Tasks.Task PostalCodeChange(string args)
        {
            if (trade.PostalCode.Length == 7)
            {
                var recoDbGetPostalCodeDetailsResult = await RecoDb.GetPostalCodeDetails(new Query() { Filter = $@"i => i.PostalCode == @0", FilterParameters = new object[] { trade.PostalCode } });
                if (recoDbGetPostalCodeDetailsResult.FirstOrDefault() != null) {
                    trade.Province = recoDbGetPostalCodeDetailsResult.FirstOrDefault().ProvinceID;
                }

                if (recoDbGetPostalCodeDetailsResult.FirstOrDefault() != null) {
                    trade.City = recoDbGetPostalCodeDetailsResult.First().City;
                }
            }
        }

        protected async System.Threading.Tasks.Task ButtonFindRelatedBuyerCdClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>($"Select CD Claim", new Dictionary<string, object>() { {"ProgramID", getCDProgramID}, {"ExcludeClaimID", 0}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != 0) {
                trade.BuyerCDFileID = dialogResult;
            }

            if (dialogResult != 0) {
                buyerCDFileID = (int)trade.BuyerCDFileID ;
            }

            if (dialogResult != 0)
            {
                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { sellerCDFileID, buyerCDFileID, sharedAgentClaimID } });
                getAssocCDClaimsResult = recoDbGetClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonFindRelatedSellerCdClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>($"Select CD Claim", new Dictionary<string, object>() { {"ProgramID", getCDProgramID}, {"ExcludeClaimID", 0}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != 0) {
                trade.SellerCDFileID = dialogResult;
            }

            if (dialogResult != 0) {
                sellerCDFileID = (int)trade.SellerCDFileID;
            }

            if (dialogResult != 0)
            {
                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { sellerCDFileID, buyerCDFileID, sharedAgentClaimID } });
                getAssocCDClaimsResult = recoDbGetClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonShowBuilderDetailsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBuilder>("Add Builder", null, new DialogOptions(){ Width = $"{800}px" });
            builder = dialogResult;

            if (builder != null) {
                trade.BuilderID = dialogResult.BuilderID;
            }

            if (builder != null)
            {
                var recoDbGetBuilderDetailsResult = await RecoDb.GetBuilderDetails(new Query() { OrderBy = $"Name asc" });
                getBuildersList = recoDbGetBuilderDetailsResult;
            }
        }

        protected async System.Threading.Tasks.Task GridCommissionInstallmentsRowSelect(RecoCms6.Models.RecoDb.CommissionInstallment args)
        {
            var dialogResult = await DialogService.OpenAsync<EditCommissionInstallment>("Edit Commission Installment", new Dictionary<string, object>() { {"CommissionInstallmentID", args.CommissionInstallmentID} });
            await gridCommissionInstallments.Reload();

            await InvokeAsync(() => { StateHasChanged();});
        }

        protected async System.Threading.Tasks.Task ButtonAddInstallmentClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddCommissionInstallment>("Add Commission Installment", new Dictionary<string, object>() { {"TradeID", trade.TradeID} });
        }

        protected async System.Threading.Tasks.Task ButtonFindSharedAgentClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Registrants>("Registrants", new Dictionary<string, object>() { {"SelectAgent", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != null) {
                sharedAgent = dialogResult;
            }

            if (dialogResult != null)
            {
                var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { dialogResult.RegistrantID } });
                getSharedAgent = recoDbGetRegistrantsResult;

                trade.SharedAgentID = sharedAgent.RegistrantID;
            }
        }

        protected async System.Threading.Tasks.Task ButtonFindSubmittedClaimClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<Claims>($"Find Submitted Claim", new Dictionary<string, object>() { {"ProgramID", claim.ProgramID}, {"ExcludeClaimID", claim.ClaimID}, {"SelectClaim", true} }, new DialogOptions(){ Width = $"{1024}px" });
            if (dialogResult != 0) {
                trade.SharedAgentClaimID = dialogResult;
            }

            if (dialogResult != 0) {
                sharedAgentClaimID = (int)trade.SharedAgentClaimID;
            }

            if (dialogResult != 0)
            {
                var recoDbGetClaimsResult = await RecoDb.GetClaims(new Query() { Filter = $@"i => i.ClaimID == @0 || i.ClaimID == @1 || i.ClaimID == @2", FilterParameters = new object[] { sellerCDFileID, buyerCDFileID, sharedAgentClaimID } });
                getAssocCDClaimsResult = recoDbGetClaimsResult;
            }
        }

        protected async System.Threading.Tasks.Task ButtonSaveTradeClick(MouseEventArgs args)
        {
            await SaveTrade();
        }
    }
}
