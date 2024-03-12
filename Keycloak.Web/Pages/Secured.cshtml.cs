using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Keycloak.Web.Pages
{
    [Authorize]
    public class SecuredModel : PageModel
    {
        public void OnGet()
        {
            // get token in HttpContext
            var token = HttpContext.GetTokenAsync("access_token").Result;


            //get request to API
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = client.GetAsync("https://localhost:7094/secured-endpoint").Result;
            var content = response.Content.ReadAsStringAsync().Result;
        }
    }
}