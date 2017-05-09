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

        public IActionResult ViewGame(int id)
        {
            List<GameMenu> players = context
                .GameMenus
                .Include(player => player.User)
                .Where(gm => gm.GameID == id)
                .ToList();

            Game game = context.Games.Single(g => g.ID == id);

            ViewGameMenuViewModel viewModel = new ViewGameMenuViewModel
            {
                Game = game,
                Players = players
            };

            return View(viewModel);
        }

        public IActionResult AddPlayer(int id)
        {
            Game game = context.Games.Single(g => g.ID == id);
            List<User> users = context.Users.ToList();

            return View(new AddGameMenuPlayerViewModel(game, users));
        }

        [HttpPost]
        public IActionResult AddPlayer(AddGameMenuPlayerViewModel addGameMenuPlayerViewModel)
        {
            if (ModelState.IsValid)
            {
                var userID = addGameMenuPlayerViewModel.UserID;
                var gameID = addGameMenuPlayerViewModel.GameID;

                IList<GameMenu> existingPlayers = context.GameMenus
                    .Where(gm => gm.UserID == userID)
                    .Where(gm => gm.GameID == gameID)
                    .ToList();

                if (existingPlayers.Count == 0)
                {
                    GameMenu gamePlayer = new GameMenu
                    {
                        User = context.Users.Single(g => g.Id == userID),
                        Game = context.Games.Single(g => g.ID == gameID)
                    };

                    context.GameMenus.Add(gamePlayer);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/Game/ViewGame/{0}", addGameMenuPlayerViewModel.GameID));
            }

            return View(addGameMenuPlayerViewModel);
        }
    }
}
