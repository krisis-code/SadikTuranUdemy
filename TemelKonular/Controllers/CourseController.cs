using Microsoft.AspNetCore.Mvc;
using TemelKonular.Models;



namespace TemelKonular.Controllers;

public class CourseController : Controller{
public IActionResult Index()
{
    var kurs = new Course();
    kurs.Id = 1;
    kurs.Title="Aspnet core kursu";
    
    return View(kurs);
}
public IActionResult List()
{
    return View("CourseList");
}

}