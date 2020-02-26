using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RecipesDataContext _context;

        public Repository(RecipesDataContext context)
        {
            _context = context;
        }
        public virtual void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Remove(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
    }
}
