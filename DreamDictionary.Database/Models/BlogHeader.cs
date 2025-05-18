using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamDictionary.Database.Models;

public partial class BlogHeader
{
    [Key]

    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
