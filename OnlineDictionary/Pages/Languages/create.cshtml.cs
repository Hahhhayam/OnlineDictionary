using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Languages
{
    public class createModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        public void OnGet() {}

        public void OnPost(string name, string info)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), $@"https://localhost:7014/api/Language/");
            requestMessage.Content = JsonContent.Create(new { Name = name, Info = info });
            client.SendAsync(requestMessage);
        }
    }
}
