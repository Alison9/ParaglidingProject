using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class LicenseConfiguration : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> builder)
        {
            builder.Property(b => b.Title).HasMaxLength(250);

            builder.HasOne(lic => lic.Level)
                .WithMany(lvl => lvl.Licenses)
                .HasForeignKey(lic => lic.LevelID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(lic => lic.Possessions)
                .WithOne(p => p.License)
                .HasForeignKey(p => p.LicenseID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(lic => lic.Traineeships)
                .WithOne(t => t.License)
                .HasForeignKey(t => t.LicenseID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
