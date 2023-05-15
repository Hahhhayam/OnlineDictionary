using System;
using System.Collections.Generic;

namespace OnlineDictionary.API.Models;

public partial class Dict
{
    public int Id { get; set; }

    public string? Info { get; set; }

    public int Language1Id { get; set; }

    public int Language2Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DictsTranslate> DictsTranslates { get; set; } = new List<DictsTranslate>();

    public virtual Language Language1 { get; set; } = null!;

    public virtual Language Language2 { get; set; } = null!;
}
