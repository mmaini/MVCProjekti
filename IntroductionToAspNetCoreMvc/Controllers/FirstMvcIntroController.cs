using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToAspNetCoreMvc.Controllers
{
    public class FirstMvcIntroController : Controller
    {
        
        public IActionResult Index()
        {
            //automatski traži View imena Index u folderu Views/FirstMvcIntro
            return View();
        }

        //actions mogu vraćati i obični string, ili neki drugi tip, ne nužno IActionResult
        public string Index2()
        {
            return "Pozdrav iz Index2";
        }

        //Kada stavimo kao povratni tip ViewResult, onda možemo vratiti samo View, dok za IactionResult možemo vratiti sve tipove
        //koji nasljeđuju IactionResult
        public ViewResult Index3()
        {
            //kada View nema isto ime kao metoda, onda moramo navesti koji View vraćamo
            return View("Index33");
        }


        //Prosljeđivanje podataka u View
        public ViewResult Index4()
        {
            int hour = DateTime.Now.Hour;
            string viewModel = hour < 12 ? "Dobro jutro" : "Dobar dan";
            return View("Index4", viewModel);
        }

    }
}
