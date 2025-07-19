using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TravelAgency.Data.Models;

namespace TravelAgency.Data.EntityConfigurations
{
    public class GuideConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.FullName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(g => g.Language)
                .IsRequired();
        }
    }
}
