using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NisanKurumsalSite.Data;
using NisanKurumsalSite.Entities;

namespace NisanKurumsalSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CategoriesController : Controller
    {
        
private readonly DatabaseContext _context;
public CategoriesController(DatabaseContext context)
{
    _context = context;
}

        public IActionResult Index()
        {
            return View(_context.Categories);
        }
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            //*Ekrandaki kategori seçim elemanına veritabanındaki kategorileri gönderiyoruz.
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Categories.Add(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch 
                {
                     ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            return View(collection);
        }
        public ActionResult Edit(int id)
        {
             ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            var model = _context.Categories.Find(id); 
            return View (model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            if(ModelState.IsValid)
            try
            {
                _context.Categories.Update(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
            }
            catch 
            {
               ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            return View(collection);
        }
         public ActionResult Delete(int id)
        {
             ViewBag.ParentId = new SelectList(_context.Categories, "Id", "Name");
            var model = _context.Categories.Find(id); 
            return View (model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Delete(int id, Category collection)
         {
            try
            {
                _context.Categories.Remove(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
            }
            catch 
            {
             return View();
            }
            
         }
    }
}