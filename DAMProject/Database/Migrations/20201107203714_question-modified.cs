using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class questionmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextAnswer",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
