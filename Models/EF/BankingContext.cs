using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiApplication.Models.EF;

public partial class BankingContext : DbContext
{
    public BankingContext()
    {
    }

    public BankingContext(DbContextOptions<BankingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:amolapidemo.database.windows.net,1433;Initial Catalog=Banking;Persist Security Info=False;User ID=AmolN;Password=Cognizant@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__products__DD36D562EC4E594D");

            entity.ToTable("products");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("pId");
            entity.Property(e => e.PCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice).HasColumnName("pPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
