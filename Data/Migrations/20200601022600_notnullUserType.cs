using Microsoft.EntityFrameworkCore.Migrations;

namespace Majestics.Data.Migrations
{
    public partial class notnullUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
