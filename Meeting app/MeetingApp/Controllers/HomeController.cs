using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.controllers
{
    public class HomeController : Controller {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

           ViewData["UserName"] = "Enes";
            ViewData["selamlama"] = saat > 12 ? "İyi Günler ":" Günaydın" ;
            var meetinginfo = new MeetingInfo()
            {
                Id = 1,
                Location ="İstanbul ,Abc kongre Merkezi",
                Date = new DateTime(2024,01,20,20,0,0),
                NumberOfPeople = 100
            };
            return View(meetinginfo);
        }

    }
}