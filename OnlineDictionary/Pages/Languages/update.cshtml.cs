using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Languages
{
    public class updateModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        [BindProperty]
        public Language lang { get; set; }
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id = id;
            var responseMessage = client.GetAsync($@"https://localhost:7014/api/Language/{Id}").Result;
            responseMessage.EnsureSuccessStatusCode();
            lang = responseMessage.Content.ReadFromJsonAsync<Language>().Result;
        }

        public void OnPost(int id, string name, string info) 
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Language/{id}");
            requestMessage.Content = JsonContent.Create(new {Name = name, Info = info});
            client.SendAsync(requestMessage);
        }
    }
}
