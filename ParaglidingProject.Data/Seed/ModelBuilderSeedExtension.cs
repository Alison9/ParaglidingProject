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
            modelBuilder.Entity<Site>().HasData(
                new Site
                {
                    ID = 1,
                    Name = "Boom",
                    Orientation = "S-E",
                    AltitudeTakeOff = 30,
                    FlightType = "Thermodynamiques",
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
                    FlightType = "Thermodynamiques",
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
                    FlightType = "Thermodynamiques",
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
                     FlightType = "Thermodynamiques",
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
