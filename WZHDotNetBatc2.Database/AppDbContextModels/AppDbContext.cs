using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WZHDotNetBatc2.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMovie> TblMovies { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSaleDetail> TblSaleDetails { get; set; }

    public virtual DbSet<TblSaleSummary> TblSaleSummaries { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMovie>(entity =>
        {
            entity.HasKey(e => e.MovieId);

            entity.ToTable("Tbl_Movie");

            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Tbl_Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblSaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId);

            entity.ToTable("Tbl_SaleDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblSaleSummary>(entity =>
        {
            entity.HasKey(e => e.SaleId);

            entity.ToTable("Tbl_SaleSummary");

            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VoucherNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VoucherNO");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId);

            entity.ToTable("Tbl_Staff");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Mobile No");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffCode).HasMaxLength(20);
            entity.Property(e => e.StaffName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Staff Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
