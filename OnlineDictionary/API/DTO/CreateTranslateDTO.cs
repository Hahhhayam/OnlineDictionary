using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class CreateTranslateDTO
    {
        [Required]
        public int Word1Id { get; set; }

        [Required]
        public int Word2Id { get; set; }

        public string? Example { get; set; }
    }
}
