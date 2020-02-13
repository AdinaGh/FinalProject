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
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipesRepository;
        public RecipeService(IRecipeRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }
        public void Add(Recipe recipe)
        {
            _recipesRepository.Add(recipe);
        }

        public void Delete(int id)
        {
            var recipe = GetById(id);
            _recipesRepository.Remove(recipe);
        }

        public void Dispose()
        {
            _recipesRepository.Dispose();
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _recipesRepository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return _recipesRepository.GetById(id);
        }

        public void Update(Recipe recipe)
        {
            _recipesRepository.Update(recipe);
        }
    }
}
