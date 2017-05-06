using ArithmeticGame.Models;
using Microsoft.EntityFrameworkCore;


namespace ArithmeticGame.Data
{
    public class GameDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> Categories { get; set; }
        public DbSet<GameMenu> GameMenus { get; set; }
        public DbSet<Game> Games { get; set; }


        public GameDbContext(DbContextOptions<GameDbContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameMenu>().HasKey(c => new { c.UserID, c.GameID });
        }

    }
}
