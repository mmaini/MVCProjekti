using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.Data.ViewModels
{
    public class MovieDropDowns
    {
        public MovieDropDowns()
        {
            Producers = new List<Producer>();
            Cinemas= new List<Cinema>();
            Actors= new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
