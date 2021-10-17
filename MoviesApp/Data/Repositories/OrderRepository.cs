using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmail)
        {
            var order = new Order {UserId = userId, Email = userEmail, OrderItems = new List<OrderItem>()};

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.MovieId,
                    Price = item.Movie.Price
                };
                order.OrderItems.Add(orderItem);
            }
            _context.Orders.Add(order);
        }

        public List<Order> GetOrdersByUserId(string userId)
        {
            var orders = _context
                .Orders.Include(x => x.OrderItems).ThenInclude(x => x.Movie)
                .Where(x => x.UserId == userId).ToList();
            return orders;
        }
    }
}
