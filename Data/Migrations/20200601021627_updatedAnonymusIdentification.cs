using Microsoft.EntityFrameworkCore.Migrations;

namespace Majestics.Data.Migrations
{
    public partial class updatedAnonymusIdentification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ip",
                table: "Marks");

            migrationBuilder.AddColumn<string>(
                name: "IdCode",
                table: "Marks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCode",
                table: "Marks");

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "Marks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
