using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Name { get; set; }
    }
}
