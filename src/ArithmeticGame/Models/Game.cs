using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArithmeticGame.Models
{
    public class Game
    {
        IEnumerable<GameMenu> GameMenus { get; set; } 

        //public double MultiplicationGame { get; set; }
        //public double DivisionGame { get; set; }
        //public double AdditionGame { get; set; }
        //public double SubtractionGame { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }

        //public IList<User> Users { get; set; }

    }
}
