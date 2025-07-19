namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        public int TourPackageId { get; set; }

        public TourPackage TourPackage { get; set; } = null!;

        public int GuideId { get; set; }

        public Guide Guide { get; set; } = null!;
    }
}
