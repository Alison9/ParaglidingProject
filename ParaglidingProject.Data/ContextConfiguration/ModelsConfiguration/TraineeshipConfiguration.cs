using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class TraineeshipConfiguration : IEntityTypeConfiguration<Traineeship>
    {
        public void Configure(EntityTypeBuilder<Traineeship> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(De => De.DateOfEnd)
                .HasColumnType("date");
            builder.Property(Ds => Ds.DateOfStart)
                .HasColumnType("date");
            builder.Property(p => p.Prize)
                .HasColumnType("decimal(5,2)");

            builder.HasMany(pts => pts.PilotTraineeships)
                .WithOne(t => t.Traineeship)
                .HasForeignKey(k => k.TraineeshipId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Certificate)
                .WithMany(ts => ts.Traineeships)
                .HasForeignKey(k => k.CertificateId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.Level)
                .WithMany(ts => ts.Traineeships)
                .HasForeignKey(k => k.LevelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
