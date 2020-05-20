using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ParaglidingProject.Models;

namespace ParaglidingProject.Data.Seed
{
    public static class ModelBuilderSeedExtension
    {
        public static void PilotSeed(this ModelBuilder modelBuilder)
        {
            //Abdel
        }

        public static void FlightSeed(this ModelBuilder modelBuilder)
        {
            //Abdel
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
            //Alison
        }

        public static void ParagliderSeed(this ModelBuilder modelBuilder)
        {
            //Francisco
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
            //Maud
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
            //Alison
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
