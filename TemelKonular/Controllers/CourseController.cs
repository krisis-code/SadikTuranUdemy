using Microsoft.AspNetCore.Mvc;
using TemelKonular.Models;



namespace TemelKonular.Controllers;

public class CourseController : Controller{
    public IActionResult Index()
    {
        var kurs = new Course();
           
        kurs.Id = 1;
        kurs.Title = "Komple Uygulamalı Web Geliştirme Eğitimi";
        kurs.Description = "Sıfırdan ileri seviyeye 'Web Geliştirme': Html, Css, Sass, Flexbox, Bootstrap, Javascript, Angular, JQuery, Asp.Net Mvc&Core Mvc";
        kurs.image = "1.jpg";

        return View(kurs);
    }
public IActionResult Details()
{
               var kurs = new Course();
            
                kurs.Id = 1;
                kurs.Title = "Komple Uygulamalı Web Geliştirme Eğitimi";
                kurs.Description = "Sıfırdan ileri seviyeye 'Web Geliştirme': Html, Css, Sass, Flexbox, Bootstrap, Javascript, Angular, JQuery, Asp.Net Mvc&Core Mvc";
                kurs.image = "1.jpg";
            
            return View(kurs);
}
public IActionResult List()
{
    
    return View("CourseList",Repository.Courses);
}

}