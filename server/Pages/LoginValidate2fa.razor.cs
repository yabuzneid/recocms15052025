using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using QRCoder;
using Radzen;
using RecoCms6.Models;
using RecoCms6.Utility;

namespace RecoCms6.Pages;

public partial class LoginValidate2fa
{
    [Inject]
    public UserManager<ApplicationUser> UserManager { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }

    [Inject]
    protected NavigationManager UriHelper { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }


    [Parameter]
    public string redirectUrl { get; set; }
    [Parameter]
    public bool rememberMe { get; set; }
    [Parameter]
    public string EncodedUsername { get; set; }

    private bool _rememberIp;
    protected bool rememberIp
    {
        get => _rememberIp;
        set
        {
            _rememberIp = value;
            if (!Equals(rememberIp, value))
            {
                InvokeAsync(StateHasChanged);
            }
        }
    }
    [Inject]
    protected SecurityService Security { get; set; }
    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    public string QrCodeBase64 { get; set; }
    public string Secret { get; set; }
    public ApplicationUser User { get; set; }
    public bool QrCodeIsVisible { get; set; }

    private string _validationCode = "";
    protected string validationCode
    {
        get => _validationCode;
        set
        {
            _validationCode = value;
            if (!Equals(validationCode, value))
            {
                InvokeAsync(StateHasChanged);
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await Security.InitializeAsync(AuthenticationStateProvider);
        User = await GetUser();

        QrCodeIsVisible = !(User?.LoggedInTwoFactor ?? true);
        if (QrCodeIsVisible)
        {
            Secret = await GetSecret();
            QrCodeBase64 = await GetQrCode(Secret);
        }

        var query = System.Web.HttpUtility.ParseQueryString(new Uri(UriHelper.ToAbsoluteUri(UriHelper.Uri).ToString()).Query);

        var error = query.Get("error");

        redirectUrl = query.Get("redirectUrl"); ;

        if (!string.IsNullOrEmpty(error))
        {
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"{error}" });
        }

    }

    private async Task<string> GetSecret()
    {
        var key = await UserManager.GetAuthenticatorKeyAsync(User);
        if (string.IsNullOrEmpty(key))
        {
            await UserManager.ResetAuthenticatorKeyAsync(User);
            key = await UserManager.GetAuthenticatorKeyAsync(User);
        }

        return key;
    }

    private async Task<ApplicationUser> GetUser()
    {
        return await UserManager.FindByNameAsync(EncodedUsername.Decode());
    }

    private async Task<string> GetQrCode(string secret)
    {
        var identity = Configuration["ApplicationName"] + ":" + EncodedUsername.Decode();
        var label = Uri.EscapeDataString(identity);
        var issuer = Uri.EscapeDataString(Configuration["ApplicationName"]);
        var url = $"otpauth://totp/{label}?secret={secret}&issuer={issuer}";
        using var generator = new QRCodeGenerator();
        using var data = generator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        using var code = new PngByteQRCode(data);
        return Convert.ToBase64String(code.GetGraphic(20));
    }
}