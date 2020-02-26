using Entities.Models;

namespace Services.Interfaces
{
    public interface IRecipeIngredientService : IService<RecipeIngredient>
    {
        void DeleteByRecipe(int recipeId);
    }
}
