using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotTraineeshipConfiguration : IEntityTypeConfiguration<PilotTraineeship>
    {
        public void Configure(EntityTypeBuilder<PilotTraineeship> builder)
        {
            builder.HasKey(sc => new { sc.PilotId, sc.TraineeshipId });

            builder.HasOne(p => p.Pilot)
                .WithMany(c => c.PilotTraineeships)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Traineeship)
                .WithMany(c => c.PilotTraineeships)
                .HasForeignKey(k => k.TraineeshipId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
