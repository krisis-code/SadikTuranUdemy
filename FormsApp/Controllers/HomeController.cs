using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{
   

   

    public IActionResult Index(string searchString , string Categories)
    {
        var product = Repository.Products;
        
        if(! string.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            product = product.Where(p=> p.Name.ToLower().Contains(searchString)).ToList();

        }
         
        if(! string.IsNullOrEmpty(Categories) && Categories != "0")
        {
           
            product = product.Where(p=> p.CategoryId==int.Parse(Categories)).ToList();

        }
        // ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name",Categories);

        var model = new ProductViewModel{
        Products=product,
        Categories=Repository.Categories,
        SelectedCategory=Categories

        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

   
}
