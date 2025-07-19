using Newtonsoft.Json;
using System.Globalization;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.DataProcessor.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guidesSpeakingSpanishWithTours = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuideWithTourPackagesDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tp => new ExportTourPackageDto()
                        {
                            Name = tp.TourPackage.PackageName,
                            Description = tp.TourPackage.Description,
                            Price = tp.TourPackage.Price
                        })
                        .OrderByDescending(tp => tp.Price)
                        .ThenBy(tp => tp.Name)
                        .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToList();

            XmlHelper xmlHelper = new XmlHelper();
            return xmlHelper.Serialize(guidesSpeakingSpanishWithTours, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customersWithBookings = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new ExportCustomerWithBookingDto()
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new ExportBookingDto()
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToList();

            return JsonConvert.SerializeObject(customersWithBookings, Formatting.Indented);
        }
    }
}
