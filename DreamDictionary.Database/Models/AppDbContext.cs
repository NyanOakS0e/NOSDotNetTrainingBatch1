using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DreamDictionary.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlogDetail> BlogDetails { get; set; }

    public virtual DbSet<BlogHeader> BlogHeaders { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogDetail>(entity =>
        {
            entity.ToTable("BlogDetail");
        });

        modelBuilder.Entity<BlogHeader>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("BlogHeader");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
