using DataAccess.Interfaces;
using Entities.Models;

namespace DataAccess
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(RecipesDataContext context) : base(context)
        {
        }
    }
}
