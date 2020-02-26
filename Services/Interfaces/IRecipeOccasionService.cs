using Entities.Models;

namespace Services.Interfaces
{
    public interface IRecipeOccasionService : IService<RecipeOccasion>
    {
        void DeleteByRecipe(int recipeId);
    }
}
