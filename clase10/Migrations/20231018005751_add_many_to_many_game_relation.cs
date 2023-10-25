using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clase7.Migrations
{
    /// <inheritdoc />
    public partial class add_many_to_many_game_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_GameConsole_GameConsoleId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_GameConsoleId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameConsoleId",
                table: "Game");

            migrationBuilder.CreateTable(
                name: "VideoGameConsoles",
                columns: table => new
                {
                    ConsolesId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGameConsoles", x => new { x.ConsolesId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_VideoGameConsoles_GameConsole_ConsolesId",
                        column: x => x.ConsolesId,
                        principalTable: "GameConsole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGameConsoles_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGameConsoles_GamesId",
                table: "VideoGameConsoles",
                column: "GamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGameConsoles");

            migrationBuilder.AddColumn<int>(
                name: "GameConsoleId",
                table: "Game",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameConsoleId",
                table: "Game",
                column: "GameConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_GameConsole_GameConsoleId",
                table: "Game",
                column: "GameConsoleId",
                principalTable: "GameConsole",
                principalColumn: "Id");
        }
    }
}
