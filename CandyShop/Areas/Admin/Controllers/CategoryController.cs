using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Area.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return RedirectToAction("List", "Category");
        }

        public IActionResult List()
        {
            var categories = _db.Categories.OrderBy(x => x.Id).ToList();
            return View(categories);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Dodaj";
            return View("AddUpdate", new Category());
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Ažuriraj";
            Category category = _db.Categories.Find(id);
            //koristimo isti view za dodavanje i ažuriranje
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if(ModelState.IsValid)
            {
                //ako je id = 0 onda dodajemo 
                if(category.Id ==0)
                {
                    _db.Categories.Add(category);
                }
                else
                {
                    _db.Categories.Update(category);
                }
                _db.SaveChanges();
                return RedirectToAction("List", "Category");
            }
            else
            {
                ViewBag.Action = "Spremi";
                return View("AddUpdate");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = _db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("List", "Category");
        }

    }
}
