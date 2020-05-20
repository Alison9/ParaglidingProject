using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.Seed
{
    public static class ModelBuilderSeedExtension
    {
        public static void PilotSeed(this ModelBuilder modelBuilder)
        {
            //Abdel
            modelBuilder.Entity<Pilot>().HasData(
                new Pilot()
                {
                    ID = 1,
                    FirstName = "Yves",
                    LastName = "Blavier",
                    Address = "Rue DeChezYves 4020",
                    PhoneNumber = "0489055522",
                    Weight = 100,
                    IsActive = true,
                    RoleID = 3
                },
                new Pilot()
                {
                    ID = 2,
                    FirstName = "Alison",
                    LastName = "Franck",
                    Address = "Rue DeChezAlison 4030",
                    PhoneNumber = "0489955522",
                    Weight = 50,
                    IsActive = true
                },
                new Pilot()
                {
                    ID = 3,
                    FirstName = "Antho",
                    LastName = "Truc",
                    Address = "Rue Antho 4420",
                    PhoneNumber = "0499055522",
                    Weight = 70,
                    IsActive = true
                },
                new Pilot()
                {
                    ID = 4,
                    FirstName = "El Pedro",
                    LastName = "Gomez",
                    Address = "Rue DeChezPedro 4020",
                    PhoneNumber = "0489055532",
                    Weight = 80,
                    IsActive = true,
                    RoleID = 1
                },
                new Pilot()
                {
                    ID = 5,
                    FirstName = "Lionel",
                    LastName = "Hardy",
                    Address = "Rue DeChezLionel 4030",
                    PhoneNumber = "0489555522",
                    Weight = 65,
                    IsActive = true
                },
                new Pilot()
                {
                    ID = 6,
                    FirstName = "Sandrine",
                    LastName = "Remy",
                    Address = "Rue Technifutur 4000",
                    PhoneNumber = "0488055522",
                    Weight = 55,
                    IsActive = true
                },
                new Pilot()
                {
                    ID = 7,
                    FirstName = "Fred",
                    LastName = "Breda",
                    Address = "Rue DeChezFred 4000",
                    PhoneNumber = "0489955522",
                    Weight = 70,
                    IsActive = true
                },
                new Pilot()
                {
                    ID = 8,
                    FirstName = "Steve",
                    LastName = "Ramackers",
                    Address = "Rue ChezSteve 4030",
                    PhoneNumber = "0489055622",
                    Weight = 75,
                    IsActive = true,
                    RoleID = 2,
                },
                new Pilot()
                {
                    ID = 9,
                    FirstName = "Francisco",
                    LastName = "Carmo",
                    Address = "Rue Carmo 4020",
                    PhoneNumber = "0499955522",
                    Weight = 60,
                    IsActive = true
                },
                new Pilot()
                {
                    ID = 10,
                    FirstName = "Junior",
                    LastName = "Capellen",
                    Address = "Rue DeChezJunior",
                    PhoneNumber = "0488066522",
                    Weight = 68,
                    IsActive = false
                });
        }

        public static void FlightSeed(this ModelBuilder modelBuilder)
        {
            //Abdel
            modelBuilder.Entity<Flight>().HasData(
                new Flight {
                    ID = 1, 
                    FlightDate = new DateTime(2020,1,1), 
                    Duration = 1, 
                    PilotID = 1, 
                    IsActive = true,
                    ParagliderID = 1,
                    TakeOffSiteID = 1,
                    LandingSiteID = 2
                    },
                new Flight
                {
                    ID = 2,
                    FlightDate = new DateTime(2020, 2, 1),
                    Duration = 1.25M,
                    PilotID = 2,
                    IsActive = true,
                    ParagliderID = 2,
                    TakeOffSiteID = 3,
                    LandingSiteID = 2
                    },
                new Flight
                {
                    ID = 3,
                    FlightDate = new DateTime(2020, 1, 2),
                    Duration = 1.50M,
                    PilotID = 3,
                    IsActive = true,
                    ParagliderID = 3,
                    TakeOffSiteID = 3,
                    LandingSiteID = 2
                },
                new Flight
                {
                    ID = 4,
                    FlightDate = new DateTime(2019, 12, 1),
                    Duration = 2,
                    PilotID = 4,
                    IsActive = true,
                    ParagliderID = 4,
                    TakeOffSiteID = 1,
                    LandingSiteID = 4
                },
                new Flight
                {
                    ID = 5,
                    FlightDate = new DateTime(2019, 8, 21),
                    Duration = 2.75M,
                    PilotID = 5,
                    IsActive = true,
                    ParagliderID = 5,
                    TakeOffSiteID = 1,
                    LandingSiteID = 4
                },
                new Flight
                {
                    ID = 6,
                    FlightDate = new DateTime(2020, 5, 20),
                    Duration = 1,
                    PilotID = 6,
                    IsActive = true,
                    ParagliderID = 4,
                    TakeOffSiteID = 3,
                    LandingSiteID = 4
                },
                new Flight
                {
                    ID = 7,
                    FlightDate = new DateTime(2019, 5, 18),
                    Duration = 2,
                    PilotID = 7,
                    IsActive = true,
                    ParagliderID = 3,
                    TakeOffSiteID = 1,
                    LandingSiteID = 2
                },
                new Flight
                {
                    ID = 8,
                    FlightDate = new DateTime(2019, 8, 2),
                    Duration = 1.50M,
                    PilotID = 8,
                    IsActive = true,
                    ParagliderID = 2,
                    TakeOffSiteID = 3,
                    LandingSiteID = 2
                },
                new Flight
                {
                    ID = 9,
                    FlightDate = new DateTime(2020, 4, 3),
                    Duration = 0.75M,
                    PilotID = 9,
                    IsActive = false,
                    ParagliderID = 1,
                    TakeOffSiteID = 1,
                    LandingSiteID = 4
                }
                );
        }

        public static void LevelSeed(this ModelBuilder modelBuilder)
        {
            //Yves
        }

        public static void LicenseSeed(this ModelBuilder modelBuilder)
        {
            //Alison
        }

        public static void ParagliderSeed(this ModelBuilder modelBuilder)
        {
            //Francisco
        }

        public static void ParagliderModelSeed(this ModelBuilder modelBuilder)
        {
            //Steve
        }

        public static void PilotTraineeshipSeed(this ModelBuilder modelBuilder)
        {
            //Maud
        }

        public static void PossessionSeed(this ModelBuilder modelBuilder)
        {
            //Ruaa
        }

        public static void RoleSeed(this ModelBuilder modelBuilder)
        {
            //Lionel
        }

        public static void SiteSeed(this ModelBuilder modelBuilder)
        {
            //Alison
        }

        public static void SubscriptionSeed(this ModelBuilder modelBuilder)
        {
            //Lionel
        }

        public static void SubscriptionPaymentSeed(this ModelBuilder modelBuilder)
        {
            //Francisco
        }

        public static void TraineeshipSeed(this ModelBuilder modelBuilder)
        {
            //Steve
        }

        public static void TraineeshipPaymentSeed(this ModelBuilder modelBuilder)
        {
            //Maud
        }



    }
}
