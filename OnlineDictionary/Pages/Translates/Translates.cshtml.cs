using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Translates
{
    public class TranslatesModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        public bool isLogged { get; set; }

        [BindProperty]
        public string langName1 { get; set; }
        [BindProperty]
        public string langName2 { get; set; }

        public List<Language> supportLanguages { get; set; }

        [BindProperty]
        public List<Translate> givenTranslates { get; set; } = new List<Translate>();
        
        
        public void OnGet()
        {
            var responseMessage = client.GetAsync(@"https://localhost:7014/api/Language").Result;
            responseMessage.EnsureSuccessStatusCode();
            supportLanguages = responseMessage.Content.ReadFromJsonAsync<List<Language>>().Result;
            responseMessage = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
            isLogged = responseMessage.Content.ReadFromJsonAsync<bool>().Result;
        }
        public void OnPost() 
        {
            OnGet();
            var responseMessage = client.GetAsync($@"https://localhost:7014/api/Translate/all/type?type={langName1}-{langName2}").Result;
            responseMessage.EnsureSuccessStatusCode();
            givenTranslates = responseMessage.Content.ReadFromJsonAsync<List<Translate>>().Result;
        }
        public void OnPostDelete(int id) 
        {
            OnGet();
            client.DeleteAsync($@"https://localhost:7014/api/Translate/{id}");
        }
    }
}
