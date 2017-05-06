using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ArithmeticGame.Data;

namespace ArithmeticGame.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArithmeticGame.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("ArithmeticGame.Models.GameMenu", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("GameID");

                    b.HasKey("UserID", "GameID");

                    b.HasIndex("GameID");

                    b.HasIndex("UserID");

                    b.ToTable("GameMenu");
                });

            modelBuilder.Entity("ArithmeticGame.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Age");

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.Property<string>("Verify");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArithmeticGame.Models.UserCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ArithmeticGame.Models.GameMenu", b =>
                {
                    b.HasOne("ArithmeticGame.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArithmeticGame.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArithmeticGame.Models.User", b =>
                {
                    b.HasOne("ArithmeticGame.Models.UserCategory", "Category")
                        .WithMany("Users")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
