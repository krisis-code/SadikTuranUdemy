using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
