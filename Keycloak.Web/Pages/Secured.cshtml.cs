using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Keycloak.Web.Pages
{
    [Authorize]
    public class SecuredModel : PageModel
    {
        [ModelBinder] public string? AccessToken { get; set; }

        [ModelBinder] public string? RefreshToken { get; set; }

        [ModelBinder] public string? IdToken { get; set; }

        public async Task OnGetAsync()
        {
            // get token in HttpContext
            AccessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            RefreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            IdToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            //get request to API
            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", AccessToken);
            //var response = client.GetAsync("https://localhost:7094/secured-endpoint").Result;
            //var content = response.Content.ReadAsStringAsync().Result;
        }


        public async Task<IActionResult> OnGetSignOut()
        {
            return new SignOutResult(
                new[]
                {
                    OpenIdConnectDefaults.AuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme
                });
        }
    }
}