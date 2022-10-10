using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineClothingStore.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineClothingStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>().HasOne(pc => pc.Product).WithMany(p => p.ProductCategories).HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>().HasOne(pc => pc.Category).WithMany(p => p.ProductCategories).HasForeignKey(pc => pc.CategoryId);
            base.OnModelCreating(modelBuilder);

        }
    
    }
}