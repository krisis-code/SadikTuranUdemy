using Microsoft.AspNetCore.Mvc;
using TemelKonular.Models;



namespace TemelKonular.Controllers;

public class CourseController : Controller{
public IActionResult Index()
{
    var kurs = new Course();
    kurs.Id = 1;
    kurs.Title="Aspnet core kursu";
    kurs.Description = "Güzel bir eğitim";
    
    return View(kurs);
}
public IActionResult List()
{
    var kurslar = new List<Course>
    {
        new Course (){Id = 1, Title ="Aspnet Core Kursu 1" , Description="A dan Z ye tüm detayları ile"},
        new Course (){Id = 2, Title ="Aspnet Core Kursu 2" , Description="A dan Z ye tüm detayları ile"},
        new Course (){Id = 3, Title ="Aspnet Core Kursu 3" , Description="A dan Z ye tüm detayları ile"},
    };
    return View("CourseList",kurslar);
}

}