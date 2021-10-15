using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using LoggingServiceDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingServiceDemo.Controllers
{
    public class HomeController : Controller
    {
        //instancu loggera dobijemo automatski
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogTrace("U konstruktoru sam...");
        }

        public IActionResult Index()
        {
            _logger.LogDebug("Ulazim u Index metodu...{0}", DateTime.Now.ToString());
            _logger.LogInformation("Hello world");
            string s = "Hello";
            string s2 = "World";

            _logger.LogInformation("{0} {1}", s, s2);
            if (s.Length < 10)
            {
                _logger.LogWarning("Oprez: vrijednost string s je premala...");
            }

            if (s2.Length < 10)
            {
                _logger.LogError("Oprez: vrijednost string s2 je premala...");
            }

            if(s2.Length < 10)
            {
                _logger.LogCritical("Oprez: vrijednost string s2 je premala...");
            }

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
    }
}
