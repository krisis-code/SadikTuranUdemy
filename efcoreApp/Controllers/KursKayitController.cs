using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using efcoreApp.Models;
using efcoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Immutable;

namespace efcoreApp.Controllers;

public class KursKayitController : Controller
{
    private readonly DataContext _context;
    public KursKayitController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
      
       var kursKayitlari = await _context
                                .Kurskayitleri
                                .Include(x => x.ogrenci)
                                .Include(x=>x.kurs)
                                .ToListAsync();
        return View(kursKayitlari);
    }
    
    public async Task< IActionResult>  Create()
    {
        ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(),"OgrenciId" , "AdSoyad");
        ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(KursKayit model)
    {
        model.KayitTarihi = DateTime.Now;
        _context.Kurskayitleri.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var krs = await _context.Kurskayitleri.FindAsync(id);

        if (krs == null)
        {
            return NotFound();
        }
        return View(krs);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, KursKayit model)
    {
        if (id != model.KursId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Kurskayitleri.Any(o => o.KursId == model.KursId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        return View(model);
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var kurs = await _context.Kurskayitleri.FindAsync(id);

        if (kurs == null)
        {
            return NotFound();
        }

        return View(kurs);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var kurs = await _context.Kurslar.FindAsync(id);
        if (kurs == null)
        {
            return NotFound();
        }
        _context.Kurslar.Remove(kurs);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
