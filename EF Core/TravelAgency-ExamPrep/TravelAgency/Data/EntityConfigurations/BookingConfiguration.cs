using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TravelAgency.Data.Models;

namespace TravelAgency.Data.EntityConfigurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BookingDate)
                .IsRequired();

            builder.HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .IsRequired();

            builder.HasOne(b => b.TourPackage)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TourPackageId)
                .IsRequired();
        }
    }
}
