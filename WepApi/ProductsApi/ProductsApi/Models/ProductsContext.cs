using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
        {

        }
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
