using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.controllers
{
    public class HomeController : Controller {
        public string Index()
        {
            return "home/index";
        }

    }
}