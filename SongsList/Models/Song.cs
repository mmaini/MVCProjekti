using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class Song
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="Naziv pjesme je obavezan")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Godina je obavezna")]
        [Range(1900, 2021, ErrorMessage ="Dopušteni raspon godina je 1900-2021")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Ocjena je obavezna")]
        [Range(1, 5, ErrorMessage = "Ocjena mora biti između 1 i 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Žanr je obavezan")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
