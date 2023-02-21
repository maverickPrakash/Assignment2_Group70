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
            modelBuilder.Entity<User>().HasData(
                new User { Username="buyer",Password="buyer",Email="buer@gmail.com",UserType="buyer"},
                new User { Username="seller",Password="seller",Email="seller@gmail.com",UserType="seller"}
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Sunflower",
                    Description = "Prakash has created product stuff",
                    StartBidDate = DateTime.Now,
                    ExpiryBidDate = DateTime.Now,
                    Asset_condition = "new",
                    Cost = "12.0",
                    CategoryId = 1,
                    Username = "seller",
                    Image="sunflower.png"

                },
                new Product
                {
                    Id = 2,
                    Name = "Kitkat",
                    Description = "Prakash has created product stuff",
                    StartBidDate = DateTime.Now,
                    ExpiryBidDate = DateTime.Now,
                    Asset_condition = "old",
                    Cost = "12.0",
                    CategoryId = 2,
                    Username = "seller",
                    Image="Kitkat.png"

                },
                new Product
                {
                    Id = 3,
                    Name = "Tulip",
                    Description = "Fresh Tulip",
                    StartBidDate = DateTime.Now,
                    ExpiryBidDate = DateTime.Now,
                    Asset_condition = "new",
                    Cost = "12.0",
                    CategoryId = 1,
                    Username = "seller",
                    Image="tulips.png"

                },
                new Product
                {
                    Id = 4,
                    Name = "Tobelerone",
                    Description = "Sweet in taste",
                    StartBidDate = DateTime.Now,
                    ExpiryBidDate = DateTime.Now,
                    Asset_condition = "old",
                    Cost = "12.0",
                    CategoryId = 2,
                    Username = "buyer",
                    Image="Toblerone.png"

                }
                ); ;

        }
    }
}
