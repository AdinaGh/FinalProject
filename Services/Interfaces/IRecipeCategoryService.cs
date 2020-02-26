using Entities.Models;

namespace Services.Interfaces
{
    public interface IRecipeCategoryService : IService<RecipeCategory>
    {
        void DeleteByRecipe(int recipeId);

    }
}
