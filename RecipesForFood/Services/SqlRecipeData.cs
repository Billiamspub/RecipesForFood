using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesForFood.Data;
using RecipesForFood.Models;

namespace RecipesForFood.Services
{
    public class SqlRecipeData : IRecipeData
    {
        private RecipesForFoodDBContext _context;

        public SqlRecipeData(RecipesForFoodDBContext context)
        {
            _context = context;
        }
        public Recipe Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public Recipe Get(int id)
        {
            return _context.Recipes.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes.OrderBy(r => r.Name);
        }
    }
}
