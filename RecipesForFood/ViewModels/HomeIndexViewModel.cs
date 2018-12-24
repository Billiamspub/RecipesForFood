using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public string CurrentMessage { get; set; }
    }
}
