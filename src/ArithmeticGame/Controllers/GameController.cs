using ArithmeticGame.Data;
using ArithmeticGame.Models;
using ArithmeticGame.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ArithmeticGame.Controllers
{
    public class GameController : Controller
    {
        private readonly GameDbContext context;

        public GameController(GameDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Game> games = context.Games.ToList();

            return View(games);
        }

        public IActionResult Add()
        {
            AddGameMenuViewModel addGameMenuViewModel = new AddGameMenuViewModel();
            return View(addGameMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGameMenuViewModel addGameMenuViewModel)
        {
            if(ModelState.IsValid)
            {
                Game newGame = new Game
                {
                    Name = addGameMenuViewModel.Name
                };

                context.Games.Add(newGame);
                context.SaveChanges();

                return Redirect("/Game");
            }

            return View(addGameMenuViewModel);
        }

    }
}
