using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SongsList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //dohvati listu svih pjesama i sortiraj ih po godini
            //uz pjesme dohvati i žanrove 
            var songs = _db.Songs.Include(x => x.Genre).OrderBy(x => x.Year).ToList();
            return View(songs);
        }

   
    }
}
