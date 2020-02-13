using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoriesRepository;
        public CategoryService(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void Add(Category category)
        {
            _categoriesRepository.Add(category);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            _categoriesRepository.Remove(category);
        }

        public void Dispose()
        {
            _categoriesRepository.Dispose();
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoriesRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoriesRepository.GetById(id);
        }

        public void Update(Category category)
        {
            _categoriesRepository.Update(category);
        }
    }
}
