using System;
using System.Collections.Generic;

namespace OnlineDictionary.API.Models;

public partial class Word
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public string Info { get; set; } = null!;

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<Translate> TranslateWord1s { get; set; } = new List<Translate>();

    public virtual ICollection<Translate> TranslateWord2s { get; set; } = new List<Translate>();
}
