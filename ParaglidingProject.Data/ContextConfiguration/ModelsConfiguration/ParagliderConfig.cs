using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using ParaglidingProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class ParagliderConfig : IEntityTypeConfiguration<Paraglider>
    {
        public void Configure(EntityTypeBuilder<Paraglider> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(p => p.Name).HasColumnType("string");
            builder.Property(p => p.CommissioningDate).HasColumnType("date");
            builder.Property(p => p.LastRevisionDate).HasColumnType("date");
            builder.Property(p => p.FlightHours).HasColumnType("decimal(5,2)");

            builder.HasOne(p => p.ParagliderModel)
                .WithMany(p => p.Paragliders)
                .HasForeignKey(p => p.ParagliderModelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(fs => fs.Flights)
                .WithOne(p => p.Paraglider)
                .HasForeignKey(k => k.ParagliderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}