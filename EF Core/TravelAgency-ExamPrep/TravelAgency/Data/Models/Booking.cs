namespace TravelAgency.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public int TourPackageId { get; set; }

        public TourPackage TourPackage { get; set; } = null!;
    }
}
