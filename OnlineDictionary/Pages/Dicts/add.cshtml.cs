using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineDictionary.Pages.Dicts
{
    public class addModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        public void OnGet() { }

        public void OnPost(int id, int idTranslate)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Dict/{id}/add/{idTranslate}");
            client.SendAsync(requestMessage);
        }
    }
}
