using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Services
{
    public class InMemoryRestaurantData : IRecipeData
    {
        List<Recipe> _recipes;

        public InMemoryRestaurantData()
        {
            _recipes = new List<Recipe>
            {
                new Recipe{Id=1, Name="Famous Spaghetti"},
                new Recipe{Id=2, Name="Indian Curry"},
                new Recipe{Id=3, Name="Mashed Potatoes"}
            };
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _recipes.OrderBy(r => r.Name);
        }
    }
}
