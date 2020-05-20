using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class PossessionConfiguration : IEntityTypeConfiguration<Possession>
    {
        public void Configure(EntityTypeBuilder<Possession> builder)
        {
            builder.HasKey(po => new { po.PilotID, po.LicenceID });

            builder.Property(po => po.ExamDate).HasColumnType("date");

            builder.HasOne(po => po.License)
                .WithMany(l => l.Possessions)
                .HasForeignKey(po => po.LicenceID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(po => po.Pilot)
                .WithMany(pi => pi.Possessions)
                .HasForeignKey(po => po.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
