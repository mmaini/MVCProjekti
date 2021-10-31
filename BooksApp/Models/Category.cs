using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Naziv kategorije")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
