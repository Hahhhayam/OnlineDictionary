using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Words
{
    public class CreateModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        public void OnGet() { }

        public void OnPost(string value, string info, string langName)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), $@"https://localhost:7014/api/Word/");
            requestMessage.Content = JsonContent.Create(new { Value = value, Info = info, LanguageName = langName });
            client.SendAsync(requestMessage);
        }
    }
}
