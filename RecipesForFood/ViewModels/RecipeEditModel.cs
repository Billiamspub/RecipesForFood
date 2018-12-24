using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.ViewModels
{
    public class RecipeEditModel
    {
        public string Name { get; set; }
        public Categories Category { get; set; }
    }
}
