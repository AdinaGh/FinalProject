using DataAccess.Interfaces;
using Entities.Models;

namespace DataAccess
{
    public class CuisineRepository : Repository<Cuisine>, ICuisineRepository
    {
        public CuisineRepository(RecipesDataContext context) : base(context)
        {
        }
    }
}
