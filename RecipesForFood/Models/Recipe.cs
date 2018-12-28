using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipesForFood.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Display(Name="Recipe Name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        [Display(Name="Recipe Category")]
        public Categories Category { get; set; }
    }
}
