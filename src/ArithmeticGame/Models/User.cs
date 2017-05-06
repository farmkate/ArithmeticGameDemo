using System;
using System.Collections.Generic;

namespace ArithmeticGame.Models
{
    public class User
    {
        IList<GameMenu> GameMenus { get; set; }

        public string Username { get; set; }
        public string Age { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Verify { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }

        public int CategoryID { get; set; }
        public UserCategory Category { get; set; }


    }
}
