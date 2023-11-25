

using Microsoft.AspNetCore.Mvc;

namespace TemelKonular.Controllers;

public class CourseController : Controller{
public string Index()
{
    return "Course/index";
}
public string List()
{
    return "Course/List";
}

}