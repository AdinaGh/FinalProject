using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;

namespace Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
