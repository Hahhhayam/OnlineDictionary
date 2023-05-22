using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineDictionary.Pages.Translates
{
    public class createModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        [BindProperty]
        public string Word1 { get; set; }
        [BindProperty]
        public string Word2 { get; set; }
        [BindProperty]
        public string Type1 { get; set; }
        [BindProperty]
        public string Type2 { get; set; }
        public void OnGet() { }

        public void OnPost()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), $@"https://localhost:7014/api/Translate/zero");
            requestMessage.Content = JsonContent.Create(new { Value1 = Word1, LangName1 = Type1, Value2 = Word2, LangName2 = Type2});
            client.SendAsync(requestMessage);
        }
    }
}
