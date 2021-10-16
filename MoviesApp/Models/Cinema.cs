using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Logo je obavezan")]
        public string Logo { get; set; }
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ime mora imati od 3 do 50 znakova")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Opis je obavezan")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        // u jednom kinu može igrati više filmova
        public List<Movie >  Movies{ get; set; }
    }
}
