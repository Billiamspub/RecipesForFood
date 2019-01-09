using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesForFood.Models;
using RecipesForFood.Services;
using RecipesForFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Controllers
{
    [Authorize] // still need to put in Edit razor page since we have a mix of stuff
    public class HomeController : Controller
    {
        private IRecipeData _recipeData;
        private IGreeter _greeter;

        public HomeController(IRecipeData recipeData, IGreeter greeter)
        {
            _recipeData = recipeData;
            _greeter = greeter;
        }
        [AllowAnonymous] // moved Authorize to controller but we want anyone to hit the home page;
        public IActionResult Index()
        {
            //var model = _recipeData.GetAll();
            var model = new HomeIndexViewModel();
            model.Recipes = _recipeData.GetAll();
            model.CurrentMessage = _greeter.GetTitleOfTheDay();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            // return Content(id.ToString());
            var model = _recipeData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        //[Authorize] // can set parameters such as Policy and Roles, Policy can check countries or department (flexible)
        // recommends putting above on controller in order to avoid missing some
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecipeEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRecipe = new Recipe();
                newRecipe.Name = model.Name;
                newRecipe.Category = model.Category;
                newRecipe = _recipeData.Add(newRecipe);

                return RedirectToAction(nameof(Details), new { id = newRecipe.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
