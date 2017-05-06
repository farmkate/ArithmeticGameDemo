using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticGame.Models
{
    public class GameMenu
    {
        public int GameID { get; set; }
        public Game Game { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
