using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArithmeticGame.Migrations
{
    public partial class AddGameMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMenu_Game_GameID",
                table: "GameMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMenu_Users_UserID",
                table: "GameMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameMenu",
                table: "GameMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameMenus",
                table: "GameMenu",
                columns: new[] { "UserID", "GameID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Game",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMenus_Games_GameID",
                table: "GameMenu",
                column: "GameID",
                principalTable: "Game",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMenus_Users_UserID",
                table: "GameMenu",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_GameMenu_UserID",
                table: "GameMenu",
                newName: "IX_GameMenus_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GameMenu_GameID",
                table: "GameMenu",
                newName: "IX_GameMenus_GameID");

            migrationBuilder.RenameTable(
                name: "GameMenu",
                newName: "GameMenus");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameMenus_Games_GameID",
                table: "GameMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMenus_Users_UserID",
                table: "GameMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameMenus",
                table: "GameMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameMenu",
                table: "GameMenus",
                columns: new[] { "UserID", "GameID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Games",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMenu_Game_GameID",
                table: "GameMenus",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMenu_Users_UserID",
                table: "GameMenus",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_GameMenus_UserID",
                table: "GameMenus",
                newName: "IX_GameMenu_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_GameMenus_GameID",
                table: "GameMenus",
                newName: "IX_GameMenu_GameID");

            migrationBuilder.RenameTable(
                name: "GameMenus",
                newName: "GameMenu");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");
        }
    }
}
