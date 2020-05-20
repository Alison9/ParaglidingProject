using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class SubscriptionPaymentConfiguration : IEntityTypeConfiguration<SubscriptionPayment>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPayment> builder)
        {
            builder.HasKey(sc => new { sc.PilotID, sc.SubscriptionID });

            builder.Property(sp => sp.DatePay)
                .HasColumnType("date");
            builder.HasOne(sp => sp.Pilot)
                .WithMany(p => p.SubscriptionsPayments)
                .HasForeignKey(sp => sp.PilotID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sp => sp.Subscription)
                .WithMany(sub => sub.SubscriptionPayments)
                .HasForeignKey(sp => sp.SubscriptionID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
