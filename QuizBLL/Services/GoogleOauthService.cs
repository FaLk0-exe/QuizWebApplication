using Microsoft.AspNetCore.WebUtilities;
using QuizBLL.Helpers;
using QuizBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizWebApplication.Services
{
    public class GoogleOauthService
    {
        private const string _clientId = "628886548175-dvbc1vv5a1ii62p8a65kllun4dh0v30k.apps.googleusercontent.com";
        private const string _clientSecret = "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";
        private const string _refreshEndpoint = "https://oauth2.googleapis.com/token";
        public static string GenerateOauthRequestUrl(string scope,string redirectUrl,string codeChallenge) 
        {
            var oauthServerEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
            var queryParams = new Dictionary<string, string>()
            {
                {"client_id",_clientId},
                {"redirect_uri",redirectUrl},
                {"response_type","code"},
                {"scope",scope },
                { "code_challenge",codeChallenge},
                { "code_challenge_method","S256" },
                {"access_type","offline" }
            };
            var url = QueryHelpers.AddQueryString(oauthServerEndpoint, queryParams);
            return url;
        }
        public static async Task<TokenResult> ExchangeCodeOnTokenAsync(string code, string codeVerifier, string redirectUrl) 
        {
            var tokenEndpoint = "https://oauth2.googleapis.com/token";
            var oauthParams = new Dictionary<string, string>()
            {
                { "client_id",_clientId},
                { "client_secret",_clientSecret},
                {"code",code },
                { "code_verifier",codeVerifier},
                { "grant_type","authorization_code"},
                {"redirect_uri",redirectUrl }
            };
            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(tokenEndpoint, oauthParams);
            return tokenResult;
        }
        public static async Task<TokenResult> RefreshTokenAsync(string refreshToken)
        {
            var refreshParams = new Dictionary<string, string>
            {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken }
            };
            var tokenResult = await HttpClientHelper.SendPostRequest<TokenResult>(_refreshEndpoint, refreshParams);
            return tokenResult;
        }
    }
}
