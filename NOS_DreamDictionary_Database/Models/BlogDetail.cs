using System;
using System.Collections.Generic;

namespace NOS_DreamDictionary_Database.Models;

public partial class Blogdetail
{
    private readonly AppDbContext _context;

    public Blogdetail(AppDbContext context)
    {
        _context = context;
    }

    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string BlogContent { get; set; } = null!;
}
