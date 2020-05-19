using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasMany(ts => ts.Traineeships)
                .WithOne(l => l.Level)
                .HasForeignKey(k => k.LevelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(ls => ls.LandingSites)
                .WithOne(l => l.Level)
                .HasForeignKey(k => k.LevelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(ls => ls.LaunchingSites)
                .WithOne(l => l.Level)
                .HasForeignKey(k => k.LevelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
