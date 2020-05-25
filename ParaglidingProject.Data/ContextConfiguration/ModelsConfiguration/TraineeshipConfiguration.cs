using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class TraineeshipConfiguration : IEntityTypeConfiguration<Traineeship>
    {
        public void Configure(EntityTypeBuilder<Traineeship> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(Sd => Sd.StartDate)
                .HasColumnType("date");
            builder.Property(Ed => Ed.EndDate)
                .HasColumnType("date");
            builder.Property(p => p.Price)
                .HasColumnType("decimal");

            builder.HasMany(pts => pts.PilotTraineeships)
                .WithOne(ts => ts.Traineeship)
                .HasForeignKey(ts => ts.TraineeshipID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(l => l.TraineeshipPayments)
                .WithOne(ts => ts.Traineeship)
                .HasForeignKey(ts => ts.TraineeshipID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.License)
                .WithMany(ts => ts.Traineeships)
                .HasForeignKey(k => k.LicenseID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
