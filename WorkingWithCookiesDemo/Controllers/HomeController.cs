using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkingWithCookiesDemo.Models;

namespace WorkingWithCookiesDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            //dodajemo vrijednost u Cookie s trajanjem 5 minuta
            CookieOptions option= new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(5);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("Username","Korisnik");


            //za brisanje cookie
            //_httpContextAccessor.HttpContext.Response.Cookies.Delete("Username");

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
