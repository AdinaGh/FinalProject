using DataAccess.Interfaces;
using Entities.Models;

namespace DataAccess
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipesDataContext context) : base(context)
        {
        }
    }
}
