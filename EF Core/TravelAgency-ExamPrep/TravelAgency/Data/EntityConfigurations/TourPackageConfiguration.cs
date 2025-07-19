using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TravelAgency.Data.Models;

namespace TravelAgency.Data.EntityConfigurations
{
    public class TourPackageConfiguration : IEntityTypeConfiguration<TourPackage>
    {
        public void Configure(EntityTypeBuilder<TourPackage> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.PackageName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(200);

            builder.Property(t => t.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
