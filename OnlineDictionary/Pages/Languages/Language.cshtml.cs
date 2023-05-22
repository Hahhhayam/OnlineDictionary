using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Languages
{
    public class LanguageModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        public Language lang { get; set; }
        public List<Word> words { get; set; }
        public int Id { get; set; }
        public bool isLogged { get; set; }
        public void OnGet(int id)
        {
            Id = id;   
            var responseMessage = client.GetAsync($@"https://localhost:7014/api/Language/{id}").Result;
            responseMessage.EnsureSuccessStatusCode();
            lang = responseMessage.Content.ReadFromJsonAsync<Language>().Result;
            responseMessage = client.GetAsync($@"https://localhost:7014/api/Word/all/{id}").Result;
            responseMessage.EnsureSuccessStatusCode();
            words = responseMessage.Content.ReadFromJsonAsync<List<Word>>().Result;
            responseMessage = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
            isLogged = responseMessage.Content.ReadFromJsonAsync<bool>().Result;
        }
    }
}
