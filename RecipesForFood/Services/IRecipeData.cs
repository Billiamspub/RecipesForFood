﻿using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Services
{
    public interface IRecipeData
    {
        IEnumerable<Recipe> GetAll();
    }
}
