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
          modelBuilder.Entity<PilotTraineeship>().HasData (
            new PilotTraineeship { PilotID = 1, TraineeshipID = 1 },
            new PilotTraineeship { PilotID = 2, TraineeshipID = 2 },
            new PilotTraineeship { PilotID = 3, TraineeshipID = 3 },
            new PilotTraineeship { PilotID = 4, TraineeshipID = 4 },
            new PilotTraineeship { PilotID = 5, TraineeshipID = 5 },
            new PilotTraineeship { PilotID = 6, TraineeshipID = 6 },
            new PilotTraineeship { PilotID = 7, TraineeshipID = 7 },
            new PilotTraineeship { PilotID = 8, TraineeshipID = 8 },
            new PilotTraineeship { PilotID = 9, TraineeshipID = 9 },
            new PilotTraineeship { PilotID = 10, TraineeshipID = 10 }
            );
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
         modelBuilder.Entity<TraineeshipPayment>().HasData(
           new TraineeshipPayment { PilotID = 1, TraineeshipID = 1, PaymentDate= new DateTime(2020,05,14), IsPaid = true },
           new TraineeshipPayment { PilotID = 2, TraineeshipID = 2, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 3, TraineeshipID = 3, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 4, TraineeshipID = 4, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 5, TraineeshipID = 5, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 6, TraineeshipID = 6, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 7, TraineeshipID = 7, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 8, TraineeshipID = 8, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 9, TraineeshipID = 9, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true },
           new TraineeshipPayment { PilotID = 10, TraineeshipID = 10, PaymentDate = new DateTime(2020, 05, 14), IsPaid = true }
           );
        }



    }
}
