using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasMany(ls => ls.LaunchingSites)
                .WithOne(s => s.Site)
                .HasForeignKey(k => k.SiteId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(ls => ls.LandingSites)
                .WithOne(s => s.Site)
                .HasForeignKey(k => k.SiteId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(fs => fs.Flights)
                .WithOne(s => s.Site)
                .HasForeignKey(k => k.SiteId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
