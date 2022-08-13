using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Management.Migrations
{
    public partial class UpdateProjectsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccesfull",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsSuccesfull",
                table: "Projects");
        }
    }
}
