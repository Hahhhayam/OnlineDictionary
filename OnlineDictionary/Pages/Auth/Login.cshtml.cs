using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineDictionary.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
        }
        public void OnPost(string name, string password) 
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Auth/login");
            requestMessage.Content = JsonContent.Create(new { Login = name, Password = password });
            client.SendAsync(requestMessage);
        }
    }
}
