using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TemelKonular.Models;

namespace TemelKonular.Controllers;

public class HomeController : Controller
{
  

    public string Index()
    {
        return "Home/index";
    }

    public string Contact()
    {
        return "Home/Contact";
    }

    
}
