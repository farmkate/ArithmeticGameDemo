using System.Collections.Generic;

namespace ArithmeticGame.Models
{
    public class UserCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<User> Users { get; set; }
    }
}
