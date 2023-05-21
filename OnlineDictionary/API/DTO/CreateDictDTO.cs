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
        public int Language1Id { get; set; }

        [Required]
        public int Language2Id { get; set; }
    }
}
