using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clase5.Migrations
{
    /// <inheritdoc />
    public partial class add_prop_image_in_game : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Game",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Game");
        }
    }
}
