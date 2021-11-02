using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cijena je obavezna")]
        [Column(TypeName="decimal(18,2)")] //definiramo tip kolone u bazi
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Kategorija je obavezna")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount => Price * DiscountPercent;
        public decimal DiscoutPrice => Price - DiscountAmount;
        
        [Required(ErrorMessage = "Šifra je obavezna")]
        public string Code { get; set; }
        //zamjenjujemo razmake s -
        public string Slug => Name==null? "":Name.Replace(' ', '-');

    }
}
