using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeeklyGoals.Migrations
{
    public partial class WeekEntityDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Weeks_WeekId",
                table: "Progress");

            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.DropIndex(
                name: "IX_Progress_WeekId",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "WeekId",
                table: "Progress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeekId",
                table: "Progress",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    End = table.Column<DateTime>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progress_WeekId",
                table: "Progress",
                column: "WeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Weeks_WeekId",
                table: "Progress",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
