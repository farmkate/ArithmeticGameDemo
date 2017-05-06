using ArithmeticGame.Data;
using ArithmeticGame.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArithmeticGame.ViewModels;

namespace ArithmeticGame.Controllers
{
    public class CategoryController : Controller
    {

        private readonly GameDbContext context;

        public CategoryController(GameDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<UserCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                UserCategory newCategory = new UserCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();
            }

            return Redirect("/Category");
        }
    }
}
