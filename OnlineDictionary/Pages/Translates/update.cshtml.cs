using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Translates
{
    public class updateModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        [BindProperty]
        public Translate translate { get; set; }
        [BindProperty]
        public string Example { get; set; }
        public void OnGet(int id)
        {
            var responseMessage = client.GetAsync($@"https://localhost:7014/api/Translate/{id}").Result;
            responseMessage.EnsureSuccessStatusCode();
            translate = responseMessage.Content.ReadFromJsonAsync<Translate>().Result;
        }

        public void OnPost(int id)
        {
            OnGet(id);
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Translate/{id}");
            requestMessage.Content = JsonContent.Create(new { Example });
            client.SendAsync(requestMessage);
        }
    }
}
