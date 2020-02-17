using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRecipeIngredientService : IService<RecipeIngredient>
    {
        void DeleteByRecipe(int recipeId);
    }
}
