using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class PilotTraineeshipConfiguration : IEntityTypeConfiguration<PilotTraineeship>
    {
        public void Configure(EntityTypeBuilder<PilotTraineeship> builder)
        {
            builder.HasKey(sc => new { sc.PilotID, sc.TraineeshipID });

            builder.HasOne(p => p.Pilot)
                .WithMany(c => c.PilotTraineeships)
                .HasForeignKey(k => k.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Traineeship)
                .WithMany(c => c.PilotTraineeships)
                .HasForeignKey(k => k.TraineeshipID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
