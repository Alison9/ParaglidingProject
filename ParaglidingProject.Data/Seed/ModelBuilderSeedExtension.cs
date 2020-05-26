using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                    //RoleID = 3
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
                    //RoleID = 1
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
                    //RoleID = 2,
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
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    ID = 1,
                    Name = "Level 1",
                    Skill = "brevet A",
                    IsActive = true
                },
                new Level
                   { ID = 2,
                    Name = "Level 2",
                    Skill = "brevet B",
                    IsActive = true
                },
                new Level
                {
                    ID = 3,
                    Name = "Level 3",
                    Skill = "brevet C",
                    IsActive = true

                },
                new Level
                {
                    ID = 4,
                    Name = "Level 4",
                    Skill = "brevet D",
                    IsActive = false

                }
             );

        }
    
        

        public static void LicenseSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<License>().HasData(
                new License
                {
                    ID = 1,
                    Title = "Pilote de parapente",
                    LevelID = 1
                },
                new License
                {
                    ID = 2,
                    Title = "Pilote XC de parapente",
                    LevelID = 2
                },
                new License
                {
                    ID = 3,
                    Title = "Moniteur de parapente",
                    LevelID = 2
                },
                 new License
                 {
                     ID = 4,
                     Title = "Pilote au treuil de parapente",
                     LevelID = 3
                 },
                 new License
                 {
                     ID = 5,
                     Title = "Examinateur de parapente",
                     LevelID = 3
                 }
             );
        }

        public static void ParagliderSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paraglider>().HasData(
                new Paraglider { 
                    ID = 1, 
                    Name = "Cabriolet", 
                    CommissioningDate = DateTime.Parse("2011-12-05"), 
                    LastRevisionDate = DateTime.Parse("2015-10-12"), 
                    IsActive = true, 
                    ParagliderModelID = 1 
                },
                new Paraglider { 
                    ID = 2, 
                    Name = "F350", 
                    CommissioningDate = DateTime.Parse("2011-07-30"), 
                    LastRevisionDate = DateTime.Parse("2016-11-23"), 
                    IsActive = true, 
                    ParagliderModelID = 2 
                },
                new Paraglider { 
                    ID = 3, 
                    Name = "Malibu", 
                    CommissioningDate = DateTime.Parse("2011-08-18"), 
                    LastRevisionDate = DateTime.Parse("2013-03-13"), 
                    IsActive = true, 
                    ParagliderModelID = 3 
                },
                new Paraglider { 
                    ID = 4, 
                    Name = "Murciélago", 
                    CommissioningDate = DateTime.Parse("2011-11-24"), 
                    LastRevisionDate = DateTime.Parse("2015-10-04"), 
                    IsActive = true, 
                    ParagliderModelID = 4 
                },
                new Paraglider { 
                    ID = 5, 
                    Name = "Durango", 
                    CommissioningDate = DateTime.Parse("2012-03-02"), 
                    LastRevisionDate = DateTime.Parse("2012-12-30"), 
                    IsActive = true, 
                    ParagliderModelID = 5 
                },
                new Paraglider
                {
                    ID = 6,
                    Name = "Mercedes",
                    CommissioningDate = DateTime.Parse("2010-03-02"),
                    LastRevisionDate = DateTime.Parse("2011-12-30"),
                    IsActive = false,
                    ParagliderModelID = 5
                }
                );
        }

        public static void ParagliderModelSeed(this ModelBuilder modelBuilder)
        {
            //Steve
            modelBuilder.Entity<ParagliderModel>()
                .HasData(
                    new ParagliderModel
                    {
                        ID = 1,
                        Size = "22 m²",
                        MinWeightPilot = 50,
                        MaxWeightPilot = 70,
                        ApprovalNumber = "EN/LTF A",
                        ApprovalDate = DateTime.Parse("1990-03-02"),
                        IsActive = true
                    }, 
                    new ParagliderModel
                    {
                        ID = 2,
                        Size = "24 m²",
                        MinWeightPilot = 60,
                        MaxWeightPilot = 80,
                        ApprovalNumber = "EN/LTF A",
                        ApprovalDate = DateTime.Parse("1993-09-17"),
                        IsActive = true
                    },
                    new ParagliderModel
                    {
                        ID = 3,
                        Size = "26 m²",
                        MinWeightPilot = 70,
                        MaxWeightPilot = 95,
                        ApprovalNumber = "EN/LTF A",
                        ApprovalDate = DateTime.Parse("2001-07-21"),
                        IsActive = true
                    },
                    new ParagliderModel
                    {
                        ID = 4,
                        Size = "28 m²",
                        MinWeightPilot = 85,
                        MaxWeightPilot = 110,
                        ApprovalNumber = "EN/LTF A",
                        ApprovalDate = DateTime.Parse("2002-10-02"),
                        IsActive = true
                    },
                    new ParagliderModel
                    {
                        ID = 5,
                        Size = "31 m²",
                        MinWeightPilot = 100,
                        MaxWeightPilot = 130,
                        ApprovalNumber = "EN/LTF A",
                        ApprovalDate = DateTime.Parse("2019-11-17"),
                        IsActive = false
                    }
                ) ;
        }

        public static void PilotTraineeshipSeed(this ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<PilotTraineeship>().HasData (
            new PilotTraineeship { PilotID = 1, TraineeshipID = 1 },
            new PilotTraineeship { PilotID = 2, TraineeshipID = 2 },
            new PilotTraineeship { PilotID = 3, TraineeshipID = 3 },
            new PilotTraineeship { PilotID = 4, TraineeshipID = 4 },
            new PilotTraineeship { PilotID = 5, TraineeshipID = 1 },
            new PilotTraineeship { PilotID = 6, TraineeshipID = 2 },
            new PilotTraineeship { PilotID = 7, TraineeshipID = 3 },
            new PilotTraineeship { PilotID = 8, TraineeshipID = 4 },
            new PilotTraineeship { PilotID = 9, TraineeshipID = 1 },
            new PilotTraineeship { PilotID = 10, TraineeshipID = 2 }
            );
        }

        public static void PossessionSeed(this ModelBuilder modelBuilder)
        {
            //Ruaa
            modelBuilder.Entity<Possession>().HasData(
            new Possession
            {
                PilotID = 1,
                LicenseID = 2,
                ExamDate = new DateTime(2019, 5, 12),
                IsSucceeded = true,
                IsActive = false
            },
            new Possession
            {
                PilotID = 2,
                LicenseID = 1,
                ExamDate = new DateTime(2019,9, 19),
                IsSucceeded = true,
                IsActive = true
            },
            new Possession
            {
                PilotID = 3,
                LicenseID = 4,
                ExamDate = new DateTime(2019, 12, 11),
                IsSucceeded = true,
                IsActive = true
            },
            new Possession
            {
                PilotID = 4,
                LicenseID = 3,
                ExamDate = new DateTime(2017, 4, 9),
                IsSucceeded = true,
                IsActive =true
            },
            new Possession
            {
                PilotID = 5,
                LicenseID = 4,
                ExamDate = new DateTime(2018, 6, 15),
                IsSucceeded = true,
                IsActive = true
            },
             new Possession
             {
                 PilotID = 2,
                 LicenseID = 2,
                 ExamDate = new DateTime(2020,2, 19),
                 IsSucceeded = true,
                 IsActive = true
             }
            );


        }

        public static void RoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role 
                {
                    IsActive = true,
                    Name = "Secretary",
                    PilotID = 1,
                    ID = 3
                },
               new Role
               {
                    IsActive = true,
                    Name = "Treasurer",
                    PilotID = 8,
                    ID = 2
               },
               new Role
               {
                    IsActive = true,
                    Name = "President",
                    PilotID = 4,
                    ID = 1
               });
        }

        public static void SiteSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().HasData(
                new Site
                {
                    ID = 1,
                    Name = "Boom",
                    Orientation = "S-E",
                    AltitudeTakeOff = 30,
                    SiteGeoCoordinate = "51° 08′ 33″ nord, 4° 36′ 67'' est",
                    IsActive = true,
                    SiteType = 1,
                    LevelID = 1

                },
                new Site
                {
                    ID = 2,
                    Name = "Hornu",
                    Orientation = "N-E",
                    ApproachManeuver = "A vue",
                    SiteGeoCoordinate = "50° 26′ 02″ nord, 3° 49′ 39″ est",
                    IsActive = true,
                    SiteType = 2,
                    LevelID = 2
                },
                new Site
                {
                    ID = 3,
                    Name = "Ouren",
                    Orientation = "S-O",
                    AltitudeTakeOff = 35,
                    SiteGeoCoordinate = "50° 08′ 25″ nord, 6° 08′ 02″ est",
                    IsActive = true,
                    SiteType = 1,
                    LevelID = 3
                },
                 new Site
                 {
                     ID = 4,
                     Name = "Avister",
                     Orientation = "S-O",
                     ApproachManeuver = "Aux instruments",
                     SiteGeoCoordinate = "50° 55′ 41″ nord, 5° 57′ 87″ est",
                     IsActive = false,
                     SiteType = 2,
                     LevelID = 1
                 }
             ) ;
        }

        public static void SubscriptionSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription
                {
                    IsActive = true,
                    Year = 2017,
                    SubscriptionAmount = 180
                },
                new Subscription
                {
                    IsActive = true,
                    Year = 2018,
                    SubscriptionAmount = 200
                },
                new Subscription
                {
                    IsActive = true,
                    Year = 2019,
                    SubscriptionAmount = 225
                },
                new Subscription
                {
                    IsActive = true,
                    Year = 2020,
                    SubscriptionAmount = 250
                }
                ); ;
            
        }

        public static void SubscriptionPaymentSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionPayment>().HasData(
                new SubscriptionPayment { 
                    PilotID = 1, 
                    SubscriptionID = 2017, 
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 2,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 3,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 4,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 5,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 6,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 7,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 8,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 9,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 10,
                    SubscriptionID = 2017,
                    DatePay = DateTime.Parse("2017-04-12")
                },

                new SubscriptionPayment
                {
                    PilotID = 1,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 2,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 3,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 4,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 5,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 6,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 7,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 8,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 9,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 10,
                    SubscriptionID = 2018,
                    DatePay = DateTime.Parse("2018-04-12")
                },

                new SubscriptionPayment
                {
                    PilotID = 1,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 2,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 3,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 4,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 5,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 6,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 7,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 8,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 9,
                    SubscriptionID = 2019,
                    DatePay = DateTime.Parse("2019-04-12")
                },
                new SubscriptionPayment
                {
                    PilotID = 1,
                    SubscriptionID = 2020,
                    DatePay = DateTime.Parse("2020-04-12")
                }
                );
        }

        public static void TraineeshipSeed(this ModelBuilder modelBuilder)
        {
            //Steve
            modelBuilder.Entity<Traineeship>()
                .HasData(
                    new Traineeship
                    {
                        ID = 1,
                        StartDate = DateTime.Parse("2020-04-17"),
                        EndDate = DateTime.Parse("2020-09-17"),
                        Price = 620,
                        LicenseID = 1,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 2,
                        StartDate = DateTime.Parse("2020-05-17"),
                        EndDate = DateTime.Parse("2020-10-17"),
                        Price = 590,
                        LicenseID = 1,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 3,
                        StartDate = DateTime.Parse("2020-06-17"),
                        EndDate = DateTime.Parse("2020-11-17"),
                        Price = 590,
                        LicenseID = 2,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 4,
                        StartDate = DateTime.Parse("2020-07-17"),
                        EndDate = DateTime.Parse("2020-12-17"),
                        Price = 620,
                        LicenseID = 4,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 5,
                        StartDate = DateTime.Parse("2020-08-17"),
                        EndDate = DateTime.Parse("2021-01-17"),
                        Price = 520,
                        LicenseID = 4,
                        IsActive = false
                    }

                );

        }

        public static void TraineeshipPaymentSeed(this ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<TraineeshipPayment>().HasData(
           new TraineeshipPayment { PilotID = 1, TraineeshipID = 1, PaymentDate= new DateTime(2020,05,14), IsPaid = true },
           new TraineeshipPayment { PilotID = 2, TraineeshipID = 2, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 3, TraineeshipID = 3, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 4, TraineeshipID = 4, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 5, TraineeshipID = 1, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 6, TraineeshipID = 2, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 7, TraineeshipID = 3, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 8, TraineeshipID = 4, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 9, TraineeshipID = 1, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 10, TraineeshipID = 2, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true }
           );
        }



    }
}
