using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeeklyGoals.Migrations
{
    public partial class StartingYearAndWeekAsSeparateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StartingWeek",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "StartingYear",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingYear",
                table: "Goals");

            migrationBuilder.AlterColumn<string>(
                name: "StartingWeek",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
