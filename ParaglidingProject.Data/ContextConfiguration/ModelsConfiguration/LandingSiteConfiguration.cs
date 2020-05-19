using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class LandingSiteConfiguration : IEntityTypeConfiguration<LandingSite>
    {
        public void Configure(EntityTypeBuilder<LandingSite> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasOne(p => p.Site)
                .WithMany(c => c.LandingSites)
                .HasForeignKey(k => k.SiteId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Level)
                .WithMany(c => c.LandingSites)
                .HasForeignKey(k => k.LevelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
