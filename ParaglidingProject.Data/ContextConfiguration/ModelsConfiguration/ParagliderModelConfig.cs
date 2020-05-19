using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    internal class ParagliderModelConfig : IEntityTypeConfiguration<ParagliderModel>
    {
        public void Configure(EntityTypeBuilder<ParagliderModel> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(p => p.DateOfHomologation)
                .HasColumnType("date");
            builder.Property(p => p.Size)
                .HasColumnType("decimal(5,2)");
            builder.Property(p => p.MinimalWeight)
                .HasColumnType("decimal(5,2)");
            builder.Property(p => p.MaximumWeight)
                .HasColumnType("decimal(5,2)");

            builder.HasMany(p => p.Paragliders)
                .WithOne(p => p.ParagliderModel)
                .HasForeignKey(p => p.ParagliderModelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

