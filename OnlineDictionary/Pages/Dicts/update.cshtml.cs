using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;

namespace OnlineDictionary.Pages.Auth
{
    public class updateModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        [BindProperty]
        public Dict dict { get; set; }
        [BindProperty]
        public string Info { get; set; }
        public void OnGet(int id)
        {
            var responseMessage = client.GetAsync($@"https://localhost:7014/api/Dict/{id}").Result;
            responseMessage.EnsureSuccessStatusCode();
            dict = responseMessage.Content.ReadFromJsonAsync<Dict>().Result;
        }

        public void OnPost(int id)
        {
            OnGet(id);
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Dict/{id}");
            requestMessage.Content = JsonContent.Create(new { Info = Info });
            client.SendAsync(requestMessage);
        }
    }
}
