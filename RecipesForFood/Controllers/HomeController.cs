using Microsoft.AspNetCore.Mvc;
using RecipesForFood.Models;
using RecipesForFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeData _recipeData;

        public HomeController(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }
        public IActionResult Index()
        {
            var model = _recipeData.GetAll();

            return View(model);
        }
    }
}
