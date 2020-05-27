using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingProject.Data.Migrations
{
    public partial class FixStringMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SiteGeoCoordinate",
                table: "Site",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Orientation",
                table: "Site",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Pilot",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Pilot",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Pilot",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Pilot",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ParagliderModel",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinWeightPilot",
                table: "ParagliderModel",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MaxWeightPilot",
                table: "ParagliderModel",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalNumber",
                table: "ParagliderModel",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Paraglider",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "License",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Skill",
                table: "Level",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Level",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 70, 50 });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 80, 60 });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 95, 70 });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 110, 85 });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 130, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SiteGeoCoordinate",
                table: "Site",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Orientation",
                table: "Site",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Pilot",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Pilot",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Pilot",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Pilot",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "ParagliderModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinWeightPilot",
                table: "ParagliderModel",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxWeightPilot",
                table: "ParagliderModel",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalNumber",
                table: "ParagliderModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Paraglider",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "License",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Skill",
                table: "Level",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Level",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 70m, 50m });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 80m, 60m });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 95m, 70m });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 110m, 85m });

            migrationBuilder.UpdateData(
                table: "ParagliderModel",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "MaxWeightPilot", "MinWeightPilot" },
                values: new object[] { 130m, 100m });
        }
    }
}
