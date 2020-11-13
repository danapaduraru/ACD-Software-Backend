using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class personupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkCV",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkCV",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Persons");
        }
    }
}
