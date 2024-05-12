using Microsoft.AspNetCore.Mvc;

namespace StoreApp.web.Controller
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
