using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParaglidingProject.Data.Migrations
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
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParagliderModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(nullable: true),
                    MaxWeightPilot = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MinWeightPilot = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ApprovalNumber = table.Column<string>(nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParagliderModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Year = table.Column<int>(nullable: false),
                    SubscriptionAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Year);
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
                    Name = table.Column<string>(nullable: true),
                    Orientation = table.Column<string>(nullable: true),
                    AltitudeTakeOff = table.Column<int>(nullable: false),
                    ApproachManeuver = table.Column<string>(nullable: true),
                    SiteGeoCoordinate = table.Column<string>(nullable: true),
                    SiteType = table.Column<int>(nullable: false),
                    LevelID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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
                name: "Paraglider",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CommissioningDate = table.Column<DateTime>(type: "date", nullable: false),
                    LastRevisionDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ParagliderModelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paraglider", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Paraglider_ParagliderModel_ParagliderModelID",
                        column: x => x.ParagliderModelID,
                        principalTable: "ParagliderModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PilotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Role_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPayment",
                columns: table => new
                {
                    PilotID = table.Column<int>(nullable: false),
                    SubscriptionID = table.Column<int>(nullable: false),
                    DatePay = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPayment", x => new { x.PilotID, x.SubscriptionID });
                    table.ForeignKey(
                        name: "FK_SubscriptionPayment_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriptionPayment_Subscription_SubscriptionID",
                        column: x => x.SubscriptionID,
                        principalTable: "Subscription",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Possession",
                columns: table => new
                {
                    PilotID = table.Column<int>(nullable: false),
                    LicenseID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsSucceeded = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possession", x => new { x.PilotID, x.LicenseID });
                    table.ForeignKey(
                        name: "FK_Possession_License_LicenseID",
                        column: x => x.LicenseID,
                        principalTable: "License",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Possession_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Traineeship",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LicenseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineeship", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Traineeship_License_LicenseID",
                        column: x => x.LicenseID,
                        principalTable: "License",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "date", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PilotID = table.Column<int>(nullable: false),
                    ParagliderID = table.Column<int>(nullable: false),
                    TakeOffSiteID = table.Column<int>(nullable: false),
                    LandingSiteID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flight_Site_LandingSiteID",
                        column: x => x.LandingSiteID,
                        principalTable: "Site",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Paraglider_ParagliderID",
                        column: x => x.ParagliderID,
                        principalTable: "Paraglider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Site_TakeOffSiteID",
                        column: x => x.TakeOffSiteID,
                        principalTable: "Site",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotTraineeship",
                columns: table => new
                {
                    PilotID = table.Column<int>(nullable: false),
                    TraineeshipID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotTraineeship", x => new { x.PilotID, x.TraineeshipID });
                    table.ForeignKey(
                        name: "FK_PilotTraineeship_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PilotTraineeship_Traineeship_TraineeshipID",
                        column: x => x.TraineeshipID,
                        principalTable: "Traineeship",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TraineeshipPayment",
                columns: table => new
                {
                    PilotID = table.Column<int>(nullable: false),
                    TraineeshipID = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeshipPayment", x => new { x.PilotID, x.TraineeshipID });
                    table.ForeignKey(
                        name: "FK_TraineeshipPayment_Pilot_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TraineeshipPayment_Traineeship_TraineeshipID",
                        column: x => x.TraineeshipID,
                        principalTable: "Traineeship",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "ID", "IsActive", "Name", "Skill" },
                values: new object[,]
                {
                    { 1, true, "Level 1", "brevet A" },
                    { 2, true, "Level 2", "brevet B" },
                    { 3, true, "Level 3", "brevet C" },
                    { 4, false, "Level 4", "brevet D" }
                });

            migrationBuilder.InsertData(
                table: "ParagliderModel",
                columns: new[] { "ID", "ApprovalDate", "ApprovalNumber", "IsActive", "MaxWeightPilot", "MinWeightPilot", "Size" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "EN/LTF A", true, 70m, 50m, "22 m²" },
                    { 2, new DateTime(1993, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "EN/LTF A", true, 80m, 60m, "24 m²" },
                    { 3, new DateTime(2001, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "EN/LTF A", true, 95m, 70m, "26 m²" },
                    { 4, new DateTime(2002, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "EN/LTF A", true, 110m, 85m, "28 m²" },
                    { 5, new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "EN/LTF A", false, 130m, 100m, "31 m²" }
                });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "ID", "Address", "FirstName", "IsActive", "LastName", "PhoneNumber", "Weight" },
                values: new object[,]
                {
                    { 10, "Rue DeChezJunior", "Junior", false, "Capellen", "0488066522", 68 },
                    { 9, "Rue Carmo 4020", "Francisco", true, "Carmo", "0499955522", 60 },
                    { 8, "Rue ChezSteve 4030", "Steve", true, "Ramackers", "0489055622", 75 },
                    { 7, "Rue DeChezFred 4000", "Fred", true, "Breda", "0489955522", 70 },
                    { 6, "Rue Technifutur 4000", "Sandrine", true, "Remy", "0488055522", 55 },
                    { 3, "Rue Antho 4420", "Antho", true, "Truc", "0499055522", 70 },
                    { 4, "Rue DeChezPedro 4020", "El Pedro", true, "Gomez", "0489055532", 80 },
                    { 2, "Rue DeChezAlison 4030", "Alison", true, "Franck", "0489955522", 50 },
                    { 1, "Rue DeChezYves 4020", "Yves", true, "Blavier", "0489055522", 100 },
                    { 5, "Rue DeChezLionel 4030", "Lionel", true, "Hardy", "0489555522", 65 }
                });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Year", "IsActive", "SubscriptionAmount" },
                values: new object[,]
                {
                    { 2019, true, 225m },
                    { 2017, true, 180m },
                    { 2018, true, 200m },
                    { 2020, true, 250m }
                });

            migrationBuilder.InsertData(
                table: "License",
                columns: new[] { "ID", "LevelID", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Pilote de parapente" },
                    { 2, 2, "Pilote XC de parapente" },
                    { 3, 2, "Moniteur de parapente" },
                    { 4, 3, "Pilote au treuil de parapente" },
                    { 5, 3, "Examinateur de parapente" }
                });

            migrationBuilder.InsertData(
                table: "Paraglider",
                columns: new[] { "ID", "CommissioningDate", "IsActive", "LastRevisionDate", "Name", "ParagliderModelID" },
                values: new object[,]
                {
                    { 6, new DateTime(2010, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2011, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes", 5 },
                    { 5, new DateTime(2012, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2012, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durango", 5 },
                    { 1, new DateTime(2011, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2015, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabriolet", 1 },
                    { 2, new DateTime(2011, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2016, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "F350", 2 },
                    { 3, new DateTime(2011, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2013, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malibu", 3 },
                    { 4, new DateTime(2011, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2015, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murciélago", 4 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "IsActive", "Name", "PilotID" },
                values: new object[,]
                {
                    { 2, true, "Treasurer", 8 },
                    { 1, true, "President", 4 },
                    { 3, true, "Secretary", 1 }
                });

            migrationBuilder.InsertData(
                table: "Site",
                columns: new[] { "ID", "AltitudeTakeOff", "ApproachManeuver", "IsActive", "LevelID", "Name", "Orientation", "SiteGeoCoordinate", "SiteType" },
                values: new object[,]
                {
                    { 2, 0, "A vue", true, 2, "Hornu", "N-E", "50° 26′ 02″ nord, 3° 49′ 39″ est", 2 },
                    { 4, 0, "Aux instruments", false, 1, "Avister", "S-O", "50° 55′ 41″ nord, 5° 57′ 87″ est", 2 },
                    { 1, 30, null, true, 1, "Boom", "S-E", "51° 08′ 33″ nord, 4° 36′ 67'' est", 1 },
                    { 3, 35, null, true, 3, "Ouren", "S-O", "50° 08′ 25″ nord, 6° 08′ 02″ est", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPayment",
                columns: new[] { "PilotID", "SubscriptionID", "DatePay" },
                values: new object[,]
                {
                    { 7, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 2019, new DateTime(2019, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2017, new DateTime(2017, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2018, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2020, new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "ID", "Duration", "FlightDate", "IsActive", "LandingSiteID", "ParagliderID", "PilotID", "TakeOffSiteID" },
                values: new object[,]
                {
                    { 5, 2.75m, new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 5, 5, 1 },
                    { 4, 2m, new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 4, 4, 1 },
                    { 7, 2m, new DateTime(2019, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 3, 7, 1 },
                    { 3, 1.50m, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 3, 3, 3 },
                    { 8, 1.50m, new DateTime(2019, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 2, 8, 3 },
                    { 2, 1.25m, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 2, 2, 3 },
                    { 9, 0.75m, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 1, 9, 1 },
                    { 1, 1m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 1, 1, 1 },
                    { 6, 1m, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 4, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Possession",
                columns: new[] { "PilotID", "LicenseID", "ExamDate", "ID", "IsActive", "IsSucceeded" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, true },
                    { 3, 4, new DateTime(2019, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, true },
                    { 4, 3, new DateTime(2017, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, true },
                    { 2, 2, new DateTime(2020, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, true },
                    { 1, 2, new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, true },
                    { 5, 4, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, true }
                });

            migrationBuilder.InsertData(
                table: "Traineeship",
                columns: new[] { "ID", "EndDate", "IsActive", "LicenseID", "Price", "StartDate" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 520m, new DateTime(2020, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2020, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 590m, new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 590m, new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 620m, new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 620m, new DateTime(2020, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PilotTraineeship",
                columns: new[] { "PilotID", "TraineeshipID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 9, 1 },
                    { 8, 4 },
                    { 4, 4 },
                    { 2, 2 },
                    { 6, 2 },
                    { 10, 2 },
                    { 7, 3 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TraineeshipPayment",
                columns: new[] { "PilotID", "TraineeshipID", "IsPaid", "PaymentDate" },
                values: new object[,]
                {
                    { 7, 3, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_LandingSiteID",
                table: "Flight",
                column: "LandingSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ParagliderID",
                table: "Flight",
                column: "ParagliderID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PilotID",
                table: "Flight",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_TakeOffSiteID",
                table: "Flight",
                column: "TakeOffSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_License_LevelID",
                table: "License",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Paraglider_ParagliderModelID",
                table: "Paraglider",
                column: "ParagliderModelID");

            migrationBuilder.CreateIndex(
                name: "IX_PilotTraineeship_TraineeshipID",
                table: "PilotTraineeship",
                column: "TraineeshipID");

            migrationBuilder.CreateIndex(
                name: "IX_Possession_LicenseID",
                table: "Possession",
                column: "LicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_PilotID",
                table: "Role",
                column: "PilotID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Site_LevelID",
                table: "Site",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPayment_SubscriptionID",
                table: "SubscriptionPayment",
                column: "SubscriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Traineeship_LicenseID",
                table: "Traineeship",
                column: "LicenseID");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeshipPayment_TraineeshipID",
                table: "TraineeshipPayment",
                column: "TraineeshipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "PilotTraineeship");

            migrationBuilder.DropTable(
                name: "Possession");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SubscriptionPayment");

            migrationBuilder.DropTable(
                name: "TraineeshipPayment");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Paraglider");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "Traineeship");

            migrationBuilder.DropTable(
                name: "ParagliderModel");

            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
