using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.controllers
{
    public class HomeController : Controller {
        public IActionResult Index()
        {
            return View();
        }

    }
}