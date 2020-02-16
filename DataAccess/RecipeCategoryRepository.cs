using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RecipeCategoryRepository : Repository<RecipeCategory>, IRecipeCategoryRepository
    {
        public RecipeCategoryRepository(RecipesDataContext context) : base(context)
        {
        }

        public IEnumerable<RecipeCategory> GetByRecipeId(int recipeId)
        {
            return Filter(re => re.RecipeId == recipeId);
        }
    }
}
