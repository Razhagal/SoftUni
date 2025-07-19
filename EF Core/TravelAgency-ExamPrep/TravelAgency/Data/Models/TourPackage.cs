namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        public TourPackage()
        {
            this.Bookings = new HashSet<Booking>();
            this.TourPackagesGuides = new HashSet<TourPackageGuide>();
        }

        public int Id { get; set; }

        public string PackageName { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    }
}
