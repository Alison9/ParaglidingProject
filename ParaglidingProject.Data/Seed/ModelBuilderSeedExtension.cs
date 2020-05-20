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
            modelBuilder.Entity<Traineeship>()
                .HasData(
                    new Traineeship
                    {
                        ID = 1,
                        StartDate = DateTime.Parse("2020-04-17"),
                        EndDate = DateTime.Parse("2020-09-17"),
                        Price = 620,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 2,
                        StartDate = DateTime.Parse("2020-05-17"),
                        EndDate = DateTime.Parse("2020-10-17"),
                        Price = 590,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 3,
                        StartDate = DateTime.Parse("2020-06-17"),
                        EndDate = DateTime.Parse("2020-11-17"),
                        Price = 590,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 4,
                        StartDate = DateTime.Parse("2020-07-17"),
                        EndDate = DateTime.Parse("2020-12-17"),
                        Price = 620,
                        IsActive = true
                    },
                    new Traineeship
                    {
                        ID = 5,
                        StartDate = DateTime.Parse("2020-08-17"),
                        EndDate = DateTime.Parse("2021-01-17"),
                        Price = 520,
                        IsActive = false
                    }

                );

        }

        public static void TraineeshipPaymentSeed(this ModelBuilder modelBuilder)
        {
            //Maud
        }



    }
}
