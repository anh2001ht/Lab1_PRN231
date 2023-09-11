using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models;

public partial class Prn221dbContext : DbContext
{
    public Prn221dbContext()
    {
    }

    public Prn221dbContext(DbContextOptions<Prn221dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=D-OS3-ANHNH49\\MSSQLSERVER03;Database=PRN221DB;user=sa;password=HA@1234567; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "CategoryName");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.HasIndex(e => e.ProductName, "ProductName");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
