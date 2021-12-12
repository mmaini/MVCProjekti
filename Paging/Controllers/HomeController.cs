using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Paging.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Koristimo Nuget pakete - X.PagedList i X.PagedList.Mvc.Core


        [HttpGet]
        [Route("/")]
        [Route("home/index/{id?}")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1; // ako stranica nije navedena, onda podrazumijevamo da se radi o prvoj
            int pageSize = 5; // dohvaćamo po 5 proizvoda po stranici
            var proizvodi = _context.Products.ToPagedList(pageNumber, pageSize);
            return View(proizvodi); 
        }

     
    }
}
