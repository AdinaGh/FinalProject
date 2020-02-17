using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeCategoryService : Service<RecipeCategory>, IRecipeCategoryService
    {
        public RecipeCategoryService(IRepository<RecipeCategory> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var categories = Filter(rc => rc.RecipeId == recipeId);
            foreach (var category in categories)
            {
                Delete(category.RecipeCategoryId);
            }
        }
    }
}
