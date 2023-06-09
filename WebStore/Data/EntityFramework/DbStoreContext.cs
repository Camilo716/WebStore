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
        ConfigureCategory(modelBuilder);
        ConfigureBrand(modelBuilder);
        ConfigureProduct(modelBuilder);
        ConfigureClient(modelBuilder);
        ConfigureShoppingCart(modelBuilder);
        ConfigureSale(modelBuilder);
        ConfigureSaleDetails(modelBuilder);
        ConfigureAdmin(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryModel>(category =>
        {
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.CategoryId).ValueGeneratedOnAdd();

            category.Property(c => c.Description).HasMaxLength(100);

            category
                .HasMany(c => c.ProductsInCategory)
                .WithOne(prod => prod.Category)
                .HasForeignKey(prod => prod.CategoryId);
        });
    }

    private void ConfigureBrand(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandModel>(brand =>
        {
            brand.HasKey(b => b.BrandId);
            brand.Property(b => b.BrandId).ValueGeneratedOnAdd();

            brand.Property(b => b.Description).HasMaxLength(100);

            brand
                .HasMany(b => b.ProductsInBrand)
                .WithOne(prod => prod.Brand)
                .HasForeignKey(prod => prod.BrandId);
        });
    }

    private void ConfigureProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>(product =>
        {
            product.HasKey(p => p.ProductId);
            product.Property(p => p.ProductId).ValueGeneratedOnAdd();

            product.Property(p => p.Name).HasMaxLength(500);
            product.Property(p => p.Description).HasMaxLength(500);
            product.Property(p => p.ImgRoute).HasMaxLength(100);
            product.Property(p => p.ImgName).HasMaxLength(100);

            product
                .HasOne(p => p.Category)
                .WithMany(cat => cat.ProductsInCategory)
                .HasForeignKey(p => p.CategoryId);

            product
                .HasOne(p => p.Brand)
                .WithMany(brand => brand.ProductsInBrand)
                .HasForeignKey(p => p.BrandId);
        });
    }

    private void ConfigureClient(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientModel>(client =>
        {
            client.HasKey(c => c.ClientId);
            client.Property(c => c.ClientId).ValueGeneratedOnAdd();

            client.Property(c => c.Names).HasMaxLength(100);
            client.Property(c => c.Lastnames).HasMaxLength(100);
            client.Property(c => c.Mail).HasMaxLength(100);
            client.Property(c => c.Password).HasMaxLength(150);
        });
    }

    private void ConfigureShoppingCart(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCartModel>(cart =>
        {
            cart.HasKey(c => c.ShoppingCartId);
            cart.Property(c => c.ShoppingCartId).ValueGeneratedOnAdd();

            cart
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId);

            cart
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);
        });
    }

    private void ConfigureSale(ModelBuilder modelBuilder)
    {  
        modelBuilder.Entity<SaleModel>(sale => 
        {
            sale.HasKey(s => s.SaleId);
            sale.Property(s => s.SaleId).ValueGeneratedOnAdd();

            sale.Property(s => s.Contact).HasMaxLength(50);
            sale.Property(s => s.Adress).HasMaxLength(100);

            sale
                .HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.ClientId);
        });
    }

    private void ConfigureSaleDetails(ModelBuilder modelBuilder)
    {  
        modelBuilder.Entity<SaleDetailsModel>(details => 
        {
            details.HasKey(d => d.SaleDetailsId);
            details.Property(d => d.SaleDetailsId).ValueGeneratedOnAdd();
            
            details 
                .HasOne(d => d.Sale)
                .WithMany()
                .HasForeignKey(d => d.SaleId);

            details
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId);
        });
    }

    private void ConfigureAdmin(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminModel>(admin =>
        {
            admin.HasKey(a => a.AdminId);
            admin.Property(a => a.AdminId).ValueGeneratedOnAdd();

            admin.Property(a => a.Names).HasMaxLength(100);
            admin.Property(a => a.Lastnames).HasMaxLength(100);
            admin.Property(a => a.Mail).HasMaxLength(100);
            admin.Property(a => a.Password).HasMaxLength(150);
        });
    }
}
