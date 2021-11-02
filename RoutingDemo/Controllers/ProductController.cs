using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingDemo.Controllers
{
    public class ProductController : Controller
    {
        //https://localhost:44371/product/list
        //https://localhost:44371/product/list/keks/2 - da bi ovo radilo dodali smo vlastitu rutu u startup
        public IActionResult List(string category, int pageNumber)
        {
            return Content("Product controller, List action, Category= " + category + ", Page= " + pageNumber);
        }

        //https://localhost:44371/product/detail
        //https://localhost:44371/product/detail/2
        public IActionResult Detail(int id)
        {
            return Content("Product controller, Detail action, Id= " + id);
        }
    }
}
