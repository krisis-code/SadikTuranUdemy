

using Microsoft.AspNetCore.Mvc;

namespace TemelKonular.Controllers;

public class CourseController : Controller{
public IActionResult Index()
{
    return View();
}
public IActionResult List()
{
    return View("CourseList");
}

}