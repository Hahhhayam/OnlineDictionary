using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class UpdateLanguageDTO
    {
        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string? Name { get; set; }

        [StringLength(250)]
        public string? Info { get; set; }
    }
}
