using Microsoft.AspNetCore.Mvc;
using StoreApp.data.Abstract;

namespace StoreApp.web.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repository;

		public HomeController(IStoreRepository repository)
		{
			_repository = repository;
		}

		public IActionResult Index() => View(_repository.Products);
        
    }
}
