using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Models
{
    public class ProductsContext : IdentityDbContext<AppUser,AppRole,int>
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
