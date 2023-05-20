using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class CreateTranslateZeroDTO
    {
        [Required]
        [StringLength(50)]
        public string Value1 { get; set; } = null!;

        [Required]
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string LangName1 { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Value2 { get; set; } = null!;

        [Required]
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string LangName2 { get; set; } = null!;
    }
}
