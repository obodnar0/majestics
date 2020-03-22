using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Majestics.Data.Migrations
{
    public partial class Forum_Posts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastChanged = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: false),
                    ChangedByUserId = table.Column<Guid>(nullable: false),
                    CreatedByUserId1 = table.Column<string>(nullable: true),
                    ChangedByUserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_ChangedByUserId1",
                        column: x => x.ChangedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_CreatedByUserId1",
                        column: x => x.CreatedByUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ChangedByUserId1",
                table: "Posts",
                column: "ChangedByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedByUserId1",
                table: "Posts",
                column: "CreatedByUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
