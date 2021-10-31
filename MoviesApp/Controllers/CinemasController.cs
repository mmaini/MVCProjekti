using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Data.Repositories;
using MoviesApp.Data.Static;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class CinemasController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CinemasController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [AllowAnonymous] //dopuštamo svima da pristupe
        public IActionResult Index()
        {
            var data = _uow.Cinemas.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _uow.Cinemas.Add(cinema);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous] //dopuštamo svima da pristupe
        public IActionResult Details(int id)
        {
            var cinemaDetails = _uow.Cinemas.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }


        public IActionResult Edit(int id)
        {
            var cinemaDetails = _uow.Cinemas.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _uow.Cinemas.Update(id, cinema);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var cinemaDetails = _uow.Cinemas.GetById(id);
            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cinemaDetails = _uow.Cinemas.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            _uow.Cinemas.Delete(id);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
