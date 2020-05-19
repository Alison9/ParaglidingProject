using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotCertificateConfiguration : IEntityTypeConfiguration<PilotCertificate>
    {
        public void Configure(EntityTypeBuilder<PilotCertificate> builder)
        {
            builder.HasKey(sc => new { sc.PilotId, sc.CertificateId });

            builder.Property(p => p.DateOfSucc).HasColumnType("date");

            builder.HasOne(p => p.Certificate)
                .WithMany(c => c.PilotCertificates)
                .HasForeignKey(k => k.CertificateId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Pilot)
                .WithMany(c => c.PilotCertificates)
                .HasForeignKey(k => k.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
