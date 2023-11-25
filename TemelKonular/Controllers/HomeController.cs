using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TemelKonular.Models;

namespace TemelKonular.Controllers;

public class HomeController : Controller
{
  

    public IActionResult Index()
    {
        return  View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    
}
