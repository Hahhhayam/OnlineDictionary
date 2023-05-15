using System;
using System.Collections.Generic;

namespace OnlineDictionary.API.Models;

public partial class Language
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Info { get; set; }

    public virtual ICollection<Dict> DictLanguage1s { get; set; } = new List<Dict>();

    public virtual ICollection<Dict> DictLanguage2s { get; set; } = new List<Dict>();

    public virtual ICollection<Word> Words { get; set; } = new List<Word>();
}
