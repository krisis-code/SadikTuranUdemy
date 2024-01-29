using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
