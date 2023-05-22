 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Words
{
    public class WordModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        [BindProperty]
        public Word word { get; set; }
        public bool isLogged { get; set; }
        public void OnGet(int id)
        {
            var rM = client.GetAsync($@"https://localhost:7014/api/Word/{id}").Result;
            rM.EnsureSuccessStatusCode();
            word = rM.Content.ReadFromJsonAsync<Word>().Result;
            rM = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
            isLogged = rM.Content.ReadFromJsonAsync<bool>().Result;
        }
    }
}
