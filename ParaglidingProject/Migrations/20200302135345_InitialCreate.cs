using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<string>(nullable: true),
                    DifficultyNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelParagliding",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeightParagliding = table.Column<string>(nullable: true),
                    MaxWeightPilot = table.Column<int>(nullable: false),
                    MinWeightPilot = table.Column<int>(nullable: false),
                    AprovalNumber = table.Column<string>(nullable: true),
                    AprovalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelParagliding", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Adress = table.Column<string>(maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    PostitionID = table.Column<int>(nullable: true),
                    IsActif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    YearID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.YearID);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    LevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.ID);
                    table.ForeignKey(
                        name: "FK_License_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OrientationLanding = table.Column<string>(nullable: true),
                    OrientationTakeOff = table.Column<string>(nullable: true),
                    AltitudeTakeOff = table.Column<int>(nullable: true),
                    FlightType = table.Column<string>(nullable: true),
                    LevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Site_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paragliding",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCommissioning = table.Column<DateTime>(nullable: false),
                    DateOfLastRevision = table.Column<DateTime>(nullable: false),
                    ModelParaglidingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragliding", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Paragliding_ModelParagliding_ModelParaglidingID",
                        column: x => x.ModelParaglidingID,
                        principalTable: "ModelParagliding",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PilotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Position_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotID = table.Column<int>(nullable: false),
                    SubsciptionID = table.Column<int>(nullable: false),
                    IsPay = table.Column<bool>(nullable: false),
                    DatePay = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Subscription_SubsciptionID",
                        column: x => x.SubsciptionID,
                        principalTable: "Subscription",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CoursePrice = table.Column<decimal>(nullable: false),
                    LicenseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_License_LicenseID",
                        column: x => x.LicenseID,
                        principalTable: "License",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obtaining",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotID = table.Column<int>(nullable: false),
                    LicenseID = table.Column<int>(nullable: false),
                    ObtainingDate = table.Column<DateTime>(nullable: true),
                    IsSucced = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obtaining", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obtaining_License_LicenseID",
                        column: x => x.LicenseID,
                        principalTable: "License",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obtaining_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(nullable: false),
                    FlightStart = table.Column<DateTime>(nullable: false),
                    FlightEnd = table.Column<DateTime>(nullable: false),
                    PilotID = table.Column<int>(nullable: false),
                    ParaglidingID = table.Column<int>(nullable: false),
                    SiteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flight_Paragliding_ParaglidingID",
                        column: x => x.ParaglidingID,
                        principalTable: "Paragliding",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Site_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Site",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Particiption",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false),
                    DateOfParticipation = table.Column<DateTime>(nullable: false),
                    IsPay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Particiption", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Particiption_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Particiption_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teaching",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PilotID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaching", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teaching_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teaching_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_LicenseID",
                table: "Course",
                column: "LicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ParaglidingID",
                table: "Flight",
                column: "ParaglidingID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PilotID",
                table: "Flight",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_SiteID",
                table: "Flight",
                column: "SiteID");

            migrationBuilder.CreateIndex(
                name: "IX_License_LevelID",
                table: "License",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Obtaining_LicenseID",
                table: "Obtaining",
                column: "LicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Obtaining_PilotID",
                table: "Obtaining",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Paragliding_ModelParaglidingID",
                table: "Paragliding",
                column: "ModelParaglidingID");

            migrationBuilder.CreateIndex(
                name: "IX_Particiption_CourseID",
                table: "Particiption",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Particiption_PilotID",
                table: "Particiption",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PilotID",
                table: "Payment",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SubsciptionID",
                table: "Payment",
                column: "SubsciptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PilotID",
                table: "Position",
                column: "PilotID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_LevelID",
                table: "Site",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_CourseID",
                table: "Teaching",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_PilotID",
                table: "Teaching",
                column: "PilotID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Obtaining");

            migrationBuilder.DropTable(
                name: "Particiption");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Teaching");

            migrationBuilder.DropTable(
                name: "Paragliding");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "ModelParagliding");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
