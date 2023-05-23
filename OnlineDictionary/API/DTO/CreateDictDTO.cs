using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class CreateDictDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(250)]
        public string? Info { get; set; }
        
        [Required]
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string Language1Name { get; set; } = null!;

        [Required]
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string Language2Name { get; set; } = null!;
    }
}
