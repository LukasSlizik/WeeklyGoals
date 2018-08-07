using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeeklyGoals.Migrations
{
    public partial class StartingWeekRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarValue",
                table: "Goals");

            migrationBuilder.AddColumn<string>(
                name: "StartingWeek",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingWeek",
                table: "Goals");

            migrationBuilder.AddColumn<string>(
                name: "CalendarValue",
                table: "Goals",
                nullable: false,
                defaultValue: "");
        }
    }
}
