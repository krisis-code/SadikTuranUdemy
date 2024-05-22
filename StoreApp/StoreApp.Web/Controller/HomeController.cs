using Microsoft.AspNetCore.Mvc;
using StoreApp.data.Abstract;
using StoreApp.web.Models;

namespace StoreApp.web.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repository;
		public int pageSize = 3;

		public HomeController(IStoreRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index(int page = 1) {

			var products = _repository.Products.Skip((page-1)*pageSize).Select(p => new ProductViewModel
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price
			}).Take(pageSize); 
			
			return View(new ProductListViewModel { Products = products});
		}
	}
}
