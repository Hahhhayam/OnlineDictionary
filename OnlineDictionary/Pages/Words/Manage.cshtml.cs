using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Words
{
    public class ManageModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<Word> words { get; set; }
        public void OnGet()
        {
            var rM = client.GetAsync($@"https://localhost:7014/api/Word/all").Result;
            rM.EnsureSuccessStatusCode();
            words = rM.Content.ReadFromJsonAsync<List<Word>>().Result;
            rM = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
        }
        public void OnPost(int id) 
        {
            client.DeleteAsync($@"https://localhost:7014/api/Word/{id}");
        }
    }
}
