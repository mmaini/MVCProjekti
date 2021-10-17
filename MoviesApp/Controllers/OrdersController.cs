using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data.Cart;
using MoviesApp.Data.Repositories;
using MoviesApp.Data.ViewModels;

namespace MoviesApp.Controllers
{
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
            string userId = "";
            var orders = _uow.Orders.GetOrdersByUserId(userId);
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
            string userId = "";
            string userEmail = "";

            _uow.Orders.StoreOrder(items, userId, userEmail);
            _shoppingCart.ClearShoppingCart();
            _uow.SaveChanges();

            return View("OrderCompleted");
        }


    }
}
