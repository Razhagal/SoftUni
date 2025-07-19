using TravelAgency.Data.Models.Enums;

namespace TravelAgency.Data.Models
{
    public class Guide
    {
        public Guide()
        {
            this.TourPackagesGuides = new HashSet<TourPackageGuide>();
        }

        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public Language Language { get; set; }

        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    }
}
