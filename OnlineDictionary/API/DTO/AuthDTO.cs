using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class AuthDTO
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
