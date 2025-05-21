using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NOS_DreamDictionary_Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blogdetail> BlogDetails { get; set; }

    public virtual DbSet<BlogHeader> BlogHeaders { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blogdetail>(entity =>
        {
            entity
                .HasKey(e => e.BlogDetailId);
            entity
                .ToTable("BlogDetail");

            entity.Property(e => e.BlogContent).HasMaxLength(200);
            entity.Property(e => e.BlogDetailId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BlogHeader>(entity =>
        {
            entity
                .HasKey(e => e.BlogId);
            entity
                .ToTable("BlogHeader");

            entity.Property(e => e.BlogId).ValueGeneratedOnAdd();
            entity.Property(e => e.BlogTitle).HasMaxLength(50);
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
