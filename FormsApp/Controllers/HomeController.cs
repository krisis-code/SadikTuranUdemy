﻿using System.Diagnostics;
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

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name");
        return View();
    }
    [HttpPost]
    public async Task <IActionResult> Create(Product model, IFormFile imageFile)
    {
        var allowedExtension = new [] {".jpg",".jpeg",".png"};
        var extension = Path.GetExtension(imageFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
        var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",randomFileName);
        if(imageFile != null)
        {
            if(!allowedExtension.Contains(extension))
            {
            ModelState.AddModelError("","Geçerli bir format seçiniz(.jpg , .jpeg , .png)");
            }
        }
        if(ModelState.IsValid)
        {
            if(imageFile != null)
            {  
            using(var stream = new FileStream(path,FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);

            }
            }
            model.Image=randomFileName;
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name");
        return View(model);
        
    }
    public IActionResult Edit(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if(entity == null)
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name");
        return View(entity);
    }

    [HttpPost]
 public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
 {
     if(id != model.ProductId)
     {
         return NotFound();
     }

     if(ModelState.IsValid)
     {
         if(imageFile != null) 
         {
             var extension = Path.GetExtension(imageFile.FileName); // abc.jpg
             var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
             var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

             using(var stream = new FileStream(path, FileMode.Create))
             {
                 await imageFile.CopyToAsync(stream);
             }
             model.Image = randomFileName;
         }
         Repository.EditProduct(model);
         return RedirectToAction("Index");
     }
     ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
     return View(model);
 }

   
}
