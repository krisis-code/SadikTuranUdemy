using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.controllers
{
    public class HomeController : Controller {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

           ViewData["UserName"] = "Enes";
            ViewData["selamlama"] = saat > 12 ? "İyi Günler ":" Günaydın" ;
            return View();
        }

    }
}