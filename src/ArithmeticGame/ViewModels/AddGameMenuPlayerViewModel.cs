using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArithmeticGame.Models;
using ArithmeticGame.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ArithmeticGame.ViewModels
{
    public class AddGameMenuPlayerViewModel
    {
        public Game Game { get; set; }
        public List<SelectListItem> Users { get; set; }

        public int GameID { get; set; }
        public int UserID { get; set; }

        public AddGameMenuPlayerViewModel() { }

        public AddGameMenuPlayerViewModel(Game game, IEnumerable<User> users)
        {
            Users = new List<SelectListItem>();

            foreach (var user in users)
            {
                Users.Add(new SelectListItem
                {
                    Value = user.Id.ToString(),
                    Text = user.FullName
                });
            }

            Game = game;

        }
    }
}
