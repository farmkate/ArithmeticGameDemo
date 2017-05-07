using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticGame.Models
{
    public class Game
    {
        IEnumerable<GameMenu> GameMenus { get; set; } 

        public int ID { get; set; }
        public string Name { get; set; }

    }
}
