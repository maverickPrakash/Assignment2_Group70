using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class BidSiteContext : DbContext
    {
        public BidSiteContext(DbContextOptions<BidSiteContext> options)
            : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public object Category { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "Electronic" },
                new Category { CategoryId = 3, CategoryName = "Fashion" },
                new Category { CategoryId = 4, CategoryName = "Game" },
                new Category { CategoryId = 5, CategoryName = "Books" },
                new Category { CategoryId = 6, CategoryName = "Computer" }
                );

        }
    }
}
