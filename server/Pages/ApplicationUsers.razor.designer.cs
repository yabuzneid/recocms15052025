﻿using System;
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
    public partial class ApplicationUsersComponent : ComponentBase, IDisposable
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
        protected RadzenDataGrid<UserDetail> grid0;

        IEnumerable<UserDetail> _users;
        protected IEnumerable<UserDetail> users
        {
            get
            {
                return _users;
            }
            set
            {
                if (!object.Equals(_users, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "users", NewValue = value, OldValue = _users };
                    _users = value;
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
            var securityGetUsersResult = await RecoDb.GetUserDetails(new Query() { OrderBy = $"Name asc" });
            users = securityGetUsersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddApplicationUser>("Add Application User", null);
            await Load();

            await grid0.Reload();
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(UserDetail args)
        {
            var dialogResult = await DialogService.OpenAsync<EditApplicationUser>("Edit Application User", new Dictionary<string, object>() { { "Id", args.Id } }, new DialogOptions() { Width = $"{"60%"}", Resizable = true });
            await Load();

            await grid0.Reload();
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, UserDetail data)
        {
            try
            {
                var securityDeleteUserResult = await Security.DeleteUser($"{data.Id}");
                await Load();

                if (securityDeleteUserResult != null)
                {
                    await grid0.Reload();
                }
            }
            catch (System.Exception securityDeleteUserException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to delete user" });
            }
        }
    }
}
