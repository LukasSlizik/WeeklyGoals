using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeeklyGoals.Migrations
{
    public partial class ProgressChangedToInteger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Progress",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Progress",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
