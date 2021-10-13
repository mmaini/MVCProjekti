using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace StronglyTypedModelViewsDemo.Models
{
    public class Product
    {
        [Display(Name = "ID")]
        public int ProductId { get; set; }
        [Display(Name = "Naziv proizvoda")]
        public string ProductName { get; set; }
        [Display(Name = "Količina")]
        public int Quantity { get; set; }
        [Display(Name = "U zalihama")]
        public int UnitsInStock { get; set; }
        [Display(Name = "Dostupno")]
        public bool Discontinued { get; set; }
        [Display(Name = "Cijena")]
        public double Cost { get; set; }
        [Display(Name = "Porez")]
        public double Tax { get; set; }
        [Display(Name = "Dostupno od")]
        public DateTime LaunchDate { get; set; }    
    }
}
