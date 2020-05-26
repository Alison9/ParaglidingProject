using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Entities;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
           builder.HasQueryFilter(p => p. IsActive);

            builder.HasOne(f => f.Paraglider)
                .WithMany(p => p.Flights)
                .HasForeignKey(f => f.ParagliderID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.Pilot)
                .WithMany(pi => pi.Flights)
                .HasForeignKey(f => f.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

           builder.HasOne(f => f.TakeOffSite)
                .WithMany(s => s.LandingFlights)
                .HasForeignKey(f => f.TakeOffSiteID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

          builder.HasOne(f => f.LandingSite)
                    .WithMany(s => s.TakeOffFlights)
                    .HasForeignKey(f => f.LandingSiteID)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

          builder.Property(sc => sc.FlightDate)
                    .HasColumnType("date");
              builder.Property(sc => sc.Duration)
                  .HasColumnType("decimal(5,2)");
        }
    }
}
