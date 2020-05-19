using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Entities.Models;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.Data.ContextConfiguration.ModelsConfiguration
{
    internal class ParagliderModelConfig : IEntityTypeConfiguration<ParagliderModel>
    {
        public void Configure(EntityTypeBuilder<ParagliderModel> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(p => p.ApprovalDate)
                .HasColumnType("date");
            builder.Property(p => p.Size)
                .HasColumnType("decimal(5,2)");
            builder.Property(p => p.MinWeightPilot)
                .HasColumnType("decimal(5,2)");
            builder.Property(p => p.MaxWeightPilot)
                .HasColumnType("decimal(5,2)");

            builder.HasMany(p => p.Paragliders)
                .WithOne(p => p.ParagliderModel)
                .HasForeignKey(p => p.ID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

