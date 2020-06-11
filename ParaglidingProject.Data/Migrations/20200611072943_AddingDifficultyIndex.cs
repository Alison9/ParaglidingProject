using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingProject.Data.Migrations
{
    public partial class AddingDifficultyIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyIndex",
                table: "Level",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Level",
                keyColumn: "ID",
                keyValue: 1,
                column: "DifficultyIndex",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Level",
                keyColumn: "ID",
                keyValue: 2,
                column: "DifficultyIndex",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Level",
                keyColumn: "ID",
                keyValue: 3,
                column: "DifficultyIndex",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Level",
                keyColumn: "ID",
                keyValue: 4,
                column: "DifficultyIndex",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyIndex",
                table: "Level");
        }
    }
}
