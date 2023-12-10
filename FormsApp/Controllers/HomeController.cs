using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;

namespace FormsApp.Controllers;

public class HomeController : Controller
{
   

   

    public IActionResult Index(string searchString)
    {
        var product = Repository.Products;
        
        if(! string.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            product = product.Where(p=> p.Name.ToLower().Contains(searchString)).ToList();

        }
        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

   
}
