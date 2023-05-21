using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class TranslateDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
