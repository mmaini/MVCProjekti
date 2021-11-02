using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class Genre
    {
        //Id može biti i string
        public string Id { get; set; }
        [Required(ErrorMessage = "Naziv žanra je obavezan")]
        public string Name { get; set; }
    }
}
