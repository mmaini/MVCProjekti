using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FormsTagHelperDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FormsTagHelperDemo.Controllers
{
    public class HomeController : Controller
    {
        Category objectCategory= new Category();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //punimo ViewBag.Categories za ddl i listbox
            ViewBag.Categories = objectCategory.Categories;

            return View();
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            
            ViewBag.Categories = objectCategory.Categories;
            //bez ovoga ne bi napravio update vrijednosti na formi kad izračunamo dodatna polja
            ModelState.Clear();

            //izračunamo iznos računa
            product.BillAmount = product.Cost * product.Quantity;
            //ako je iznos veći od 10000 i ako je proizvod dio neke posebne akcije
            if (product.BillAmount > 10000 && product.IsPartOfDeal)
            {
                product.Discount = product.BillAmount * 10 / 100;
            }
            else
            {
                product.Discount = product.BillAmount * 5 / 100;
            }

            //računamo neto iznos
            product.NetBillAmount = product.BillAmount - product.Discount;

            switch (product.CategoryId)
            {
                //ako je kategorija 1 ili 2 dajemo još 1000 kn popusta
                case 1:
                case 2:
                    product.NetBillAmount -= 1000;
                    break;
            }

            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
