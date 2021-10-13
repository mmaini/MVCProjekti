using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DevConferenceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevConferenceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        //ovo će vratiti prazan view za popunjavanje
        public ViewResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        //ovo će se pozvati na submit forme
        public ViewResult RegisterForm(WebinarInvite response)
        {
            //ako prođe validacija (na svakom svojstvu smo stavili validaciju u WebinarInvite klasi)
            if (ModelState.IsValid)
            {
                //dodajemo odgovor u listu odgovora
                Repository.AddResponse(response);
                //preusmjeravano na view zahvale
                return View("ThankYou", response);
            }
            else
            {
                //vratit će View na kojem će biti greške
                return View();
            }
           
        }


        //metoda koja vraća popis svih sudionika koji su potvrdili dolazak
        public ViewResult ListResponse()
        {
            //vraćamo listu svih onih koji su potvrdili dolazak na konferenciju
            //Responses je lista objekata koje možemo po potrebi filtrirati, ovdje s Where (koji radi na isti način kao u SQL-u) filtriramo i tražimo
            //one koji imaju WillJoin = true
            return View(Repository.Responses.Where(r => r.WillJoin == true));
        }

    }
}
