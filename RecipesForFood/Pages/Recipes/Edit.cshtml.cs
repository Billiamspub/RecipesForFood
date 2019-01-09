using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipesForFood.Models;
using RecipesForFood.Services;

namespace RecipesForFood.Pages.Recipes
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IRecipeData _recipeData;

        [BindProperty]
        public Recipe Recipe { get; set; }

        public EditModel(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }
        public IActionResult OnGet(int id)
        {
            Recipe = _recipeData.Get(id);
            if (Recipe == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _recipeData.Update(Recipe);
                return RedirectToAction("Details", "Home", new { id = Recipe.Id });
            }
            return Page();
        }
    }
}