using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IService<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> Filter(Func<T, bool> predicate);
    }
}