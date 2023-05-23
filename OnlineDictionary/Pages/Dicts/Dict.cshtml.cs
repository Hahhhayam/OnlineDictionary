using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineDictionary.API.Models;
using System;

namespace OnlineDictionary.Pages.Dicts
{
    public class DictModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        public bool isLogged { get; set; }

        public Dict dict { get; set; }

        public void OnGet(int id)
        {
            var rM = client.GetAsync(@"https://localhost:7014/api/Auth").Result;
            isLogged = rM.Content.ReadFromJsonAsync<bool>().Result;

            rM = client.GetAsync($@"https://localhost:7014/api/Dict/{id}").Result;
            rM.EnsureSuccessStatusCode();
            dict = rM.Content.ReadFromJsonAsync<Dict>().Result;
        }
        public void OnPost(int id, int idTranslate) 
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), $@"https://localhost:7014/api/Dict/{id}/remove/{idTranslate}");
            client.SendAsync(requestMessage);
            OnGet(id);
        }
    }
}
