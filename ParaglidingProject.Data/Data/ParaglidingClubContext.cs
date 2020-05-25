using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Data
{
    public class ParaglidingClubContext : DbContext
    {
        public ParaglidingClubContext(DbContextOptions<ParaglidingClubContext> options) : base(options)
        {
        }

        public DbSet<Traineeship> Traineeships { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<ParagliderModel> ParagliderModels { get; set; }
        public DbSet<Possession> Possessions { get; set; }
        public DbSet<Paraglider> Paragliders { get; set; }
        public DbSet<PilotTraineeship> PilotTraineeships { get; set; }
        public DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TraineeshipPayment> TraineeshipPayments { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Traineeship>().ToTable("Traineeship");
            modelBuilder.Entity<Flight>().ToTable("Flight");
            modelBuilder.Entity<Level>().ToTable("Level");
            modelBuilder.Entity<License>().ToTable("License");
            modelBuilder.Entity<ParagliderModel>().ToTable("ParagliderModel");
            modelBuilder.Entity<Possession>().ToTable("Obtaining");
            modelBuilder.Entity<Paraglider>().ToTable("Paraglider");
            modelBuilder.Entity<PilotTraineeship>().ToTable("PilotTraineeship");
            modelBuilder.Entity<SubscriptionPayment>().ToTable("SubscriptionPayment");
            modelBuilder.Entity<Pilot>().ToTable("Pilot");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
            modelBuilder.Entity<TraineeshipPayment>().ToTable("TraineeshipPayment");
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<Role>().ToTable("Role");


        }
    }
}
