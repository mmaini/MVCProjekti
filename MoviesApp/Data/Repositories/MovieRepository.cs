using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data.ViewModels;
using MoviesApp.Models;

namespace MoviesApp.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.Include(x => x.Cinema).Include(x => x.Producer).Include(x => x.ActorsMovies).ThenInclude(a => a.Actor).ToList();
        }

        public new Movie GetById(int id)
        {
            return _context.Movies.Include(x => x.Cinema).Include(x => x.Producer).Include(x => x.ActorsMovies).ThenInclude(a => a.Actor)
                .FirstOrDefault(x => x.Id == id);
        }

        public MovieDropDowns GetDropDownsValues()
        {
            MovieDropDowns dropDowns = new MovieDropDowns
            {
                Actors = _context.Actors.OrderBy(x => x.FullName).ToList(),
                Cinemas = _context.Cinemas.OrderBy(x => x.Name).ToList(),
                Producers = _context.Producers.OrderBy(x => x.FullName).ToList()
            };
            return dropDowns;
        }

        public void AddNewMovie(MovieVM movieVm)
        {
           var newMovie = new Movie();
           newMovie.Name = movieVm.Name;
           newMovie.Description = movieVm.Description;
           newMovie.Price = movieVm.Price;
           newMovie.ImageUrl = movieVm.ImageUrl;
           newMovie.CinemaId = movieVm.CinemaId;
           newMovie.StartDate = movieVm.StartDate;
           newMovie.EndDate = movieVm.EndDate;
           newMovie.MovieCategory = movieVm.MovieCategory;
           newMovie.ProducerId = movieVm.ProducerId;

           _context.Movies.Add(newMovie);
           newMovie.ActorsMovies = new List<ActorMovie>();

           //dodavanje glumaca
           foreach (var actorId in movieVm.ActorsIds)
           {
               newMovie.ActorsMovies.Add(new ActorMovie{ActorId =  actorId});
           }

        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .Include(x => x.Cinema)
                .Include(x => x.Producer)
                .Include(x => x.ActorsMovies)
                .ThenInclude(a => a.Actor).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMovie(MovieVM movieVm)
        {
            var dbMovie = _context.Movies.Find(movieVm.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = movieVm.Name;
                dbMovie.Description = movieVm.Description;
                dbMovie.Price = movieVm.Price;
                dbMovie.ImageUrl = movieVm.ImageUrl;
                dbMovie.CinemaId = movieVm.CinemaId;
                dbMovie.StartDate = movieVm.StartDate;
                dbMovie.EndDate = movieVm.EndDate;
                dbMovie.MovieCategory = movieVm.MovieCategory;
                dbMovie.ProducerId = movieVm.ProducerId;


                var existingActorsDb = _context.ActorsMovies.Where(x => x.MovieId == movieVm.Id).ToList();
                _context.ActorsMovies.RemoveRange(existingActorsDb);

                foreach (var actorId in movieVm.ActorsIds)
                {
                    dbMovie.ActorsMovies.Add(new ActorMovie { ActorId = actorId });
                }

            }

         
        }
    }
    }
    

