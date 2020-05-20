using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class ParagliderConfig : IEntityTypeConfiguration<Models.Paraglider>
    {
        public void Configure(EntityTypeBuilder<Models.Paraglider> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(p => p.DateOfService).HasColumnType("date");
            builder.Property(p => p.DateOfUse).HasColumnType("date");
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
