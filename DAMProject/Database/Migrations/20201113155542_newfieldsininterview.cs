using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class newfieldsininterview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationHours",
                table: "Interviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "Interviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationHours",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "Interviews");
        }
    }
}
