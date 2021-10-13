using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StateManagementDemo.Controllers
{
    public class StateDemoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //spremamo podatke kao key-value parove
            ViewData["Code"] = 101;
            ViewData["Name"] = "Pero";

            ViewBag.Message = "Ovo je iz ViewBag";


            //cookie based temp data
            //ono što se unese ostaje dostupno, za razliku od ViewData i ViewBag gdje jednom kad pročitamo podatke oni nestaju
            if (TempData["Country"] == null) //dodaj samo ako nije već definiran, inače bi bacilo grešku
            {
                TempData.Add("Country", "Hrvatska");
            }
        
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection ifc)
        {
            return View();
        }
    }
}
