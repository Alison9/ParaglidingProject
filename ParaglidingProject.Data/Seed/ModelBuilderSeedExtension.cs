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
