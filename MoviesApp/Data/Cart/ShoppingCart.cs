using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Models;

namespace MoviesApp.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Movie movie)
        {
            //provjeravamo da li u košarici možda već imamo taj film
            var shoppingCartItem =
                _context.ShoppingCartItems.FirstOrDefault(x =>
                    x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            //ako nemamo dodajemo stavku
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId =  ShoppingCartId,
                    MovieId = movie.Id,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                //ako imamo povećavamo količinu
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            //provjeravamo da li u košarici možda već imamo taj film
            var shoppingCartItem =
                _context.ShoppingCartItems.FirstOrDefault(x =>
                    x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);

            //ako imamo
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1) shoppingCartItem.Amount--;
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

                _context.SaveChanges();
            }
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
            {
                if (ShoppingCartItems != null) return ShoppingCartItems;

                return _context.ShoppingCartItems
                    .Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Movie).ToList();
            }

            public double GetShoppingCartTotal()
            {
                return  _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
                    .Select(x => x.Movie.Price * x.Amount).Sum();
            
            }

            public static ShoppingCart GetShoppingCart(IServiceProvider services)
            {
                ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
                var context = services.GetService<AppDbContext>();
                string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
                session.SetString("CartId", cartId);

                return new ShoppingCart(context) {ShoppingCartId = cartId};
            }


            public void ClearShoppingCart()
            {
                var items = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).ToList();
                _context.ShoppingCartItems.RemoveRange(items);

            }


    }
}
