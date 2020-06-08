using Microsoft.EntityFrameworkCore.Migrations;

namespace Majestics.Data.Migrations
{
    public partial class AddedCustomerByCriteria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "Criterias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Criterias_ContestId",
                table: "Criterias",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterias_Contests_ContestId",
                table: "Criterias",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterias_Contests_ContestId",
                table: "Criterias");

            migrationBuilder.DropIndex(
                name: "IX_Criterias_ContestId",
                table: "Criterias");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "Criterias");
        }
    }
}
