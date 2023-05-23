using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineDictionary.Pages.Dicts
{
    public class createModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string info { get; set; }
        [BindProperty]
        public string lang1 { get; set; }
        [BindProperty]
        public string lang2 { get; set; }
        public void OnGet() { }

        public void OnPost()
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), $@"https://localhost:7014/api/Dict");
            requestMessage.Content = JsonContent.Create(new { Name = name, Info = info, Language1Name = lang1, Language2Name = lang2 });
            client.SendAsync(requestMessage);
        }
    }
}
