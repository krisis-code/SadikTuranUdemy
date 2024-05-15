using StoreApp.data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.data.Concrete
{
	public class EFStoreRepository : IStoreRepository
	{
		private StoreDbContext _context;

        public EFStoreRepository(StoreDbContext context)
        {
            _context = context;
        }
		public IQueryable<Product> Products => _context.Products;

		public void CreateProduct(Product entity)
		{
			throw new NotImplementedException();
		}
	}
}
