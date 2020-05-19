using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(5,2)")
                .IsRequired(true);

            builder.HasOne(r => r.Role)
                .WithOne(p => p.Pilot)
                .HasForeignKey<Role>(k => k.RoleId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(fs => fs.Flights)
                .WithOne(p => p.Pilot)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(pms => pms.PilotMemberships)
                .WithOne(p => p.Pilot)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(pts => pts.PilotTraineeships)
                .WithOne(p => p.Pilot)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(pcs => pcs.PilotCertificates)
                .WithOne(p => p.Pilot)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
