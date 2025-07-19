using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class ExportCustomerWithBookingDto
    {
        [JsonProperty(nameof(FullName))]
        public string FullName { get; set; } = null!;

        [JsonProperty(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; } = null!;

        public ExportBookingDto[] Bookings { get; set; }
    }
}