namespace TemelKonular.Models
{ 
public class Repository
{
    private static readonly List<Course> _courses = new();

    static Repository()
    {
        _courses = new List<Course>()
    {

        new Course (){Id = 1, Title ="Komple Uygulamalı Web Geliştirme Eğitimi" ,
         Description="Sıfırdan ileri seviyeye 'Web Geliştirme': Html, Css, Sass, Flexbox, Bootstrap, Javascript, Angular, JQuery, Asp.Net Mvc&Core Mvc" , image = "1.jpg"},
        new Course (){Id = 2, Title ="Sıfırdan İleri Seviye Modern Javascript Dersleri ES7+" , Description="Modern javascript dersleri ile (ES6 & ES7+) Nodejs, Angular, React ve VueJs için sağlam bir temel oluşturun.",image="2.jpg"},
        new Course (){Id = 3, Title ="Node.js ile Sıfırdan İleri Seviye Web Geliştirme" , Description="Node.js ile sıfırdan ileri seviye dinamik web uygulaması geliştirmeyi öğren.",image="3.jpg"},
        new Course (){Id = 4, Title ="Python ile Sıfırdan İleri Seviye Python Programlama" , Description="Sıfırdan İleri Seviye Python Dersleri.Veritabanı,Veri Analizi,Bot Yazımı,Web Geliştirme(Django).",image="4.jpg"}
    };

    }
    public static List<Course> Courses
    {
        get {
            return _courses;
        }
    }

}
}