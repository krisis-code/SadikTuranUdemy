using StoreApp.data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.data.Abstract
{
	public interface IStoreRepository
	{
		IQueryable<Product> Products { get; }

		void CreateProduct(Product entity);
	}
}
