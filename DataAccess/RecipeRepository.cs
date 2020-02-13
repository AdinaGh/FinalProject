using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipesDataContext _context;
        public RecipeRepository(RecipesDataContext context)
        {
            _context = context;
        }

        public void Add(Recipe item)
        {
            _context.Recipes.Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetById(int id)
        {
            return _context.Recipes.Find(id);
        }

        public void Remove(Recipe item)
        {
            _context.Recipes.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Recipe item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
