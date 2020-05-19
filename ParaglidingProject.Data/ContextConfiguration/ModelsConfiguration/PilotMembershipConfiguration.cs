using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotMembershipConfiguration : IEntityTypeConfiguration<PilotMembership>
    {
        public void Configure(EntityTypeBuilder<PilotMembership> builder)
        {
            builder.HasKey(sc => new { sc.PilotId, sc.MembershipId });

            builder.Property(p => p.DateOfPay)
                .HasColumnType("date");
            builder.HasOne(p => p.Pilot)
                .WithMany(c => c.PilotMemberships)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Membership)
                .WithMany(c => c.PilotMemberships)
                .HasForeignKey(k => k.MembershipId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
