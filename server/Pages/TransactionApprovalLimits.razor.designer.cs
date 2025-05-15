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
    public partial class TransactionApprovalLimitsComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<RecoCms6.Models.RecoDb.TransactionApprovalLimit> grid0;

        IEnumerable<RecoCms6.Models.RecoDb.TransactionApprovalLimit> _getTransactionApprovalLimitsResult;
        protected IEnumerable<RecoCms6.Models.RecoDb.TransactionApprovalLimit> getTransactionApprovalLimitsResult
        {
            get
            {
                return _getTransactionApprovalLimitsResult;
            }
            set
            {
                if (!object.Equals(_getTransactionApprovalLimitsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTransactionApprovalLimitsResult", NewValue = value, OldValue = _getTransactionApprovalLimitsResult };
                    _getTransactionApprovalLimitsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        RecoCms6.Models.RecoDb.TransactionApprovalLimit _transactionapprovallimit;
        protected RecoCms6.Models.RecoDb.TransactionApprovalLimit transactionapprovallimit
        {
            get
            {
                return _transactionapprovallimit;
            }
            set
            {
                if (!object.Equals(_transactionapprovallimit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "transactionapprovallimit", NewValue = value, OldValue = _transactionapprovallimit };
                    _transactionapprovallimit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getCategoryList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getCategoryList
        {
            get
            {
                return _getCategoryList;
            }
            set
            {
                if (!object.Equals(_getCategoryList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCategoryList", NewValue = value, OldValue = _getCategoryList };
                    _getCategoryList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getTypeList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getTypeList
        {
            get
            {
                return _getTypeList;
            }
            set
            {
                if (!object.Equals(_getTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTypeList", NewValue = value, OldValue = _getTypeList };
                    _getTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> _getProgramList;
        protected IEnumerable<RecoCms6.Models.RecoDb.ParameterDetail> getProgramList
        {
            get
            {
                return _getProgramList;
            }
            set
            {
                if (!object.Equals(_getProgramList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProgramList", NewValue = value, OldValue = _getProgramList };
                    _getProgramList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<IdentityRole> _roleList;
        protected IEnumerable<IdentityRole> roleList
        {
            get
            {
                return _roleList;
            }
            set
            {
                if (!object.Equals(_roleList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "roleList", NewValue = value, OldValue = _roleList };
                    _roleList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<RecoCms6.Models.RecoDb.UserDetail> _userList;
        protected IEnumerable<RecoCms6.Models.RecoDb.UserDetail> userList
        {
            get
            {
                return _userList;
            }
            set
            {
                if (!object.Equals(_userList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "userList", NewValue = value, OldValue = _userList };
                    _userList = value;
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
            var recoDbGetTransactionApprovalLimitsResult = await RecoDb.GetTransactionApprovalLimits();
            getTransactionApprovalLimitsResult = recoDbGetTransactionApprovalLimitsResult;

            transactionapprovallimit = new RecoCms6.Models.RecoDb.TransactionApprovalLimit(){};

            var recoDbGetParameterDetailsResult = await RecoDb.GetParameterDetails(new Query() { Filter = $@"i => i.ParamTypeDesc == @0 || i.ParamTypeDesc == @1 || i.ParamTypeDesc == @2", FilterParameters = new object[] { "Incurred Category", "Incurred Type", "ProgramID" }, OrderBy = $"ParamDesc asc" });
            getCategoryList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Incurred Category");

            getTypeList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="Incurred Type");

            getProgramList = recoDbGetParameterDetailsResult.Where(pd=>pd.ParamTypeDesc=="ProgramID");

            var securityGetRolesResult = await Security.GetRoles();
            roleList = securityGetRolesResult;

            var recoDbGetUserDetailsResult = await RecoDb.GetUserDetails(new Query() { OrderBy = $"Email asc" });
            userList = recoDbGetUserDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.grid0.InsertRow(new RecoCms6.Models.RecoDb.TransactionApprovalLimit());
        }

        protected async System.Threading.Tasks.Task Grid0RowCreate(dynamic args)
        {
            var recoDbCreateTransactionApprovalLimitResult = await RecoDb.CreateTransactionApprovalLimit(args);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowUpdate(dynamic args)
        {
            var recoDbUpdateTransactionApprovalLimitResult = await RecoDb.UpdateTransactionApprovalLimit(args.ApprovalLimitID, args);
        }

        protected async System.Threading.Tasks.Task EditButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.EditRow(data);
        }

        protected async System.Threading.Tasks.Task SaveButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.UpdateRow(data);
        }

        protected async System.Threading.Tasks.Task CancelButtonClick(MouseEventArgs args, dynamic data)
        {
            this.grid0.CancelEditRow(data);

            var recoDbCancelTransactionApprovalLimitChangesResult = await RecoDb.CancelTransactionApprovalLimitChanges(data);
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var recoDbDeleteTransactionApprovalLimitResult = await RecoDb.DeleteTransactionApprovalLimit(data.ApprovalLimitID);
                    if (recoDbDeleteTransactionApprovalLimitResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception recoDbDeleteTransactionApprovalLimitException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TransactionApprovalLimit" });
            }
        }
    }
}
