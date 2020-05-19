using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasOne(p => p.Paraglider)
                .WithMany(fs => fs.Flights)
                .HasForeignKey(k => k.ParagliderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Pilot)
                .WithMany(fs => fs.Flights)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Site)
                .WithMany(fs => fs.Flights)
                .HasForeignKey(k => k.SiteId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(sc => sc.FlightDate)
                .HasColumnType("date");
            builder.Property(sc => sc.FlightDuration)
                .HasColumnType("decimal(5,2)");
        }
    }
}
