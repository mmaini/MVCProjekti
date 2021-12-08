using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data;
using MoviesApp.Data.Repositories;
using MoviesApp.Data.Static;
using MoviesApp.Data.ViewModels;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class AccountController : Controller
    {
        //ugrađeni servisi za rukovanje userima/rolama
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IUnitOfWork _uow;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUnitOfWork uow)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);
            //ugrađena metoda
            var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Pogrešan unos. Molimo pokušajte ponovno.";
                return View(loginVm);

            }

            TempData["Error"] = "Pogrešan unos. Molimo pokušajte ponovno.";
            return View(loginVm);
        }


        public IActionResult Register()
        {
            var response = new RegisterVM();
            return View(response);
        }


        [HttpPost, ActionName("Register")]
        public async Task<IActionResult> RegisterUser(RegisterVM registerVm)
        {
            if (!ModelState.IsValid) return View(registerVm);
            var user = await _userManager.FindByEmailAsync(registerVm.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Već postoji korisnik s unesenom e-mail adresom";
                return View(registerVm);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVm.FullName,
                Email = registerVm.EmailAddress,
                UserName = registerVm.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVm.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRole.User);
                return View("RegisterCompleted");
            }
            else
            {
                string errors = "";
                foreach (var error in newUserResponse.Errors)
                {
                    errors += error.Description + ". ";
                }
                TempData["Error"] = errors;
                return View(registerVm);
            }

        }

        [HttpPost]
        public async Task<IActionResult>  Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }


        public IActionResult Users()
        {
            var users = _uow.ApplicationUsers.GetAll();
            return View(users);

        }


    }
}
