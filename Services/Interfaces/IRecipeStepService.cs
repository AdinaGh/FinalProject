using Entities.Models;

namespace Services.Interfaces
{
    public interface IRecipeStepService : IService<RecipeStep>
    {
        void DeleteByRecipe(int recipeId);
    }
}
