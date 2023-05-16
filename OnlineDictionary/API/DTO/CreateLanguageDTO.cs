using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class CreateLanguageDTO
    {
        [Required]
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string Name { get; set; } = null!;

        [StringLength(250)]
        public string? Info { get; set; }
    }
}
