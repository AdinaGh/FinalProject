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
    public class RecipeOccasionService : Service<RecipeOccasion>, IRecipeOccasionService
    {
        public RecipeOccasionService(IRepository<RecipeOccasion> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var occasions = Filter(rc => rc.RecipeId == recipeId).ToList();
            foreach (var occasion in occasions)
            {
                Delete(occasion.RecipeOccasionId);
            }
        }

        public IEnumerable<RecipeOccasion> GetByRecipeId(int recipeId)
        {
            return Filter(rc => rc.RecipeId == recipeId);
        }
    }
}
