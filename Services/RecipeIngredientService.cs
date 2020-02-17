﻿using DataAccess.Interfaces;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RecipeIngredientService : Service<RecipeIngredient>, IRecipeIngredientService
    {
        public RecipeIngredientService(IRepository<RecipeIngredient> repository) : base(repository)
        {
        }

        public void DeleteByRecipe(int recipeId)
        {
            var ingredients = Filter(rc => rc.RecipeId == recipeId);
            foreach(var ingredient in ingredients)
            {
                Delete(ingredient.RecipeIngredientId);
            }
        }
    }
}
