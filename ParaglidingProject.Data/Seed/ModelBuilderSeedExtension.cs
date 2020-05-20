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
                    ID = 5,
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
        }

        public static void TraineeshipPaymentSeed(this ModelBuilder modelBuilder)
        {
            //Maud
        }



    }
}
