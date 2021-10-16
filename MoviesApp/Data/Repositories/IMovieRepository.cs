using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data.ViewModels;
using MoviesApp.Models;

namespace MoviesApp.Data.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IEnumerable<Movie> GetAllMovies();
        MovieDropDowns GetDropDownsValues();
        void AddNewMovie(MovieVM movieVm);
        Movie GetMovieById(int id);
        void UpdateMovie(MovieVM movieVm);

    }
}
