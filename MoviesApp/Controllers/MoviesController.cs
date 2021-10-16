using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Data.Repositories;
using MoviesApp.Data.ViewModels;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public MoviesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            var data = _uow.Movies.GetAllMovies();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var movieDetails = _uow.Movies.GetById(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }

        public IActionResult Create()
        {
            var dropDowns = _uow.Movies.GetDropDownsValues();
            ViewBag.Cinemas = new SelectList(dropDowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropDowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dropDowns.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieVM movieVm)
        {
            if (!ModelState.IsValid)
            {
                var dropDowns = _uow.Movies.GetDropDownsValues();
                ViewBag.Cinemas = new SelectList(dropDowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropDowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dropDowns.Actors, "Id", "FullName");
                return View(movieVm);
            }
            _uow.Movies.AddNewMovie(movieVm);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Edit(int id)
        {
            var movieDetails = _uow.Movies.GetMovieById(id);
            if (movieDetails == null) return View("NotFound");

            var response = new MovieVM()
            {
                Id= movieDetails.Id,
                Name= movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                CinemaId = movieDetails.CinemaId,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                ActorsIds = movieDetails.ActorsMovies.Select(x=> x.ActorId ).ToList()
            };

            var dropDowns = _uow.Movies.GetDropDownsValues();
            ViewBag.Cinemas = new SelectList(dropDowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropDowns.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(dropDowns.Actors, "Id", "FullName");
            return View(response);
        }


        [HttpPost]
        public IActionResult Edit(int id, MovieVM movieVm)
        {
            if (id != movieVm.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dropDowns = _uow.Movies.GetDropDownsValues();
                ViewBag.Cinemas = new SelectList(dropDowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropDowns.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(dropDowns.Actors, "Id", "FullName");
                return View(movieVm);
            }
            _uow.Movies.UpdateMovie(movieVm);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Filter(string searchString)
        {
            var data = _uow.Movies.GetAllMovies();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(x =>
                    x.Name.ToUpper().Contains(searchString.ToUpper()) ||
                                              x.Description.ToUpper().Contains(searchString.ToUpper())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", data);
        }
    }
}
