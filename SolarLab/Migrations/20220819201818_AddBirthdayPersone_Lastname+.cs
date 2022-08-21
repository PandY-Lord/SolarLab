using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.Migrations
{
    public partial class AddBirthdayPersone_Lastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "BirthdayPersons",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "BirthdayPersons",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "BirthdayPersons");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "BirthdayPersons");
        }
    }
}
