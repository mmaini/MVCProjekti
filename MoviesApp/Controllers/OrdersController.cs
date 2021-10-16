using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data.Cart;
using MoviesApp.Data.Repositories;

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
            var items = _shoppingCart.GetShoppingCartItems();
            return View();
        }
    }
}
