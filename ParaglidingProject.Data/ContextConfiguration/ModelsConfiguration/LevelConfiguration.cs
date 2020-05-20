using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParaglidingProject.Models;

namespace ParagliderProject.Data.ContextConfiguration.ModelsConfiguration
{
    class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasQueryFilter(p => p.IsActive);

            builder.HasMany(lvl => lvl.Licenses)
                .WithOne(lic => lic.Level)
                .HasForeignKey(lic => lic.LevelID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(lvl => lvl.Sites)
                .WithOne(s => s.Level)
                .HasForeignKey(s => s.LevelID)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
