using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.DataProcessor.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[]? importedCustomerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, "Customers");
            if (importedCustomerDtos != null)
            {
                ICollection<Customer> customersToImport = new List<Customer>();
                foreach (var customerDto in importedCustomerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //bool customerExists = context.Customers
                    //    .Any(c => c.FullName == customerDto.FullName ||
                    //        c.Email == customerDto.Email ||
                    //        c.PhoneNumber == customerDto.PhoneNumber);
                    bool customerExists = customersToImport
                        .Any(c => c.FullName == customerDto.FullName ||
                            c.Email == customerDto.Email ||
                            c.PhoneNumber == customerDto.PhoneNumber);
                    if (customerExists)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer newCustomer = new Customer()
                    {
                        FullName = customerDto.FullName,
                        Email = customerDto.Email,
                        PhoneNumber = customerDto.PhoneNumber
                    };

                    customersToImport.Add(newCustomer);
                    sb.AppendLine(string.Format(SuccessfullyImportedCustomer, newCustomer.FullName));
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return sb.ToString();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportBookingDto[]? importedBookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);
            if (importedBookingDtos != null)
            {
                ICollection<Booking> bookingsToImport = new List<Booking>();
                foreach (var bookingDto in importedBookingDtos)
                {
                    if (!IsValid(bookingDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool bookingDateIsCorrect = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate);
                    if (!bookingDateIsCorrect)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer customer = context.Customers
                        .FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                    TourPackage tourPackage = context.TourPackages
                        .FirstOrDefault(t => t.PackageName == bookingDto.TourPackageName);

                    Booking newBooking = new Booking()
                    {
                        BookingDate = parsedDate,
                        Customer = customer,
                        TourPackage = tourPackage
                    };

                    bookingsToImport.Add(newBooking);
                    sb.AppendLine(string.Format(SuccessfullyImportedBooking, newBooking.TourPackage.PackageName, newBooking.BookingDate.ToString("yyyy-MM-dd")));
                }

                context.Bookings.AddRange(bookingsToImport);
                context.SaveChanges();
            }

            return sb.ToString();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
