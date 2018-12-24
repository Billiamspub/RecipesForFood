using RecipesForFood.Models;
using System.Collections.Generic;

namespace RecipesForFood.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public string CurrentMessage { get; set; }
    }
}
