using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class CreateWordDTO
    {
        [Required]
        public string Value { get; set; } = null!;

        public string? Info { get; set; }

        [Required]
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string LanguageName { get; set; } = null!;
    }
}
