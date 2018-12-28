using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.ViewModels
{
    public class RecipeEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public Categories Category { get; set; }
    }
}
