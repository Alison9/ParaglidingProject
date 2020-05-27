using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{ 
    class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasIndex(p => new { p.FirstName, p.LastName }).IsUnique(false);

            builder.HasOne<Role>(p => p.Role)
                .WithOne(r => r.Pilot)
                .HasForeignKey<Role>(r => r.PilotID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Flights)
                .WithOne(f => f.Pilot)
                .HasForeignKey(f => f.PilotID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SubscriptionsPayments)
                .WithOne(sp => sp.Pilot)
                .HasForeignKey(sp => sp.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.TraineeshipPayments)
                .WithOne(tp => tp.Pilot)
                .HasForeignKey(tp => tp.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PilotTraineeships)
               .WithOne(t => t.Pilot)
               .HasForeignKey(t => t.PilotID)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.Restrict);

             builder.HasMany(p => p.Possessions)
                .WithOne(po => po.Pilot)
                .HasForeignKey(po => po.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
