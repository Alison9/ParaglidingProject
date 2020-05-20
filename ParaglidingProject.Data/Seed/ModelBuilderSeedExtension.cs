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
        }

        public static void FlightSeed(this ModelBuilder modelBuilder)
        {
            //Abdel
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
