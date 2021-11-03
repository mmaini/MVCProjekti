using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private List<Category> _categories;
        public ProductController(AppDbContext db)
        {
            _db = db;
            _categories = _db.Categories.OrderBy(x => x.Id).ToList();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
      
        public IActionResult List(string id="All")
        {
            List<Product> products;
            if(id=="All")
            {
                products = _db.Products.OrderBy(x => x.Id).ToList();
            }
            else
            {
                products = _db.Products.Where(x => x.Category.Name == id).ToList();
            }

            ViewBag.Categories = _categories;
            ViewBag.SelectedCategoryName = id;
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            product.Category = _db.Categories.Find(1);
            ViewBag.Action = "Dodaj";
            ViewBag.Categories = _categories;
            return View("AddUpdate", product);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            ViewBag.Action = "Ažuriraj";
            ViewBag.Categories = _categories;
            return View("AddUpdate", product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if(ModelState.IsValid)
            {
                if(product.Id ==0)
                {
                    _db.Products.Add(product);
                }
                else
                {
                    _db.Products.Update(product);
                }

                _db.SaveChanges();
                return RedirectToAction("List", "Product");
            }

            ViewBag.Action = "Spremi";
            ViewBag.Categories = _categories;
            return View("AddUpdate", product);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("List", "Product");
        }


    }
}
