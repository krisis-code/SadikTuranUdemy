using Microsoft.AspNetCore.Mvc;
using StoreApp.data.Abstract;
using StoreApp.web.Models;

namespace StoreApp.web.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repository;

		public HomeController(IStoreRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index() {

			var products = _repository.Products.Select(p => new ProductViewModel
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price
			}).ToList(); 
			
			return View(new ProductListViewModel { Products = products});
		}
	}
}
