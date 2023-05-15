using System;
using System.Collections.Generic;

namespace OnlineDictionary.API.Models;

public partial class Translate
{
    public int Id { get; set; }

    public int Word1Id { get; set; }

    public int Word2Id { get; set; }

    public string? Example { get; set; }

    public virtual Word Word1 { get; set; } = null!;

    public virtual Word Word2 { get; set; } = null!;
}
