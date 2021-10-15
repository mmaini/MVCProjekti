using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DependenyInjectionDemo.Models;
using DependenyInjectionDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DependenyInjectionDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //kreiramo instancu servisa - na ovaj način ne koristimo DI
        //SiteVisitorsCounter svc = new SiteVisitorsCounter();

        //ovo koristimo za DI - inicijalizacija ide kroz konstruktor
        private readonly ISiteVisitorsCounter _counter;

        public HomeController(ILogger<HomeController> logger, ISiteVisitorsCounter counter)
        {
            _logger = logger;
            _counter = counter;
        }

        public IActionResult Index()
        {
            //pozovemo metodu - uvijek će vratiti 1 jer se svaki puta kreira nova instanca
            //ViewBag.Counter = svc.GetCounter();

            //koristimo DI s AddTransient - na kraju ispiše 3 jer smo cijelo vrijeme u istom zahtjevu
            //isto vrijedi za AddScoped
            ViewBag.Counter = _counter.GetCounter();
            ViewBag.Counter = _counter.GetCounter();
            ViewBag.Counter = _counter.GetCounter();

            //s AddSingleton će ispisati 3 jer koristi istu instancu
            return View();
        }

        public IActionResult Privacy()
        {
            //ispisat će 1 s AddTransient jer smo otišli na drugu stranicu i to je novi zahtjev i nova instanca servisa
            //ispisat će 4 s AddSingleton jer koristi istu instancu servisa
            //ispisat će 1 s AddScoped jer smo otišli na drugu stranicu i to je novi zahtjev i nova instanca servisa
            ViewBag.Counter = _counter.GetCounter();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
