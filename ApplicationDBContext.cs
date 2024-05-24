using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Models;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<VwSalesDetail> VwSalesDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=sql.bsite.net\\MSSQL2016;initial catalog=salesdashboard_;User Id=salesdashboard_;Password=Admin1234*;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.ToTable("Branch");

            entity.HasIndex(e => e.Cityid, "IX_Branch_Cityid");

            entity.HasOne(d => d.City).WithMany(p => p.Branches).HasForeignKey(d => d.Cityid);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8FBAFAF27");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.CustomerType).WithMany(p => p.InverseCustomerType)
                .HasForeignKey(d => d.CustomerTypeId)
                .HasConstraintName("Customer_FK");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.ToTable("CustomerType");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductCategoryid, "IX_Product_ProductCategoryid");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products).HasForeignKey(d => d.ProductCategoryid);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3213E83FDBC8A7A7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Gender).HasMaxLength(255);
            entity.Property(e => e.InvoiceNo).HasMaxLength(255);
            entity.Property(e => e.OrderTime).HasPrecision(0);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Sales)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Sales__BranchId__440B1D61");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sales__CustomerI__44FF419A");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("FK__Sales__PaymentTy__46E78A0C");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Sales__ProductID__45F365D3");
        });

        modelBuilder.Entity<VwSalesDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_SalesDetail");

            entity.Property(e => e.Cogs)
                .HasColumnType("money")
                .HasColumnName("Cogs");
            entity.Property(e => e.DayName)
                .HasMaxLength(3)
                .HasColumnName("day_name");
            entity.Property(e => e.Gender).HasMaxLength(255);
            entity.Property(e => e.GrossIncome)
                .HasColumnType("money")
                .HasColumnName("GrossIncome");
            // entity.Property(e => e.GrossIncome)
            //     .HasColumnType("money")
            //     .HasColumnName("gross_income");
            entity.Property(e => e.GrossMarginper)
                .HasColumnType("money")
                .HasColumnName("gross_marginper");
            entity.Property(e => e.InvoiceNo).HasMaxLength(255);
            entity.Property(e => e.MonthName)
                .HasMaxLength(3)
                .HasColumnName("month_name");
            entity.Property(e => e.OrderTime).HasPrecision(0);
            entity.Property(e => e.TimeOfDay)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("time_of_day");
            entity.Property(e => e.TotalSalesAmount).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
