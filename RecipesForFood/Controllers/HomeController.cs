using Microsoft.AspNetCore.Mvc;
using RecipesForFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesForFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Recipe { Id = 1, Name = "Beans and Rice" };
            return View(model);
        }
    }
}
