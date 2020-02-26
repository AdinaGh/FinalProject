using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System.Linq;

namespace Services
{
    public class RecipeCategoryService : Service<RecipeCategory>, IRecipeCategoryService
    {
        public RecipeCategoryService(IRepository<RecipeCategory> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var categories = Filter(rc => rc.RecipeId == recipeId).ToList();
            foreach (var category in categories)
            {
                Delete(category.RecipeCategoryId);
            }
        }
    }
}
