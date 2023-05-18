using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class UpdateWordDTO
    {
        public string? Value { get; set; }
        public string? Info { get; set; }

        [RegularExpression(@"\A[a-z]{2}\Z")]
        public string? LanguageName { get; set; }
    }
}
