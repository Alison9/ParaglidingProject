using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasMany(s => s.TakeOffFlights)
                .WithOne(f => f.TakeOffSite)
                .HasForeignKey(f => f.TakeOffSiteID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.LandingFlights)
              .WithOne(f => f.LandingSite)
              .HasForeignKey(f => f.LandingSiteID)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Level)
                .WithMany(s=>s.Sites)
               .HasForeignKey(s=> s.LevelID)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.Name).HasMaxLength(250);
            builder.Property(s => s.Orientation).HasMaxLength(250);
            builder.Property(s => s.SiteGeoCoordinate).HasMaxLength(250);

        }
    }
}
