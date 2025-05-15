using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecoCms6.Models;

namespace RecoCms6.Pages;

public partial class SetPassword : ComponentBase
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private UserManager<ApplicationUser> UserManager { get; set; }
    
    
    [Parameter]
    public string userId { get; set; }
    [Parameter] 
    public string code { get; set; }

    private string _currentPassword;
    public string CurrentPassword
    {
        get => _currentPassword;
        set
        {
            _currentPassword = value;
            if (!Equals(CurrentPassword, value))
            {
                InvokeAsync(StateHasChanged);
            }
        }
    }

    private string _newPassword;
    public string newPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            if (!Equals(newPassword, value))
            {
                InvokeAsync(StateHasChanged);
            }
        }
    }

    private string _confirmPassword;
    public string ConfirmPassword
    {
        get => _confirmPassword; 
        set
        {
            _confirmPassword = value;
            if (!Equals(ConfirmPassword, value))
            {
                InvokeAsync(StateHasChanged);
            }
        } 
    }

    protected override async Task OnInitializedAsync()
    {
        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
        var queryParams = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query);

        if (queryParams.TryGetValue("userId", out var userId))
        {
            this.userId = userId;
        }

        if (queryParams.TryGetValue("code", out var code))
        {
            this.code = code;
        }
    }
}
