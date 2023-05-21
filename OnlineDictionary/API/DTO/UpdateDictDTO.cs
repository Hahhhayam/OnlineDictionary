using System.ComponentModel.DataAnnotations;

namespace OnlineDictionary.API.DTO
{
    public class UpdateDictDTO
    {
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(250)]
        public string? Info { get; set; }

        public int? Language1Id { get; set; }

        public int? Language2Id { get; set; }
    }
}
