using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Data;

namespace MoviesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Ime")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Cijena")]
        public double Price { get; set; }
        [Display(Name = "Slika")]
        public string ImageUrl { get; set; }
        [Display(Name = "Početak prikazivanja")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Kraj prikazivanja")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Kategorija")]
        public MovieCategory MovieCategory { get; set; }

        //film može imati više glumaca - veza više na više
        public List<ActorMovie> ActorsMovies { get; set; }
        //veza na kino
        [Display(Name = "Kino")]
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        [Display(Name = "Kino")]
        public Cinema Cinema { get; set; }
        //veza na producenta
        [Display(Name = "Producent")]
        public int ProducerId { get; set; }
        [Display(Name = "Producent")]
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
