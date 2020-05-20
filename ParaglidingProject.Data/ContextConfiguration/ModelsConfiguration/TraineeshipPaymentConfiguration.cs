using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class TraineeshipPaymentConfiguration : IEntityTypeConfiguration<TraineeshipPayment>
    {
        public void Configure(EntityTypeBuilder<TraineeshipPayment> builder)
        {
            builder.HasKey(key => new { key.PilotID, key.TraineeshipID });

            builder.Property(p => p.PaymentDate)
                .HasColumnType("date");

            builder.HasOne(tp => tp.Pilot)
                .WithMany(p => p.TraineeshipPayments)
                .HasForeignKey(tp => tp.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tp => tp.Traineeship)
                .WithMany(t => t.TraineeshipPayments)
                .HasForeignKey(tp => tp.TraineeshipID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
