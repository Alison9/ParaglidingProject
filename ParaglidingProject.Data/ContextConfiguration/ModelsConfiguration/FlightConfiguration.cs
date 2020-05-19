using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Entities;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
          // builder.HasQueryFilter(p => p. IsActive);

            builder.HasOne(p => p.Paraglider)
                .WithMany(fs => fs.Flights)
                .HasForeignKey(k => k.ParagliderID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Pilot)
                .WithMany(fs => fs.Flights)
                .HasForeignKey(k => k.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Site)
                .WithMany(fs => fs.Flights)
                .HasForeignKey(k => k.SiteID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(sc => sc.FlightDate)
                .HasColumnType("date");
            builder.Property(sc => sc.Duration)
                .HasColumnType("decimal(5,2)");
        }
    }
}
