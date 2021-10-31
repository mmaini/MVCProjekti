using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManagementDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManagementDemo.Controllers
{
    public class HiddenFieldController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

        [HttpGet]
        //https://localhost:44383/hiddenfield/SetHiddenFieldValue
        public IActionResult SetHiddenFieldValue()
        {
            User newUser = new User()
            {
                Id = 101,
                Name = "John",
                Age = 31
            };
            return View(newUser);
        }

        //ova metoda će primiti id od view-a
        [HttpPost]
        public IActionResult SetHiddenFieldValue(IFormCollection keyValues)
        {
            var id = keyValues["Id"];
            return View();
        }
    }
}
