using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data.Cart;
using MoviesApp.Data.Repositories;
using MoviesApp.Data.Static;
using MoviesApp.Data.ViewModels;

namespace MoviesApp.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly ShoppingCart _shoppingCart;


        public OrdersController(IUnitOfWork uow, ShoppingCart shoppingCart)
        {
            _uow = uow;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = _uow.Orders.GetOrdersByUserIdAndRole(userId, userRole);
            return View(orders);

        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public IActionResult AddToShoppingCart(int id)
        {
            var movie = _uow.Movies.GetMovieById(id);
            if (movie != null)
            {
                _shoppingCart.AddItemToCart(movie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public IActionResult RemoveItemFromCart(int id)
        {
            var movie = _uow.Movies.GetMovieById(id);
            if (movie != null)
            {
                _shoppingCart.RemoveItemFromCart(movie);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }

        public IActionResult CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            _uow.Orders.StoreOrder(items, userId, userEmail);
            _shoppingCart.ClearShoppingCart();
            _uow.SaveChanges();

            return View("OrderCompleted");
        }


    }
}
