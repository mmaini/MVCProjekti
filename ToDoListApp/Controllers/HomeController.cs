using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string id)
        {
            var model = new ToDoViewModel();
            //punimo model sa svim podacima koje ćemo proslijediti view-u
            model.Filters = new Filters(id);
            model.Categories = _db.Categories.ToList();
            model.Statuses = _db.Statuses.ToList();
            model.DueFilters = Filters.DueFilterValues;

            IQueryable<ToDo> query = _db.ToDos.Include(c => c.Category).Include(s => s.Status);
            //ako imamo filtere, primijeni ih na upit
            if(model.Filters.HasCategory)
            {
                query = query.Where(x => x.CategoryId == model.Filters.CategoryId);
            }
            if (model.Filters.HasStatus)
            {
                query = query.Where(x => x.StatusId == model.Filters.StatusId);
            }
            if (model.Filters.HasDue)
            {
                //definiraj koji je današnji datum
                var today = DateTime.Today;
                //ovisno o tome da li korisnik traži obaveze u prošlosti/sadašnjosti/budućnosti primijeni filtriranje
                if(model.Filters.IsPast)
                    query = query.Where(x => x.DueDate <today);
                else if(model.Filters.IsFuture)
                    query = query.Where(x => x.DueDate > today);
                else if(model.Filters.IsToday)
                    query = query.Where(x => x.DueDate == today);
            }

            //dohvati iz baze 
            var tasks = query.OrderBy(t => t.DueDate).ToList();
            model.Tasks = tasks;
            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var model = new ToDoViewModel();
            model.Categories = _db.Categories.ToList();
            model.Statuses = _db.Statuses.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ToDoViewModel model)
        {
            if(ModelState.IsValid)
            {
                _db.ToDos.Add(model.CurrentTask);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            model.Categories = _db.Categories.ToList();
            model.Statuses = _db.Statuses.ToList();
            return View(model);

        }    

        [HttpPost]
        //id su filteri, tako da kad ponovno učitamo zadržimo filtere koje je korisnik odabrao
        public IActionResult EditDelete([FromRoute] string id, ToDo selected)
        {
            if(selected.StatusId == null)
            {
                _db.ToDos.Remove(selected);
            }
            else
            {
                //objekt kojeg dobijemo od view-a ima novi status
                string newStatusId = selected.StatusId;
                //dohvati objekt iz baze (on još uvijek ima staru vrijednost statusa)
                //dodijelimo mu novi status
                selected = _db.ToDos.Find(selected.Id);
                selected.StatusId = newStatusId;
                _db.ToDos.Update(selected);              
            }
            _db.SaveChanges();
            //proslijeđujemo i filtere
            return RedirectToAction("Index", "Home", new { ID = id } );
        }

        [HttpPost]
        //metoda kada korisnik odabere filtere
        public IActionResult Filter(string[] filters)
        {
            //iz niza stringova kreiramo jedan string
            string id = string.Join('-', filters);
            return RedirectToAction("Index", "Home", new { ID = id });
        }
    }
}
