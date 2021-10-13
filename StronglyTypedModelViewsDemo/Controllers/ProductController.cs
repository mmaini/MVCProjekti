using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StronglyTypedModelViewsDemo.Models;

namespace StronglyTypedModelViewsDemo.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> _products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Keks",
                Quantity = 10,
                UnitsInStock = 40,
                Discontinued = false,
                Cost = 9.99,
                Tax = 2.5,
                LaunchDate = new DateTime(2021,1,1)
            },

            new Product
            {
                ProductId = 2,
                ProductName = "Čokolada",
                Quantity = 20,
                UnitsInStock = 100,
                Discontinued = false,
                Cost = 7.99,
                Tax= 2,
                LaunchDate = new DateTime(2021,5,1)
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Bomboni",
                Quantity = 30,
                UnitsInStock = 200,
                Discontinued = true,
                Cost = 12.99,
                Tax=4,
                LaunchDate = new DateTime(2021,8,1)
            },
        };


        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Details(int id)
        {
            var prod = _products.Find(x => x.ProductId.Equals(id));
            return View(prod);
        }

        //ova će metoda samo vratiti podatke na formu da se može ažurirati proizvod
        public IActionResult Edit(int id)
        {
            var prod = _products.Find(x => x.ProductId.Equals(id));
            return View(prod);
        }

        //ova se metoda okine kad se klikne button na formi za ažuriranje
        [HttpPost]
        public IActionResult Edit(Product modifiedProduct)
        {
            //nađemo proizvod
            var prod = _products.FirstOrDefault(x => x.ProductId.Equals(modifiedProduct.ProductId));
            //nađemo njegov index
            var indexof = _products.IndexOf(prod);
            //ubacimo na njegovu poziciju izmijenjeni proizvod
            _products[indexof] = modifiedProduct;

            //vraćamo se na listu proizvoda automatski
            return View("Index", _products);
        }

        //samo dohvaća podatke o proizvodu radi prikaza
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prod = _products.Find(x => x.ProductId.Equals(id));
            return View(prod);
        }

        [HttpPost]
        //ovako možemo definirati pod kojim nazivom će se metoda pozivati
        [ActionName(("Delete"))]
        //interno metoda ima drugačiji naziv - ovo je napravljeno iz razloga što ne možemo imati 2 metode koje
        //imaju isto ime i primaju iste parametre, a u ovom slučaju Delete metoda i u Get i u Post varijanti prima int id
        public IActionResult DeleteProduct(int id)
        {
            //nađemo proizvod
            var prod = _products.Find(x => x.ProductId.Equals(id));
            //uklonimo ga iz liste
            _products.Remove(prod);
            //odemo na pregled svih proizvoda
            return View("Index", _products);

        }

        [HttpGet]
        //samo će nas preusmjeriti na View za unos novog proizvoda
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            //ako je validacija prošla ok, dodaj proizvod u listu i vrati view s listom proizvoda
            if (ModelState.IsValid)
            {
                _products.Add(newProduct);
                return View("Index", _products);
            }
            else
            {
                //vrati na View otkud smo i došli kako bi se unijele ispravne vrijednosti
                return View();
            }
        }
    }
}
