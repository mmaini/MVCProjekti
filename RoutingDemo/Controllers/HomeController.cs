using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingDemo.Controllers
{
    public class HomeController : Controller
    {

        //https://localhost:44371/
        //https://localhost:44371/home/index
        public IActionResult Index()
        {
            return Content("Home");
        }

        //https://localhost:44371/home/about
        public IActionResult About()
        {
            return Content("About");
        }

        //https://localhost:44371/home/display
        //https://localhost:44371/home/display/aaa
        public IActionResult Display(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("No Id supplied");
            else
                return Content("Id is " + id);
        }

        //ako ne definiramo route
        //https://localhost:44371/home/countdown
        //https://localhost:44371/home/countdown/5


        //ako definiramo rutu kao dolje - nema controllera
        //https://localhost:44371/countdown
        //https://localhost:44371/countdown/5
        [Route("[action]/{id?}")]
        public IActionResult CountDown(int id =0)
        {
            string contentString = "Countig down:\n";
            for(int i=id; i>=0;--i)
            {
                contentString += i + "\n";
            }
            return Content(contentString);
        }


        //https://localhost:44371/countdown2/5
        //https://localhost:44371/countdown2/5/1
        //https://localhost:44371/countdown2/5/1/poruka
        //ruta s opcionalnim parametrima
        [Route("[action]/{start}/{end?}/{message?}")]
        public IActionResult CountDown2(int start, int end = 0, string message="")
        {
            string contentString = "Countig down:\n";
            for (int i = start; i >= end; --i)
            {
                contentString += i + "\n";
            }
            contentString += message;
            return Content(contentString);
        }

    }
}
