using Microsoft.EntityFrameworkCore.Migrations;

namespace Majestics.Data.Migrations
{
    public partial class markingMarkWithuserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Marks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Marks");
        }
    }
}
