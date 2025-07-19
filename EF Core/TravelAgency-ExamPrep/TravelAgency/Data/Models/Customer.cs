namespace TravelAgency.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; }
    }
}
