using Microsoft.EntityFrameworkCore;

namespace StoreApp.data.Concrete
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options) 
        {
        
        }
        public DbSet<Product> Products => Set<Product>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new List<Product>()
                {
                    new (){Id = 1, Name =  "İphone 10",Price = 20000,Description = "İphone" , Category = "Telefon" },
					 new (){Id = 2, Name =  "İphone 11",Price = 25000,Description = "İphone" , Category = "Telefon" },
					  new (){Id = 3, Name =  "İphone 12",Price = 30000,Description = "İphone" , Category = "Telefon" },
					   new (){Id = 4, Name =  "İphone 13",Price = 35000,Description = "İphone" , Category = "Telefon" },
						new (){Id = 5, Name =  "İphone 14",Price = 40000,Description = "İphone" , Category = "Telefon" },



				}

				);
		}
	}
}
