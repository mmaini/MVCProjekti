using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(EmployeeDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public void Delete(object id)
        {
            T existing = _db.Find(id);
            _db.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.ToList();
        }

        public T GetById(object id)
        {
            return _db.Find(id);
        }

        public void Insert(T obj)
        {
            _db.Add(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            _db.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
