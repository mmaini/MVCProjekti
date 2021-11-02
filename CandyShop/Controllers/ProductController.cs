using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        public IActionResult Details(int id)
        {
            var categories = _db.Categories.OrderBy(x => x.Id).ToList();
            Product product = _db.Products.Find(id);
            var categoryName = "";
            foreach(var category in categories)
            {
                if (category.Id == product.CategoryId) categoryName = category.Name;
            }
            string imageFileName = product.Code + "-m.jpg";
            ViewBag.CategoryName = categoryName;
            ViewBag.ImageFileName = imageFileName;
            return View(product);
        }

        //id ovdje prestavlja kategoriju
        public IActionResult List(string id="All")
        {
            var categories = _db.Categories.OrderBy(x => x.Id).ToList();
            List<Product> products;
            //ako nije proslijeđen Id ili ako je All onda dohvaćamo sve proizvode
            if(id == "All")
            {
                products = _db.Products.OrderBy(x => x.Id).ToList();
            }
            else
            {
                //u suprotnom dohvaćamo proizvode koji pripadaju nekoj kategoriji
                products = _db.Products.Where(x=>x.Category.Name == id).OrderBy(x => x.Id).ToList();
            }

            ViewBag.SelectedCategoryName = id;
            ViewBag.AllCategories = categories;
            return View(products);
        }
    }
}
