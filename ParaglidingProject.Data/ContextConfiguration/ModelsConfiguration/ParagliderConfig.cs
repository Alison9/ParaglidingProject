using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;

namespace ParaglidingProject.Data.ContextConfiguration.ModelsConfiguration
{
    internal class ParagliderConfig : IEntityTypeConfiguration<Paraglider>
    {
        public void Configure(EntityTypeBuilder<Paraglider> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            //builder.Property(p => p.Name).HasColumnType("string");
            builder.Property(p => p.CommissioningDate).HasColumnType("date");
            builder.Property(p => p.LastRevisionDate).HasColumnType("date");
            builder.Property(p => p.Name).HasColumnType("nvarchar(250)").HasMaxLength(250);

            builder.HasOne(p => p.ParagliderModel)
                .WithMany(p => p.Paragliders)
                .HasForeignKey(p => p.ParagliderModelID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(fs => fs.Flights)
                .WithOne(p => p.Paraglider)
                .HasForeignKey(k => k.ParagliderID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
