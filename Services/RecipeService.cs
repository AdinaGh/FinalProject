using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;

namespace Services
{
    public class RecipeService : Service<Recipe>, IRecipeService
    {
        public RecipeService(IRepository<Recipe> repository) : base(repository)
        {
        }
    }
}
