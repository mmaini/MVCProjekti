using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Models;

namespace MoviesApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(IServiceScopeFactory serviceScopeFactory)
        {
            _context = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        private IGenericRepository<Actor> _actors;
        private IMovieRepository _movies;
        private IGenericRepository<Producer> _producers;
        private IGenericRepository<Cinema> _cinemas;


        public IGenericRepository<Actor> Actors => _actors ??= new GenericRepository<Actor>(_context);
        public IMovieRepository Movies => _movies ??= new MovieRepository(_context);
        public IGenericRepository<Producer> Producers => _producers ??= new GenericRepository<Producer>(_context);
        public IGenericRepository<Cinema> Cinemas => _cinemas ??= new GenericRepository<Cinema>(_context);


  


    }
}
