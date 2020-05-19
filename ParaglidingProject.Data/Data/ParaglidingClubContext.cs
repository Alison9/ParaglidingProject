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
        public DbSet<Possession> Obtainings { get; set; }
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
            modelBuilder.Entity<Possession>().ToTable("Obtaining");
            modelBuilder.Entity<Paragliding>().ToTable("Paragliding");
            modelBuilder.Entity<Participation>().ToTable("Particiption");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Pilot>().ToTable("Pilot");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
            modelBuilder.Entity<Teaching>().ToTable("Teaching");
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<Position>().ToTable("Position");

            modelBuilder.Entity<Course>()
                .HasMany(p => p.Participations)
                .WithOne(c => c.Course)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(t => t.Teachings)
                .WithOne(c => c.Course)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Level>()
                .HasMany(l => l.Licenses)
                .WithOne(lv => lv.Level)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Level>()
                .HasMany(s => s.Sites)
                .WithOne(lv => lv.Level)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<License>()
                .HasMany(o => o.Obtainings)
                .WithOne(l => l.License)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<License>()
                .HasMany(c => c.Courses)
                .WithOne(l => l.License)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ModelParagliding>()
                .HasMany(pa => pa.Paraglidings)
                .WithOne(mp => mp.ModelParagliding)
                .HasForeignKey(mp => mp.ModelParaglidingID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Paragliding>()
                .HasMany(f => f.Flights)
                .WithOne(pa => pa.Paragliding)
                .HasForeignKey(p => p.ParaglidingID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pilot>()
                .HasMany(f => f.Flights)
                .WithOne(pi => pi.Pilot)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pilot>()
                .HasMany(py => py.Payments)
                .WithOne(pi => pi.Pilot)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pilot>()
                .HasMany(pt => pt.Participations)
                .WithOne(pi => pi.Pilot)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pilot>()
                .HasMany(t => t.Teachings)
                .WithOne(pi => pi.Pilot)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pilot>()
                .HasMany(o => o.Obtainings)
                .WithOne(pi => pi.Pilot)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Site>()
                .HasMany(f => f.Flights)
                .WithOne(s => s.Site)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .HasMany(py => py.Payments)
                .WithOne(sb => sb.Subscription)
                .HasForeignKey(si => si.SubsciptionID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
