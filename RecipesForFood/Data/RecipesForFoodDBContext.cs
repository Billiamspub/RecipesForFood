using Microsoft.EntityFrameworkCore;
using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Data
{
    public class RecipesForFoodDBContext: DbContext
    {
        public RecipesForFoodDBContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
