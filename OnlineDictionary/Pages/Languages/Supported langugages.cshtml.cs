using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Languages
{
    public class Supported_langugagesModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<Language> languages { get; set; }
        public bool isLogged { get; set; }
        public void OnGet()
        {
            var responseMessage = client.GetAsync(@"https://localhost:7014/api/Language").Result;
            responseMessage.EnsureSuccessStatusCode();
            languages = responseMessage.Content.ReadFromJsonAsync<List<Language>>().Result;
            responseMessage = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
            isLogged = responseMessage.Content.ReadFromJsonAsync<bool>().Result;
        }
        public void OnPost(int id) 
        {
            client.DeleteAsync($@"https://localhost:7014/api/Language/{id}");
        }
    }
}
