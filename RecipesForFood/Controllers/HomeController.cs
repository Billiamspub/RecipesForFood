using Microsoft.AspNetCore.Mvc;
using RecipesForFood.Models;
using RecipesForFood.Services;
using RecipesForFood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeData _recipeData;
        private IGreeter _greeter;

        public HomeController(IRecipeData recipeData,
            IGreeter greeter)
        {
            _recipeData = recipeData;
            _greeter = greeter;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Recipes = _recipeData.GetAll();
            model.CurrentMessage = _greeter.GetTitleOfTheDay();

            return View(model);
        }
    }
}
