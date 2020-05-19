using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(m => m.SubscriptionAmount)
                .HasColumnType("decimal(5,2)");
            builder.HasMany(pms => pms.SubscriptionPayments)
                .WithOne(m => m.Subscription)
                .HasForeignKey(k => k.SubscriptionID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}