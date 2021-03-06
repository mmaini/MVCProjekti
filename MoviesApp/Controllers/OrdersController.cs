using Microsoft.AspNetCore.Mvc;
using MoviesApp.Data.Cart;
using MoviesApp.Data.Repositories;
using MoviesApp.Data.ViewModels;
using System.Security.Claims;

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
            //za ulogiranog korisnika dohvaćamo id i rolu
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            //dohvaćamo sve narudžbe za ulogiranog korisnika
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

            //pohrani narudžbu
            _uow.Orders.StoreOrder(items, userId, userEmail);
            //počisti košaricu
            _shoppingCart.ClearShoppingCart();
            _uow.SaveChanges();

            return View("OrderCompleted");
        }


    }
}
