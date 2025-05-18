using System;
using System.Collections.Generic;

namespace NOS_DreamDictionary_Database.Models;

public partial class BlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
