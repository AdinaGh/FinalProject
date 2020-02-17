using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T: class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}