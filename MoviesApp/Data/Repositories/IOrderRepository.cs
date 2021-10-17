using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.Data.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmail);
        List<Order> GetOrdersByUserId(string userId);

    }
}
