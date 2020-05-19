using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.Property(m => m.MembershipAmount)
                .HasColumnType("decimal(5,2)");
            builder.HasMany(pms => pms.PilotMemberships)
                .WithOne(m => m.Membership)
                .HasForeignKey(k => k.MembershipId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
