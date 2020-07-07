using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingProject.Data.Migrations
{
    public partial class AddingNameForModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER [dbo].[IsActiveToFalse] ON [dbo].[Paraglider]  INSTEAD OF DELETE AS BEGIN UPDATE Paraglider  SET IsActive = 0 FROM Paraglider AS p  INNER JOIN deleted AS d ON p.ID = d.ID END");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ParagliderModel",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Advance ALPHA 6 22");

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Advance ALPHA 6 24");

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Niviuk Hook 5 26");

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Niviuk Hook 5 28");

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 5,
                column: "Name",
                value: "Ozone Buzz Z6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop trigger [dbo].[IsActiveToFalse]");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ParagliderModel");
        }
    }
}
