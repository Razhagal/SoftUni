using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TravelAgency.Data.Models;

namespace TravelAgency.Data.EntityConfigurations
{
    public class TourPackageGuideConfiguration : IEntityTypeConfiguration<TourPackageGuide>
    {
        public void Configure(EntityTypeBuilder<TourPackageGuide> builder)
        {
            builder.HasKey(t => new { t.TourPackageId, t.GuideId });
        }
    }
}
