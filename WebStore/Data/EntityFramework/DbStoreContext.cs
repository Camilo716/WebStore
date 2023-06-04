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
        modelBuilder.Entity<CategoryModel>(category =>
        {
            category.HasKey(c => c.CategoryId);
            category
                .Property(c => c.CategoryId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            category
                .Property(c => c.Description)
                .HasMaxLength(100);

            category
                .HasMany(c => c.ProductsInCategory)
                .WithOne(prod => prod.Category)
                .HasForeignKey(prod => prod.CategoryId);
        });

        modelBuilder.Entity<BrandModel>(brand => 
        {
            brand.HasKey(b => b.BrandId);
            brand
                .Property(b => b.BrandId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            brand
                .Property(b => b.Description)
                .HasMaxLength(100);
        });
    }

}
