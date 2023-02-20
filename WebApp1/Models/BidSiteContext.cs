using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class BidSiteContext: DbContext
    {
        public BidSiteContext(DbContextOptions<BidSiteContext> options)
            : base(options) { }
        public DbSet<Product> Products { get; set; }
        public D
    }
}
