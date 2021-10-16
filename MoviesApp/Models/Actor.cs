using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Display(Name="Slika")]
        [Required(ErrorMessage = "Slika je obavezna")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ime mora imati od 3 do 50 znakova")]
        public string FullName { get; set; }
        [Display(Name = "Biografija")]
        [Required(ErrorMessage = "Biografija je obavezna")]
        public string Bio { get; set; }

        public List<ActorMovie> ActorsMovies { get; set; }

      
    }
}
