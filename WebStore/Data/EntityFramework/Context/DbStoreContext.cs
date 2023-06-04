using WebStore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Data.EntityFramework.Context;

public class DbStoreContext : DbContext
{
    DbSet<CategoryModel> Categories { get; set;}
    DbSet<BrandModel> Brands { get; set;}
    DbSet<ProductModel> Products { get; set;}
    DbSet<ShoppingCartModel> ShoppingCarts { get; set;}

    DbSet<ClientModel> Clients { get; set;}
    DbSet<SaleModel> Sales { get; set;}
    DbSet<SaleDetailsModel> SalesDetails { get; set;}

    DbSet<AdminModel> Admins { get; set;}
    
    public DbStoreContext(DbContextOptions<DbStoreContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        new CategoryEntityConfiguration()
            .Configure(modelBuilder.Entity<CategoryModel>());

        // modelBuilder.Entity<CategoryModel>()
        //     .HasKey(c => c.CategoryId);

        // modelBuilder.Entity<CategoryModel>()
        //     .Property(c => c.CategoryId).ValueGeneratedOnAdd();

        // modelBuilder.Entity<CategoryModel>()
        //     .Property(c => c.Description).HasMaxLength(100);

        // modelBuilder.Entity<CategoryModel>()
        // base.OnModelCreating(modelBuilder);
    }

}
