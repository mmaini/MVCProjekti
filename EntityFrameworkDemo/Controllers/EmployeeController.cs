using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _uow;

      
        public EmployeeController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _uow.Employees.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _uow.Employees.Insert(model);
                _uow.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            Employee model = _uow.Employees.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _uow.Employees.Update(model);
                _uow.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            Employee model = _uow.Employees.GetById(id);
            return View(model);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Employees.Delete(id);
            _uow.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}
