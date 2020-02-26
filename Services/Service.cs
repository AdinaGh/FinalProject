using DataAccess.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T item)
        {
            _repository.Add(item);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _repository.Remove(item);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _repository.Filter(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }
    }
}
