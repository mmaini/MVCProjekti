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
    //ukoliko želimo pristupiti akcijama moramo biti autorizirani
    [Authorize(Roles = UserRole.Admin)] 
    public class ActorsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ActorsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //dopuštamo svima da pristupe jer se radi samo o pregledu
        [AllowAnonymous] 
        public IActionResult Index()
        {
            var data = _uow.Actors.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _uow.Actors.Add(actor);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //dopuštamo svima da pristupe jer se radi samo o pregledu
        [HttpGet]
        [AllowAnonymous] 
        public IActionResult Details(int id)
        {
            var actorDetails = _uow.Actors.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        public IActionResult Edit(int id)
        {
            var actorDetails = _uow.Actors.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _uow.Actors.Update(id, actor);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var actorDetails = _uow.Actors.GetById(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var actorDetails = _uow.Actors.GetById(id);
            if (actorDetails == null) return View("NotFound");
            _uow.Actors.Delete(id);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
