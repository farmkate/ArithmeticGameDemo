using ArithmeticGame.Data;
using ArithmeticGame.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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



    }
}
