using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using Newtonsoft.Json.Linq;
using RecoCms6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace RecoCms6.Services.GraphApi
{
    public class GraphApiAuthProvider : IAuthenticationProvider
    {
        private IHttpContextAccessor _httpContextAccessor;
        private readonly RecoDbContext _dbContext;
        private AuthenticationStateProvider _authenticationStateProvider;
        private string _cliendId;
        private string _cliendSecret;
        private string _callbackPath;
        private string _userId;
        public Exception Exception;

        public GraphApiAuthProvider(IHttpContextAccessor httpContextAccessor,IConfiguration configuration, RecoDbContext dbContext, 
            AuthenticationStateProvider authenticationStateProvider)
        {
            try
            {
                _httpContextAccessor = httpContextAccessor;
                _dbContext = dbContext;

                _cliendId = configuration.GetSection("AzureAd:ClientId").Value;
                _cliendSecret = configuration.GetSection("AzureAd:ClientSecret").Value;
                _callbackPath = configuration.GetSection("AzureAd:CallbackPath").Value;
                _authenticationStateProvider = authenticationStateProvider;
                trySetUser(authenticationStateProvider);
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
          
        }

        public void SetUser(HttpContext context) 
        {
            _userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.NameIdentifierId).Value;
        }

        private void trySetUser(AuthenticationStateProvider authenticationStateProvider)
        {
            try
            {
                _userId = authenticationStateProvider.GetAuthenticationStateAsync().GetAwaiter().GetResult().User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.NameIdentifierId).Value;
            }
            catch (Exception)
            {
            }
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("bearer", await GetAccessToken());
        }

        public async Task<string> GetAccessToken()
        {
            var cachedToken = _dbContext.TokenCaches.FirstOrDefault(x => x.UserId == _userId);

            if (cachedToken == null || cachedToken.ExpiresAt > DateTime.Now.AddDays(60))
            {
                InitiateLogin();
                return string.Empty;
            }

            if (cachedToken.ExpiresAt < DateTime.Now.AddMinutes(-1))
                return await RefreshToken(cachedToken.RefreshToken);

            return cachedToken.AccessToken;
        }

        public async Task<string> GetAccessTokenWithCode(string code)
        {
            List<KeyValuePair<string, string>> keyValues = getBaseRequest("authorization_code");
            keyValues.Add(new KeyValuePair<string, string>("code", code));

            return await SendTokenRequest(keyValues);
        }

        public void InitiateLogin(string returnUrl = "", HttpContext context = null) 
            => (_httpContextAccessor.HttpContext ?? context).Response.Redirect(getLoginUrl(returnUrl));

        private async Task<string> RefreshToken(string refreshToken)
        {
            List<KeyValuePair<string, string>> keyValues = getBaseRequest("refresh_token");
            keyValues.Add(new KeyValuePair<string, string>("refresh_token", refreshToken));

            return await SendTokenRequest(keyValues);
        }

        private async Task<string> SendTokenRequest(List<KeyValuePair<string, string>> keyValues)
        {
            HttpClient client = getBaseClient();
            HttpRequestMessage request = getRequest(keyValues);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return await SaveToken(responseJson);
        }

        private async Task<string> SaveToken(string responseJson)
        {
            var JSonObject = JObject.Parse(responseJson);
            int.TryParse(JSonObject["expires_in"].ToString(), out int expiresIn);
            var expiresAt = DateTime.Now.AddSeconds(expiresIn);
            var accessToken = JSonObject["access_token"].ToString();
            var refreshToken = JSonObject["refresh_token"].ToString();

            var cachedToken = _dbContext.TokenCaches.FirstOrDefault(x => x.UserId == _userId);
            if (cachedToken == null) // insert new
            {
                var toInsert = new Models.RecoDb.TokenCache()
                {
                    UserId = _userId,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresAt = expiresAt
                };
                _dbContext.TokenCaches.Add(toInsert);
            }
            else // update
            {
                cachedToken.AccessToken = accessToken;
                cachedToken.RefreshToken = refreshToken;
                cachedToken.ExpiresAt = expiresAt;
            }
            
            await _dbContext.SaveChangesAsync();

            return accessToken;
        }

        private static HttpClient getBaseClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://login.microsoftonline.com");
            return client;
        }

        private static HttpRequestMessage getRequest(List<KeyValuePair<string, string>> keyValues)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/common/oauth2/v2.0/token");
            request.Content = new FormUrlEncodedContent(keyValues);
            return request;
        }

        private List<KeyValuePair<string, string>> getBaseRequest(string grantType)
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("client_id", _cliendId));
            keyValues.Add(new KeyValuePair<string, string>("scope", string.Join(" ", GraphConstants.Scopes)));
            keyValues.Add(new KeyValuePair<string, string>("redirect_uri", getRedirectUri()));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", grantType));
            keyValues.Add(new KeyValuePair<string, string>("client_secret", _cliendSecret));
            return keyValues;
        }

        private string getLoginUrl(string returnUrl)
        {
            string redirectUri = getRedirectUri();
            string scopesEncoded = getScopesEncoded();

            var loginUrl = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?" +
                $"client_id={_cliendId}&" +
                $"response_type=code&redirect_uri={redirectUri}&" +
                $"response_mode=query&" +
                $"scope={scopesEncoded}&" +
                $"state={returnUrl}&" +
                $"prompt=consent";

            return loginUrl;
        }

        private static string getScopesEncoded()
        {
            return Uri.EscapeDataString(string.Join(" ", GraphConstants.Scopes));
        }

        private string getRedirectUri()
        {
            string host = this._httpContextAccessor.HttpContext.Request.Host.ToString();
            var scheme = this._httpContextAccessor.HttpContext.Request.Scheme.ToString();

            return  $"{scheme}://{host}{_callbackPath}";
        }

        
    }
}
