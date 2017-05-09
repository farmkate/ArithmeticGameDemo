using System.Collections.Generic;
using ArithmeticGame.Models;

namespace ArithmeticGame.ViewModels
{
    public class ViewGameMenuViewModel
    {
        public Game Game { get; set; }
        public IList<GameMenu> Players { get; set; }
    }
}
