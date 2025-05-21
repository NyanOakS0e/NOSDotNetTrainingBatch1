using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamDictionary.Database.Models;

public partial class BlogDetail
{
    [Key]
    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string? BlogContent { get; set; }
}
