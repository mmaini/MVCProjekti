using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Actor> Actors { get; }
        IMovieRepository Movies { get; }
        IGenericRepository<Producer> Producers { get; }
        IGenericRepository<Cinema> Cinemas { get; }
        IOrderRepository Orders { get; }
        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        void SaveChanges();
    }
}
