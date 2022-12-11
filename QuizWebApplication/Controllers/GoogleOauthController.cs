using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizBLL.Helpers;
using QuizWebApplication.Services;
using System;
using System.Threading.Tasks;

namespace QuizWebApplication.Controllers
{
    public class GoogleOauthController:Controller
    {
        private string _scope = "https://www.googleapis.com/auth/youtube";
        private string _redirectUrl = "https://localhost:5001/GoogleOauth/Code";
        private string _redirectThemesUrl = "https://localhost:5001/Theme/Themes";
        public IActionResult RedirectOnOauthServer()
        {
            var codeVerifier = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("codeVerifier", codeVerifier);
            var codeChallenge = Sha256Helper.ComputeHash(codeVerifier);
            return Redirect(GoogleOauthService.GenerateOauthRequestUrl(_scope,_redirectUrl,codeChallenge));
        }

        public async Task<IActionResult> CodeAsync(string code)
        {
            string codeVerifier = HttpContext.Session.GetString("codeVerifier");
            var tokenResult = await GoogleOauthService.ExchangeCodeOnTokenAsync(code,codeVerifier,_redirectUrl);
            return Redirect("https://localhost:5001/Theme/Themes");
        }
    }
}
