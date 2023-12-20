using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using efcoreApp.Models;
using efcoreApp.Data;

namespace efcoreApp.Controllers;

public class OgrenciController : Controller
{
    private readonly DataContext _context;
    public OgrenciController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ogrenci model)
    {
        _context.Ogrenciler.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Home");
    }
}