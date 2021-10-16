using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.Data.ViewModels
{
    public class MovieVM
    {

        public int Id { get; set; }
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Opis je obavezan")]
        public string Description { get; set; }

        [Display(Name = "Cijena")]
        [Required(ErrorMessage = "Cijena je obavezna")]
        public double Price { get; set; }

        [Display(Name = "Slika")]
        [Required(ErrorMessage = "Slika je obavezna")]
        public string ImageUrl { get; set; }

        [Display(Name = "Početak prikazivanja")]
        [Required(ErrorMessage = "Početak prikazivanja je obavezan")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Kraj prikazivanja")]
        [Required(ErrorMessage = "Kraj prikazivanja je obavezan")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Kategorija je obavezna")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Odaberi glumce")]
        [Required(ErrorMessage = "Potrebno je odabrati glumce")]
        public List<int> ActorsIds { get; set; }

        [Display(Name = "Odaberi kino")]
        [Required(ErrorMessage = "Potrebno je odabrati kino")]
        public int CinemaId { get; set; }

        [Display(Name = "Odaberi producenta")]
        [Required(ErrorMessage = "Potrebno je odabrati producenta")]
        public int ProducerId { get; set; }
   
   
    }
}
