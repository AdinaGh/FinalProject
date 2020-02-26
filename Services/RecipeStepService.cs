using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System.Linq;

namespace Services
{
    public class RecipeStepService : Service<RecipeStep>, IRecipeStepService
    {
        public RecipeStepService(IRepository<RecipeStep> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var items = Filter(rc => rc.RecipeId == recipeId).ToList();
            foreach (var item in items)
            {
                Delete(item.RecipeStepId);
            }
        }
    }
}
