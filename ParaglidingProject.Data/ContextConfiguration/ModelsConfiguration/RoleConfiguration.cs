using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Entities.Models;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasOne(r => r.Pilot)
                .WithOne(p => p.Role)
                //.HasForeignKey<Pilot>(p => p.RoleID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
