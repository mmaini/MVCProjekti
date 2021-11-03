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

        private readonly AppDbContext _context;

        public HomeController(AppDbContext ctx)
        {
            _context = ctx;
        }

        public IActionResult Index(string id)
        {
            var model = new ToDoViewModel();
            //punimo model podacima
            model.Filters = new Filters(id);
            model.Categories = _context.Categories.ToList();
            model.Statuses = _context.Statuses.ToList();
            model.DueFilters = Filters.DueFilterValues;

            IQueryable<ToDo> query = _context.ToDos.Include(c => c.Category).Include(s => s.Status);

            //ako je definirano neko filtriranje, uključi ga
            if (model.Filters.HasCategory)
                query = query.Where(t => t.CategoryId == model.Filters.CategoryId);

            if (model.Filters.HasStatus)
                query = query.Where(t => t.StatusId == model.Filters.StatusId);

            if (model.Filters.HasDue)
            {
                var today = DateTime.Today;

                if (model.Filters.IsPast)
                    query = query.Where(t => t.DueDate < today);
                else if (model.Filters.IsFuture)
                    query = query.Where(t => t.DueDate > today);
                else if (model.Filters.IsToday)
                    query = query.Where(t => t.DueDate == today);
            }

            var tasks = query.OrderBy(t => t.DueDate).ToList();
            model.Tasks = tasks;
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ToDoViewModel();
            model.Categories = _context.Categories.ToList();
            model.Statuses = _context.Statuses.ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ToDoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ToDos.Add(model.CurrentTask);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.Categories = _context.Categories.ToList();
                model.Statuses = _context.Statuses.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult EditDelete([FromRoute] string id, ToDo selected)
        {
            if (selected.StatusId == null)
                _context.ToDos.Remove(selected);
            else
            {
                //dohvati novi status iz objekta kojeg nam je poslao view
                string newStatusId = selected.StatusId;
                //dohvati objekt iz baze koji još ima stari status
                selected = _context.ToDos.Find(selected.Id);
                //postavi mu novi status
                selected.StatusId = newStatusId;
                _context.ToDos.Update(selected);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home", new { ID = id });
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            //spajamo niz stringova u jedan string
            string id = string.Join('-', filter);
            return RedirectToAction("Index", "Home", new { ID = id });
        }
    }
}
