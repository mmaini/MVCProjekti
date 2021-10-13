using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using ReturnTypesOfActionsDemo.Models;

namespace ReturnTypesOfActionsDemo.Controllers
{
    public class HomeController : Controller
    {
        //svaka action metoda može vratiti jedan od 2 "tipa" odgovora
        //generički - IActionResult
        //specifični - npr. JsonResult, FileResult, RedirectResult... (oni su izvedeni iz IActionResult)


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ContentResult GreetUser()
        {
            //vraćamo obični string koji će se prikazati u browseru
            return Content("Hello user");

            //bit će prikazano kao html, da nismo naveli prikazalo bi kao običan tekst
            //return Content("<div><b>Hello user</b></div>", "text/html");

            //bit će prikazano kao xml, da nismo naveli prikazalo bi kao običan tekst
            //return Content("<div><b>Hello user</b></div>", "text/xml");

        }

        //poziv = https://localhost:44329/home/wishuser?pozdrav
        //ako ne proslijedimo parametar ispisat će Neka poruka
        public ViewResult WishUser(string message = "Neka poruka")
        {
            ViewBag.Message = message;
            return View();
        }


        #region Redirect
        public RedirectResult GoToUrl()
        {
            //Status code: 302
            //A 302 Found message is an HTTP response status code indicating that the requested resource has been temporarily moved to a different URI.
            return Redirect("http://www.google.com");
        }

        public RedirectResult GoToUrlPermanently()
        {
            //Status code: 301
            //A 301 Moved Permanently is an HTTP response status code indicating that the requested resource has been permanently moved to a new URL
            return RedirectPermanent("http://www.google.com");
        }


        //preusmjerava na neku drugu metodu, u ovom slučaju WishUser, i prosljeđuje parametar je metoda WishUser prima parametar message
        public RedirectToActionResult GoToContactsAction()
        {
            return RedirectToAction("WishUser", new {message = "Redirect iz druge metode"});
        }

        #endregion Redirect


        //vratit će neku datoteku za download kao odgovor, u ovom slučaju file kojeg imamo u css folderu
        public FileResult DownloadFile()
        {
            return File("/css/site.css", "text/plain", "newsite.css");
        }

        //vraća odgovor kao Json ({"productCode":1,"name":"Bajadera","cost":5})
        public JsonResult ShowNewProducts()
        {
            Product prod = new Product();
            prod.ProductCode = 1;
            prod.Name = "Bajadera";
            prod.Cost = 5;
            return Json(prod);
        }

        public EmptyResult EmptyResultDemo()
        {
            //Status code: 200 (Ok)
            return new EmptyResult();
        }

        public NoContentResult NoContentResultDemo()
        {
            //Status code: 204
            return NoContent();
        }


        #region BadRequest
        //vratit će 400 i u browseru će se prikazati standardni prikaz za error 400
        public BadRequestResult BadRequestResultDemo()
        {
            return BadRequest();
        }

        //vratit će u ovom slučaju 400 i u browseru će se prikazati standardni prikaz za error 400
        //možemo vratiti bilo koji StatusCode na ovaj način, ovisno o potrebama 
        public StatusCodeResult ReturnBadRequest()
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }


        //u browseru će prikazati grešku koju smo proslijedili
        public BadRequestObjectResult BadRequestObjectResultDemo()
        {
            var modelState= new ModelStateDictionary();
            modelState.AddModelError("br", "Bad request");
            //vraćamo Dictionary s key/value elementima
            //return BadRequest(modelState);

            //možemo vratiti i samo string kao poruku o grešci
            return BadRequest("Krivi podaci");
        }
        #endregion BadRequest


        #region Unauthorized
        //dobijemo stranicu s greškom 401
        public UnauthorizedResult UnauthorizedResultDemo()
        {

            return Unauthorized();
        }

        public UnauthorizedObjectResult UnauthorizedObjectResultDemo()
        {
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("br", "Niste autorizirani");
            //vraćamo Dictionary s key/value elementima
            //return Unauthorized(modelState);
            //možemo vratiti i samo string kao poruku o grešci
            return Unauthorized("Niste autorizirani");
        }

        #endregion Unauthorized


        //404 status code
        public NotFoundResult NotFoundDemo()
        {
            return NotFound();
        }


        //Status code 200
        public OkObjectResult ReturnOk()
        {
            return new OkObjectResult(new {Message = "Ok"});
        }

        

    }
}
