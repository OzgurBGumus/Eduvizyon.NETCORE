using Microsoft.EntityFrameworkCore.Migrations;

namespace Edu.data.Migrations
{
    public partial class AddColumnIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Time",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "State",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SImage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "School",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Language",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Country",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "City",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Branch",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BImage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Accommodation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "State");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SImage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "School");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "City");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BImage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Accommodation");
        }
    }
}
