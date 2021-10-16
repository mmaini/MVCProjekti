using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _db.ToList();
          
        }

        public T GetById(int id)
        {
            return _db.Find(id);
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public void Update(int id, T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _db.Find(id);
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
