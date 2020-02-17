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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<ModelParagliding> ModelParaglidings { get; set; }
        public DbSet<Obtaining> Obtainings { get; set; }
        public DbSet<Paragliding> Paraglidings { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Flight>().ToTable("Flight");
            modelBuilder.Entity<Level>().ToTable("Level");
            modelBuilder.Entity<License>().ToTable("License");
            modelBuilder.Entity<ModelParagliding>().ToTable("ModelParagliding");
            modelBuilder.Entity<Obtaining>().ToTable("Obtaining");
            modelBuilder.Entity<Paragliding>().ToTable("Paragliding");
            modelBuilder.Entity<Participation>().ToTable("Particiption");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Pilot>().ToTable("Pilot");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
            modelBuilder.Entity<Teaching>().ToTable("Teaching");
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<Position>().ToTable("Position");

        }
    }
}
