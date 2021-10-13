using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WorkingWithControllersDemo.Models;

namespace WorkingWithControllersDemo.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            //jedan od načina prosljeđivanja podataka 
            //ViewBag je objekt kojem možemo dodavati svojstva po želji 
            ViewBag.Greeting = "Hello world iz MVC Core";
            ViewBag.CompanyName = "Vsite";
            ViewBag.Country = "Hrvatska";

            Author author = new Author();
            author.Name = "Tolstoj";
            author.Country = "Rusija";

            //prosljeđjemo model View-u
            return View(author);
        }


        //za poziv u URL: https://localhost:44358/HelloWorld/QueryStringDemo?Message=Pozdrav
        //ako ne proslijedimo ništa kao parametar, onda će uzeti default vrijednost
        public IActionResult QueryStringDemo(string message= "Hello world iz MVC Core")
        {
            ViewBag.Greeting = message;
            return View();
        }


        //ako i ne navedemo HttpGet, poziv je GET - to je default
        //https://localhost:44358/HelloWorld/GoToUrl - ako ne navedemo ništa vodi nas na google 
        //https://localhost:44358/HelloWorld/gotourl?url=https://vsite.hr/hr - ako proslijedimo parametar vodi nas na tu stranicu
        [HttpGet]
        public IActionResult GoToUrl(string url="http://www.google.com")
        {
            return Redirect(url);

        }

        [HttpPost]
        //https://localhost:44358/HelloWorld
        public IActionResult GoToUrl(IFormCollection ifCollection)
        {
            //kada se okine submit na stranici, parametre možemo dohvatiti iz IFormCollection
            string url = ifCollection["url"];
            //ako nam ništa nije proslijeđeno
            if (string.IsNullOrEmpty(url)) 
                return Redirect("http://www.google.com");
            
            return Redirect(url);

        }



    }


}

