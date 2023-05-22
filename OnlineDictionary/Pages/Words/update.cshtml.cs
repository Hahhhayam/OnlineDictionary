using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Words
{
    public class updateModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        [BindProperty]
        public Word word { get; set; }
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
            var responseMessage = client.GetAsync($@"https://localhost:7014/api/Word/{Id}").Result;
            responseMessage.EnsureSuccessStatusCode();
            word = responseMessage.Content.ReadFromJsonAsync<Word>().Result;
        }

        public void OnPost(int id, string value, string info, string langName)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Word/{id}");
            requestMessage.Content = JsonContent.Create(new { Value = value, Info = info, LanguageName = langName });
            client.SendAsync(requestMessage);
        }
    }
}
