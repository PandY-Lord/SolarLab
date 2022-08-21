using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarLab.Migrations
{
    public partial class PhotoLink_NuLL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoLink",
                table: "BirthdayPersons",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BirthdayPersons",
                keyColumn: "PhotoLink",
                keyValue: null,
                column: "PhotoLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoLink",
                table: "BirthdayPersons",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
