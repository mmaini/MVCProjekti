using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Data.Repositories;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class ProducersController : Controller
    {

        private readonly IUnitOfWork _uow;

        public ProducersController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            var data = _uow.Producers.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var producerDetails = _uow.Producers.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _uow.Producers.Add(producer);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var producerDetails = _uow.Producers.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _uow.Producers.Update(id, producer);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var producerDetails = _uow.Producers.GetById(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails = _uow.Producers.GetById(id);
            if (producerDetails == null) return View("NotFound");
            _uow.Producers.Delete(id);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
