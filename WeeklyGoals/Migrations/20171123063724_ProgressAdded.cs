using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeeklyGoals.Migrations
{
    public partial class ProgressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPoints",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Goals",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Factor",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WeeklyTarget",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Factor",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "WeeklyTarget",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Goals",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "MaxPoints",
                table: "Goals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "Goals",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Goals",
                nullable: false,
                defaultValue: 0);
        }
    }
}
