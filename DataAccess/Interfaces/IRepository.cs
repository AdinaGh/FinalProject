using System;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IRepository<T>: IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Remove(T item);
    }
}