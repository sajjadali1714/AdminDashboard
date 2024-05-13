using AdminDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Data;

public class ApplicationDBContext : DbContext {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options){} 

      public DbSet<Branch> Branch {get; set;}
      public DbSet<City> City {get; set;}
      public DbSet<CustomerType> CustomerType {get; set;}
      public DbSet<PaymentType> PaymentTypes {get; set;}
      public DbSet<Product> Product {get; set;}
      public DbSet<ProductCategory> ProductCategory {get; set;}

      public DbSet<Sale> Sales {get; set;}

}