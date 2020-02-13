using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}