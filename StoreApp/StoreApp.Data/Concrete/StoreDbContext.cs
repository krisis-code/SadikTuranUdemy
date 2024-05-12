using Microsoft.EntityFrameworkCore;

namespace StoreApp.data.Concrete
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options) 
        {
        
        }
        public DbSet<Product> Products => Set<Product>();
    }
}
