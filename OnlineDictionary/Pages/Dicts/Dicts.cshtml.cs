using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Dicts
{
    public class DictsModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        
        public bool isLogged { get; set; }
        [BindProperty]
        public List<Dict> dicts { get; set; }

        public void OnGet()
        {
            var rM = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
            isLogged = rM.Content.ReadFromJsonAsync<bool>().Result;

            rM = client.GetAsync(@"https://localhost:7014/api/Dict/all").Result;
            rM.EnsureSuccessStatusCode();
            dicts = rM.Content.ReadFromJsonAsync<List<Dict>>().Result;
        }
        public void OnPost(int id) 
        {
            client.DeleteAsync($@"https://localhost:7014/api/Dict/{id}");
            OnGet();
        }
    }
}
