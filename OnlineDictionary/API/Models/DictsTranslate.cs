using System;
using System.Collections.Generic;

namespace OnlineDictionary.API.Models;

public partial class DictsTranslate
{
    public int DictId { get; set; }

    public int TranslateId { get; set; }

    public virtual Dict Dict { get; set; } = null!;
    public virtual Translate Translate { get; set; } = null!;
}
