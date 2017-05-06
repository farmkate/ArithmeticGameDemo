using Microsoft.AspNetCore.Mvc;
using ArithmeticGame.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArithmeticGame.Models;
using ArithmeticGame.ViewModels;
using System;
using Microsoft.EntityFrameworkCore;

namespace ArithmeticGame.Controllers
{
    public class UserController : Controller
    {
        private GameDbContext context;

        public UserController(GameDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            IList<User> users = context.Users.Include(c => c.Category).ToList();
            return View(users);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel(context.Categories.ToList());
            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                UserCategory newUserCategory = context.Categories.Single(c => c.ID == addUserViewModel.CategoryID);

                // Add the new cheese to my existing cheeses
                User newUser = new User
                {
                    Username = addUserViewModel.Username,
                    Password = addUserViewModel.Password,
                    Verify = addUserViewModel.Verify,
                    Email = addUserViewModel.Email,
                    Category = newUserCategory
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                return Redirect("/User");


            }

            return View(addUserViewModel);
        }

    }
}
