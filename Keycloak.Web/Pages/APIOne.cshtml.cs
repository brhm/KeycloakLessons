using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Keycloak.Web.Pages
{
    public class APIOneModel : PageModel
    {
        [ModelBinder] public HttpStatusCode ResponseStatus { get; set; }

        [ModelBinder] public string? ResponseContent { get; set; }

        public async Task OnGetAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);


            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            var response = await client.GetAsync("https://localhost:7094/secured-endpoint");


            ResponseStatus = response.StatusCode;


            if (response.IsSuccessStatusCode)
            {
                ResponseContent = await response.Content.ReadAsStringAsync();
            }
        }
    }
}