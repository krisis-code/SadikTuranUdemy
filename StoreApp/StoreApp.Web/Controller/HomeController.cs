using Microsoft.AspNetCore.Mvc;

namespace StoreApp.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
