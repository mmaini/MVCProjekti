using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Data.Repositories;

namespace MoviesApp.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        [Display(Name = "Film")]
        public int MovieId { get; set; }
        [Display(Name = "Film")]
        public Movie Movie { get; set; }
        [Display(Name="Količina")]
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
