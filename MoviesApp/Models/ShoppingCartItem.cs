using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Data.Repositories;

namespace MoviesApp.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
