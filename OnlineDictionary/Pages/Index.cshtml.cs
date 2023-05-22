using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineDictionary.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            client.PatchAsync($@"https://localhost:7014/api/Auth/logout", null);
        }
    }
}