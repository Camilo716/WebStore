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

            brand
                .HasMany(b => b.ProductsInBrand)
                .WithOne(prod => prod.Brand)
                .HasForeignKey(prod => prod.BrandId);
        });

        modelBuilder.Entity<ProductModel>(product =>
        {
            product.HasKey();
            product
                .Property(p => p.ProductId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            product
                .Property(p => p.Name)
                .HasMaxLength(500);

            product
                .Property(p => p.Description)
                .HasMaxLength(500);

            product
                .Property(p => p.ImgRoute)
                .HasMaxLength(100);

            product
                .Property(p => p.ImgName)
                .HasMaxLength(100);

            product
                .HasOne(p => p.Category)
                .WithMany(cat => cat.ProductsInCategory)
                .HasForeignKey(p => p.CategoryId);

            product
                .HasOne(p => p.Brand)
                .WithMany(brand => brand.ProductsInBrand)
                .HasForeignKey(p => p.BrandId);
        });

        modelBuilder.Entity<ClientModel>(client =>
        {
            client.HasKey(c => c.ClientId);
            client
                .Property(c => c.ClientId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            client
                .Property(c => c.Names)
                .HasMaxLength(100);

            client
                .Property(c => c.Lastnames)
                .HasMaxLength(100);

            client
                .Property(c => c.Mail)
                .HasMaxLength(100);

            client 
                .Property(c => c.Password)
                .HasMaxLength(150);
        });
    }

}
