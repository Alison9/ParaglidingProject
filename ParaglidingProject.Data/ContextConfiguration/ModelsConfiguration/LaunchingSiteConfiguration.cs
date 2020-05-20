using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class LaunchingSiteConfiguration : IEntityTypeConfiguration<LaunchingSite>
    {
        public void Configure(EntityTypeBuilder<LaunchingSite> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasOne(p => p.Level)
                 .WithMany(c => c.LaunchingSites)
                 .HasForeignKey(c => c.LevelId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Site)
                .WithMany(c => c.LaunchingSites)
                .HasForeignKey(k => k.SiteId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
